using UnityModManagerNet;
using System;
using System.Reflection;
using System.Linq;
using Kingmaker.Blueprints;
using System.Collections.Generic;
using Kingmaker.PubSubSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Controllers.Brain.Blueprints;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Controllers;

namespace TweakMod
{
    class ForceSelfBuffs : IUnitCombatHandler
    {
        public void HandleUnitJoinCombat(UnitEntityData unit)
        {
            //Main.logger.Log($"Unit joining combat: {unit.CharacterName}");
            var autoCastAbilities = unit.Brain.Actions.Where(action => action.Blueprint.name.StartsWith("SLE_PRECAST"));

            foreach (var autoCast in autoCastAbilities)
            {
                var spellCast = autoCast.Blueprint as BlueprintAiCastSpell;
                var spellbook = unit.Descriptor.Spellbooks.First();
                var abilityData = new AbilityData(spellCast.Ability, unit.Descriptor, unit.Descriptor.Spellbooks.First().Blueprint);
                //Main.logger.Log($"auto casting buff '{spellCast.Ability.name} at level {abilityData.CalculateParams().SpellLevel}' on combat join");
                //Main.logger.Log($"spellbook pre-cast: {spellbook.GetAvailableForCastSpellCount(abilityData)}");
                var proc = new AbilityExecutionContext(abilityData, abilityData.CalculateParams(), new Kingmaker.Utility.TargetWrapper(unit));
                AbilityExecutionProcess.ApplyEffectImmediate(proc, unit);
                abilityData.SpendFromSpellbook();
                //Main.logger.Log($"spellbook post-cast: {spellbook.GetAvailableForCastSpellCount(abilityData)}");
            }
        }

        public void HandleUnitLeaveCombat(UnitEntityData unit)
        {
        }
    }
    internal class Main
    {

        internal static UnityModManagerNet.UnityModManager.ModEntry.ModLogger logger;
        internal static Harmony.HarmonyInstance harmony;
        internal static LibraryScriptableObject library;

        static readonly Dictionary<Type, bool> typesPatched = new Dictionary<Type, bool>();
        static readonly List<String> failedPatches = new List<String>();
        static readonly List<String> failedLoading = new List<String>();

        [System.Diagnostics.Conditional("DEBUG")]
        internal static void DebugLog(string msg)
        {
            if (logger != null) logger.Log(msg);
        }
        internal static void DebugError(Exception ex)
        {
            if (logger != null) logger.Log(ex.ToString() + "\n" + ex.StackTrace);
        }
        internal static bool enabled;
        internal static ForceSelfBuffs forceSelfBuffs;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                logger = modEntry.Logger;
                harmony = Harmony.HarmonyInstance.Create(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                forceSelfBuffs = new ForceSelfBuffs();

                EventBus.Subscribe(forceSelfBuffs);
            }
            catch (Exception ex)
            {
                DebugError(ex);
                throw ex;
            }
            return true;
        }
        [Harmony.HarmonyPatch(typeof(LibraryScriptableObject), "LoadDictionary")]
        [Harmony.HarmonyPatch(typeof(LibraryScriptableObject), "LoadDictionary", new Type[0])]
        static class LibraryScriptableObject_LoadDictionary_Patch

        {
            [Harmony.HarmonyBefore(new string[] { "KingmakerAI" })]

            static void Postfix(LibraryScriptableObject __instance)
            {
                var self = __instance;
                if (Main.library != null) return;
                Main.library = self;
                try
                {
                    Main.logger.Log("Loading Tweak Mod");

#if DEBUG                
                    bool allow_guid_generation = true;
#else
                    bool allow_guid_generation = false; //no guids should be ever generated in release
#endif
                    CallOfTheWild.Helpers.GuidStorage.load(Properties.Resources.blueprints, allow_guid_generation);


                    SpellsTweaks.load();
                    StoryTweaks.load();


#if DEBUG
                    string guid_file_name = @"./Mods/StolenLands_blueprints_dump.txt"; // @"C:\Users\Josiah\Desktop\My Kingmaker Mods\Tweak Mod\Tweak Mod for Kingmaker\Tweak Mod\blueprints.txt";
                    CallOfTheWild.Helpers.GuidStorage.dump(guid_file_name);
#endif
                    CallOfTheWild.Helpers.GuidStorage.dump(@"./Mods/TweakMod/loaded_blueprints.txt");
                }
                catch (Exception ex)
                {
                    Main.DebugError(ex);
                }
            }
        }

        internal static Exception Error(String message)
        {
            logger?.Log(message);
            return new InvalidOperationException(message);
        }
    }
}