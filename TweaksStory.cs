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

namespace TweakMod
{
    class StoryTweaks
    {
        static LibraryScriptableObject library = Main.library;
        static Consideration light_armor_consideration = library.Get<ArmorTypeConsideration>("2ba801c8a6f585749b7fd636e843e6f0");
        static Consideration heavy_armor_consideration = library.Get<ArmorTypeConsideration>("c376d918c01838b48befcb711cc528ff");
        static Consideration targetself = library.Get<TargetSelfConsideration>("f4be6fc6f46b61044a44715f99f1918d");
        static Consideration ArcaneCasterPriorityConsiderationVordakai = library.Get<TargetClassConsideration>("fddbc4306c4d47640bb7ea482fab7b46");
        static CommandCooldownConsideration swift_action_available = library.Get<CommandCooldownConsideration>("c2b7d2f9a5cb8d04d9e1aa4bf3d3c598");
        static Consideration AOE_ChooseMoreEnemies = library.Get<UnitsAroundConsideration>("b2490b137b8b53a4e950c1d79d1c5c1d");
        static Consideration units_around = library.Get<UnitsThreateningConsideration>("ee3f6b33227c2f847acda914e90f25af");
        static Consideration attacktargetspriority = library.Get<ComplexConsideration>("7a2b25dcc09cd244db261ce0a70cca84");
        static Consideration SupporCasterFocusConsideration = library.Get<TargetClassConsideration>("60bfe8583de6d3f45818c641b459386e");


        static class Spells
        {
            public static BlueprintAbility cape_of_wasps = library.Get<BlueprintAbility>("093ed1d67a539ad4c939d9d05cfe192c");
            public static BlueprintAbility summon_worm = library.Get<BlueprintAbility>("954f1469ed62843409783c9fa7472998");
            public static BlueprintAbility displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            public static BlueprintAbility divinepower = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            public static BlueprintAbility prayer = library.Get<BlueprintAbility>("faabd2cc67efa4646ac58c7bb3e40fcc");
            public static BlueprintAbility umbralstrike = library.Get<BlueprintAbility>("474ed0aa656cc38499cc9a073d113716");
            public static BlueprintAbility hellfireray = library.Get<BlueprintAbility>("700cfcbd0cb2975419bcab7dbb8c6210");
            public static BlueprintAbility wailbanshee = library.Get<BlueprintAbility>("b24583190f36a8442b212e45226c54fc");
            public static BlueprintAbility summonelderearth = library.Get<BlueprintAbility>("65254c7a2cf18944287207e1de3e44e8");
            public static BlueprintAbility sunburst = library.Get<BlueprintAbility>("e96424f70ff884947b06f41a765b7658");
            public static BlueprintAbility stormbolt = library.Get<BlueprintAbility>("7cfbefe0931257344b2cb7ddc4cdff6f");
            public static BlueprintAbility tarpool = library.Get<BlueprintAbility>("7d700cdf260d36e48bb7af3a8ca5031f");
            public static BlueprintAbility seamantle = library.Get<BlueprintAbility>("7ef49f184922063499b8f1346fb7f521");
            public static BlueprintAbility trueseeing = library.Get<BlueprintAbility>("4cf3d0fae3239ec478f51e86f49161cb");
            public static BlueprintAbility greaterdispel = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
            public static BlueprintAbility greaterdispelarea = library.Get<BlueprintAbility>("b9be852b03568064b8d2275a6cf9e2de");
            public static BlueprintAbility frightfulaspect = library.Get<BlueprintAbility>("e788b02f8d21014488067bdd3ba7b325");
            public static BlueprintAbility wavesofexhaust = library.Get<BlueprintAbility>("3e4d3b9a5bd03734d9b053b9067c2f38");
            public static BlueprintAbility fear = library.Get<BlueprintAbility>("d2aeac47450c76347aebbc02e4f463e0");
            public static BlueprintAbility overwhelmingpresence = library.Get<BlueprintAbility>("41cf93453b027b94886901dbfc680cb9");
            public static BlueprintAbility SummonMonsterIX = library.Get<BlueprintAbility>("52b5df2a97df18242aec67610616ded0");
            public static BlueprintAbility SummonMonsterIXd3 = library.Get<BlueprintAbility>("4988b2e622c6f2d4b897894e3be13f09");
            public static BlueprintAbility blasphemy = library.Get<BlueprintAbility>("bd10c534a09f44f4ea632c8b8ae97145");
            public static BlueprintAbility inflictseriousmass = library.Get<BlueprintAbility>("820170444d4d2a14abc480fcbdb49535");
            public static BlueprintAbility vampireshield = library.Get<BlueprintAbility>("a34921035f2a6714e9be5ca76c5e34b5");
            public static BlueprintAbility bansheeblast = library.Get<BlueprintAbility>("d42c6d3f29e07b6409d670792d72bc82");
            public static BlueprintAbility unholyaura = library.Get<BlueprintAbility>("47f9cb1c367a5e4489cfa32fce290f86");
            public static BlueprintAbility cleaveaction = library.Get<BlueprintAbility>("6447d104a2222c14d9c9b8a36e4eb242");
            public static BlueprintAbility mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            public static BlueprintAbility constrictingcoils = library.Get<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
            public static BlueprintAbility entangle = library.Get<BlueprintAbility>("0fd00984a2c0e0a429cf1a911b4ec5ca");


        }


        static class AiActions
        {
            static public BlueprintAiCastSpell cape_of_wasps_cast_first = createCastSpellAction("CastCapeOfWaspsBuff", Spells.cape_of_wasps,
                                                                                     new Consideration[] { },
                                                                                     new Consideration[] { },
                                                                                     base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell divine_power_first = createCastSpellAction("CastDivinePowerFirst", Spells.divinepower,
                                                                         new Consideration[] { },
                                                                         new Consideration[] { },
                                                                         base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell summon_worm_first = createCastSpellAction("CastSummonWorm", Spells.summon_worm,
                                                                         new Consideration[] { },
                                                                         new Consideration[] { },
                                                                         base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell displacement_first = createCastSpellAction("CastDisplacementBuff", Spells.displacement,
                                                                                     new Consideration[] { },
                                                                                     new Consideration[] { },
                                                                                     base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell prayer_second = createCastSpellAction("CastPrayerSecond", Spells.prayer,
                                                                         new Consideration[] { },
                                                                         new Consideration[] { },
                                                                         base_score: 10.0f, combat_count: 2);

            static public BlueprintAiCastSpell umbral_strike = createCastSpellAction("CastUmbralStrike", Spells.umbralstrike,
                                                             new Consideration[] { },
                                                             new Consideration[] { },
                                                              base_score: 10.0f);
            static public BlueprintAiCastSpell hellfire_ray = createCastSpellAction("CastHellfireRay", Spells.hellfireray,
                                                             new Consideration[] { },
                                                             new Consideration[] { },
                                                             base_score: 10.0f);
            static public BlueprintAiCastSpell wail_banshee_first = createCastSpellAction("CastWailBanshee", Spells.wailbanshee,
                                                                         new Consideration[] { },
                                                                         new Consideration[] { },
                                                                         base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell summon_elder_earth = createCastSpellAction("CastSummonElderEarth", Spells.summonelderearth,
                                                             new Consideration[] { },
                                                             new Consideration[] { },
                                                             base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell sunburst = createCastSpellAction("CastSunburst", Spells.sunburst,
                                                 new Consideration[] { },
                                                 new Consideration[] { },
                                                 base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell stormbolt = createCastSpellAction("CastStormbolt", Spells.stormbolt,
                                     new Consideration[] { },
                                     new Consideration[] { },
                                     base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell tarpool = createCastSpellAction("CastTarpool", Spells.tarpool,
                         new Consideration[] { },
                         new Consideration[] { ArcaneCasterPriorityConsiderationVordakai },
                         base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell seamantle = createCastSpellAction("CastSeamantle", Spells.seamantle,
             new Consideration[] { },
             new Consideration[] { },
             base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell greaterdispel = createCastSpellAction("CastGreaterDispelQuick", Spells.greaterdispel,
                new Consideration[] { },
                new Consideration[] { AOE_ChooseMoreEnemies },
                base_score: 19.0f, variant: Spells.greaterdispelarea, combat_count: 1);

            static public BlueprintAiCastSpell frightfulaspect = createCastSpellAction("CastFrightfulAspect", Spells.frightfulaspect,
               new Consideration[] { },
               new Consideration[] { },
               base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell wavesofexhaust = createCastSpellAction("CastWavesOfExhaustion", Spells.wavesofexhaust,
               new Consideration[] { },
               new Consideration[] { AOE_ChooseMoreEnemies },
               base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell fear = createCastSpellAction("CastFear", Spells.fear,
              new Consideration[] { },
              new Consideration[] { AOE_ChooseMoreEnemies },
              base_score: 10.0f, combat_count: 1);


            static public BlueprintAiCastSpell overwhelmingpresence = createCastSpellAction("CastOverwhelmingpresence", Spells.overwhelmingpresence,
            new Consideration[] { },
            new Consideration[] { AOE_ChooseMoreEnemies },
            base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell summonmonsterIX = createCastSpellAction("CastSummonMonsterIX", Spells.SummonMonsterIX,
            new Consideration[] { },
            new Consideration[] { },
            base_score: 20.0f, variant: Spells.SummonMonsterIXd3, combat_count: 1);

            static public BlueprintAiCastSpell blasphemy = createCastSpellAction("CastBlasphemy", Spells.blasphemy,
                new Consideration[] { },
                new Consideration[] { },
                base_score: 10.0f, combat_count: 10);

            static public BlueprintAiCastSpell inflictseriousmass = createCastSpellAction("CastInflictSeriousWoundsMass", Spells.inflictseriousmass,
                  new Consideration[] { },
                 new Consideration[] { },
               base_score: 10.0f, combat_count: 4);
            static public BlueprintAiCastSpell vampireshield = createCastSpellAction("CastVampireShield", Spells.vampireshield,
                new Consideration[] { },
                new Consideration[] { },
              base_score: 10.0f, combat_count: 1);
            static public BlueprintAiCastSpell bansheeblast = createCastSpellAction("CastBansheeBlast", Spells.bansheeblast,
            new Consideration[] { },
            new Consideration[] { AOE_ChooseMoreEnemies },
            base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell unholyaura = createCastSpellAction("Castunholyaura", Spells.unholyaura,
            new Consideration[] { },
            new Consideration[] { },
            base_score: 20.0f, combat_count: 2);


            static public BlueprintAiCastSpell cleave = createCastSpellAction("UseCleave", Spells.cleaveaction,
            new Consideration[] { units_around },
            new Consideration[] { attacktargetspriority },
            base_score: 10.0f, combat_count: 3, cooldown_rounds: 3);

            static public BlueprintAiCastSpell mirrorimage = createCastSpellAction("Castmirrorimage", Spells.mirrorimage,
                new Consideration[] { },
                new Consideration[] { },
                base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell entangle = createCastSpellAction("Castentangle", Spells.entangle,
                new Consideration[] { },
                 new Consideration[] { AOE_ChooseMoreEnemies },
                base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell constrictingcoils = createCastSpellAction("Castconstrictingcoils", Spells.constrictingcoils,
             new Consideration[] { },
             new Consideration[] {SupporCasterFocusConsideration },
             base_score: 20.0f, combat_count: 1);




            //static public BlueprintAiCastSpell trueseeing = createCastSpellAction("CastTrueSeeing", Spells.trueseeing,
            //new Consideration[] { NoBuffDisplacement },
            //new Consideration[] { targetself },
            //base_score: 10.0f, combat_count: 1);


        }





        static BlueprintAiCastSpell createCastSpellAction(string name, BlueprintAbility spell, Consideration[] actor_consideration, Consideration[] target_consideration,
                                                       float base_score = 1f, BlueprintAbility variant = null, int combat_count = 0, int cooldown_rounds = 0, string guid = "")
        {

            var action = CallOfTheWild.Helpers.Create<BlueprintAiCastSpell>();
            action.Ability = spell;
            action.Variant = variant;
            action.ActorConsiderations = actor_consideration;
            action.TargetConsiderations = target_consideration;
            action.name = name;
            action.BaseScore = base_score;
            action.CombatCount = combat_count;
            action.CooldownRounds = cooldown_rounds;
            library.AddAsset(action, guid);

            return action;
        }


  


        static internal void load()
        {


            updateStagLord();

            updateKoboldTeacher();

            updateClericGorum();
            updateVordakai();
            updateDefacedSisterAbandonedKeep();
            fixDreadZombieFighter();
            fixDreadZombieCleric();
            updateDwarfMagus();
            updateTrollGuard();

            updateWrigglingMan();





            //updateDweomerLion();
            updateThickLizardQueen();
            updateLadyofSorrows();
            updateInsaneWizard();
            updateEvilDruid();
            updateQueenRavena();
            updateWickdedOmen();
            updatePatientShadow();
            //changeIronGolem();






        }

        static void updateStagLord()
        {



            var StagLord = library.Get<BlueprintUnit>("ef69e3a2787f4f34bbcbd048902c4bd3");
            var StagLord_feature = library.Get<BlueprintFeature>("6ad0806c857cd6a429c21edd066d8b87");
            var ranger = library.Get<BlueprintCharacterClass>("cda0615668a6df14eb36ba19ee881af6");
            var entangle = library.Get<BlueprintAbility>("0fd00984a2c0e0a429cf1a911b4ec5ca");





             var rangerLevels = StagLord_feature.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == ranger);
            var newrangerLevels = rangerLevels.CreateCopy();
            newrangerLevels.Levels = 10;
            var spell_list = newrangerLevels.MemorizeSpells.AddToArray(entangle);
            newrangerLevels.MemorizeSpells = spell_list;
            StagLord_feature.ReplaceComponent(rangerLevels, newrangerLevels);


            var brain = StagLord.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.entangle);


        }

        static void updateKoboldTeacher()
        {



            var KoboldTeacher = library.Get<BlueprintUnit>("5bffe8529599c954bab2670ab60a3c2e");
            var sorcerer = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)KoboldTeacher.AddFacts[0], "KoboldTeacherFeature", "aed7b8c113c640f38fe4251c44fde493");
            KoboldTeacher.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var KoboldTeacherFeature = library.Get<BlueprintFeature>("aed7b8c113c640f38fe4251c44fde493");

            var sorcererLevels = KoboldTeacherFeature.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == sorcerer);
            var newsorcererLevels = sorcererLevels.CreateCopy();
            newsorcererLevels.Levels = 6;
            var spell_list = newsorcererLevels.SelectSpells.AddToArray(magicmissle);
            newsorcererLevels.MemorizeSpells = spell_list;
            KoboldTeacherFeature.ReplaceComponent(sorcererLevels, newsorcererLevels);

            

            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("e689225185e99d3469052d9cce20316d", "MagicMissileAiAction", "");

            var brain = KoboldTeacher.Brain;
            brain.Actions = brain.Actions.AddToArray(ai_action);

        }



        static void updateClericGorum()      
        {
            var cleric = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var cleric_gorum_feature = library.Get<BlueprintFeature>("ca063d3e6c8576642a23fe74f2379ee0");
            var cleric_gorum = library.Get<BlueprintUnit>("4602809f9d59cc24a815d304715771c7");
            var divine_power = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var searing_light = library.Get<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
            var sm5 = library.Get<BlueprintAbility>("630c8b85d9f07a64f917d79cb5905741");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var heal = library.Get<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");
            var hellfireray = library.Get<BlueprintAbility>("700cfcbd0cb2975419bcab7dbb8c6210");
            var constrictingcoils = library.Get<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var divinefavor = library.Get<BlueprintAbility>("9d5d2d3ffdd73c648af3eb3e585b1113");



            cleric_gorum.AddFacts = cleric_gorum.AddFacts.AddToArray(quicken);



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)cleric_gorum.AddFacts[0], "ClericGorumFeature", "7141bd7cf6ce461ab8fb7e49b7ade9cf");
            cleric_gorum.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


 

            var clericgorumfeature = library.Get<BlueprintFeature>("7141bd7cf6ce461ab8fb7e49b7ade9cf");



            var clericLevels = clericgorumfeature.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == cleric);
            var newclericLevels = clericLevels.CreateCopy();
            newclericLevels.Levels = 13;
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(searing_light,heal,hellfireray,constrictingcoils);
            newclericLevels.MemorizeSpells = spell_list;
            clericgorumfeature.ReplaceComponent(clericLevels, newclericLevels);

            var clericLevels2 = clericgorumfeature.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == cleric);
            var newclericLevels2 = clericLevels2.CreateCopy();

            var spell_list2 = newclericLevels2.MemorizeSpells.RemoveFromArray(sm5);
            newclericLevels2.MemorizeSpells = spell_list2;
            clericgorumfeature.ReplaceComponent(clericLevels2, newclericLevels2);

            var clericLevels3 = clericgorumfeature.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == cleric);
            var newclericLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newclericLevels3.MemorizeSpells.RemoveFromArray(holdperson);
            newclericLevels3.MemorizeSpells = spell_list3;
            clericgorumfeature.ReplaceComponent(clericLevels3, newclericLevels3);

            var clericLevels4 = clericgorumfeature.ComponentsArray
                 .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == cleric);
            var newclericLevels4 = clericLevels4.CreateCopy();
            var spell_list4 = newclericLevels4.MemorizeSpells.RemoveFromArray(divinefavor);
            newclericLevels4.MemorizeSpells = spell_list4;
            clericgorumfeature.ReplaceComponent(clericLevels4, newclericLevels4);



            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.prayer);

            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("359210ef372c2e14e886062aa1014780", "SearingLightAiAction", "");
            var ai_action2 = library.CopyAndAdd<BlueprintAiCastSpell>("ca6c7898753350d4b9f42567d40d3dc4", "MisbegottenTrollHealAiAction", ""); 
            var brain = cleric_gorum.Brain;
            brain.Actions = brain.Actions.AddToArray(ai_action,ai_action2,AiActions.hellfire_ray,AiActions.constrictingcoils);






        }



        static void fixDreadZombieFighter()
        {
            
            var dread_zombie = library.Get<BlueprintUnit>("3fefbe1243265274f89e0280fb87a31b");
            var unit = library.Get<BlueprintFeature>("653d1afcb01ca694a9c867a65efe7f84");
            var fighter = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            var fighterLevels = unit.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighter);
            var newfighterLevels = fighterLevels.CreateCopy();
            newfighterLevels.Levels = 6;
            unit.ReplaceComponent(fighterLevels, newfighterLevels);


            var brain = dread_zombie.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);


        }


        static void fixDreadZombieCleric()
        {
            var cleric = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var dread_cleric= library.Get<BlueprintUnit>("fe662d20a0272bb4ea66bef675b4b52d");
            var unit = library.Get<BlueprintFeature>("82662ebad000b1349baf02e2f8e86748");
            var boneshaker = library.Get<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
            var hold_person= library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var Resfirecommun= library.Get<BlueprintAbility>("832bf98966e72cd478eecc9f8ba829f5");

            var add_class_levels = dread_cleric.GetComponent<AddAbilityToCharacterComponent>();

            var ability_list = add_class_levels.Abilities.RemoveFromArray(hold_person);

            add_class_levels.Abilities= ability_list;

            var add_class_levels_two = dread_cleric.GetComponent<AddAbilityToCharacterComponent>();
            var ability_list_two = add_class_levels_two.Abilities.AddToArray(Resfirecommun);
            add_class_levels_two.Abilities = ability_list_two;

 

            var clericLevels = unit.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == cleric);
            var newclericLevels = clericLevels.CreateCopy();
            newclericLevels.Levels = 12;
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(boneshaker);
            newclericLevels.MemorizeSpells = spell_list;
            unit.ReplaceComponent(clericLevels, newclericLevels);

            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("19eaed3ccfe2ab84492967e8f2ff6b56", "ResistFireCommunalAiAction", "");
            var ai_action_two = library.CopyAndAdd<BlueprintAiCastSpell>("d80fd23d61ab7e447831162153b8a9ad", "BoneshakerAiAction", "");
            var brain = dread_cleric.Brain;
            brain.Actions = brain.Actions.AddToArray(ai_action,ai_action_two);


        }

        static void updateVordakai()


        {

            var vordakai_feature = library.Get<BlueprintFeature>("1e873037c4cc3804abcfb7ea369e59aa");
            var vordakai_spells = library.Get<BlueprintFeature>("b3f49646e5c68124db58fbcabbde5a28");
            var vordakai= library.Get<BlueprintUnit>("f66d7df4dc3c7e04d9f357935e95f9e9");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var summon_monster_8 = library.Get<BlueprintAbility>("d3ac756a229830243a72e84f3ab050d0");
            var horrid_wilting = library.Get<BlueprintAbility>("08323922485f7e246acb3d2276515526");
            //var para_touch = library.Get<BlueprintAbility>("035d9ddcac2485e4282b56c542e21336");


            {
                //var add_class_levels = vordakai_feature.GetComponent<AddFacts>();

                //var ability_list = add_class_levels.Facts.RemoveFromArray(para_touch);

                //add_class_levels.Facts = ability_list;



                var wizardLevels = vordakai_feature.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
                var newwizardLevels = wizardLevels.CreateCopy();
                newwizardLevels.Levels = 18;
                var spell_list = newwizardLevels.MemorizeSpells.AddToArray(summon_monster_8,horrid_wilting);
                newwizardLevels.MemorizeSpells = spell_list;
                vordakai_feature.ReplaceComponent(wizardLevels, newwizardLevels);

                var wizardLevels2 = vordakai_spells.ComponentsArray
                   .OfType<LearnSpells>()
                   .First(c => c.CharacterClass == wizardClass);
                var newwizardLevels2 = wizardLevels2.CreateCopy();
                var spell_list2 = newwizardLevels2.Spells.AddToArray(summon_monster_8,horrid_wilting);
                newwizardLevels2.Spells = spell_list2;
                vordakai_spells.ReplaceComponent(wizardLevels2, newwizardLevels2);


                var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("7768e7b1d652b1545940c4f7426f3c2a", "LostlarnGhostMage_SummonMonsterVIII_AiAction", "");
                var ai_actiontwo = library.CopyAndAdd<BlueprintAiCastSpell>("40fd7a3ed09570842a9de7a8e9c8ffe5", "IrovettiPalace_GhostMageHorridWiltingAiAction", "");
                var brain = vordakai.Brain;
                brain.Actions = brain.Actions.AddToArray(ai_action,ai_actiontwo);

                



            }
        }

        static void updateDefacedSisterAbandonedKeep()

        {


            var fire_storm= library.Get<BlueprintAbility>("e3d0dfe1c8527934294f241e0ae96a8d");
            var plaguestorm = library.Get<BlueprintAbility>("82a5b848c05e3f342b893dedb1f9b446");
            var nymphclass = library.Get<BlueprintCharacterClass>("9a20b40b57f4e684fa20d17c0edfd5ba");
            var defaced_sister = library.Get<BlueprintUnit>("818785a4faef02a40bd448a6c6e6e557");
            var stormbolt = library.Get<BlueprintAbility>("7cfbefe0931257344b2cb7ddc4cdff6f");


            {


                var nymphLevels = defaced_sister.ComponentsArray
                      .OfType<AddClassLevels>()
                      .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels = nymphLevels.CreateCopy();
                newnymphLevels.Levels = 16;
                var spell_list = newnymphLevels.MemorizeSpells.AddToArray(fire_storm, plaguestorm);
                newnymphLevels.MemorizeSpells = spell_list;
                defaced_sister.ReplaceComponent(nymphLevels, newnymphLevels);

                var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("3e430588863f8b24fa7e05fdc2d92441", "FireStormAiAction", "");
                var brain = defaced_sister.Brain;
                brain.Actions = brain.Actions.AddToArray(ai_action, AiActions.stormbolt); 
            }
        }

        static void updateTrollGuard()
        {


            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var humanoidClass = library.Get<BlueprintCharacterClass>("6ab4526f94d2e3e439af0599a29b6675");
            var TrollGuard = library.Get<BlueprintUnit>("95f5cde9458d6f0439a6c9b0753667cd");


           TrollGuard.Strength = 20;

           TrollGuard.Dexterity = 15;

           TrollGuard.Constitution = 20;

            var humanoidLevels = TrollGuard.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == humanoidClass);
            var newhumanoidLevels = humanoidLevels.CreateCopy();
            newhumanoidLevels.Levels = 14;
            TrollGuard.ReplaceComponent(humanoidLevels, newhumanoidLevels);

            var fighterLevels = TrollGuard.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == fighterClass);
            var newfighterLevels = fighterLevels.CreateCopy();
            newfighterLevels.Levels = 12;
            TrollGuard.ReplaceComponent(fighterLevels, newfighterLevels);

           TrollGuard.Body.Armor = library.Get<BlueprintItemArmor>("61787c56c01996f4c82866aca8fb0187"); //Full plate +2

        }

        static void updateDwarfMagus()
        {


            var MagusClass = library.Get<BlueprintCharacterClass>("45a4607686d96a1498891b3286121780");
            var DwarfMagus = library.Get<BlueprintUnit>("66eae7f874edda341814e555ac4570cf");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
                       


            DwarfMagus.Strength = 24;

            DwarfMagus.Dexterity = 16;

            DwarfMagus.Intelligence = 20;

            DwarfMagus.Constitution = 18;

            DwarfMagus.AddFacts = DwarfMagus.AddFacts.AddToArray(quicken);




            var magusLevels = DwarfMagus.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == MagusClass);
            var newmagusLevels = magusLevels.CreateCopy();
            newmagusLevels.Levels = 18;
            DwarfMagus.ReplaceComponent(magusLevels, newmagusLevels);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add( Spells.mirrorimage);


        }


        static void updateWrigglingMan()
        {


            var vermin = library.Get<BlueprintCharacterClass>("d1a15612d1a96334d94edf5f1d3b8d29");
            var wrigglingman = library.Get<BlueprintUnit>("baf4cbd8e093b314ea73b9315551af33");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var wizardclass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var fireball = library.Get<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3");
            var fireresist15 = library.Get<BlueprintFeature>("24700a71dd3dc844ea585345f6dd18f6");

           wrigglingman.AddFacts = wrigglingman.AddFacts.AddToArray(fireresist15);










            var verminlevels = wrigglingman.GetComponent<AddClassLevels>();
            var newverminLevels = verminlevels.CreateCopy();
            newverminLevels.CharacterClass = library.Get<BlueprintCharacterClass>("d1a15612d1a96334d94edf5f1d3b8d29");
            newverminLevels.Levels = 20;
            wrigglingman.AddComponent(newverminLevels);



            var wizardLevels = wrigglingman.ComponentsArray
              .OfType<AddClassLevels>()
              .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels = wizardLevels.CreateCopy();
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(displacement);
            newAddClassLevels.SelectSpells = spell_list;
            wrigglingman.ReplaceComponent(wizardLevels, newAddClassLevels);

            var wizardLevels2 = wrigglingman.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newAddClassLevels2.MemorizeSpells.AddToArray(displacement);
            newAddClassLevels2.MemorizeSpells = spell_list2;
            wrigglingman.ReplaceComponent(wizardLevels2, newAddClassLevels2);

            var wizardLevels3 = wrigglingman.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels3 = wizardLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.MemorizeSpells.RemoveFromArray(fireball);
            newAddClassLevels3.MemorizeSpells = spell_list3;
            wrigglingman.ReplaceComponent(wizardLevels3, newAddClassLevels3);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);

            var brain = wrigglingman.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacement_first);

        }

























        static void updateThickLizardQueen()

        {


            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var clericClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var lizard_queen = library.Get<BlueprintUnit>("98efa959deae59a46b3007aca1621052");
            var bullsmass = library.Get<BlueprintAbility>("6a234c6dcde7ae94e94e9c36fd1163a7");
            var umbralstrike = library.Get<BlueprintAbility>("474ed0aa656cc38499cc9a073d113716");
            var hellfireray = library.Get<BlueprintAbility>("700cfcbd0cb2975419bcab7dbb8c6210");
            var divinepower = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");

            lizard_queen.Wisdom = 24;

            lizard_queen.Strength = 8;

            var clericLevels = lizard_queen.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            newAddClassLevels.Levels = 16;
            lizard_queen.ReplaceComponent(clericLevels, newAddClassLevels);


            var clericLevels2 = lizard_queen.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels2 = clericLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(bullsmass, umbralstrike, umbralstrike, hellfireray, hellfireray, divinepower);
            newAddClassLevels2.MemorizeSpells = spell_list;
            lizard_queen.ReplaceComponent(clericLevels2, newAddClassLevels2);




            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("8066bed11e9aef74298d9988dfca3166", "DruidGuard_BullStrengthMassAiAction", "");
            var brain = lizard_queen.Brain;
            brain.Actions = brain.Actions.AddToArray(ai_action, AiActions.divine_power_first, AiActions.umbral_strike, AiActions.hellfire_ray);


            {
                //TODO
            };



        }

        static void updateInsaneWizard()

        {


            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var insane_wizard = library.Get<BlueprintUnit>("426bdee2866ab3f409ea2d6196d2c101");
            var umbralstrike = library.Get<BlueprintAbility>("474ed0aa656cc38499cc9a073d113716");
            var sm7 = library.Get<BlueprintAbility>("ab167fd8203c1314bac6568932f1752f");
            var trueseeing = library.Get<BlueprintAbility>("b3da3fbee6a751d4197e446c7e852bcb");

            var wizardLevels = insane_wizard.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels = wizardLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            newAddClassLevels.Levels = 20;
            insane_wizard.ReplaceComponent(wizardLevels, newAddClassLevels);

            var wizardLevels2 = insane_wizard.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels2 = wizardLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.SelectSpells.RemoveFromArray(sm7);
            newAddClassLevels2.SelectSpells = spell_list;
            insane_wizard.ReplaceComponent(wizardLevels2, newAddClassLevels2);

            var wizardLevels3 = insane_wizard.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels3 = wizardLevels3.CreateCopy();
            var spell_list2 = newAddClassLevels3.SelectSpells.AddToArray(umbralstrike, trueseeing);
            newAddClassLevels3.SelectSpells = spell_list2;
            insane_wizard.ReplaceComponent(wizardLevels3, newAddClassLevels3);

            var wizardLevels4 = insane_wizard.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels4 = wizardLevels4.CreateCopy();
            var spell_list3 = newAddClassLevels4.MemorizeSpells.AddToArray(umbralstrike, trueseeing);
            newAddClassLevels4.MemorizeSpells = spell_list3;
            insane_wizard.ReplaceComponent(wizardLevels4, newAddClassLevels4);


            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.trueseeing);


            var brain = insane_wizard.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.umbral_strike);




        }


        static void updateLadyofSorrows()

        {


            var sorcererClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var lady_shallows = library.Get<BlueprintUnit>("ac131b0101870b6489609a7f33b5e576");
            var wailbanshee = library.Get<BlueprintAbility>("b24583190f36a8442b212e45226c54fc");


            var sorcererLevels = lady_shallows.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == sorcererClass);
            var newsorcererLevels = sorcererLevels.CreateCopy();
            newsorcererLevels.Levels = 20;
            lady_shallows.ReplaceComponent(sorcererLevels, newsorcererLevels);


            var sorcererLevels2 = lady_shallows.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == sorcererClass);
            var newsorcererLevels2 = sorcererLevels2.CreateCopy();
            var spell_list = newsorcererLevels2.SelectSpells.AddToArray(wailbanshee);
            newsorcererLevels2.SelectSpells = spell_list;
            lady_shallows.ReplaceComponent(sorcererLevels2, newsorcererLevels2);




            var brain = lady_shallows.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.wail_banshee_first, AiActions.seamantle);





        }

        static void updateEvilDruid()

        {

            var fire_storm = library.Get<BlueprintAbility>("e3d0dfe1c8527934294f241e0ae96a8d");
            var sunburst = library.Get<BlueprintAbility>("e96424f70ff884947b06f41a765b7658");
            var plaguestorm = library.Get<BlueprintAbility>("82a5b848c05e3f342b893dedb1f9b446");
            var druidclass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            var stormbolt = library.Get<BlueprintAbility>("7cfbefe0931257344b2cb7ddc4cdff6f");
            var evil_druid = library.Get<BlueprintUnit>("ca694cea2d423ec4f9dfb52187017ef4");
            var tarpool = library.Get<BlueprintAbility>("7d700cdf260d36e48bb7af3a8ca5031f");
            var seamantle = library.Get<BlueprintAbility>("7ef49f184922063499b8f1346fb7f521");
            var trueseeing = library.Get<BlueprintAbility>("4cf3d0fae3239ec478f51e86f49161cb");
            var greaterdispel = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");




            evil_druid.Wisdom = 26;




            var druidLevels = evil_druid.ComponentsArray
                       .OfType<AddClassLevels>()
                          .First(c => c.CharacterClass == druidclass);
            var newAddClassLevels = druidLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            newAddClassLevels.Levels = 20;
            evil_druid.ReplaceComponent(druidLevels, newAddClassLevels);

            var druidLevels2 = evil_druid.ComponentsArray
                     .OfType<AddClassLevels>()
                   .First(c => c.CharacterClass == druidclass);
            var newAddClassLevels2 = druidLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(fire_storm, plaguestorm, sunburst, stormbolt, tarpool, seamantle, greaterdispel);
            newAddClassLevels2.MemorizeSpells = spell_list;
            evil_druid.ReplaceComponent(druidLevels2, newAddClassLevels2);






            var add_class_levels = evil_druid.GetComponent<AddClassLevels>();
            evil_druid.AddFacts = new Kingmaker.Blueprints.Facts.BlueprintUnitFact[] {
                                                                                          library.Get<BlueprintBuff>("09b4b69169304474296484c74aa12027"),
                                                                                          library.Get<BlueprintFeature>("71a3f1c1ac77ae3488b9b3d6d2aac01a"),
                                                                                          library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936")

            };





            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.greaterdispel);




            var defaced_sister_brain = library.Get<BlueprintBrain>("6fbe3c1065a223f42857acee47543a60");

            var new_actions = defaced_sister_brain.Actions;

            evil_druid.Brain.Actions = new_actions;



            var brain = evil_druid.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.greaterdispel, AiActions.seamantle, AiActions.tarpool, AiActions.sunburst, AiActions.stormbolt);

        }


        static void updateWickdedOmen()

        {

            var wicked_omen = library.Get<BlueprintUnit>("48f6d4e80a5ee1840a21b4d1b4f705a5");
            var outsiderclass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            var wailbanshee = library.Get<BlueprintAbility>("b24583190f36a8442b212e45226c54fc");
            var wizardclass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var frightfulaspect = library.Get<BlueprintAbility>("e788b02f8d21014488067bdd3ba7b325");
            var wavesofexhaust = library.Get<BlueprintAbility>("3e4d3b9a5bd03734d9b053b9067c2f38");
            var enervation = library.Get<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
            var fear = library.Get<BlueprintAbility>("d2aeac47450c76347aebbc02e4f463e0");
            var natarmor15 = library.Get<BlueprintUnitFact>("72c294dca841e3944869fb087bacf272");
            var natarmor18 = library.Get<BlueprintUnitFact>("66b08b1f48983c54eb3f175d24ac7039");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");

            wicked_omen.AddFacts = wicked_omen.AddFacts.RemoveFromArray(enervation);
            wicked_omen.AddFacts = wicked_omen.AddFacts.RemoveFromArray(natarmor15);
            wicked_omen.AddFacts = wicked_omen.AddFacts.AddToArray(natarmor18, quicken);





            var wizardLevels = wicked_omen.GetComponent<AddClassLevels>();
            var newwizardLevels = wizardLevels.CreateCopy();
            newwizardLevels.CharacterClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            newwizardLevels.Levels = 20;
            wicked_omen.AddComponent(newwizardLevels);




            var wizardLevels2 = wicked_omen.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels2 = wizardLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.SelectSpells.AddToArray(frightfulaspect, wailbanshee, wavesofexhaust, fear);
            newAddClassLevels2.SelectSpells = spell_list;
            wicked_omen.ReplaceComponent(wizardLevels2, newAddClassLevels2);

            var wizardLevels3 = wicked_omen.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels3 = wizardLevels3.CreateCopy();
            var spell_list2 = newAddClassLevels3.MemorizeSpells.AddToArray(frightfulaspect, wailbanshee, wavesofexhaust, fear);
            newAddClassLevels3.MemorizeSpells = spell_list2;
            wicked_omen.ReplaceComponent(wizardLevels3, newAddClassLevels3);







            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.frightfulaspect);



            var brain = wicked_omen.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.wavesofexhaust, AiActions.frightfulaspect, AiActions.fear, AiActions.wail_banshee_first);





        }


        static void updatePatientShadow()

        {

            var patient_shadow = library.Get<BlueprintUnit>("ad43d3925f0754d498e07e7b1d43f385");
            var outsiderclass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            var vampireshield = library.Get<BlueprintAbility>("a34921035f2a6714e9be5ca76c5e34b5");
            var wizardclass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var frightfulaspect = library.Get<BlueprintAbility>("e788b02f8d21014488067bdd3ba7b325");
            var bansheeblast = library.Get<BlueprintAbility>("d42c6d3f29e07b6409d670792d72bc82");
            var wavesofexhaust = library.Get<BlueprintAbility>("3e4d3b9a5bd03734d9b053b9067c2f38");
            var vampirictouchastral = library.Get<BlueprintAbility>("5db2468da97174048bfb0b3096d01fd6");
            var enervation = library.Get<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
            var energydrain = library.Get<BlueprintAbility>("37302f72b06ced1408bf5bb965766d46");
            var fingerofdeath = library.Get<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe");
            var fear = library.Get<BlueprintAbility>("d2aeac47450c76347aebbc02e4f463e0");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var natarmor18 = library.Get<BlueprintUnitFact>("66b08b1f48983c54eb3f175d24ac7039");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var trueseeing = library.Get<BlueprintBuff>("09b4b69169304474296484c74aa12027");



            patient_shadow.AddFacts = patient_shadow.AddFacts.RemoveFromArray(vampirictouchastral);
            patient_shadow.AddFacts = patient_shadow.AddFacts.RemoveFromArray(energydrain);
            patient_shadow.AddFacts = patient_shadow.AddFacts.RemoveFromArray(enervation);
            patient_shadow.AddFacts = patient_shadow.AddFacts.RemoveFromArray(fingerofdeath);
            patient_shadow.AddFacts = patient_shadow.AddFacts.RemoveFromArray(natarmor14);
            patient_shadow.AddFacts = patient_shadow.AddFacts.AddToArray(natarmor18, quicken, trueseeing);





            patient_shadow.Intelligence = 34;
            patient_shadow.Constitution = 36;
            patient_shadow.Strength = 30;

            var outsiderLevels = patient_shadow.ComponentsArray
                       .OfType<AddClassLevels>()
                          .First(c => c.CharacterClass == outsiderclass);
            var newAddClassLevels = outsiderLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            newAddClassLevels.Levels = 28;
            patient_shadow.ReplaceComponent(outsiderLevels, newAddClassLevels);

            var wizardLevels = patient_shadow.GetComponent<AddClassLevels>();
            var newwizardLevels = wizardLevels.CreateCopy();
            newwizardLevels.CharacterClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            newwizardLevels.Levels = 20;
            patient_shadow.AddComponent(newwizardLevels);




            var wizardLevels2 = patient_shadow.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels2 = wizardLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.SelectSpells.AddToArray(frightfulaspect, fingerofdeath, fingerofdeath, bansheeblast);
            newAddClassLevels2.SelectSpells = spell_list;
            patient_shadow.ReplaceComponent(wizardLevels2, newAddClassLevels2);

            var wizardLevels3 = patient_shadow.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels3 = wizardLevels3.CreateCopy();
            var spell_list2 = newAddClassLevels3.MemorizeSpells.AddToArray(frightfulaspect, fingerofdeath, fingerofdeath, bansheeblast);
            newAddClassLevels3.MemorizeSpells = spell_list2;
            patient_shadow.ReplaceComponent(wizardLevels3, newAddClassLevels3);





            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.frightfulaspect);



            var brain = patient_shadow.Brain;
            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("4e7b7b939da6de14491c687409adcdf1", "FingerOfDeathVordakaiAIAction", "");
            brain.Actions = brain.Actions.AddToArray(AiActions.frightfulaspect, AiActions.bansheeblast, ai_action, ai_action);





        }



        static void updateDweomerLion()

        {

            var dweomer_lion = library.Get<BlueprintUnit>("d18e88914526d38438463ea50541c4cd");
            var nat_arm_8 = library.Get<BlueprintUnitFact>("b9342e2a6dc5165489ba3412c50ca3d1");
            var nat_arm_16 = library.Get<BlueprintUnitFact>("73a90b2a70d576f429ad401e7a5a8a4f");




            dweomer_lion.AddFacts = dweomer_lion.AddFacts.RemoveFromArray(nat_arm_8);

            dweomer_lion.AddFacts = dweomer_lion.AddFacts.AddToArray(nat_arm_16);


            dweomer_lion.ReplaceComponent<AddClassLevels>(a =>
            {
                a.Levels = 20;

            });
        }

        static void updateQueenRavena()

        {


            var fighterclass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var clericclass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var rogueclass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var queen_ravena = library.Get<BlueprintUnit>("23779e7e2168070469b588b03c570ed9"); //GlobalPuzzleLadyBoss
            var overwhelmingpresence = library.Get<BlueprintAbility>("41cf93453b027b94886901dbfc680cb9");
            var summonMonsterIX = library.Get<BlueprintAbility>("52b5df2a97df18242aec67610616ded0");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var augmentsummon = library.Get<BlueprintFeature>("38155ca9e4055bb48a89240a2055dcc3");
            var sneakattacker = library.Get<BlueprintFeature>("9f0187869dc23744292c0e5bb364464e");
            var blindingcriticalfeature = library.Get<BlueprintFeature>("787e56055e3ef864d9c78a3ec21e56be");
            var Cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var dazzlingdisplay = library.Get<BlueprintFeature>("bcbd674ec70ff6f4894bb5f07b6f4095");
            var basicfeatselection = library.Get<BlueprintFeatureSelection>("247a4068296e8be42890143f451b4b45");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var frightfulaspect = library.Get<BlueprintAbility>("e788b02f8d21014488067bdd3ba7b325");
            var superiorsummmoning = library.Get<BlueprintFeature>("0477936c0f74841498b5c8753a8062a3");
            var blasphemy = library.Get<BlueprintAbility>("bd10c534a09f44f4ea632c8b8ae97145");
            var inflictseriousmass = library.Get<BlueprintAbility>("820170444d4d2a14abc480fcbdb49535");
            var heavyarmorprof = library.Get<BlueprintFeature>("1b0f68188dcc435429fb87a022239681");
            var shieldbash = library.Get<BlueprintFeature>("121811173a614534e8720d7550aae253");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var unholyaura = library.Get<BlueprintAbility>("47f9cb1c367a5e4489cfa32fce290f86");
            var improvedinitiative = library.Get<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");






            // var greaterdispel = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");

            queen_ravena.Alignment = Alignment.ChaoticEvil;


            queen_ravena.Wisdom = 36;
            queen_ravena.Constitution = 40;
            queen_ravena.Dexterity = 34;
            queen_ravena.Strength = 30;







            var clericlevels = queen_ravena.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterclass);
            var newAddClassLevels = clericlevels.CreateCopy();
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.RemoveFromArray(sneakattacker);
                selection.Features = selection.Features.RemoveFromArray(Cornugon);
                selection.Features = selection.Features.RemoveFromArray(dazzlingdisplay);
                selection.Features = selection.Features.RemoveFromArray(blindingcriticalfeature);
                selection.Features = selection.Features.RemoveFromArray(shieldbash);
            }
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            newAddClassLevels.Levels = 20;
            queen_ravena.ReplaceComponent(clericlevels, newAddClassLevels);

            var roguelevels = queen_ravena.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == rogueclass);
            var newAddClassLevels3 = roguelevels.CreateCopy();
            newAddClassLevels3.CharacterClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            newAddClassLevels3.Levels = 0;
            queen_ravena.ReplaceComponent(roguelevels, newAddClassLevels3);



            var clericlevels2 = queen_ravena.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == clericclass);
            var newAddClassLevels2 = clericlevels2.CreateCopy();
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(overwhelmingpresence, frightfulaspect, summonMonsterIX, unholyaura);
            newAddClassLevels2.MemorizeSpells = spell_list;
            queen_ravena.ReplaceComponent(clericlevels2, newAddClassLevels2);

            var clericlevels4 = queen_ravena.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == clericclass);
            var newAddClassLevels4 = clericlevels4.CreateCopy();
            foreach (var selection in newAddClassLevels4.Selections)
            {
                selection.Features = selection.Features.AddToArray(augmentsummon, combatcasting, superiorsummmoning, heavyarmorprof, toughness, improvedinitiative);

            }
            queen_ravena.ReplaceComponent(clericlevels4, newAddClassLevels4);







            queen_ravena.AddFacts = new Kingmaker.Blueprints.Facts.BlueprintUnitFact[] {

                                                                                          library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936"),
                                                                                          library.Get<BlueprintFeature>("9ebe166b9b901c746b1858029f13a2c5"),
                                                                                          library.Get<BlueprintFeature>("57299a78b2256604dadf1ab9a42e2873"),
                                                                                          library.Get<BlueprintFeature>("156cfcb07f2d0bf45aa9d35c76dda5d3")

        };


            queen_ravena.Body.Neck = library.Get<BlueprintItemEquipmentNeck>("081a2ffe763320a469de20f1e9b1cd71");


            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.SummonMonsterIX);
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.frightfulaspect);


            var brain = queen_ravena.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.overwhelmingpresence, AiActions.frightfulaspect, AiActions.summonmonsterIX, AiActions.unholyaura, AiActions.blasphemy);


        }

        static void changeIronGolem()

        {


            var IronGolem = library.Get<BlueprintUnit>("a7eaa09a61b298e4ebe97695e8be4b03");



            IronGolem.LocalizedName = Helpers.Create<SharedStringAsset>(c => c.String = Helpers.CreateString($"{IronGolem.name}.name", "Test"));

            IronGolem.Prefab = new UnitViewLink() { AssetId = "d93845f1f55257147bd328a66a0cb4b0" };




        }












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
