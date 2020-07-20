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

namespace TweakMod
{
    class PrisonTweaks
    {
        static LibraryScriptableObject library = Main.library;
        static Consideration light_armor_consideration = library.Get<ArmorTypeConsideration>("2ba801c8a6f585749b7fd636e843e6f0");
        static Consideration heavy_armor_consideration = library.Get<ArmorTypeConsideration>("c376d918c01838b48befcb711cc528ff");
        static Consideration targetself = library.Get<TargetSelfConsideration>("f4be6fc6f46b61044a44715f99f1918d");
        static Consideration ArcaneCasterPriorityConsiderationVordakai = library.Get<TargetClassConsideration>("fddbc4306c4d47640bb7ea482fab7b46");
        static CommandCooldownConsideration swift_action_available = library.Get<CommandCooldownConsideration>("c2b7d2f9a5cb8d04d9e1aa4bf3d3c598");
        static Consideration AOE_ChooseMoreEnemies = library.Get<UnitsAroundConsideration>("b2490b137b8b53a4e950c1d79d1c5c1d");


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
                         new Consideration[] {ArcaneCasterPriorityConsiderationVordakai },
                         base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell seamantle = createCastSpellAction("CastSeamantle", Spells.seamantle,
             new Consideration[] { },
             new Consideration[] { },
             base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell greaterdispel = createCastSpellAction("CastGreaterDispelQuick", Spells.greaterdispel, 
                new Consideration[] {  },
                new Consideration[] { AOE_ChooseMoreEnemies },
                base_score: 19.0f, variant: Spells.greaterdispelarea, combat_count: 1);

            static public BlueprintAiCastSpell frightfulaspect = createCastSpellAction("CastFrightfulAspect", Spells.frightfulaspect,
               new Consideration[] { },
               new Consideration[] {},
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
            new Consideration[] {AOE_ChooseMoreEnemies},
            base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell summonmonsterIX = createCastSpellAction("CastSummonMonsterIX", Spells.SummonMonsterIX,
            new Consideration[] { },
            new Consideration[] { },
            base_score: 20.0f, variant: Spells.SummonMonsterIXd3, combat_count: 1);

            static public BlueprintAiCastSpell blasphemy = createCastSpellAction("CastBlasphemy", Spells.blasphemy,
                new Consideration[] { },
                new Consideration[] { },
                base_score: 10.0f,  combat_count: 5);

            static public BlueprintAiCastSpell inflictseriousmass = createCastSpellAction("CastInflictSeriousWoundsMass", Spells.inflictseriousmass,
                  new Consideration[] { },
                 new Consideration[] { },
               base_score: 10.0f, combat_count: 4);


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
            


            
            //updatePoacherMelee();
            //updateDweomerLion();
            updateThickLizardQueen();
            updateLadyofSorrows();
            updateInsaneWizard();
            updateEvilDruid();
            updateQueenRavena();
            updateWickdedOmen();
            //changeIronGolem();



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
            var spell_list2 = newAddClassLevels3.SelectSpells.AddToArray(umbralstrike,trueseeing);
            newAddClassLevels3.SelectSpells = spell_list2;
            insane_wizard.ReplaceComponent(wizardLevels3, newAddClassLevels3);

            var wizardLevels4 = insane_wizard.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels4 = wizardLevels4.CreateCopy();
            var spell_list3 = newAddClassLevels4.MemorizeSpells.AddToArray(umbralstrike,trueseeing);
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
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(fire_storm, plaguestorm,sunburst,stormbolt,tarpool,seamantle,greaterdispel);
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
            wicked_omen.AddFacts = wicked_omen.AddFacts.AddToArray(natarmor18,quicken);
 


            var wizardLevels = wicked_omen.GetComponent<AddClassLevels>();
            var newwizardLevels = wizardLevels.CreateCopy();
            newwizardLevels.CharacterClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            newwizardLevels.Levels = 20;
            wicked_omen.AddComponent(newwizardLevels);




            var wizardLevels2 = wicked_omen.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels2 = wizardLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.SelectSpells.AddToArray(frightfulaspect, wailbanshee, wavesofexhaust,fear);
            newAddClassLevels2.SelectSpells = spell_list;
            wicked_omen.ReplaceComponent(wizardLevels2, newAddClassLevels2);

            var wizardLevels3 = wicked_omen.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels3 = wizardLevels3.CreateCopy();
            var spell_list2 = newAddClassLevels3.MemorizeSpells.AddToArray(frightfulaspect, wailbanshee,wavesofexhaust,fear);
            newAddClassLevels3.MemorizeSpells = spell_list2;
            wicked_omen.ReplaceComponent(wizardLevels3, newAddClassLevels3);



      

         

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.frightfulaspect);



            var brain = wicked_omen.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.wavesofexhaust, AiActions.frightfulaspect, AiActions.fear, AiActions.wail_banshee_first);





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





            // var greaterdispel = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");

            queen_ravena.Alignment = Alignment.ChaoticEvil;


            queen_ravena.Wisdom = 36;
            queen_ravena.Constitution = 30;
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
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(overwhelmingpresence,frightfulaspect,summonMonsterIX,inflictseriousmass);
            newAddClassLevels2.MemorizeSpells = spell_list;
            queen_ravena.ReplaceComponent(clericlevels2, newAddClassLevels2);

            var clericlevels4 = queen_ravena.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == clericclass);
            var newAddClassLevels4 = clericlevels4.CreateCopy();
            foreach (var selection in newAddClassLevels4.Selections)
            {
                selection.Features = selection.Features.AddToArray(augmentsummon,combatcasting,superiorsummmoning,heavyarmorprof);

            }
            queen_ravena.ReplaceComponent(clericlevels4, newAddClassLevels4);




                                                          


            queen_ravena.AddFacts = new Kingmaker.Blueprints.Facts.BlueprintUnitFact[] {
                                                                                          library.Get<BlueprintBuff>("9eda82a1f78558747a03c17e0e9a1a68"),
                                                                                          library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936"),
                                                                                          library.Get<BlueprintFeature>("9ebe166b9b901c746b1858029f13a2c5"),
                                                                                          library.Get<BlueprintFeature>("57299a78b2256604dadf1ab9a42e2873")
                                                                                          
        }; 


            queen_ravena.Body.Neck = library.Get<BlueprintItemEquipmentNeck>("081a2ffe763320a469de20f1e9b1cd71");


            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.overwhelmingpresence);


            var brain = queen_ravena.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.overwhelmingpresence,AiActions.frightfulaspect,AiActions.summonmonsterIX,AiActions.inflictseriousmass,AiActions.blasphemy);


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
