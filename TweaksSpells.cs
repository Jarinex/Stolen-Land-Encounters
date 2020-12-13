using CallOfTheWild;
using dnlib.DotNet;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Controllers.Brain.Blueprints;
using Kingmaker.Controllers.Brain.Blueprints.Considerations;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Localization;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyJson;
using CallOfTheWild.FavoredEnemyMechanics;
using CallOfTheWild.SizeMechanics;
using UnityEngine.UI;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;




namespace Kingmaker.UnitLogic.Mechanics.Actions
{
    public class CustomContextActionSpawnMonster : ContextAction
    {

        public override string GetCaption()
        {
            return "Summon monster";

        }

        public override void RunAction()
        {
            UnitEntityData maybeCaster = base.Context.MaybeCaster;
            if (maybeCaster == null)
            {
                UberDebug.LogError(this, "Caster is missing", Array.Empty<object>());
                return;
            }
            Vector3 vector = base.Target.Point;
            vector += new Vector3(3, 0, -2);
            vector = ObstacleAnalyzer.GetNearestNode(vector).clampedPosition;
            UnitEntityView unitEntityView = this.Blueprint.Prefab.Load(false);
            float radius = (unitEntityView != null) ? unitEntityView.Corpulence : 0.5f;
            FreePlaceSelector.PlaceSpawnPlaces(3, radius, vector);
            Game.Instance.EntityCreator.SpawnUnit(this.Blueprint, vector, Quaternion.identity, maybeCaster.HoldingState);
        }

        public BlueprintUnit Blueprint;
    }

}

namespace Kingmaker.UnitLogic.Mechanics.Actions
{
    public class CustomContextActionSpawnMonster2 : ContextAction
    {

        public override string GetCaption()
        {
            return "Summon monster";

        }

        public override void RunAction()
        {
            UnitEntityData maybeCaster = base.Context.MaybeCaster;
            if (maybeCaster == null)
            {
                UberDebug.LogError(this, "Caster is missing", Array.Empty<object>());
                return;
            }
            Vector3 vector = base.Target.Point;
            vector += new Vector3(-3, 0, -2);
            vector = ObstacleAnalyzer.GetNearestNode(vector).clampedPosition;
            UnitEntityView unitEntityView = this.Blueprint.Prefab.Load(false);
            float radius = (unitEntityView != null) ? unitEntityView.Corpulence : 0.5f;
            FreePlaceSelector.PlaceSpawnPlaces(3, radius, vector);
            Game.Instance.EntityCreator.SpawnUnit(this.Blueprint, vector, Quaternion.identity, maybeCaster.HoldingState);
        }

        public BlueprintUnit Blueprint;
    }

}

namespace Kingmaker.UnitLogic.Mechanics.Actions
{
    public class CustomContextActionSpawnMonster3 : ContextAction
    {

        public override string GetCaption()
        {
            return "Summon monster";

        }

        public override void RunAction()
        {
            UnitEntityData maybeCaster = base.Context.MaybeCaster;
            if (maybeCaster == null)
            {
                UberDebug.LogError(this, "Caster is missing", Array.Empty<object>());
                return;
            }
            Vector3 vector = base.Target.Point;
            vector += new Vector3(3, 0, 3);
            vector = ObstacleAnalyzer.GetNearestNode(vector).clampedPosition;
            UnitEntityView unitEntityView = this.Blueprint.Prefab.Load(false);
            float radius = (unitEntityView != null) ? unitEntityView.Corpulence : 0.5f;
            FreePlaceSelector.PlaceSpawnPlaces(3, radius, vector);
            Game.Instance.EntityCreator.SpawnUnit(this.Blueprint, vector, Quaternion.identity, maybeCaster.HoldingState);
        }

        public BlueprintUnit Blueprint;
    }

}

namespace Kingmaker.UnitLogic.Mechanics.Actions
{
    public class CustomContextActionSpawnMonster4 : ContextAction
    {

        public override string GetCaption()
        {
            return "Summon monster";

        }

        public override void RunAction()
        {
            UnitEntityData maybeCaster = base.Context.MaybeCaster;
            if (maybeCaster == null)
            {
                UberDebug.LogError(this, "Caster is missing", Array.Empty<object>());
                return;
            }
            Vector3 vector = base.Target.Point;
            vector += new Vector3(-3, 0, 3);
            vector = ObstacleAnalyzer.GetNearestNode(vector).clampedPosition;
            UnitEntityView unitEntityView = this.Blueprint.Prefab.Load(false);
            float radius = (unitEntityView != null) ? unitEntityView.Corpulence : 0.5f;
            FreePlaceSelector.PlaceSpawnPlaces(3, radius, vector);
            Game.Instance.EntityCreator.SpawnUnit(this.Blueprint, vector, Quaternion.identity, maybeCaster.HoldingState);
        }

        public BlueprintUnit Blueprint;
    }

}

namespace Kingmaker.UnitLogic.Mechanics.Actions
{
    public class CustomContextActionSpawnMonster5 : ContextAction
    {

        public override string GetCaption()
        {
            return "Summon monster";

        }

        public override void RunAction()
        {
            UnitEntityData maybeCaster = base.Context.MaybeCaster;
            if (maybeCaster == null)
            {
                UberDebug.LogError(this, "Caster is missing", Array.Empty<object>());
                return;
            }
            Vector3 vector = base.Target.Point;
            vector += new Vector3(-2, 0, 2);
            vector = ObstacleAnalyzer.GetNearestNode(vector).clampedPosition;
            UnitEntityView unitEntityView = this.Blueprint.Prefab.Load(false);
            float radius = (unitEntityView != null) ? unitEntityView.Corpulence : 0.5f;
            FreePlaceSelector.PlaceSpawnPlaces(3, radius, vector);
            Game.Instance.EntityCreator.SpawnUnit(this.Blueprint, vector, Quaternion.identity, maybeCaster.HoldingState);
        }

        public BlueprintUnit Blueprint;
    }

}

namespace Kingmaker.UnitLogic.Mechanics.Actions
{
    public class CustomContextActionSpawnMonster6 : ContextAction
    {

        public override string GetCaption()
        {
            return "Summon monster";

        }

        public override void RunAction()
        {
            UnitEntityData maybeCaster = base.Context.MaybeCaster;
            if (maybeCaster == null)
            {
                UberDebug.LogError(this, "Caster is missing", Array.Empty<object>());
                return;
            }
            Vector3 vector = base.Target.Point;
            vector += new Vector3(2, 0, -2);
            vector = ObstacleAnalyzer.GetNearestNode(vector).clampedPosition;
            UnitEntityView unitEntityView = this.Blueprint.Prefab.Load(false);
            float radius = (unitEntityView != null) ? unitEntityView.Corpulence : 0.5f;
            FreePlaceSelector.PlaceSpawnPlaces(3, radius, vector);
            Game.Instance.EntityCreator.SpawnUnit(this.Blueprint, vector, Quaternion.identity, maybeCaster.HoldingState);
        }

        public BlueprintUnit Blueprint;
    }

}



namespace TweakMod
{
    class SpellsTweaks
    {

        static LibraryScriptableObject library = Main.library;

        static internal void load()
        {
            testsummongorum();
            callcylops();
            callghosts();
            callghostsstandard();
            callundeadfriends();
        }



        static void testsummongorum()
        {
            var cleric_gorum = library.Get<BlueprintUnit>("4602809f9d59cc24a815d304715771c7");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster>(c => c.Blueprint = cleric_gorum),
               Helpers.Create<CustomContextActionSpawnMonster2>(c => c.Blueprint = cleric_gorum));

            var ability = Helpers.CreateAbility("Summon Spirits",
                "Summon Spirits",
               "Summon the spirits of recently slain clerics of gorum so that they may exact revenge on their enemy.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var summoncleric_resource = Helpers.CreateAbilityResource("summonclericResource", "", "", "", null);
            summoncleric_resource.SetFixedResource(1);

        }

        static void callcylops()
        {
            var dread_zombie = library.Get<BlueprintUnit>("3fefbe1243265274f89e0280fb87a31b");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster3>(c => c.Blueprint = dread_zombie),
               Helpers.Create<CustomContextActionSpawnMonster4>(c => c.Blueprint = dread_zombie));

            var ability = Helpers.CreateAbility("Call Minions",
                "Call Minions",
               "Summon two thick-skinned cyclops to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var summoncyclops_resource2 = Helpers.CreateAbilityResource("summoncyclopsResource2", "", "", "", null);
            summoncyclops_resource2.SetFixedResource(2);

        }

        static void callghosts()
        {
            var spectre = library.Get<BlueprintUnit>("2f91d7337b60e3b4b9b137198a8c8745");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = spectre),
               Helpers.Create<CustomContextActionSpawnMonster6>(c => c.Blueprint = spectre));

            var ability = Helpers.CreateAbility("Summon Ghostly Aid",
                "Summon Ghostly Aid",
               "Summon ghosts to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var summonghosts_resource2 = Helpers.CreateAbilityResource("summonghostsResource2", "", "", "", null);
            summonghosts_resource2.SetFixedResource(2);

        }

        static void callghostsstandard()
        {
            var ghosts = library.Get<BlueprintUnit>("655ac57b330918c4aadc78a00fb2ccaf");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = ghosts),
               Helpers.Create<CustomContextActionSpawnMonster6>(c => c.Blueprint = ghosts));

            var ability = Helpers.CreateAbility("Summon Ghosts",
                "Summon Ghosts",
               "Summon ghosts.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var summonghosts_resource3 = Helpers.CreateAbilityResource("summonghostsResource3", "", "", "", null);
            summonghosts_resource3.SetFixedResource(2);

        }

        static void callundeadfriends()
        {
            var skeletonarcher = library.Get<BlueprintUnit>("9928642aa0612434bbb23f478dbbf988");
            var zombielord = library.Get<BlueprintUnit>("3f40cda42b20ee44683548d5856f035e");

            var actions = Helpers.CreateRunActions(
                Helpers.Create<CustomContextActionSpawnMonster>(c => c.Blueprint = skeletonarcher),
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = zombielord),
               Helpers.Create<CustomContextActionSpawnMonster6>(c => c.Blueprint = zombielord));

            var ability = Helpers.CreateAbility("Summon Undead",
                "Summon Undead",
               "Summon Undead.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var summonundead_resource3 = Helpers.CreateAbilityResource("summonundeadResource", "", "", "", null);
            summonundead_resource3.SetFixedResource(2);

        }

        // static void callcyclops()
        // {
        //   var dread_zombie = library.Get<BlueprintUnit>("3fefbe1243265274f89e0280fb87a31b");
        //
        //  var actions = Helpers.CreateRunActions(
        //    Helpers.Create<CustomContextActionSpawnMonster>(c => c.Blueprint = dread_zombie),
        //    Helpers.Create<CustomContextActionSpawnMonster2>(c => c.Blueprint = dread_zombie));

        //var ability = Helpers.CreateAbility("Call for Minions",
        //  "Call for Minions",
        //  "Call two dread zombie cyclops to your aid.",
        //  "",
        //   null,
        //Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
        //Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
        // Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
        //    "",
        //    "",
        //actions);

        //var callcyclops_resource = Helpers.CreateAbilityResource("callcyclopsresource", "", "", "", null);
        // callcyclops_resource.SetFixedResource(1);

        // }





































        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}