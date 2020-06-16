using CallOfTheWild;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Controllers.Brain.Blueprints;
using Kingmaker.Controllers.Brain.Blueprints.Considerations;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweakMod
{
    class Tweaks
    {
        static LibraryScriptableObject library = Main.library;

        static class Spells
        {
            public static BlueprintAbility cape_of_wasps = library.Get<BlueprintAbility>("093ed1d67a539ad4c939d9d05cfe192c");
            public static BlueprintAbility summon_worm = library.Get<BlueprintAbility>("954f1469ed62843409783c9fa7472998");
            public static BlueprintAbility displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
        }


        static class AiActions
        {
            static public BlueprintAiCastSpell cape_of_wasps_cast_first = createCastSpellAction("CastCapeOfWaspsBuff", Spells.cape_of_wasps,
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
            


            updateFerociusDevourer();
            updateClericGorum();
            updateVordakai();
            updateDefacedSister();
            fixDreadZombieCleric();
            updatePoacherMelee();
            updateDweomerLion();
            updateThickLizardQueen();
            updateInsaneWizard();
            updateEvilDruid();



        }



        static void updateClericGorum()
        {
            var unit = library.Get<BlueprintFeature>("ca063d3e6c8576642a23fe74f2379ee0");
            var cleric_gorum = library.Get<BlueprintUnit>("4602809f9d59cc24a815d304715771c7");
            var divine_power = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var searing_light = library.Get<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");

            {
                var add_class_levels = unit.GetComponent<AddClassLevels>();

                var spell_list = add_class_levels.MemorizeSpells.RemoveFromArray(divine_power); //this removes the spell


                spell_list = spell_list.AddToArray(new BlueprintAbility[] // this adds the new spell
                                                        {
                                                                            searing_light
                                                        }
                                   );

                add_class_levels.MemorizeSpells = spell_list; //this puts them both together and adds it to the units spell list


                unit.ReplaceComponent<AddClassLevels>(a =>
                {
                    a.Levels = 20;

                });// This increases there levels. I think it has to come AFTER the spell stuff, otherwise it doesnt load it.

                var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("359210ef372c2e14e886062aa1014780", "SearingLightAiAction", "");
                var brain = cleric_gorum.Brain;
                brain.Actions = brain.Actions.AddToArray(ai_action); //this gets the AI to actually cast the spell

            }
        }


        static void updateFerociusDevourer()
        {
            var ferocious_devourer = library.Get<BlueprintUnit>("741f1f72663260c4fa6350a8829c843e");// The Kingmaker Blueprint Unit C17 Ferocious Devourer

            var add_class_levels = ferocious_devourer.GetComponent<AddClassLevels>();
            ferocious_devourer.AddFacts = new Kingmaker.Blueprints.Facts.BlueprintUnitFact[] {
                                                                                          library.Get<BlueprintBuff>("4231e0d5008744d428842eb068e5ed92"), // Vordakais Fear


            };

            ferocious_devourer.ReplaceComponent<AddClassLevels>(a =>
            {
                a.Levels = 18;

            });
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

        static void updateDefacedSister()

        {


            var fire_storm= library.Get<BlueprintAbility>("e3d0dfe1c8527934294f241e0ae96a8d");
            var plaguestorm = library.Get<BlueprintAbility>("82a5b848c05e3f342b893dedb1f9b446");
            var nymphclass = library.Get<BlueprintCharacterClass>("9a20b40b57f4e684fa20d17c0edfd5ba");
            var defaced_sister = library.Get<BlueprintUnit>("818785a4faef02a40bd448a6c6e6e557");

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
                var ai_action_two = library.CopyAndAdd<BlueprintAiCastSpell>("e571595ce30b691468fd56aa6796e407", "FinalDungeon_GolemAdamantine_StormboltsAiACtion", "");
                var brain = defaced_sister.Brain;
                brain.Actions = brain.Actions.AddToArray(ai_action,ai_action_two); //this gets the AI to actually cast the spell
            }
        }

        static void updatePoacherMelee()

        {
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var poacher_melee = library.Get<BlueprintUnit>("ecf28e6595834494bb8619912b08a2fb");


            var rogueLevels = poacher_melee.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == rogueClass);
            var newRogueLevels = rogueLevels.CreateCopy();
            newRogueLevels.Levels = 10;
            poacher_melee.ReplaceComponent(rogueLevels, newRogueLevels);

            var barbarianLevels = poacher_melee.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == barbarianClass);
            var newBarbarianLevels = barbarianLevels.CreateCopy();
            newBarbarianLevels.Levels = 10;
            poacher_melee.ReplaceComponent(barbarianLevels, newBarbarianLevels);
        }

        static void updateThickLizardQueen()

        {


            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var druidClass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            var lizard_queen = library.Get<BlueprintUnit>("98efa959deae59a46b3007aca1621052");
            var tar_pool = library.Get<BlueprintAbility>("7d700cdf260d36e48bb7af3a8ca5031f");
            var healcast = library.Get<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");



            var druidLevels = lizard_queen.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = druidLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            newAddClassLevels.Levels = 17;
            lizard_queen.ReplaceComponent(druidLevels, newAddClassLevels);


            var druidLevels2 = lizard_queen.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == druidClass);
            var newAddClassLevels2 = druidLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(tar_pool, healcast);
            newAddClassLevels2.MemorizeSpells = spell_list;
            lizard_queen.ReplaceComponent(druidLevels2, newAddClassLevels2);

            var druidLevels3 = lizard_queen.ComponentsArray
                 .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == druidClass);
            lizard_queen.AddFacts = new Kingmaker.Blueprints.Facts.BlueprintUnitFact[] {
                                                                                          library.Get<BlueprintBuff>("fd28ca0fc5461d240a4ddd0c15e81d65") }; // Vordakais Fear



            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("68cec7b669a739a4081a92145b73f224", "TarPoolAiAction", "");
            var ai_action_three = library.CopyAndAdd<BlueprintAiCastSpell>("f14f57a76b28de34bba9ad13bdf25ef6", "KnurlyWitchHealAiAction", "");
            var brain = lizard_queen.Brain;
            brain.Actions = brain.Actions.AddToArray(ai_action, ai_action_three); 


            {
                //TODO
            };



        }

        static void updateInsaneWizard()

        {


            var wizardclass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var tsunamni = library.Get<BlueprintAbility>("d8144161e352ca846a73cf90e85bf9ac");
            var insane_wizard = library.Get<BlueprintUnit>("426bdee2866ab3f409ea2d6196d2c101");
            var sm8 = library.Get<BlueprintAbility>("ab167fd8203c1314bac6568932f1752f");


            var add_class_levels = insane_wizard.GetComponent<AddClassLevels>();

            var spell_list = add_class_levels.MemorizeSpells.RemoveFromArray(sm8); //this removes the spell


            spell_list = spell_list.AddToArray(new BlueprintAbility[] // this adds the new spell
                                                    {
                                                                            tsunamni
                                                    }
                               );

            add_class_levels.MemorizeSpells = spell_list; //this puts them both together and adds it to the units spell list


           insane_wizard.ReplaceComponent<AddClassLevels>(a =>
            {
                a.Levels = 20;

            });// This increases there levels. I think it has to come AFTER the spell stuff, otherwise it doesnt load it.


            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("349e589adc1e7974988f769af68a8123", "WrigglingManTsunamiAiAction", "");
            var brain = insane_wizard.Brain;
            brain.Actions = brain.Actions.AddToArray(ai_action,AiActions.displacement_first);




        }

        static void updateEvilDruid()

        {

            var fire_storm = library.Get<BlueprintAbility>("e3d0dfe1c8527934294f241e0ae96a8d");
            var tsunami = library.Get<BlueprintAbility>("d8144161e352ca846a73cf90e85bf9ac");
            var plaguestorm = library.Get<BlueprintAbility>("82a5b848c05e3f342b893dedb1f9b446");
            var summon_worm = library.Get<BlueprintAbility>("954f1469ed62843409783c9fa7472998");
            // var thorn_body = library.Get<BlueprintAbility>("2daf9c5112f16d54ab3cd6904c705c59");
            // var cape_wasps = library.Get<BlueprintAbility>("e418c20c8ce362943a8025d82c865c1c");
            var druidclass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
          //  var clericclass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var evil_druid = library.Get<BlueprintUnit>("ca694cea2d423ec4f9dfb52187017ef4");
          //  var evil_druid_brain = library.Get<BlueprintBrain>("9d6113642d42ed44a931618e45922472");
         //   var wild_shape_ai = library.Get<BlueprintAiCastSpell>("2355064eee71aa0469cd0fbf6f3c7a98");
          //  var thorn_body_ai = library.Get<BlueprintAiCastSpell>("23c9ffbe648e18542920660b69f429cb");
            //var attack_ai = library.Get<BlueprintAiCastSpell>("866ffa6c34000cd4a86fb1671f86c7d8");

            evil_druid.Wisdom = 26;



            //var brainremove = evil_druid.Brain;
             //brainremove.Actions = brainremove.Actions.RemoveFromArray(wild_shape_ai);

            //var brainremove2 = evil_druid.Brain;
            //brainremove2.Actions = brainremove2.Actions.RemoveFromArray(thorn_body_ai);

            // var brainremove3 = evil_druid.Brain;
            //brainremove3.Actions = brainremove3.Actions.RemoveFromArray(attack_ai);


            //var add_class_levels = evil_druid.GetComponent<AddClassLevels>();

            //var ability_list = add_class_levels.MemorizeSpells.RemoveFromArray(thorn_body);

            // add_class_levels.MemorizeSpells = ability_list;

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
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(fire_storm, plaguestorm,tsunami,summon_worm);
            newAddClassLevels2.MemorizeSpells = spell_list;
            evil_druid.ReplaceComponent(druidLevels2, newAddClassLevels2);



            //  var druidLevels3 = evil_druid.ComponentsArray
            //  .OfType<AddClassLevels>()
            //   .First(c => c.CharacterClass == druidclass);
            //  evil_druid.AddFacts = new Kingmaker.Blueprints.Facts.BlueprintUnitFact[] {
            //                                                                          library.Get<BlueprintBuff>("fd28ca0fc5461d240a4ddd0c15e81d65") }; // Vordakais Fear



            //var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("3e430588863f8b24fa7e05fdc2d92441", "FireStormAiAction", "");
           // var ai_action_three = library.CopyAndAdd<BlueprintAiCastSpell>("e571595ce30b691468fd56aa6796e407", "PlagueStormAiAction	", "");
           // var brain3 = evil_druid.Brain;
            //brain3.Actions = brain3.Actions.AddToArray(ai_action, ai_action_three, AiActions.cape_of_wasps_cast_first);

            var defaced_sister_brain = library.Get<BlueprintBrain>("6fbe3c1065a223f42857acee47543a60");

            var new_actions = defaced_sister_brain.Actions;

            evil_druid.Brain.Actions = new_actions;


            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("56fd246b71b8e864e888b66aeec9fb96", "C61_NyrissaTsunamiAiAction", "");
            var brain = evil_druid.Brain;
            brain.Actions = brain.Actions.AddToArray(ai_action,AiActions.summon_worm_first);

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
