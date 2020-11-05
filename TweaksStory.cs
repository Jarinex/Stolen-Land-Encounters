using CallOfTheWild;
using dnlib.DotNet;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Experience;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.Items;
using Kingmaker.Blueprints.Items.Shields;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Controllers.Brain.Blueprints;
using Kingmaker.Controllers.Brain.Blueprints.Considerations;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
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

        static Consideration ArcaneCasterPriorityConsiderationVordakai = library.Get<TargetClassConsideration>("fddbc4306c4d47640bb7ea482fab7b46");
        static CommandCooldownConsideration swift_action_available = library.Get<CommandCooldownConsideration>("c2b7d2f9a5cb8d04d9e1aa4bf3d3c598");
        static Consideration AOE_ChooseMoreEnemies = library.Get<UnitsAroundConsideration>("b2490b137b8b53a4e950c1d79d1c5c1d");
        static Consideration units_around = library.Get<UnitsThreateningConsideration>("ee3f6b33227c2f847acda914e90f25af");
        static Consideration attacktargetspriority = library.Get<ComplexConsideration>("7a2b25dcc09cd244db261ce0a70cca84");
        static Consideration SupporCasterFocusConsideration = library.Get<TargetClassConsideration>("60bfe8583de6d3f45818c641b459386e");
        static Consideration ChaoticBehavior = library.Get<RandomConsideration>("aad346ba597e8aa45bb4b589d9f9d0ea");
        static Consideration NoBuffDisplacement = library.Get<BuffConsideration>("6d0ad23e4e010bd41bd1dffa5dabf23d");
        static Consideration NoBuffBlur = library.Get<BuffConsideration>("8a629688cbc97c142a5e7a41794c12c4");
        static Consideration AlliesNoBuff_Haste = library.Get<BuffsAroundConsideration>("8d02fafb7d3ed7744bb78cde35285e5d");
        static Consideration NoBuffSlow = library.Get<BuffConsideration>("5dfd84e3c5099c6409d46968c93b318b");
        static Consideration NoBuffShield = library.Get<BuffConsideration>("905abbae3815c5945a216d80d282ef15");
        static Consideration AlliesNoBuff_Stoneskin = library.Get<BuffsAroundConsideration>("3b380952d267ae3498e93f41657f9450");
        static Consideration TargetSelf = library.Get<TargetSelfConsideration>("83e2dd97b82d769498394c3edf0d260e");
        static Consideration AoE_AvoidFriends = library.Get<UnitsAroundConsideration>("8e6f34026b34c3d4ba831bb94548904a");
        static Consideration NoBuffHideousLaughter = library.Get<BuffConsideration>("cda52cd9004adb3429956e82734781f7");
        static Consideration IntGreaterThan2 = library.Get<StatConsideration>("9fe91dc89e64fe3488786d98dbe1814d");
        static Consideration NoBuffHurricaneBow = library.Get<BuffConsideration>("55bebe3428e9e6648878a8645c9f0248");
        static Consideration NoBuffBarkskin = library.Get<BuffConsideration>("3330505fd47bc3e4bbaf1bf7a5542dfa");
        static Consideration HealSpellConsideration = library.Get<HealthConsideration>("fc1512ca56ce08e49aa257e32c6365d4");
        static Consideration EnemiesNoDebuff_Prayer = library.Get<BuffsAroundConsideration>("18705e45d8cdea746aa0ef47a40b58e6");
        static Consideration AlliesNoBuff_Prayer = library.Get<BuffsAroundConsideration>("def28ea7f64241844b0a0dbccc1c4348");
        static Consideration AlliesNoBuff_Bless = library.Get<BuffsAroundConsideration>("1ae4bc050c1a0844ca356d9013e3ecb8");
        static Consideration NoBuff_DivineFavor = library.Get<BuffConsideration>("dd92328b39caaab40b48c0a26af16c08");
        static Consideration AlliesNoBuff_Heroism = library.Get<BuffsAroundConsideration>("cc9beda0bfe77424bbd02f6e8007a53b");
        static Consideration NoBuffMageArmor = library.Get<BuffConsideration>("053312e626b5b3d42ba4126d518a9d3a");
        static Consideration ArcaneCasterFocusConsiderationVordakai = library.Get<TargetClassConsideration>("a10afa800940a9143bda381d487fcd5c");
        static Consideration IgnoreControlledConsiderationVordakai = library.Get<ComplexConsideration>("081277d57cd22f946a518bd61707bc7f");
        static Consideration AlliesNoBuff_ResistFire = library.Get<BuffsAroundConsideration>("647d5f83acd33414a9eef9281b032e56");
        static Consideration LongRange = library.Get<DistanceConsideration>("37226cf3dc2948343b92f04b5992653a");
        static Consideration AlliesNoBuff_ProtectionFromFire = library.Get<BuffsAroundConsideration>("49a17f72e9984d44d8c9f905a9aaa1d5");
        static Consideration NoBuffShieldBuff = library.Get<BuffConsideration>("a3ffff7b93017744ea88433311569cec");
        static Consideration NoDisarmBuff = library.Get<BuffConsideration>("48d96793fce780144bf12bcb9a2b62a4");
        static Consideration NoBuffStaggered = library.Get<BuffConsideration>("1089841cc5fba29419540cca51e0919c");
        static Consideration NotUndead = library.Get<FactConsideration>("15d3f3497bda0d042a1cf5fe3b1af942");
        static Consideration NoBuffVampiricTouch = library.Get<BuffConsideration>("49c1e6eb9d095bf4e8b29185d5bf2d95");
        static Consideration AlliesNoBuff_CatsGrace = library.Get<BuffsAroundConsideration>("c351d1cf6693233448931abef192540c");
        static Consideration SwiftAction = library.Get<ComplexConsideration>("f335c9d35bc608648af2ca45ef2e096c");
        static Consideration StandardActionOffCooldown = library.Get<CommandCooldownConsideration>("a82d061edd18ce748a1a7f97e7e6d9d2");




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
            public static BlueprintAbility holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            public static BlueprintAbility summonelementalmedium = library.Get<BlueprintAbility>("e42b1dbff4262c6469a9ff0a6ce730e3");
            public static BlueprintAbility summonelementalmediumearth = library.Get<BlueprintAbility>("4ed414d36753459499578c9c3eb38b17");
            public static BlueprintAbility stonecall = library.Get<BlueprintAbility>("5181c2ed0190fc34b8a1162783af5bf4");
            public static BlueprintAbility calllightning = library.Get<BlueprintAbility>("2a9ef0e0b5822a24d88b16673a267456");
            public static BlueprintAbility stonefist = library.Get<BlueprintAbility>("85067a04a97416949b5d1dbf986d93f3");
            public static BlueprintAbility summonmonsterIII = library.Get<BlueprintAbility>("5d61dde0020bbf54ba1521f7ca0229dc");
            public static BlueprintAbility summonmonsterIIIsingle = library.Get<BlueprintAbility>("15b5efe371d47c944b58444e7b734ffb");
            public static BlueprintAbility summonmonsterIIId3 = library.Get<BlueprintAbility>("28f49845fad6a534b95a65b6cea8f8d6");
            public static BlueprintAbility blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            public static BlueprintAbility acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            public static BlueprintAbility magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            public static BlueprintAbility summonclerics = library.Get<BlueprintAbility>("5a1c766d3a5948bf98001e417e76ef0d");
            public static BlueprintAbility horrid_wilting = library.Get<BlueprintAbility>("08323922485f7e246acb3d2276515526");
            public static BlueprintAbility leadblades = library.Get<BlueprintAbility>("779179912e6c6fe458fa4cfb90d96e10");
            public static BlueprintAbility thundercall = library.Get<BlueprintAbility>("584427c2d3d3c5d45a169b82431612bc");
            public static BlueprintAbility earpiercescream = library.Get<BlueprintAbility>("8e7cfa5f213a90549aadd18f8f6f4664");
            public static BlueprintAbility summoncyclops = library.Get<BlueprintAbility>("4089fb0f36bb4ca2a459a4420279ff87");
            public static BlueprintAbility blindbomb = library.Get<BlueprintAbility>("bd05918a568c41e49aed7b9526ba596b");
            public static BlueprintAbility haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            public static BlueprintAbility slow = library.Get<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
            public static BlueprintAbility stinkycloud = library.Get<BlueprintAbility>("68a9e6d7256f1354289a39003a46d826");
            public static BlueprintAbility trip = library.Get<BlueprintAbility>("6fd05c4ecfebd6f4d873325de442fc17");
            public static BlueprintAbility chainlightning = library.Get<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58");
            public static BlueprintAbility magicmissleswift = library.Get<BlueprintAbility>("e4fc6161735811f44b6ee8b2043fc086");
            public static BlueprintAbility summonmonsterVI = library.Get<BlueprintAbility>("e740afbab0147944dab35d83faa0ae1c");
            public static BlueprintAbility summonmonsterVId3 = library.Get<BlueprintAbility>("237d76aebbb28334e95d83475611cb47");
            public static BlueprintAbility dragonsbreath = library.Get<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");
            public static BlueprintAbility dragonsbreathblue = library.Get<BlueprintAbility>("2809e762f83cbdb47b2f8b7816cc2a34");
            public static BlueprintAbility dragonsbreathsilver = library.Get<BlueprintAbility>("45e0813484581514fbfcf49939ee050d");
            public static BlueprintAbility dragonsbreathgreen = library.Get<BlueprintAbility>("48c4433acbcecae499d1d38a56f72f36");
            public static BlueprintAbility icestorm = library.Get<BlueprintAbility>("fcb028205a71ee64d98175ff39a0abf9");
            public static BlueprintAbility stoneskincommunal = library.Get<BlueprintAbility>("7c5d556b9a5883048bf030e20daebe31");
            public static BlueprintAbility lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");
            public static BlueprintAbility hideouslaughter = library.Get<BlueprintAbility>("fd4d9fd7f87575d47aafe2a64a6e2d8d");
            public static BlueprintAbility barkskin = library.Get<BlueprintAbility>("5b77d7cc65b8ab74688e74a37fc2f553");
            public static BlueprintAbility hurricanebow = library.Get<BlueprintAbility>("3e9d1119d43d07c4c8ba9ebfd1671952");
            public static BlueprintAbility summonelementalgreat = library.Get<BlueprintAbility>("8eb769e3b583f594faabe1cfdb0bb696");
            public static BlueprintAbility summonelementalgreatearth = library.Get<BlueprintAbility>("3ecd589cf1a55df42a3b66940ee93ea4");
            public static BlueprintAbility coldicestrike = library.Get<BlueprintAbility>("5ef85d426783a5347b420546f91a677b");
            public static BlueprintAbility heal = library.Get<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");
            public static BlueprintAbility bladebarrier = library.Get<BlueprintAbility>("36c8971e91f1745418cc3ffdfac17b74");
            public static BlueprintAbility righteousmight = library.Get<BlueprintAbility>("90810e5cf53bf854293cbd5ea1066252");
            public static BlueprintAbility flamestrike = library.Get<BlueprintAbility>("f9910c76efc34af41b6e43d5d8752f0f");
            public static BlueprintAbility summonmonsterII = library.Get<BlueprintAbility>("1724061e89c667045a6891179ee2e8e7");
            public static BlueprintAbility summonmonsterIIsingle = library.Get<BlueprintAbility>("7ab27a0d547742741beb5d089f1c3852");
            public static BlueprintAbility bless = library.Get<BlueprintAbility>("90e59f4a4ada87243b7b3535a06d0638");
            public static BlueprintAbility divinefavor = library.Get<BlueprintAbility>("9d5d2d3ffdd73c648af3eb3e585b1113");
            public static BlueprintAbility summonelementalsmall = library.Get<BlueprintAbility>("970c6db48ff0c6f43afc9dbb48780d03");
            public static BlueprintAbility summonelementalsmallearth = library.Get<BlueprintAbility>("69b36426bb910e341a943f101daed594");
            public static BlueprintAbility earthaciddart = library.Get<BlueprintAbility>("3ff40918d33219942929f0dbfe5d1dee");
            public static BlueprintAbility shout = library.Get<BlueprintAbility>("f09453607e683784c8fca646eec49162");
            public static BlueprintAbility cursedbombdeterioration = library.Get<BlueprintAbility>("3ac7286a18ba6234a908ae5d8b84d107");
            public static BlueprintAbility acidbomb = library.Get<BlueprintAbility>("fd101fbc4aacf5d48b76a65e3aa5db6d");
            public static BlueprintAbility heroism = library.Get<BlueprintAbility>("5ab0d42fb68c9e34abae4921822b9d63");
            public static BlueprintAbility magearmor = library.Get<BlueprintAbility>("9e1ad5d6f87d19e4d8883d63a6e35568");
            public static BlueprintAbility fingerofdeath = library.Get<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe");
            public static BlueprintAbility inflictmoderatewoundmass = library.Get<BlueprintAbility>("03944622fbe04824684ec29ff2cec6a7");
            public static BlueprintAbility DarknessDomainGreaterAbility = library.Get<BlueprintAbility>("31acd268039966940872c916782ae018");
            public static BlueprintAbility Resistenergycommunal = library.Get<BlueprintAbility>("7bb0c402f7f789d4d9fae8ca87b4c7e2");
            public static BlueprintAbility ResistFirecommunal = library.Get<BlueprintAbility>("832bf98966e72cd478eecc9f8ba829f5");
            public static BlueprintAbility boneshaker = library.Get<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
            public static BlueprintAbility bullsmass = library.Get<BlueprintAbility>("6a234c6dcde7ae94e94e9c36fd1163a7");
            public static BlueprintAbility protectionfromenergycommunal = library.Get<BlueprintAbility>("76a629d019275b94184a1a8733cac45e");
            public static BlueprintAbility protectionfromfirecommunal = library.Get<BlueprintAbility>("2903d31d6c8356547aa4aae5a3e7a655");
            public static BlueprintAbility firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
            public static BlueprintAbility controlledfireball = library.Get<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");
            public static BlueprintAbility shield = library.Get<BlueprintAbility>("ef768022b0785eb43a18969903c537c4");
            public static BlueprintAbility bullrushability = library.Get<BlueprintAbility>("7ab6f70c996fe9b4597b8332f0a3af5f");
            public static BlueprintAbility chargeability = library.Get<BlueprintAbility>("c78506dd0e14f7c45a599990e4e65038");
            public static BlueprintAbility scorchingray = library.Get<BlueprintAbility>("cdb106d53c65bbc4086183d54c3b97c7");
            public static BlueprintAbility disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            public static BlueprintAbility terrifyinghowl = library.Get<BlueprintAbility>("50fab1245a4342eaa1c82c8e81f883e3");
            public static BlueprintAbility terrifyingcroak = library.Get<BlueprintAbility>("d7ab3a110325b174e90ae6c7b4e96bb9");
            public static BlueprintAbility command = library.Get<BlueprintAbility>("ee88e59d9ecb40df851a5498d03d79f6");
            public static BlueprintAbility command1 = library.Get<BlueprintAbility>("08439ce8a0674a3fbc3a158255d761a8");
            public static BlueprintAbility frigidtouch = library.Get<BlueprintAbility>("b6010dda6333bcf4093ce20f0063cd41");
            public static BlueprintAbility vampirictouch = library.Get<BlueprintAbility>("8a28a811ca5d20d49a863e832c31cce1");
            public static BlueprintAbility phantasmalkiller = library.Get<BlueprintAbility>("6717dbaef00c0eb4897a1c908a75dfe5");
            public static BlueprintAbility catsgrace = library.Get<BlueprintAbility>("de7a025d48ad5da4991e7d3c682cf69d");
            public static BlueprintAbility shockinggrasp = library.Get<BlueprintAbility>("ab395d2335d3f384e99dddee8562978f");
            public static BlueprintAbility dimensionstrike = library.Get<BlueprintAbility>("cf7c4eaa2b47d7242b2c734df567cefb");
            public static BlueprintAbility volcanicstorm = library.Get<BlueprintAbility>("16ce660837fb2544e96c3b7eaad73c63");
            public static BlueprintAbility snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            public static BlueprintAbility flurryofsnowballs = library.Get<BlueprintAbility>("390e16e9595f4e4696ca90d18b803092");
            public static BlueprintAbility poxpostules = library.Get<BlueprintAbility>("bc153808ef4884a4594bc9bec2299b69");
            public static BlueprintAbility burstofnettles = library.Get<BlueprintAbility>("af0092cbb9cacd74aadfe6bf4ebcdebf");
            public static BlueprintActivatableAbility DebilitatingInjuryDisorientedAbility = library.Get<BlueprintActivatableAbility>("dda92ebaf6a03f84387f7104fd597c2e");
            public static BlueprintAbility dirtytrickblindness = library.Get<BlueprintAbility>("8b7364193036a8d4a80308fbe16c8187");
            public static BlueprintAbility summonghosts = library.Get<BlueprintAbility>("a8ba7017d97345969db2567eb7c249b7");
            
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
                                                                                     new Consideration[] {  },
                                                                                     new Consideration[] { NoBuffDisplacement },
                                                                                     base_score: 10.0f, combat_count: 4);
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
            base_score: 10.0f, cooldown_rounds: 3);

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
             new Consideration[] {SupporCasterFocusConsideration},
             base_score: 20.0f, combat_count: 2, cooldown_rounds: 2);

            static public BlueprintAiCastSpell holdpersontartuk = createCastSpellAction("Castholdpersontartuk", Spells.holdperson,
                    new Consideration[] { },
                    new Consideration[] { attacktargetspriority, ChaoticBehavior },
                    base_score: 3.0f, combat_count: 2, cooldown_rounds: 3, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell summonelementalmediumearth = createCastSpellAction("CastSummonelementalmedium", Spells.summonelementalmedium,
                new Consideration[] { },
                new Consideration[] { },
                base_score: 20.0f, variant: Spells.summonelementalmediumearth, combat_count: 1);

            static public BlueprintAiCastSpell stonecall = createCastSpellAction("Caststonecall", Spells.stonecall,
                 new Consideration[] { },
                 new Consideration[] { AOE_ChooseMoreEnemies },
                 base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell calllightningthirdturn = createCastSpellAction("calllightningthirdturn", Spells.calllightning,
                 new Consideration[] { },
                 new Consideration[] { attacktargetspriority},
                base_score: 3.0f, combat_count: 2, cooldown_rounds: 1, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell stonefist = createCastSpellAction("Caststonefist", Spells.stonefist,
                    new Consideration[] { },
                    new Consideration[] { AOE_ChooseMoreEnemies },
                    base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell summonmonsterIIIsingle = createCastSpellAction("CastsummonmonsterIII", Spells.summonmonsterIII,
                    new Consideration[] { },
                    new Consideration[] { },
                    base_score: 20.0f, variant: Spells.summonmonsterIIIsingle, combat_count: 1);

            static public BlueprintAiCastSpell blur_first = createCastSpellAction("CastBlurBuff", Spells.blur,
                              new Consideration[] { NoBuffBlur },
                              new Consideration[] { },
                              base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell acidarrowdelay = createCastSpellAction("Castacidarrowdelay", Spells.acidarrow,
                   new Consideration[] { },
                  new Consideration[] { attacktargetspriority },
                 base_score: 3.0f, cooldown_rounds: 1, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell magicmissledelay = createCastSpellAction("Castmagicmissledelay", Spells.magicmissle,
                 new Consideration[] { },
                 new Consideration[] { attacktargetspriority },
                 base_score: 3.0f, cooldown_rounds: 1, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell summonclerics = createCastSpellAction("CastSummonClerics", Spells.summonclerics,
                new Consideration[] { },
                new Consideration[] { },
                base_score: 20.0f, combat_count: 1, cooldown_rounds: 500);


            static public BlueprintAiCastSpell horridwilting = createCastSpellAction("CastHorridWilting", Spells.horrid_wilting,
                     new Consideration[] { },
                     new Consideration[] { },
                  base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell leadblades = createCastSpellAction("CastLeadBlades", Spells.leadblades,
                     new Consideration[] { },
                     new Consideration[] { },
                  base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell nothundercall = createCastSpellAction("NoCastThundercall", Spells.thundercall,
              new Consideration[] { },
              new Consideration[] { },
            base_score: 20.0f, combat_count: 1, cooldown_rounds: 500);

            static public BlueprintAiCastSpell earpierce = createCastSpellAction("castearpierce", Spells.earpiercescream,
            new Consideration[] { },
             new Consideration[] { attacktargetspriority },
            base_score: 20.0f, combat_count: 4, start_cooldown_rounds: 1);

            static public BlueprintAiCastSpell summoncyclops = createCastSpellAction("Castsummoncyclops", Spells.summoncyclops,
            new Consideration[] { },
            new Consideration[] { },
            base_score: 20.0f, combat_count: 2, cooldown_rounds: 12);

            static public BlueprintAiCastSpell throwblindbomb = createCastSpellAction("throwblindbomb", Spells.blindbomb,
            new Consideration[] { },
             new Consideration[] { AOE_ChooseMoreEnemies },
            base_score: 20.0f, combat_count: 2, cooldown_rounds: 4, start_cooldown_rounds: 1);

            static public BlueprintAiCastSpell casthaste = createCastSpellAction("casthaste", Spells.haste,
            new Consideration[] { },
            new Consideration[] { AlliesNoBuff_Haste },
            base_score: 20.0f, combat_count: 2, cooldown_rounds: 2);

            static public BlueprintAiCastSpell castslow = createCastSpellAction("castslow", Spells.slow,
                new Consideration[] { },
                new Consideration[] { attacktargetspriority, NoBuffSlow },
            base_score: 20.0f, combat_count: 2, cooldown_rounds: 3);

            static public BlueprintAiCastSpell caststinkycloud = createCastSpellAction("caststinkycloud", Spells.stinkycloud,
             new Consideration[] { },
             new Consideration[] { attacktargetspriority },
            base_score: 20.0f, combat_count: 1, start_cooldown_rounds: 1);

            static public BlueprintAiCastSpell trip = createCastSpellAction("Usetrip", Spells.trip,
            new Consideration[] {  },
            new Consideration[] { attacktargetspriority },
            base_score: 10.0f, combat_count: 2, cooldown_rounds: 3);

            static public BlueprintAiCastSpell chainlightning = createCastSpellAction("castchainlightning", Spells.chainlightning,
                new Consideration[] { },
                new Consideration[] { attacktargetspriority},
                base_score: 20.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell magicmissleswift = createCastSpellAction("castmagicmissleswift", Spells.magicmissleswift,
                new Consideration[] { },
               new Consideration[] { attacktargetspriority, NoBuffShield },
            base_score: 20.0f, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell summonmonsterVI = createCastSpellAction("CastSummonMonsterVI", Spells.summonmonsterVI,
            new Consideration[] { },
            new Consideration[] { },
            base_score: 20.0f, variant: Spells.summonmonsterVId3, combat_count: 1);

            static public BlueprintAiCastSpell dragonsbreath = createCastSpellAction("Castdragonsbreathblue", Spells.dragonsbreath,
                new Consideration[] { },
                new Consideration[] { },
            base_score: 20.0f, variant: Spells.dragonsbreathblue, combat_count: 2, cooldown_rounds: 3);

            static public BlueprintAiCastSpell icestorm = createCastSpellAction("casticestorm", Spells.icestorm,
                 new Consideration[] { },
                 new Consideration[] { attacktargetspriority },
            base_score: 20.0f, combat_count: 1 );

            static public BlueprintAiCastSpell stoneskincommunal = createCastSpellAction("caststoneskincommunal", Spells.stoneskincommunal,
                 new Consideration[] { },
                 new Consideration[] { AlliesNoBuff_Stoneskin, TargetSelf },
                base_score: 20.0f, combat_count: 1, start_cooldown_rounds: 1);

            static public BlueprintAiCastSpell trueseeing = createCastSpellAction("CastTrueSeeing", Spells.trueseeing,
            new Consideration[] {  },
            new Consideration[] { attacktargetspriority },
            base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell dragonsbreathsilver = createCastSpellAction("Castdragonsbreathsilver", Spells.dragonsbreath,
            new Consideration[] { },
            new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
            base_score: 20.0f, variant: Spells.dragonsbreathsilver, combat_count: 2, cooldown_rounds: 2, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell lightningboltfourturns = createCastSpellAction("castlightningbolt", Spells.lightningbolt,
                 new Consideration[] { },
                 new Consideration[] { attacktargetspriority, AoE_AvoidFriends },
            base_score: 3.0f, combat_count: 3, cooldown_rounds: 1, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell acidarrownixie = createCastSpellAction("Castacidarrownixie", Spells.acidarrow,
             new Consideration[] { },
                 new Consideration[] { attacktargetspriority },
             base_score: 3.0f, cooldown_rounds: 1);

            static public BlueprintAiCastSpell hideouslaughternixie = createCastSpellAction("Casthideouslaughternixie", Spells.hideouslaughter,
             new Consideration[] { },
             new Consideration[] { attacktargetspriority,NoBuffHideousLaughter,IntGreaterThan2 },
             base_score: 3.0f, cooldown_rounds: 2);

            static public BlueprintAiCastSpell barkskingoblinking = createCastSpellAction("Castbarkskin", Spells.barkskin,
            new Consideration[] {NoBuffBarkskin},
            new Consideration[] { },
             base_score: 3.0f, start_cooldown_rounds: 2);
            static public BlueprintAiCastSpell hurricanebowgoblinking = createCastSpellAction("Casthurricanebow", Spells.hurricanebow,
            new Consideration[] { NoBuffHurricaneBow},
                new Consideration[] {  },
            base_score: 3.0f, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell summonelementalgreatearth = createCastSpellAction("CastSummonelementalgreat", Spells.summonelementalgreat,
                new Consideration[] { },
                new Consideration[] { },
             base_score: 20.0f, variant: Spells.summonelementalgreatearth, combat_count: 1, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell coldicestrike = createCastSpellAction("Castcoldicestrike", Spells.coldicestrike,
            new Consideration[] { },
                new Consideration[] { },
            base_score: 20.0f, cooldown_rounds: 3, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell healspell = createCastSpellAction("Casthealspell", Spells.heal,
         new Consideration[] { },
         new Consideration[] { TargetSelf, HealSpellConsideration },
         base_score: 20.0f, cooldown_rounds: 3);

            static public BlueprintAiCastSpell righteousmightgoblinshaman = createCastSpellAction("Castrighteousmightgoblinshaman", Spells.righteousmight,
                 new Consideration[] { },
                 new Consideration[] { },
                 base_score: 20.0f, combat_count: 1, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell bladebarriergoblinshaman = createCastSpellAction("Castbladebarriergoblinshaman", Spells.bladebarrier,
                new Consideration[] { },
                 new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
            base_score: 20.0f, combat_count: 1);
            static public BlueprintAiCastSpell prayergoblinshaman = createCastSpellAction("Castprayergoblinshaman", Spells.prayer,
                                   new Consideration[] { },
                                   new Consideration[] { AlliesNoBuff_Prayer,EnemiesNoDebuff_Prayer},
                     base_score: 10.0f, combat_count: 2);

            static public BlueprintAiCastSpell flamestrikegoblinshaman = createCastSpellAction("Castflamestrikegoblinshaman", Spells.flamestrike,
                       new Consideration[] { },
                       new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
         base_score: 10.0f, combat_count: 2, cooldown_rounds: 2);

            static public BlueprintAiCastSpell hideouslaughterbanditbard = createCastSpellAction("Casthideouslaughterbanditbard", Spells.hideouslaughter,
             new Consideration[] { },
             new Consideration[] { attacktargetspriority, NoBuffHideousLaughter, IntGreaterThan2 },
             base_score: 3.0f, combat_count: 2, cooldown_rounds: 2);

            static public BlueprintAiCastSpell summonmonsterII = createCastSpellAction("CastsummonmonsterII", Spells.summonmonsterII,
        new Consideration[] { },
        new Consideration[] { },
        base_score: 20.0f, variant: Spells.summonmonsterIIsingle, combat_count: 1);

            static public BlueprintAiCastSpell blesscast = createCastSpellAction("Castbless", Spells.bless,
new Consideration[] { },
new Consideration[] { AlliesNoBuff_Bless },
base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell divinefavor = createCastSpellAction("Castdivinefavor", Spells.divinefavor,
new Consideration[] { NoBuff_DivineFavor },
new Consideration[] {  },
base_score: 20.0f,  combat_count: 1);

            static public BlueprintAiCastSpell holdpersondelay = createCastSpellAction("Castholdpersondelay", Spells.holdperson,
        new Consideration[] { },
        new Consideration[] { attacktargetspriority },
        base_score: 3.0f, combat_count: 2, cooldown_rounds: 1);

           static public BlueprintAiCastSpell blurcast = createCastSpellAction("Castblur", Spells.blur,
             new Consideration[] { NoBuffBlur },
             new Consideration[] { },
          base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell summonmonsterIIId3 = createCastSpellAction("CastsummonmonsterIIId3", Spells.summonmonsterIII,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f, variant: Spells.summonmonsterIIId3, combat_count: 1);

            static public BlueprintAiCastSpell summonelementalsmallearth = createCastSpellAction("CastSummonelementalsmall", Spells.summonelementalsmall,
    new Consideration[] { },
    new Consideration[] { },
 base_score: 20.0f, variant: Spells.summonelementalsmallearth, combat_count: 1);

            static public BlueprintAiCastSpell holdpersondsineshal = createCastSpellAction("Castholdpersondsineshal", Spells.holdperson,
            new Consideration[] { },
            new Consideration[] { attacktargetspriority },
            base_score: 3.0f, combat_count: 1, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell earthaciddart = createCastSpellAction("Castearthaciddart", Spells.earthaciddart,
           new Consideration[] { },
            new Consideration[] { },
            base_score: 3.0f,  start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell earthaciddartearlier = createCastSpellAction("Castearthaciddartearlier", Spells.earthaciddart,
            new Consideration[] { },
            new Consideration[] { },
            base_score: 3.0f, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castshout = createCastSpellAction("Castshout", Spells.shout,
            new Consideration[] { },
            new Consideration[] {AoE_AvoidFriends },
            base_score: 3.0f, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell throwcursedbombdeter = createCastSpellAction("throwcursedbombdeter", Spells.cursedbombdeterioration,
            new Consideration[] { },
            new Consideration[] { AOE_ChooseMoreEnemies, ChaoticBehavior },
            base_score: 20.0f, combat_count: 2, cooldown_rounds: 4, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell throwacidbomb = createCastSpellAction("throwacidbomb", Spells.acidbomb,
             new Consideration[] { },
             new Consideration[] { AOE_ChooseMoreEnemies, ChaoticBehavior },
            base_score: 20.0f, cooldown_rounds: 2, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castheroism = createCastSpellAction("castheroism", Spells.heroism,
            new Consideration[] { },
            new Consideration[] { AlliesNoBuff_Heroism,TargetSelf },
            base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell greaterdispelvordakai = createCastSpellAction("CastGreaterDispelvordakai", Spells.greaterdispel,
            new Consideration[] { },
            new Consideration[] { AOE_ChooseMoreEnemies },
            base_score: 19.0f, variant: Spells.greaterdispelarea, combat_count: 1);

            static public BlueprintAiCastSpell castslowvordakai = createCastSpellAction("castslowvordakai", Spells.slow,
            new Consideration[] { },
            new Consideration[] { attacktargetspriority, NoBuffSlow },
            base_score: 20.0f, cooldown_rounds: 3, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell horridwiltingvordakai = createCastSpellAction("CastHorridWiltingVordakai", Spells.horrid_wilting,
         new Consideration[] { },
         new Consideration[] { },
         base_score: 20.0f, combat_count: 1, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell castmagearmorvordakai = createCastSpellAction("Castmagearmorvordakai", Spells.magearmor,
            new Consideration[] { },
            new Consideration[] {NoBuffMageArmor },
            base_score: 20.0f, combat_count: 1, start_cooldown_rounds: 6);

            static public BlueprintAiCastSpell castfingerofdeathvordakai = createCastSpellAction("castfingerofdeathvordakai", Spells.fingerofdeath,
            new Consideration[] { },
            new Consideration[] { ArcaneCasterFocusConsiderationVordakai, IgnoreControlledConsiderationVordakai },
            base_score: 20.0f, combat_count: 3, start_cooldown_rounds: 5, cooldown_rounds: 2);

            static public BlueprintAiCastSpell displacementvordakai = createCastSpellAction("Castdisplacementvordakai", Spells.displacement,
                                                                         new Consideration[] { },
                                                                         new Consideration[] { NoBuffDisplacement, TargetSelf },
                                                                         base_score: 30.0f);

            static public BlueprintAiCastSpell inflictmoderatemass = createCastSpellAction("CastInflictmoderateWoundsMass", Spells.inflictmoderatewoundmass,
            new Consideration[] { },
            new Consideration[] { AOE_ChooseMoreEnemies },
             base_score: 20.0f, cooldown_rounds: 2);

            static public BlueprintAiCastSpell castmoonfire = createCastSpellAction("Castmoonfire", Spells.DarknessDomainGreaterAbility,
            new Consideration[] { },
            new Consideration[] {  },
            base_score: 20.0f, start_cooldown_rounds: 4, cooldown_rounds: 3);

            static public BlueprintAiCastSpell castresistfirecommunal = createCastSpellAction("Castresistfirecommunal", Spells.Resistenergycommunal,
            new Consideration[] { },
            new Consideration[] {AlliesNoBuff_ResistFire },
            base_score: 20.0f, variant: Spells.ResistFirecommunal);

            static public BlueprintAiCastSpell castboneshaker = createCastSpellAction("Castboneshaker", Spells.boneshaker,
                                                                         new Consideration[] { },
                                                                         new Consideration[] {LongRange },
                                                                         base_score: 10.0f, start_cooldown_rounds: 3, cooldown_rounds: 1);

            static public BlueprintAiCastSpell castbullsmass = createCastSpellAction("Castbullsmass", Spells.bullsmass,
                                                             new Consideration[] { },
                                                             new Consideration[] {  },
                                                             base_score: 20.0f, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell constrictingcoilszombie = createCastSpellAction("Castconstrictingcoilszombie", Spells.constrictingcoils,
        new Consideration[] { },
        new Consideration[] { SupporCasterFocusConsideration },
        base_score: 20.0f, combat_count: 2, cooldown_rounds: 2, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell protectionfromfirecommunal = createCastSpellAction("Castprotectionfromfirecommunal", Spells.protectionfromenergycommunal,
            new Consideration[] { },
            new Consideration[] { AlliesNoBuff_ProtectionFromFire },
            base_score: 30.0f, variant: Spells.protectionfromfirecommunal);

            static public BlueprintAiCastSpell castfingerofdeathastraldaemonguard = createCastSpellAction("castfingerofdeathastraldaemonguard", Spells.fingerofdeath,
    new Consideration[] { },
    new Consideration[] { attacktargetspriority },
    base_score: 20.0f,  cooldown_rounds: 5);

            static public BlueprintAiCastSpell dragonsbreathgreen = createCastSpellAction("Castdragonsbreathgreen", Spells.dragonsbreath,
    new Consideration[] { },
    new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
    base_score: 20.0f, variant: Spells.dragonsbreathgreen, combat_count: 2, cooldown_rounds: 2, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castfiresnake = createCastSpellAction("Castfiresnake", Spells.firesnake,
    new Consideration[] { },
    new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
    base_score: 20.0f, combat_count: 1 );

            static public BlueprintAiCastSpell stoneskincommunalsprig = createCastSpellAction("caststoneskincommunalsprig", Spells.stoneskincommunal,
     new Consideration[] { },
     new Consideration[] { AlliesNoBuff_Stoneskin },
    base_score: 30.0f, combat_count: 1);

            static public BlueprintAiCastSpell castcontrolledfireball = createCastSpellAction("castcontrolledfireball", Spells.controlledfireball,
    new Consideration[] { },
    new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
    base_score: 30.0f, combat_count: 2, cooldown_rounds: 3, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castmagearmorsprig = createCastSpellAction("castmagearmorsprig", Spells.magearmor,
    new Consideration[] { },
    new Consideration[] { NoBuffMageArmor,TargetSelf },
    base_score: 20.0f, combat_count: 1, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castshieldsprig = createCastSpellAction("castshieldsprig", Spells.shield,
    new Consideration[] { },
    new Consideration[] { NoBuffShieldBuff },
    base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell castslowsprig = createCastSpellAction("castslowsprig", Spells.slow,
    new Consideration[] { },
    new Consideration[] { attacktargetspriority, NoBuffSlow },
    base_score: 20.0f, combat_count: 2, cooldown_rounds: 3, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell cleavesprig = createCastSpellAction("UseCleavesprig", Spells.cleaveaction,
new Consideration[] { units_around },
new Consideration[] { attacktargetspriority },
base_score: 10.0f, cooldown_rounds: 2, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell bullrush = createCastSpellAction("Usebullrush", Spells.bullrushability,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 10.0f, combat_count: 2, cooldown_rounds: 3, start_cooldown_rounds: 1);

            static public BlueprintAiCastSpell charge = createCastSpellAction("Usecharge", Spells.chargeability,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell scorchingraydelay = createCastSpellAction("castscorchingraydelay", Spells.scorchingray,
                   new Consideration[] { },
                  new Consideration[] { attacktargetspriority },
                 base_score: 3.0f, cooldown_rounds: 1, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell usedisarm = createCastSpellAction("usedisarm", Spells.disarm,
                     new Consideration[] { },
                 new Consideration[] { attacktargetspriority, NoDisarmBuff },
                base_score: 20.0f, cooldown_rounds: 3, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell useterrifyinghowl = createCastSpellAction("useterrifyinghowl", Spells.terrifyinghowl,
            new Consideration[] { },
            new Consideration[] { attacktargetspriority},
            base_score: 40.0f);

            static public BlueprintAiCastSpell castcommand = createCastSpellAction("castcommand", Spells.command,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 40.0f, variant: Spells.command1, combat_count: 5);

            static public BlueprintAiCastSpell castfrigidtouch = createCastSpellAction("castfrigidtouch", Spells.frigidtouch,
new Consideration[] { },
new Consideration[] { attacktargetspriority, NoBuffStaggered },
base_score: 40.0f, cooldown_rounds: 2, combat_count: 4, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell castvampirictouch = createCastSpellAction("castvampirictouch", Spells.vampirictouch,
new Consideration[] { NoBuffVampiricTouch },
new Consideration[] { attacktargetspriority, NotUndead},
base_score: 40.0f, cooldown_rounds: 3, combat_count: 2, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell castphantasmalkiller = createCastSpellAction("castphantasmalkiller", Spells.phantasmalkiller,
new Consideration[] {  },
new Consideration[] { attacktargetspriority },
base_score: 40.0f, cooldown_rounds: 3, combat_count: 1, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell castcatsgrace = createCastSpellAction("Castcatsrace", Spells.catsgrace,
                                                 new Consideration[] { },
                                                 new Consideration[] { AlliesNoBuff_CatsGrace},
                                                 base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell mirrorimagecyclop = createCastSpellAction("Castmirrorimagecyclop", Spells.mirrorimage,
    new Consideration[] { },
    new Consideration[] { },
    base_score: 20.0f, combat_count: 1, start_cooldown_rounds: 12);

            static public BlueprintAiCastSpell castshockgrasp = createCastSpellAction("castshockgrasp", Spells.shockinggrasp,
            new Consideration[] { },
            new Consideration[] { attacktargetspriority },
            base_score: 40.0f, cooldown_rounds: 3, combat_count: 4, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell usedimensionstrike = createCastSpellAction("usedimensionstrike", Spells.dimensionstrike,
        new Consideration[] {StandardActionOffCooldown},
        new Consideration[] { attacktargetspriority },
        base_score: 40.0f, combat_count: 2, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell castcontrolledfireballsister = createCastSpellAction("castcontrolledfireballsister", Spells.controlledfireball,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 30.0f, combat_count: 1, cooldown_rounds: 3, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castvolcanicstorm = createCastSpellAction("castvolcanicstorm ", Spells.volcanicstorm,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 30.0f, combat_count: 1, cooldown_rounds: 3, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castgreaterdispellsister = createCastSpellAction("Castgreaterdispellsister", Spells.greaterdispel,
new Consideration[] { },
new Consideration[] { AOE_ChooseMoreEnemies },
base_score: 19.0f, variant: Spells.greaterdispelarea, combat_count: 1, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell castfiresnakesister = createCastSpellAction("Castfiresnakesister", Spells.firesnake,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 20.0f, combat_count: 2, cooldown_rounds: 3, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castflamestrikesister = createCastSpellAction("Castflamestrikesister", Spells.flamestrike,
           new Consideration[] { },
           new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
base_score: 10.0f, combat_count: 2, cooldown_rounds: 2, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell calllightningsister = createCastSpellAction("calllightningsister", Spells.calllightning,
     new Consideration[] { },
     new Consideration[] { attacktargetspriority },
    base_score: 3.0f, combat_count: 3, cooldown_rounds: 1, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell castsnowballsister = createCastSpellAction("castsnowballsister", Spells.snowball,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 3.0f, combat_count: 3, cooldown_rounds: 2);

            static public BlueprintAiCastSpell castburstofnettles = createCastSpellAction("castburstofnettles", Spells.burstofnettles,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 3.0f, combat_count: 3, cooldown_rounds: 1, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castflurryofsnowballs = createCastSpellAction("castflurryofsnowballs", Spells.flurryofsnowballs,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 3.0f, combat_count: 2, cooldown_rounds: 2, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castpoxpostules = createCastSpellAction("castpoxpostules", Spells.poxpostules,
new Consideration[] { },
new Consideration[] { attacktargetspriority, ArcaneCasterPriorityConsiderationVordakai },
base_score: 3.0f, combat_count: 2);

            static public BlueprintAiCastSpell righteousmightdugath = createCastSpellAction("Castrighteousmightdugath", Spells.righteousmight,
     new Consideration[] { },
     new Consideration[] { },
     base_score: 20.0f, combat_count: 1);


            static public BlueprintAiCastSpell usedirtytrickblind = createCastSpellAction("usedirtytrickblind", Spells.dirtytrickblindness,
            new Consideration[] { },
            new Consideration[] { },
            base_score: 20.0f, cooldown_rounds: 3, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell usesummonghosts = createCastSpellAction("usesummonghosts", Spells.summonghosts,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell usedisarmspectre = createCastSpellAction("usedisarmspectre", Spells.disarm,
         new Consideration[] { },
     new Consideration[] { attacktargetspriority, NoDisarmBuff },
    base_score: 20.0f, cooldown_rounds: 4, start_cooldown_rounds: 2);


        }





        static BlueprintAiCastSpell createCastSpellAction(string name, BlueprintAbility spell, Consideration[] actor_consideration, Consideration[] target_consideration,
                                                       float base_score = 1f, BlueprintAbility variant = null, int combat_count = 0, int cooldown_rounds = 0, int start_cooldown_rounds = 0, string guid = "")
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
            action.StartCooldownRounds = start_cooldown_rounds;
            library.AddAsset(action, guid);

            return action;
        }


  


        static internal void load()
        {

            //Chapter 1

            updateKalannah();
            updateMiteQueen();
            updateMiteSineshal();
            updateMiteCleric();
            updateKoboldKing();
            updateKoboldHerald();
            updateCR1_BanditBard();
            updateCR2_BanditPostiveCleric();
            updateStagLord();



            //Chapter 2 Trolls
            updateKoboldTeacher();
            updateKoboldBoomsayer();
            updateKoboldBladeCR3();
            updateKoboldAlchemistCR4();
            updateBoneShaman();
            updateJazon();
            updateJazonEarly();
            updateNagrundi();
            updateNagrundiTrollHound();
            fixTartuk();


            //Chapter 2 Season of Bloom

            fixLizardWilloWispBoss();

            updatefakestaglord(); 

            updatecraglinnorm();

            fixCandlemereWilloWispBoss();

            fixnixieprankster();
            fixnereidstandard();

            fixGoblinAlchemistCR7();
            fixGoblinKing();
            fixGoblinShaman();


            //Chapter 3

            changesprigganmeleefighter();
            changesprigganmeleerogueCR6();
            changesprigganmeleefighterCR4();
            changesprigganrogueranged();
            changesprigganmeleerogue();
            changesprigganmeleebarb();
            changesprigganrangedfighter();
            changesprigganboss();

            updateBarbarianCamp_ElderSister();
            updateElderSister();
            updateBarbarianCamp_YoungerSister();
            updateBarbarianCamp_SisterFromTomb();
            updateBarbarianCamp_Dugath();

            changeDaemonGuardian();
            updateVordakaiWillasGundarson();
            updateSpectreStandard();
            changeCephalLorentus();
            updateVordakai();
            updateHoragnamon();
            updateDefacedSisterAbandonedKeep();
            changeDreadZombieFighterFerocius();
            fixThickSkinnedZombieCyclopFighter();
            fixdreadzombieCR8();
            fixdreadzombieCR9();
            fixdreadgreaterbarbarian();

            fixDreadZombieCleric();
            fixundeadcyclopspriest();



            //Chapter 4

            updateClericGorum();
            updateArmag();


            //Chapter 5

            updateDwarfMagus();
            updateTrollGuard();
            changeriverbladetransmuter();



            //Chapter 6

            updateWrigglingMan();




            //PrisonEncounters and Miscellaneous

            
            updateThickLizardQueen();
            updateLadyofSorrows();
            updateInsaneWizard();
            updateEvilDruid();
            updateQueenRavena();
            updateWickdedOmen();
            updatePatientShadow();
            //changeIronGolem();
            //updateDweomerLion();

            //Tenebrious Depths

            updatespawnofrovagug();



        }

        

        //CHAPTER 1




        static void updateKalannah()
        {

            var Kalannah = library.Get<BlueprintUnit>("91190772833c8bf4ba65bb786566b644");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var KalannahSpellList = library.Get<BlueprintFeature>("8a5d921fc1279194dbed1daa65cc8b78");
            var KalannahFeatureList = library.Get<BlueprintFeature>("d10e5863b15db1b4f93da585e1d4a9fb");
            var summonmonsterII = library.Get<BlueprintAbility>("1724061e89c667045a6891179ee2e8e7");
            var summonmonsterI = library.Get<BlueprintAbility>("8fd74eddd9b6c224693d9ab241f25e84");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            var summonmonsterIII = library.Get<BlueprintAbility>("5d61dde0020bbf54ba1521f7ca0229dc");


            Kalannah.AddFacts = Kalannah.AddFacts.AddToArray(blurbuff);

            Kalannah.Intelligence = 14;

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)Kalannah.AddFacts[0], "KalannahFeatureFeatureNew", "f62e994836a14f3baa281fd5cbcb5991");
            Kalannah.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)KalannahFeatureList.GetComponent<AddFacts>().Facts[1], "KalannahSpellListNew", "cf462cecf46941b794b23f8892775095");
            KalannahFeatureList.GetComponent<AddFacts>().Facts[1] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var CR2_BanditPostiveClericFeature = library.Get<BlueprintFeature>("f62e994836a14f3baa281fd5cbcb5991");
            var CR2_BanditPostiveClericFeatureSpells = library.Get<BlueprintFeature>("cf462cecf46941b794b23f8892775095");

            


            var clericLevels = CR2_BanditPostiveClericFeature.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            var spell_list = newAddClassLevels.MemorizeSpells.RemoveFromArray(summonmonsterII);
            newAddClassLevels.MemorizeSpells = spell_list;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels, newAddClassLevels);



            var clericLevels6 = CR2_BanditPostiveClericFeature.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels6 = clericLevels6.CreateCopy();
            var spell_list6 = newAddClassLevels6.MemorizeSpells.RemoveFromArray(summonmonsterII);
            newAddClassLevels6.MemorizeSpells = spell_list6;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels6, newAddClassLevels6);

            var clericLevels8 = CR2_BanditPostiveClericFeature.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels8 = clericLevels8.CreateCopy();
            var spell_list8 = newAddClassLevels8.MemorizeSpells.RemoveFromArray(summonmonsterII);
            newAddClassLevels8.MemorizeSpells = spell_list8;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels8, newAddClassLevels8);

            var clericLevels7 = CR2_BanditPostiveClericFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels7 = clericLevels7.CreateCopy();
            var spell_list7 = newAddClassLevels7.MemorizeSpells.RemoveFromArray(summonmonsterIII);
            newAddClassLevels7.MemorizeSpells = spell_list7;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels7, newAddClassLevels7);

            var clericLevels2 = CR2_BanditPostiveClericFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels2 = clericLevels2.CreateCopy();
            var spell_list2 = newAddClassLevels2.MemorizeSpells.RemoveFromArray(summonmonsterI);
            newAddClassLevels2.MemorizeSpells = spell_list2;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels2, newAddClassLevels2);

            var clericLevels4 = CR2_BanditPostiveClericFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels4 = clericLevels4.CreateCopy();
            var spell_list4 = newAddClassLevels4.MemorizeSpells.RemoveFromArray(summonmonsterI);
            newAddClassLevels4.MemorizeSpells = spell_list4;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels4, newAddClassLevels4);

            var clericLevels3 = CR2_BanditPostiveClericFeature.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.MemorizeSpells.AddToArray(snowball, snowball, acidarrow, acidarrow, blur,summonmonsterIII);
            newAddClassLevels3.MemorizeSpells = spell_list3;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels3, newAddClassLevels3);

            var clericLevels5 = CR2_BanditPostiveClericFeature.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels5 = clericLevels5.CreateCopy();
            var spell_list5 = newAddClassLevels5.SelectSpells.AddToArray(acidarrow, blur,summonmonsterIII);
            newAddClassLevels5.SelectSpells = spell_list5;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels5, newAddClassLevels5);

            var superiorsummoning = library.Get<BlueprintFeature>("0477936c0f74841498b5c8753a8062a3");

            var clericLevels9 = CR2_BanditPostiveClericFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels9 = clericLevels9.CreateCopy();
            foreach (var selection in newAddClassLevels9.Selections)
            {
                selection.Features = selection.Features.RemoveFromArray(superiorsummoning);

            }
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels9, newAddClassLevels9);


            var summonmonsterIIIai = library.Get<BlueprintAiCastSpell>("4efd8abb25894704d8c82617f9c2dee9");
            var mephitbluraiaction = library.Get<BlueprintAiCastSpell>("0c1367bfc61f76a4ca331ce53c6fc608");
            var brain = Kalannah.Brain;

            

            brain.Actions = brain.Actions.RemoveFromArray(summonmonsterIIIai);
            brain.Actions = brain.Actions.AddToArray(AiActions.summonmonsterIIId3,AiActions.acidarrownixie,mephitbluraiaction);


        }

        static void updateMiteQueen()
        {

            var MiteQueen = library.Get<BlueprintUnit>("7132cbddedf2e264c9bb86bba1a42cbd");
            var MiteQueen_feature = library.Get<BlueprintFeature>("a6915b9ad9e7a684dbff317bc0b67dbb");
            var fey = library.Get<BlueprintCharacterClass>("f2e6e760ead99fb48ade27c7e9d4ac94");
            var ranger = library.Get<BlueprintCharacterClass>("cda0615668a6df14eb36ba19ee881af6");
            var leadblades = library.Get<BlueprintAbility>("779179912e6c6fe458fa4cfb90d96e10");


            var feyLevels = MiteQueen.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == fey);
            var newfeyLevels = feyLevels.CreateCopy();
            newfeyLevels.Levels = 1;
            MiteQueen.ReplaceComponent(feyLevels, newfeyLevels);

            var rangerLevels = MiteQueen_feature.ComponentsArray
               .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == ranger);
            var newrangerLevels = rangerLevels.CreateCopy();
            newrangerLevels.Levels = 5;
            var spell_list = newrangerLevels.MemorizeSpells.AddToArray(leadblades);
            newrangerLevels.MemorizeSpells = spell_list;
            MiteQueen_feature.ReplaceComponent(rangerLevels, newrangerLevels);




            var brain = MiteQueen.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.leadblades);

        }

        static void updateMiteSineshal()
        {

            var MiteSineshal = library.Get<BlueprintUnit>("c2b2bdd0409298a4d8dc3bc60a8d82fd");
            var clericClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var summonearthsmall = library.Get<BlueprintAbility>("970c6db48ff0c6f43afc9dbb48780d03");
            



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)MiteSineshal.AddFacts[3], " MiteSineshalFeature", "ad0d124691294c43b105c7c07b753a85");
            MiteSineshal.AddFacts[3] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();


            var MiteSineshalFeature = library.Get<BlueprintFeature>("ad0d124691294c43b105c7c07b753a85");




            var clericLevels = MiteSineshalFeature.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(summonearthsmall);
            newAddClassLevels.MemorizeSpells = spell_list;
            MiteSineshalFeature.ReplaceComponent(clericLevels, newAddClassLevels);


 





            var brain = MiteSineshal.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.summonelementalsmallearth,AiActions.holdpersondsineshal,AiActions.earthaciddart);


        }

        static void updateMiteCleric()
        {

            var MiteCleric = library.Get<BlueprintUnit>("726fb074d855ba2418d563716e144893");
            var clericClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
           




            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)MiteCleric.AddFacts[1], "CR4MiteClericFeature", "43e82624f7db48d2a9970fd26d1baed6");
            MiteCleric.AddFacts[1] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();


            var MiteClericFeatureNew = library.Get<BlueprintFeature>("43e82624f7db48d2a9970fd26d1baed6");




            var clericLevels = MiteClericFeatureNew.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.Levels = 3;
            MiteClericFeatureNew.ReplaceComponent(clericLevels, newAddClassLevels);








            var brain = MiteCleric.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.earthaciddartearlier);


        }

        static void updateKoboldKing()
        {

            var KoboldKing = library.Get<BlueprintUnit>("a00d3e0152a3c8142803d82b31ebc157");
            var KoboldKing_feature = library.Get<BlueprintFeature>("216023c5bf2aec148976f67a74e05b4a");
            var fighter = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");




            var fighterLevels = KoboldKing_feature.ComponentsArray
               .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == fighter);
            var newfighterLevels = fighterLevels.CreateCopy();
            newfighterLevels.Levels = 4;
            KoboldKing_feature.ReplaceComponent(fighterLevels, newfighterLevels);



        }

        static void updateKoboldHerald()
        {

            var KoboldHerald = library.Get<BlueprintUnit>("090d4fcb9a73f5242bc7f7f326876b89");
            var fighter = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var bardClass = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            var KoboldHeraldfeatureold = library.Get<BlueprintFeature>("17ac7f44b2f29334e953db0bc5a9e1be");
            var KoboldHeraldfeaturenew = library.Get<BlueprintFeature>("d112550a669ae8b4f99737de1ff7d837");
            var inspirecourage = library.Get<BlueprintFeature>("65c2b39752cf54841b36c4dff47643e6");
            var earpiercescream = library.Get<BlueprintAbility>("8e7cfa5f213a90549aadd18f8f6f4664");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");

            KoboldHerald.Charisma = 16;

     




            KoboldHerald.AddFacts = KoboldHerald.AddFacts.RemoveFromArray(KoboldHeraldfeatureold);
            KoboldHerald.AddFacts = KoboldHerald.AddFacts.AddToArray(KoboldHeraldfeaturenew);
            KoboldHerald.AddFacts = KoboldHerald.AddFacts.AddToArray(inspirecourage);

              var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)KoboldHerald.AddFacts[1], " KoboldHeraldFeature", "1c4a5207edee437a82e458057bc3ff5a");
             KoboldHerald.AddFacts[1] = clone;
             clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


             var KoboldHeraldFeature = library.Get<BlueprintFeature>("1c4a5207edee437a82e458057bc3ff5a");




            var bardLevels = KoboldHeraldFeature.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == bardClass);
              var newAddClassLevels = bardLevels.CreateCopy();
              newAddClassLevels.Levels = 5;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(earpiercescream);
            newAddClassLevels.SelectSpells = spell_list;
            KoboldHeraldFeature.ReplaceComponent(bardLevels, newAddClassLevels);




            



            var ai_action3 = library.CopyAndAdd<BlueprintAiCastSpell>("237c440dd94ad034288236d2988aa95f", "ThundercallerSoundBurstAiAction", "");

            var brain = KoboldHerald.Brain;
             brain.Actions = brain.Actions.AddToArray(AiActions.mirrorimage, AiActions.earpierce);


        }

        static void updateCR1_BanditBard()
        {

            var CR1_BanditBard = library.Get<BlueprintUnit>("6774bfa8c17aa6f4f88129b1451d6a4c");
            var bardClass = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            var CR1_BanditBardSpellList = library.Get<BlueprintFeature>("100d875d15c7de34bbc930ed306069cd");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var CR1_BanditBardFeatureList = library.Get<BlueprintFeature>("15f335f39a871054c9711046636f3c28");


            
            




            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)CR1_BanditBard.AddFacts[0], "CR1_BanditBardFeatureNew", "3cdb69de99cd473cb9b7d130bd604bb7");
            CR1_BanditBard.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)CR1_BanditBardFeatureList.GetComponent<AddFacts>().Facts[0], "CR1_BanditBardSpellListNew", "ff7965e9845c40bfb67bfc3f75d6dc92");
            CR1_BanditBardFeatureList.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var CR1_BanditBardFeature = library.Get<BlueprintFeature>("3cdb69de99cd473cb9b7d130bd604bb7");
            var CR1_BanditBardFeatureSpells = library.Get<BlueprintFeature>("ff7965e9845c40bfb67bfc3f75d6dc92");



            var bardLevels = CR1_BanditBardFeature.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == bardClass);
            var newAddClassLevels = bardLevels.CreateCopy();
            newAddClassLevels.Levels = 4;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(mirrorimage);
            newAddClassLevels.SelectSpells = spell_list;
            CR1_BanditBardFeature.ReplaceComponent(bardLevels, newAddClassLevels);

            var bardLevels2 = CR1_BanditBardFeatureSpells.ComponentsArray
        .OfType<LearnSpells>()
          .First(c => c.CharacterClass == bardClass);
            var newbardLevels2 = bardLevels2.CreateCopy();
            var spell_list2 = newbardLevels2.Spells.AddToArray(mirrorimage);
            newbardLevels2.Spells = spell_list2;
            CR1_BanditBardFeature.ReplaceComponent(bardLevels, newAddClassLevels);



            var brain = CR1_BanditBard.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.mirrorimage,AiActions.hideouslaughterbanditbard);


        }

        static void updateCR2_BanditPostiveCleric()
        {

            var CR2_BanditPostiveCleric = library.Get<BlueprintUnit>("9ffceca100e02644ba67cf492c17d351");
            var clericClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var shielfoffaith = library.Get<BlueprintBuff>("5274ddc289f4a7447b7ace68ad8bebb0");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var CR2_BanditClericSpellList = library.Get<BlueprintFeature>("f619dfdb9c83e9d47a2f6608ade20377");
            var CR2_BanditClericFeatureList = library.Get<BlueprintFeature>("ed3bd34059550f14b9b94c5c60bbec3c");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var summonmonsterII = library.Get<BlueprintAbility>("1724061e89c667045a6891179ee2e8e7");
            var protcommunal = library.Get<BlueprintAbility>("2cadf6c6350e4684baa109d067277a45");




            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)CR2_BanditPostiveCleric.AddFacts[0], "CR2_BanditClericFeatureNew", "f43295f644064d89b2c9a0c5d9055a3a");
            CR2_BanditPostiveCleric.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)CR2_BanditClericFeatureList.GetComponent<AddFacts>().Facts[0], "CR2_BanditClericSpellListNew", "6df66f22eed64e61bd6e199e2cb74f27");
            CR2_BanditClericFeatureList.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var CR2_BanditPostiveClericFeature = library.Get<BlueprintFeature>("f43295f644064d89b2c9a0c5d9055a3a");
            var CR2_BanditPostiveClericFeatureSpells = library.Get<BlueprintFeature>("6df66f22eed64e61bd6e199e2cb74f27");

            CR2_BanditPostiveCleric.AddFacts = CR2_BanditPostiveCleric.AddFacts.AddToArray(shielfoffaith,combatcasting);


            var clericLevels = CR2_BanditPostiveClericFeature.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            var spell_list = newAddClassLevels.MemorizeSpells.RemoveFromArray(holdperson);
            newAddClassLevels.MemorizeSpells = spell_list;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels, newAddClassLevels);

            var clericLevels2 = CR2_BanditPostiveClericFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels2 = clericLevels2.CreateCopy();
            var spell_list2 = newAddClassLevels2.MemorizeSpells.RemoveFromArray(protcommunal);
            newAddClassLevels2.MemorizeSpells = spell_list2;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels2, newAddClassLevels2);

            var clericLevels3 = CR2_BanditPostiveClericFeature.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.MemorizeSpells.AddToArray(summonmonsterII);
            newAddClassLevels3.MemorizeSpells = spell_list3;
            CR2_BanditPostiveClericFeature.ReplaceComponent(clericLevels3, newAddClassLevels3);





            var brain = CR2_BanditPostiveCleric.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.summonmonsterII,AiActions.divinefavor,AiActions.holdpersondelay);


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




        //CHAPTER 2 Trolls


        static void updateKoboldBladeCR3()
        {

            var koboldbladeCR3 = library.Get<BlueprintUnit>("3b5011e421ea0f54f93695b26c43ce33");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var natarmor1 = library.Get<BlueprintUnitFact>("10c7c5e3c5806bc4ca676e22d6fbf17e");
            var natarmor3 = library.Get<BlueprintUnitFact>("f6e106931f95fec4eb995f0d0629fb84");
            var trip = library.Get<BlueprintUnitFact>("0f15c6f70d8fb2b49aa6cc24239cc5fa");
            

            koboldbladeCR3.AddFacts = koboldbladeCR3.AddFacts.RemoveFromArray(natarmor1);
            koboldbladeCR3.AddFacts = koboldbladeCR3.AddFacts.AddToArray(natarmor3, trip);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)koboldbladeCR3.AddFacts[0], "koboldbladeCR3featurenew", "203cc38fcd9e43daa5ccae83a02a8c84");
            koboldbladeCR3.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var koboldbladeCR3new = library.Get<BlueprintFeature>("203cc38fcd9e43daa5ccae83a02a8c84");



            var fighterLevels = koboldbladeCR3new.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            koboldbladeCR3new.ReplaceComponent(fighterLevels, newAddClassLevels);






            var brain = koboldbladeCR3.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }

        static void updateKoboldAlchemistCR4()
        {

            var koboldalchemistCR4 = library.Get<BlueprintUnit>("b6138a9526b951b4ba99de864627ae6a");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var precisebomb = library.Get<BlueprintFeature>("5c396342f614dd644a48c3af08d79701");
            var natarmor1 = library.Get<BlueprintUnitFact>("10c7c5e3c5806bc4ca676e22d6fbf17e");
            var natarmor3 = library.Get<BlueprintUnitFact>("f6e106931f95fec4eb995f0d0629fb84");
            

            koboldalchemistCR4.AddFacts = koboldalchemistCR4.AddFacts.RemoveFromArray(natarmor1);
            koboldalchemistCR4.AddFacts = koboldalchemistCR4.AddFacts.AddToArray(natarmor3);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)koboldalchemistCR4.AddFacts[0], "koboldalchemistCR4featurenew", "71de291a8701403597f133482a7ea8d8");
            koboldalchemistCR4.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var koboldalchemistCR4new = library.Get<BlueprintFeature>("71de291a8701403597f133482a7ea8d8");



            var alchemistLevels = koboldalchemistCR4new.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(precisebomb);

            }
            koboldalchemistCR4new.ReplaceComponent(alchemistLevels, newAddClassLevels);









        }

        static void updateKoboldBoomsayer()
        {

            var koboldboomsayer = library.Get<BlueprintUnit>("b1c33857b8359674681d8677036bdbf0");
            
            var bardClass = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            var inspirecourage = library.Get<BlueprintFeature>("65c2b39752cf54841b36c4dff47643e6");
            var extra_performance = library.Get<BlueprintFeature>("0d3651b2cb0d89448b112e23214e744e");






            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)koboldboomsayer.AddFacts[0], "koboldboomsayerfeaturenew", "712b335de7314004ad6bf859bebd36d6");
            koboldboomsayer.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            koboldboomsayer.AddFacts = koboldboomsayer.AddFacts.AddToArray(inspirecourage, extra_performance);

           
            var koboldboomsayerfeaturenew = library.Get<BlueprintFeature>("712b335de7314004ad6bf859bebd36d6");



            var bardLevels = koboldboomsayerfeaturenew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == bardClass);
            var newAddClassLevels = bardLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            koboldboomsayerfeaturenew.ReplaceComponent(bardLevels, newAddClassLevels);






          


        }

        static void updateJazon()
        {

            var rugga = library.Get<BlueprintUnit>("7a8b35a967fe3c447acd0f82f0d7724a");


            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var druidClass= library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            var bardClass = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            var inspirecourage = library.Get<BlueprintFeature>("65c2b39752cf54841b36c4dff47643e6");
            var extra_performance = library.Get<BlueprintFeature>("0d3651b2cb0d89448b112e23214e744e");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var summonelementalmedium = library.Get<BlueprintAbility>("e42b1dbff4262c6469a9ff0a6ce730e3");
            var calllightning = library.Get<BlueprintAbility>("2a9ef0e0b5822a24d88b16673a267456");
            var stonecall = library.Get<BlueprintAbility>("5181c2ed0190fc34b8a1162783af5bf4");
            var stonefist = library.Get<BlueprintAbility>("85067a04a97416949b5d1dbf986d93f3");
            






            rugga.AddFacts = rugga.AddFacts.AddToArray(inspirecourage,extra_performance,combatcasting);

            rugga.Wisdom = 18;



            var druidLevels = rugga.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = druidLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            newAddClassLevels.Levels = 7;
            rugga.ReplaceComponent(druidLevels, newAddClassLevels);

            var druidLevels2 = rugga.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == druidClass);
            var newAddClassLevels2 = druidLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(summonelementalmedium,calllightning,calllightning,stonecall,stonefist);
            newAddClassLevels2.MemorizeSpells = spell_list;
            rugga.ReplaceComponent(druidLevels2, newAddClassLevels2);

            var bardLevels = rugga.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels3 = bardLevels.CreateCopy();
            newAddClassLevels3.CharacterClass = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            newAddClassLevels3.Levels = 1;
            rugga.ReplaceComponent(bardLevels, newAddClassLevels3);









            

            var brain = rugga.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.summonelementalmediumearth,AiActions.stonecall,AiActions.calllightningthirdturn, AiActions.stonefist);


        }

        static void updateJazonEarly()
        {

            var rugga = library.Get<BlueprintUnit>("e4275533dfc132d49a73ac7070169a8c");


            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var druidClass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            var bardClass = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            var inspirecourage = library.Get<BlueprintFeature>("65c2b39752cf54841b36c4dff47643e6");
            var extra_performance = library.Get<BlueprintFeature>("0d3651b2cb0d89448b112e23214e744e");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var summonelementalmedium = library.Get<BlueprintAbility>("e42b1dbff4262c6469a9ff0a6ce730e3");
            var calllightning = library.Get<BlueprintAbility>("2a9ef0e0b5822a24d88b16673a267456");
            var stonecall = library.Get<BlueprintAbility>("5181c2ed0190fc34b8a1162783af5bf4");
            var stonefist = library.Get<BlueprintAbility>("85067a04a97416949b5d1dbf986d93f3");







            rugga.AddFacts = rugga.AddFacts.AddToArray(inspirecourage, extra_performance, combatcasting);

            rugga.Wisdom = 18;



            var druidLevels = rugga.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = druidLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            newAddClassLevels.Levels = 7;
            rugga.ReplaceComponent(druidLevels, newAddClassLevels);

            var druidLevels2 = rugga.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == druidClass);
            var newAddClassLevels2 = druidLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(summonelementalmedium, calllightning, calllightning, stonecall, stonefist);
            newAddClassLevels2.MemorizeSpells = spell_list;
            rugga.ReplaceComponent(druidLevels2, newAddClassLevels2);

            var bardLevels = rugga.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels3 = bardLevels.CreateCopy();
            newAddClassLevels3.CharacterClass = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            newAddClassLevels3.Levels = 1;
            rugga.ReplaceComponent(bardLevels, newAddClassLevels3);











            var brain = rugga.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.summonelementalmediumearth, AiActions.stonecall, AiActions.calllightningthirdturn, AiActions.stonefist);




        }

        static void updateBoneShaman()
        {

            var boneshaman = library.Get<BlueprintUnit>("bb96b6fca3af55343a199dbbc14c4a72");
            var BoneShamanFeaturelist = library.Get<BlueprintFeature>("de7bee2497c718b4bbe623dfcc4fc78d");
            var sorcerer = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var slow = library.Get<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
            var stinkycloud = library.Get<BlueprintAbility>("68a9e6d7256f1354289a39003a46d826");



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)boneshaman.AddFacts[0], "BoneShamanFeature", "d35051cea94d474485ee57c0adeea011");
            boneshaman.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BoneShamanFeaturelist.GetComponent<AddFacts>().Facts[0], "BoneShamanSpellList", "4fc592a446354767ab827e45a160db25");
            BoneShamanFeaturelist.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var boneshamanfeature = library.Get<BlueprintFeature>("d35051cea94d474485ee57c0adeea011");
            var boneshamanspells = library.Get<BlueprintFeature>("4fc592a446354767ab827e45a160db25");

            var sorcererLevels = boneshamanfeature.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == sorcerer);
            var newsorcererLevels = sorcererLevels.CreateCopy();
            newsorcererLevels.Levels = 7;
            var spell_list = newsorcererLevels.SelectSpells.AddToArray(haste, slow, stinkycloud);
            newsorcererLevels.SelectSpells = spell_list;
            boneshamanfeature.ReplaceComponent(sorcererLevels, newsorcererLevels);

            var sorcererLevels2 = boneshamanspells.ComponentsArray
                .OfType<LearnSpells>()
              .First(c => c.CharacterClass == sorcerer);
            var newsorcererLevels2 = sorcererLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.Spells.AddToArray(haste, slow, stinkycloud);
            newsorcererLevels2.Spells = spell_list2;
            boneshamanspells.ReplaceComponent(sorcererLevels2, newsorcererLevels2);

           



            

            var brain = boneshaman.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.casthaste, AiActions.castslow);

        }

        static void updateKoboldTeacher()
        {



            var KoboldTeacher = library.Get<BlueprintUnit>("5bffe8529599c954bab2670ab60a3c2e");
            var KoboldTeacherFeatureList = library.Get<BlueprintFeature>("c8d8812f991445d4a8dacef0390d49e0");
            var KoboldTeacherOldSpells = library.Get<BlueprintFeature>("803625d14a6afcb47bd8cc59c3b5558b");
            var sorcerer = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");






            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)KoboldTeacher.AddFacts[0], "KoboldTeacherFeature", "aed7b8c113c640f38fe4251c44fde493");
            KoboldTeacher.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            // var clone3 = library.CopyAndAdd<BlueprintBrain>((BlueprintBrain)KoboldTeacher.Brain, "KoboldTeacherBrain", "e24f617a85274b209ec72ae2bd51bd8b");
            //KoboldTeacher.Brain = clone3;
            //clone3.ComponentsArray = clone3.ComponentsArray
            //    .Select(c => c.CreateCopy())
            //   .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)KoboldTeacherFeatureList.GetComponent<AddFacts>().Facts[0], "KoboldTeacherSpellList", "2778c85f85e84808a76d06bcc9a2d476");
            KoboldTeacherFeatureList.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var KoboldTeacherFeature = library.Get<BlueprintFeature>("aed7b8c113c640f38fe4251c44fde493");
            var KoboldTeacherSpellList = library.Get<BlueprintFeature>("2778c85f85e84808a76d06bcc9a2d476");
            //var KoboldTeacherBrain= library.Get<BlueprintBrain>("e24f617a85274b209ec72ae2bd51bd8b");



            var sorcererLevels = KoboldTeacherFeature.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == sorcerer);
            var newsorcererLevels = sorcererLevels.CreateCopy();
            newsorcererLevels.Levels = 7;
            var spell_list = newsorcererLevels.SelectSpells.AddToArray(haste, acidarrow, displacement);
            newsorcererLevels.SelectSpells = spell_list;
            KoboldTeacherFeature.ReplaceComponent(sorcererLevels, newsorcererLevels);

            var sorcererLevels2 = KoboldTeacherSpellList.ComponentsArray
                 .OfType<LearnSpells>()
                .First(c => c.CharacterClass == sorcerer);
            var newsorcererLevels2 = sorcererLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.Spells.AddToArray(haste, acidarrow, displacement);
            newsorcererLevels2.Spells = spell_list2;
            KoboldTeacherSpellList.ReplaceComponent(sorcererLevels2, newsorcererLevels2);

        //var sorcererLevels4 = KoboldTeacherFeature.ComponentsArray
        //   .OfType<AddClassLevels>()
        //  .First(c => c.CharacterClass == sorcerer);
        // var newsorcererLevels4 = sorcererLevels4.CreateCopy();
        //var spell_list4 = newsorcererLevels4.SelectSpells.RemoveFromArray(magicmissle);
        //newsorcererLevels4.SelectSpells = spell_list4;
        //KoboldTeacherFeature.ReplaceComponent(sorcererLevels4, newsorcererLevels4);

        //  var sorcererLevels3 = KoboldTeacherSpellList.ComponentsArray
        //  .OfType<LearnSpells>()
        //    .First(c => c.CharacterClass == sorcerer);
        // var newsorcererLevels3 = sorcererLevels2.CreateCopy();
        // var spell_list3 = newsorcererLevels3.Spells.RemoveFromArray(magicmissle);
        //  newsorcererLevels3.Spells = spell_list3;
        //  KoboldTeacherSpellList.ReplaceComponent(sorcererLevels3, newsorcererLevels3);




            var rival_brain = library.Get<BlueprintBrain>("3791a8b63cf257d46a8097c7d6902e9e");

            var new_actions = rival_brain.Actions;

            KoboldTeacher.Brain.Actions = new_actions;


            var rivalmagicmissleaiaction = library.CopyAndAdd<BlueprintAiCastSpell>("7e3aa1efcd3b39a48a97b578ee719b1b", "RivalMagicMissleAi", "");
            var ai_action2 = library.CopyAndAdd<BlueprintAiCastSpell>("c52c9c1d503180e44aebf198445d1845", "HasteAiAction", "");
            //var ai_action3 = library.CopyAndAdd<BlueprintAiCastSpell>("f081ec0ba52b30d41be591e5b1455421", "BlurAiAction", "");



            var brain = KoboldTeacher.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(rivalmagicmissleaiaction);
            brain.Actions = brain.Actions.AddToArray(AiActions.displacement_first,AiActions.magicmissledelay, ai_action2, AiActions.acidarrowdelay);



        }

        static void updateNagrundi()
        {

            var nagrundi = library.Get<BlueprintUnit>("7845110d2507b3848987d1eb172af6b4");
            var rangerClass = library.Get<BlueprintCharacterClass>("cda0615668a6df14eb36ba19ee881af6");
            var magicfang = library.Get<BlueprintBuff>("e7646b1dfdd22ce4ab340f295938ab8e");
            var sensevitals = library.Get<BlueprintAbility>("82962a820ebc0e7408b8582fdc3f4c0c"); 

            nagrundi.AddFacts = nagrundi.AddFacts.AddToArray(magicfang);


            var rangerLevels = nagrundi.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == rangerClass);
            var newAddClassLevels = rangerLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(sensevitals);
            newAddClassLevels.MemorizeSpells = spell_list;
            nagrundi.ReplaceComponent(rangerLevels, newAddClassLevels);



            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("d08cef5eda23b804dafc42b417eca858", "GaetaneSenseVitalsAiAction", "");
            var brain = nagrundi.Brain;
            brain.Actions = brain.Actions.AddToArray(ai_action);


        }

        static void updateNagrundiTrollHound()
        {

            var nagrunditrollhound = library.Get<BlueprintUnit>("9dddd1d587b6a7e4fa4c22fcd2ec25bf");
            var magicalbeastclass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var Trollhoundhowl = library.Get<BlueprintAbility>("78e79b09c2d724447a5c432e54ce4294");
            

            nagrunditrollhound.Strength = 26;

            nagrunditrollhound.Dexterity = 15;

            nagrunditrollhound.Constitution = 23;

            nagrunditrollhound.AddFacts = nagrunditrollhound.AddFacts.AddToArray(Trollhoundhowl);

            var magicalbeastLevels = nagrunditrollhound.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == magicalbeastclass);
            var newAddClassLevels = magicalbeastLevels.CreateCopy();
            newAddClassLevels.Levels = 12;
            nagrunditrollhound.ReplaceComponent(magicalbeastLevels, newAddClassLevels);


            nagrunditrollhound.AddFacts = new Kingmaker.Blueprints.Facts.BlueprintUnitFact[] {

                library.Get<BlueprintUnitFact>("2efb47f3cc42a2a45a8a85d2a87cffe9"), //sizelarge
                library.Get<BlueprintFeature>("13c87ac5985cc85498ef9d1ac8b78923"), //tripdefensefourlegs
                library.Get<BlueprintFeature>("b97edcf55321a814ea6b7807d246726c"), //weaponfocusbite
                library.Get<BlueprintFeature>("15e7da6645a7f3d41bdad7c8c4b9de1e"), //lightningreflexes
                library.Get<BlueprintFeature>("8388e2e50bb779840adc8129b3d63bf1"), //improvedcriticalbite
                library.Get<BlueprintFeature>("2d115ee0e1881dd488feedc7292f1dbd") //TrollhoundInfectiousBite
          

            };
        }

        static void fixTartuk()
        {

            var tartuk = library.Get<BlueprintUnit>("f2d11f187f76f6a4eb23f0ec1395f888");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var rivalholdpersonai = library.Get<BlueprintAiCastSpell>("5f6f4119ea089a748a80b6f3f7a38f9b");


            var add_class_levels = tartuk.GetComponent<AddAbilityToCharacterComponent>();

            var ability_list = add_class_levels.Abilities.AddToArray(displacement);

            add_class_levels.Abilities = ability_list;




            var brain = tartuk.Brain;
            var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("9d914a324b2b60a4daa6c620f21f7ae5", "RivalFireballAI", "");
            var ai_action2 = library.CopyAndAdd<BlueprintAiCastSpell>("6ceb83f4e85a70f4ebf5398ea7645fc7", "RivalScorchingRayAI", "");
            brain.Actions = brain.Actions.RemoveFromArray(rivalholdpersonai);

            brain.Actions = brain.Actions.AddToArray(AiActions.displacement_first, AiActions.holdpersontartuk, ai_action, ai_action2);


        }

        //CHAPTER 2 Season of Bloom

        static void updatefakestaglord()
        {

            var fakestaglord = library.Get<BlueprintUnit>("bf94afd79f4284e42b8116f9a478aae3");
            var bardClass = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var shout = library.Get<BlueprintAbility>("f09453607e683784c8fca646eec49162");
            var fakestaglordfeaturelist = library.Get<BlueprintFeature>("2b77a7aef84c68c478ddc69fa1d2c30d");
            var hideouslaughterai = library.Get<BlueprintAiCastSpell>("8b944da00906b6f4f9b1d73c80e46b8c");



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)fakestaglord.AddFacts[1], "fakestaglordfeaturenewlist", "432945dec0824604b4f637b95dd21a28");
            fakestaglord.AddFacts[1] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)fakestaglordfeaturelist.GetComponent<AddFacts>().Facts[0], "fakestaglordSpellListNew", "81c92e7614d04fb28498dacad3903d45");
            fakestaglordfeaturelist.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var fakestaglordfeaturenewlist = library.Get<BlueprintFeature>("432945dec0824604b4f637b95dd21a28");
            var fakestaglordSpellListNew = library.Get<BlueprintFeature>("81c92e7614d04fb28498dacad3903d45");

            var bardLevels = fakestaglordfeaturenewlist.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == bardClass);
            var newAddClassLevels = bardLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(mirrorimage,shout,displacement);
            newAddClassLevels.SelectSpells = spell_list;
            fakestaglordfeaturenewlist.ReplaceComponent(bardLevels, newAddClassLevels);

            var bardLevels2 = fakestaglordSpellListNew.ComponentsArray
            .OfType<LearnSpells>()
            .First(c => c.CharacterClass == bardClass);
            var newbardLevels2 = bardLevels2.CreateCopy();
            var spell_list2 = newbardLevels2.Spells.AddToArray(mirrorimage, shout, displacement);
            newbardLevels2.Spells = spell_list2;
            fakestaglordSpellListNew.ReplaceComponent(bardLevels, newAddClassLevels);



            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);


            fakestaglord.AddFacts = fakestaglord.AddFacts.AddToArray(quicken);


            var brain = fakestaglord.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(hideouslaughterai);
            brain.Actions = brain.Actions.AddToArray( AiActions.mirrorimage, AiActions.displacement_first, AiActions.castshout, AiActions.casthaste, AiActions.hideouslaughternixie);

        }

        static void updatecraglinnorm()
        {

            var craglinnorm = library.Get<BlueprintUnit>("b71529e55d080a04690287a31b0a6d47");
            var dragonClass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");



            var dragonLevels = craglinnorm.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == dragonClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 20;
            craglinnorm.ReplaceComponent(dragonLevels, newAddClassLevels);


            

        }

        static void fixLizardWilloWispBoss()
        {

            var LizardWilloWispBoss = library.Get<BlueprintUnit>("7f80d26947430aa47af6f1458c3d7305");
            var blur = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var abberationClass = library.Get<BlueprintCharacterClass>("e40e01860956b8b4d80059d4437996f5");
            var summonmonsterVI = library.Get<BlueprintAbility>("e740afbab0147944dab35d83faa0ae1c");
            var sorcererClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var oldmagicmissleswift = library.Get<BlueprintAiCastSpell>("e8c30e8f2729fc44baedaa287fd8e9a5");
            var magicmissleswift = library.Get<BlueprintAbility>("e4fc6161735811f44b6ee8b2043fc086");
            var augmentsummon = library.Get<BlueprintFeature>("38155ca9e4055bb48a89240a2055dcc3");
            var superiorsummmoning = library.Get<BlueprintFeature>("0477936c0f74841498b5c8753a8062a3");
            var slow = library.Get<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");


            var sorcererLevels = LizardWilloWispBoss.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == abberationClass);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            newAddClassLevels.Levels = 9;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(slow, mirrorimage);
            newAddClassLevels.SelectSpells = spell_list;
            LizardWilloWispBoss.ReplaceComponent(sorcererLevels, newAddClassLevels);


            var abberationLevels = LizardWilloWispBoss.GetComponent<AddClassLevels>();
            var newabberationLevels = abberationLevels.CreateCopy();
            newabberationLevels.CharacterClass = library.Get<BlueprintCharacterClass>("e40e01860956b8b4d80059d4437996f5");
            newabberationLevels.Levels = 8;
            LizardWilloWispBoss.AddComponent(newabberationLevels);



            LizardWilloWispBoss.AddFacts = LizardWilloWispBoss.AddFacts.AddToArray(blur, quicken);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);

            var brain = LizardWilloWispBoss.Brain;

            brain.Actions = brain.Actions.RemoveFromArray(oldmagicmissleswift);
            brain.Actions = brain.Actions.AddToArray(AiActions.summonmonsterVI, AiActions.dragonsbreath, AiActions.magicmissleswift, AiActions.castslow, AiActions.mirrorimage);


        }

        static void fixnereidstandard()
        {

            var nereidstandard = library.Get<BlueprintUnit>("7eef9336acefc764a8d8d16437193d5d");
            var feyClass = library.Get<BlueprintCharacterClass>("f2e6e760ead99fb48ade27c7e9d4ac94");
            var icestorm = library.Get<BlueprintAbility>("fcb028205a71ee64d98175ff39a0abf9");
            var sorcererClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var stoneskincommunal = library.Get<BlueprintAbility>("7c5d556b9a5883048bf030e20daebe31");
            var dragonsbreathsilver = library.Get<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            var sorcererLevels = nereidstandard.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == feyClass);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            newAddClassLevels.Levels = 10;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(icestorm,dragonsbreathsilver,stoneskincommunal,mirrorimage,lightningbolt);
            newAddClassLevels.SelectSpells = spell_list;
            nereidstandard.ReplaceComponent(sorcererLevels, newAddClassLevels);


            var abberationLevels = nereidstandard.GetComponent<AddClassLevels>();
            var newabberationLevels = abberationLevels.CreateCopy();
            newabberationLevels.CharacterClass = library.Get<BlueprintCharacterClass>("f2e6e760ead99fb48ade27c7e9d4ac94");
            newabberationLevels.Levels = 3;
            nereidstandard.AddComponent(newabberationLevels);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);


            nereidstandard.AddFacts = nereidstandard.AddFacts.AddToArray(quicken);


            var brain = nereidstandard.Brain;

            brain.Actions = brain.Actions.AddToArray(AiActions.stoneskincommunal, AiActions.icestorm,AiActions.dragonsbreathsilver, AiActions.mirrorimage, AiActions.lightningboltfourturns);

        }


        static void fixnixieprankster()
        {

            var nixiestandard = library.Get<BlueprintUnit>("7fd2ae7369b28e3489861407df3984ae");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            var sorcererClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var hideouslaughterai = library.Get<BlueprintAiCastSpell>("8b944da00906b6f4f9b1d73c80e46b8c");


            

            var sorcererLevels = nixiestandard.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == sorcererClass);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(acidarrow);
            newAddClassLevels.SelectSpells = spell_list;
            nixiestandard.ReplaceComponent(sorcererLevels, newAddClassLevels);


          


            var brain = nixiestandard.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(hideouslaughterai);
            brain.Actions = brain.Actions.AddToArray(AiActions.hideouslaughternixie, AiActions.acidarrownixie);

        }

        static void fixCandlemereWilloWispBoss()
        {

            var candlemereboss = library.Get<BlueprintUnit>("084c85929580f6a4f97caae34fab564e");
            var blur = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var abberationClass = library.Get<BlueprintCharacterClass>("e40e01860956b8b4d80059d4437996f5");
            var summonmonsterVI = library.Get<BlueprintAbility>("e740afbab0147944dab35d83faa0ae1c");
            var sorcererClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var oldmagicmissleswift = library.Get<BlueprintAiCastSpell>("e8c30e8f2729fc44baedaa287fd8e9a5");
            var magicmissleswift = library.Get<BlueprintAbility>("e4fc6161735811f44b6ee8b2043fc086");
            var dragonsbreathblue = library.Get<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");
            var augmentsummon = library.Get<BlueprintFeature>("38155ca9e4055bb48a89240a2055dcc3");
            var superiorsummmoning = library.Get<BlueprintFeature>("0477936c0f74841498b5c8753a8062a3");
            var slow = library.Get<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");


            var sorcererLevels = candlemereboss.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == abberationClass);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            newAddClassLevels.Levels = 12;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(summonmonsterVI,dragonsbreathblue,slow,mirrorimage);
            newAddClassLevels.SelectSpells = spell_list;
            candlemereboss.ReplaceComponent(sorcererLevels, newAddClassLevels);


            var abberationLevels = candlemereboss.GetComponent<AddClassLevels>();
            var newabberationLevels = abberationLevels.CreateCopy();
            newabberationLevels.CharacterClass = library.Get<BlueprintCharacterClass>("e40e01860956b8b4d80059d4437996f5");
            newabberationLevels.Levels = 8;
            candlemereboss.AddComponent(newabberationLevels);



            candlemereboss.AddFacts = candlemereboss.AddFacts.AddToArray(blur,augmentsummon,superiorsummmoning,quicken);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);

            var brain = candlemereboss.Brain;

            brain.Actions = brain.Actions.RemoveFromArray(oldmagicmissleswift);
            brain.Actions = brain.Actions.AddToArray(AiActions.summonmonsterVI,AiActions.dragonsbreath,AiActions.magicmissleswift,AiActions.castslow, AiActions.mirrorimage);


        }

        static void fixGoblinAlchemistCR7()
        {

            var goblinalchemistCR7 = library.Get<BlueprintUnit>("7ae7e5868e33fa84084a15c8a94193a2");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var precisebomb = library.Get<BlueprintFeature>("5c396342f614dd644a48c3af08d79701");
            var fastbomb = library.Get<BlueprintFeature>("128c5fccec5ca724281a4907b1f0ac83");
            var fastbombbuff = library.Get<BlueprintBuff>("c42ae8f9652bbc14eb13b31d12d20f8a");
            var blindbomb = library.Get<BlueprintFeature>("c3da68b2222768b4f9352fefd29ad15c");
           



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinalchemistCR7.AddFacts[0], "goblinalchemistCR7feature", "f7b3e1188d8549d78240140bdd80523a");
            goblinalchemistCR7.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var goblinalchemistCR7feature = library.Get<BlueprintFeature>("f7b3e1188d8549d78240140bdd80523a");



            var alchemistLevels = goblinalchemistCR7feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(precisebomb,fastbomb,blindbomb);

            }
            goblinalchemistCR7feature.ReplaceComponent(alchemistLevels, newAddClassLevels);






            goblinalchemistCR7.AddFacts = goblinalchemistCR7.AddFacts.AddToArray(fastbombbuff);


            
            var brain = goblinalchemistCR7.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.throwblindbomb);


        }

        static void fixGoblinKing()
        {

            var goblinking = library.Get<BlueprintUnit>("c6f2f6fd86ec921479b730da6c664632");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rangerClass = library.Get<BlueprintCharacterClass>("cda0615668a6df14eb36ba19ee881af6");
            var pointblank = library.Get<BlueprintFeature>("0da0c194d6e1d43419eb8d990b28e0ab");
            var preciseshot = library.Get<BlueprintFeature>("8f3d1e6b4be006f4d896081f2f889665");
            var manyshot = library.Get<BlueprintFeature>("adf54af2a681792489826f7fd1b62889");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");
            var longbowspec = library.Get<BlueprintFeature>("63f67a2a2e10f024281f0d6cb196d421");
            var longbowfocus = library.Get<BlueprintFeature>("f641e7c569328614c87e0270ac5325dd");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var deadlyaim = library.Get<BlueprintFeature>("f47df34d53f8c904f9981a3ee8e84892");
            var deadlyaimbuff = library.Get<BlueprintBuff>("6aaf11aa06ae0e7499a71b79725828df");
            var entangle = library.Get<BlueprintAbility>("0fd00984a2c0e0a429cf1a911b4ec5ca");
            var hurricanebow = library.Get<BlueprintAbility>("3e9d1119d43d07c4c8ba9ebfd1671952");
            var barkskin = library.Get<BlueprintAbility>("5b77d7cc65b8ab74688e74a37fc2f553");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var natarmor4 = library.Get<BlueprintUnitFact>("16fc201a83edcde4cbd64c291ebe0d07");
            


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinking.AddFacts[0], "goblinkingfeature", "cac7391f8147449d98ebe05c81731f4a");
            goblinking.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();





            var goblinkingfeature = library.Get<BlueprintFeature>("cac7391f8147449d98ebe05c81731f4a");

            var clericLevels = goblinkingfeature.ComponentsArray
            .OfType<AddClassLevels>()
              .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("cda0615668a6df14eb36ba19ee881af6");
            newAddClassLevels.Levels = 14;
            goblinkingfeature.ReplaceComponent(clericLevels, newAddClassLevels);


            var clericLevels2 = goblinkingfeature.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == rangerClass);
            var newAddClassLevels2 = clericLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(entangle,barkskin,hurricanebow);
            newAddClassLevels2.MemorizeSpells = spell_list;
            goblinkingfeature.ReplaceComponent(clericLevels2, newAddClassLevels2);

            var rangerLevels3 = goblinkingfeature.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == rangerClass);
            var newAddClassLevels3 = rangerLevels3.CreateCopy();
            foreach (var selection in newAddClassLevels3.Selections)
            {
                selection.Features = selection.Features.AddToArray(pointblank, preciseshot, manyshot, rapidshot, longbowspec, longbowfocus, toughness, deadlyaim);

            }
            goblinkingfeature.ReplaceComponent(rangerLevels3, newAddClassLevels3);

            goblinking.AddFacts = goblinking.AddFacts.AddToArray(rapidshotbuff, deadlyaimbuff, natarmor4);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.hurricanebow);

            goblinking.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("1f546ab76bb0e77478ad08248795f7d7"); //whirlwind bow
            goblinking.Body.SecondaryHand = null;

            var brain = goblinking.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.entangle, AiActions.barkskingoblinking, AiActions.hurricanebowgoblinking);

        }

        static void fixGoblinShaman()
        {

            var goblinshaman = library.Get<BlueprintUnit>("8421b6137d7765947958973526b5249b");
            var clericClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var summongreatrock = library.Get<BlueprintAbility>("8eb769e3b583f594faabe1cfdb0bb696");
            var coldicestrike = library.Get<BlueprintAbility>("5ef85d426783a5347b420546f91a677b");
            var heal = library.Get<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");
            var dispelgreater = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
            var bladebarrier = library.Get<BlueprintAbility>("36c8971e91f1745418cc3ffdfac17b74");
            var righteousmight = library.Get<BlueprintAbility>("90810e5cf53bf854293cbd5ea1066252");
            var constrictcoils = library.Get<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
            var flamestrike = library.Get<BlueprintAbility>("f9910c76efc34af41b6e43d5d8752f0f");
            var divinepower = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var prayer = library.Get<BlueprintAbility>("faabd2cc67efa4646ac58c7bb3e40fcc");
            var superiorsummoning = library.Get<BlueprintFeature>("0477936c0f74841498b5c8753a8062a3");
            var SummonMonsterVIId4plus1 = library.Get<BlueprintAbility>("6e805a9e3ff445146a6386f5a704d4bc");
            var SummonMonsterVId4plus1 = library.Get<BlueprintAbility>("59d28e07b948d4e45a7477ec0065ccb3");
            var selectivechannel = library.Get<BlueprintFeature>("fd30c69417b434d47b6b03b9c1f568ff");
            var divinepowerai = library.Get<BlueprintAiCastSpell>("09de02db1b07d364795f412abb557de3");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");


            goblinshaman.Wisdom = 24;


            goblinshaman.AddFacts = goblinshaman.AddFacts.RemoveFromArray(superiorsummoning);
            goblinshaman.AddFacts = goblinshaman.AddFacts.RemoveFromArray(divinepower);
            goblinshaman.AddFacts = goblinshaman.AddFacts.RemoveFromArray(SummonMonsterVId4plus1);
            goblinshaman.AddFacts = goblinshaman.AddFacts.RemoveFromArray(SummonMonsterVIId4plus1);
            goblinshaman.AddFacts = goblinshaman.AddFacts.AddToArray(selectivechannel,quicken);


            var clericLevels = goblinshaman.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(summongreatrock, coldicestrike, coldicestrike, heal, dispelgreater, righteousmight, constrictcoils, flamestrike,flamestrike, divinepower, prayer);
            newAddClassLevels.MemorizeSpells = spell_list;
            goblinshaman.ReplaceComponent(clericLevels, newAddClassLevels);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.prayer);

            var brain = goblinshaman.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(divinepowerai);
            brain.Actions = brain.Actions.AddToArray(AiActions.summonelementalgreatearth, AiActions.coldicestrike,AiActions.healspell,
                                                     AiActions.divine_power_first,AiActions.righteousmightgoblinshaman,AiActions.prayergoblinshaman,AiActions.constrictingcoils,AiActions.flamestrikegoblinshaman,AiActions.greaterdispel);


        }

        //CHAPTER 3

        static void changesprigganrogueranged()
        {
            var sprigganrogueranged = library.Get<BlueprintUnit>("9eac9269bf679d34fa4fcc9f4eff6be5");

            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var humanoidClass = library.Get<BlueprintCharacterClass>("6ab4526f94d2e3e439af0599a29b6675");
            var sorcererClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var stoneskincommunal = library.Get<BlueprintAbility>("7c5d556b9a5883048bf030e20daebe31");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
            var dragonsbreathgreen = library.Get<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");
            var magearmor = library.Get<BlueprintAbility>("9e1ad5d6f87d19e4d8883d63a6e35568");
            var controlledfireball = library.Get<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var slow = library.Get<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var shield = library.Get<BlueprintAbility>("ef768022b0785eb43a18969903c537c4");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            var scorchingray = library.Get<BlueprintAbility>("cdb106d53c65bbc4086183d54c3b97c7");


        var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
        var shieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");

           


            sprigganrogueranged.LocalizedName = Helpers.Create<SharedStringAsset>(c => c.String = Helpers.CreateString($"{sprigganrogueranged.name}.name", "Spriggan Sorcerer"));

            var sorcererLevels = sprigganrogueranged.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            newAddClassLevels.Levels = 10;
            sprigganrogueranged.ReplaceComponent(sorcererLevels, newAddClassLevels);



            var sorcererLevels3 = sprigganrogueranged.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == sorcererClass);
            var newAddClassLevels3 = sorcererLevels3.CreateCopy();
            var spell_list = newAddClassLevels3.SelectSpells.AddToArray(stoneskincommunal, mirrorimage,dragonsbreathgreen,magearmor,controlledfireball,haste,slow,displacement,shield,scorchingray,acidarrow);
            newAddClassLevels3.SelectSpells = spell_list;
            sprigganrogueranged.ReplaceComponent(sorcererLevels3, newAddClassLevels3);

            var humanoidLevels = sprigganrogueranged.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == humanoidClass);
            var newAddClassLevels2 = humanoidLevels.CreateCopy();
            newAddClassLevels2.Levels = 3;
            sprigganrogueranged.ReplaceComponent(humanoidLevels, newAddClassLevels2);

            sprigganrogueranged.Body.Armor = null;

            sprigganrogueranged.AddFacts = sprigganrogueranged.AddFacts.AddToArray(quicken,magearmorbuff,shieldbuff);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);


            

            var brain = sprigganrogueranged.Brain;

            brain.Actions = brain.Actions.AddToArray(AiActions.stoneskincommunal,AiActions.mirrorimage,AiActions.dragonsbreathgreen,
                AiActions.castmagearmorsprig,AiActions.castcontrolledfireball, 
                AiActions.casthaste, AiActions.castslowsprig,AiActions.displacementvordakai,AiActions.castshieldsprig,AiActions.acidarrowdelay,AiActions.scorchingraydelay);


        }

        static void changesprigganmeleefighter()
        {
            var sprigganfightermelee = library.Get<BlueprintUnit>("736c6a1275bfc54448119d695730b7a6");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var humanoidClass = library.Get<BlueprintCharacterClass>("6ab4526f94d2e3e439af0599a29b6675");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var ChargeAbility = library.Get<BlueprintAbility>("c78506dd0e14f7c45a599990e4e65038");
            var improvedinitiative = library.Get<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");


            sprigganfightermelee.AddFacts = sprigganfightermelee.AddFacts.AddToArray(ChargeAbility);

            sprigganfightermelee.Skills.Diplomacy = 10;



            var fighterLevels = sprigganfightermelee.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(cornugon, improvedinitiative);

            }
            sprigganfightermelee.ReplaceComponent(fighterLevels, newAddClassLevels);





            var humanoidLevels = sprigganfightermelee.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == humanoidClass);
            var newAddClassLevels2 = humanoidLevels.CreateCopy();
            newAddClassLevels2.Levels = 3;
            sprigganfightermelee.ReplaceComponent(humanoidLevels, newAddClassLevels2);







            var brain = sprigganfightermelee.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig,AiActions.bullrush,AiActions.charge);



        }

        static void changesprigganmeleefighterCR4()
        {
            var sprigganfightermelee = library.Get<BlueprintUnit>("3eaa52ef40292824393ccad2ac00cdfa");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var humanoidClass = library.Get<BlueprintCharacterClass>("6ab4526f94d2e3e439af0599a29b6675");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var chargeability = library.Get<BlueprintAbility>("c78506dd0e14f7c45a599990e4e65038");
            var improvedinitiative = library.Get<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");



            sprigganfightermelee.Skills.Diplomacy = 10;



            var fighterLevels = sprigganfightermelee.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            sprigganfightermelee.ReplaceComponent(fighterLevels, newAddClassLevels);





            var humanoidLevels = sprigganfightermelee.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == humanoidClass);
            var newAddClassLevels2 = humanoidLevels.CreateCopy();
            newAddClassLevels2.Levels = 3;
            sprigganfightermelee.ReplaceComponent(humanoidLevels, newAddClassLevels2);







            var brain = sprigganfightermelee.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig, AiActions.charge);



        }
        
        static void changesprigganmeleerogue()
        {
            var sprigganroguemelee = library.Get<BlueprintUnit>("f5a3ea6aa0be1a64f970b4dcb42b10a5");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var humanoidClass = library.Get<BlueprintCharacterClass>("6ab4526f94d2e3e439af0599a29b6675");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var disarmfeat = library.Get<BlueprintFeature>("63d8e3a9ab4d72e4081a7862d7246a79");
            var improvedinitiative = library.Get<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");
            var doubledamage = library.Get<BlueprintFeature>("8a6a1920019c45d40b4561f05dcb3240");
            



            var rogueLevels = sprigganroguemelee.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(improvedinitiative,disarmfeat);

            }
            sprigganroguemelee.ReplaceComponent(rogueLevels, newAddClassLevels);



            sprigganroguemelee.AddFacts = sprigganroguemelee.AddFacts.AddToArray(disarm,doubledamage);


            var humanoidLevels = sprigganroguemelee.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == humanoidClass);
            var newAddClassLevels2 = humanoidLevels.CreateCopy();
            newAddClassLevels2.Levels = 3;
            sprigganroguemelee.ReplaceComponent(humanoidLevels, newAddClassLevels2);







            var brain = sprigganroguemelee.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedisarm);



        }

        static void changesprigganmeleerogueCR6()
        {
            var sprigganroguemelee = library.Get<BlueprintUnit>("f5a3ea6aa0be1a64f970b4dcb42b10a5");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var humanoidClass = library.Get<BlueprintCharacterClass>("6ab4526f94d2e3e439af0599a29b6675");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var disarmfeat = library.Get<BlueprintFeature>("63d8e3a9ab4d72e4081a7862d7246a79");
            var improvedinitiative = library.Get<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");
            var doubledamage = library.Get<BlueprintFeature>("8a6a1920019c45d40b4561f05dcb3240");




            var rogueLevels = sprigganroguemelee.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(disarmfeat);

            }
            sprigganroguemelee.ReplaceComponent(rogueLevels, newAddClassLevels);



            sprigganroguemelee.AddFacts = sprigganroguemelee.AddFacts.AddToArray(disarm);


            var humanoidLevels = sprigganroguemelee.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == humanoidClass);
            var newAddClassLevels2 = humanoidLevels.CreateCopy();
            newAddClassLevels2.Levels = 3;
            sprigganroguemelee.ReplaceComponent(humanoidLevels, newAddClassLevels2);







            var brain = sprigganroguemelee.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedisarm);



        }

        static void changesprigganmeleebarb()
        {
            var sprigganbarbmelee = library.Get<BlueprintUnit>("3c5423ba291b6854aae084a55b96898f");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var humanoidClass = library.Get<BlueprintCharacterClass>("6ab4526f94d2e3e439af0599a29b6675");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            
            

          

            var barbarianLevels = sprigganbarbmelee.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = barbarianLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            sprigganbarbmelee.ReplaceComponent(barbarianLevels, newAddClassLevels);





            var humanoidLevels = sprigganbarbmelee.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == humanoidClass);
            var newAddClassLevels2 = humanoidLevels.CreateCopy();
            newAddClassLevels2.Levels = 3;
            sprigganbarbmelee.ReplaceComponent(humanoidLevels, newAddClassLevels2);







            var brain = sprigganbarbmelee.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);



        }

        static void changesprigganrangedfighter()
        {
            var sprigganrangedfighter = library.Get<BlueprintUnit>("b6eebf0dd9dc0074aad6b95c4adf5f81");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var humanoidClass = library.Get<BlueprintCharacterClass>("6ab4526f94d2e3e439af0599a29b6675");
            var crossbowweapontraining = library.Get<BlueprintFeature>("9cdfc2a236ee6d349ad6d8a2170477d5");
            var crossbowweapontraining2 = library.Get<BlueprintFeature>("9cdfc2a236ee6d349ad6d8a2170477d5");
            var improvedinitiative = library.Get<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");
            var weapontrainingrankupselect = library.Get<BlueprintFeatureSelection>("5f3cc7b9a46b880448275763fe70c0b0");
            var weapontrainingselect = library.Get<BlueprintFeatureSelection>("b8cecf4e5e464ad41b79d5b42b76b399");
            var deadlyaim = library.Get<BlueprintFeature>("f47df34d53f8c904f9981a3ee8e84892");
            var deadlyaimbuff = library.Get<BlueprintBuff>("6aaf11aa06ae0e7499a71b79725828df");




            sprigganrangedfighter.AddFacts = sprigganrangedfighter.AddFacts.RemoveFromArray(crossbowweapontraining);




            var fighterLevels = sprigganrangedfighter.ComponentsArray
            .OfType<AddClassLevels>()
              .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(improvedinitiative );
                selection.Features = selection.Features.RemoveFromArray(deadlyaim);
            }
            sprigganrangedfighter.ReplaceComponent(fighterLevels, newAddClassLevels);



            var fighterLevels3 = sprigganrangedfighter.ComponentsArray
            .OfType<AddClassLevels>()
              .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels3 = fighterLevels3.CreateCopy();
            foreach (var selection in newAddClassLevels3.Selections)
            {
                weapontrainingrankupselect.Features = weapontrainingrankupselect.Features.AddToArray(crossbowweapontraining);

            }
            sprigganrangedfighter.ReplaceComponent(fighterLevels3, newAddClassLevels3);



            var humanoidLevels = sprigganrangedfighter.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == humanoidClass);
            var newAddClassLevels2 = humanoidLevels.CreateCopy();
            newAddClassLevels2.Levels = 3;
            sprigganrangedfighter.ReplaceComponent(humanoidLevels, newAddClassLevels2);


            sprigganrangedfighter.Body.PrimaryHand = null;
            sprigganrangedfighter.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("01067a23c0cd2c54eb2d41f139f7fde7"); //whirlwind bow


            var brain = sprigganrangedfighter.Brain;
            brain.Actions = brain.Actions.AddToArray();



        }

        static void changesprigganboss()
        {
            var sprigganbarboss = library.Get<BlueprintUnit>("c819bc7aaf8f7eb428c5d3c75cda2d42");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var humanoidClass = library.Get<BlueprintCharacterClass>("6ab4526f94d2e3e439af0599a29b6675");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

          




            var barbarianLevels = sprigganbarboss.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = barbarianLevels.CreateCopy();
            newAddClassLevels.Levels = 13;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            sprigganbarboss.ReplaceComponent(barbarianLevels, newAddClassLevels);





            var humanoidLevels = sprigganbarboss.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == humanoidClass);
            var newAddClassLevels2 = humanoidLevels.CreateCopy();
            newAddClassLevels2.Levels = 3;
            sprigganbarboss.ReplaceComponent(humanoidLevels, newAddClassLevels2);







            var brain = sprigganbarboss.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);



        }




        static void updateVordakaiWillasGundarson()

        {


            var VordakaiWillasGundarson = library.Get<BlueprintUnit>("5dbafe899da6c2f4e924988118f52f3d");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var disarmfeat = library.Get<BlueprintFeature>("63d8e3a9ab4d72e4081a7862d7246a79");
            var improvedinitiative = library.Get<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");
            var doubledamage = library.Get<BlueprintFeature>("8a6a1920019c45d40b4561f05dcb3240");
            var oppurtunist = library.Get<BlueprintFeature>("5bb6dc5ce00550441880a6ff8ad4c968");
            var improvedevasion = library.Get<BlueprintFeature>("0d35d6c4d5eef8d4790d09bd9a874e57");
            var disorientedability = library.Get<BlueprintBuff>("6339eac5bdcef1747ac46885d2cf4e25");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");
            var bewilderingability = library.Get<BlueprintActivatableAbility>("c74a63e0d2fd08149bfcfff8ded43313");
            var summonghosts = library.Get<BlueprintAbility>("a8ba7017d97345969db2567eb7c249b7");
            var doubledebiliation = library.Get<BlueprintFeature>("dd699394df0ef8847abba26038333f02");
            

            {

                var undeadLevels = VordakaiWillasGundarson.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == rogueClass);
                var newAddClassLevels2 = undeadLevels.CreateCopy();
                newAddClassLevels2.CharacterClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
                newAddClassLevels2.Levels = 3;
                VordakaiWillasGundarson.ReplaceComponent(undeadLevels, newAddClassLevels2);



                var rogueLevels = VordakaiWillasGundarson.ComponentsArray
                     .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == undeadClass);
                var newAddClassLevels = rogueLevels.CreateCopy();
                newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
                newAddClassLevels.Levels = 14;
                foreach (var selection in newAddClassLevels.Selections)
                {
                    selection.Features = selection.Features.AddToArray();

                }
                VordakaiWillasGundarson.ReplaceComponent(rogueLevels, newAddClassLevels);



                VordakaiWillasGundarson.AddFacts = VordakaiWillasGundarson.AddFacts.AddToArray(oppurtunist,summonghosts,disarm, improvedevasion, disorientedability, dirtytrick, doubledebiliation);



                VordakaiWillasGundarson.Body.DisableHands = false;

                VordakaiWillasGundarson.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"); //dagger +1

                

                var brain = VordakaiWillasGundarson.Brain;
                brain.Actions = brain.Actions.AddToArray(AiActions.usedisarmspectre,AiActions.usedirtytrickblind,AiActions.usesummonghosts);


            }
        }

        static void updateSpectreStandard()

        {


            var standardspectre = library.Get<BlueprintUnit>("2f91d7337b60e3b4b9b137198a8c8745");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var improvedinitiative = library.Get<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");
            var doubledamage = library.Get<BlueprintFeature>("8a6a1920019c45d40b4561f05dcb3240");
            var oppurtunist = library.Get<BlueprintFeature>("5bb6dc5ce00550441880a6ff8ad4c968");
            var improvedevasion = library.Get<BlueprintFeature>("0d35d6c4d5eef8d4790d09bd9a874e57");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var disarmfeat = library.Get<BlueprintFeature>("63d8e3a9ab4d72e4081a7862d7246a79");




            {

                

                var rogueLevels = standardspectre.GetComponent<AddClassLevels>();
                var newrogueLevels = rogueLevels.CreateCopy();
                newrogueLevels.CharacterClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
                newrogueLevels.Levels = 8;
                standardspectre.AddComponent(newrogueLevels);

                var undeadLevels = standardspectre.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == rogueClass);
                var newAddClassLevels2 = undeadLevels.CreateCopy();
                newAddClassLevels2.Levels = 3;
                standardspectre.ReplaceComponent(undeadLevels, newAddClassLevels2);



                standardspectre.AddFacts = standardspectre.AddFacts.AddToArray(disarm, improvedevasion,  dirtytrick);



                standardspectre.Body.DisableHands = false;

                standardspectre.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"); //dagger +1



                var brain = standardspectre.Brain;
                brain.Actions = brain.Actions.AddToArray(AiActions.usedisarmspectre, AiActions.usedirtytrickblind);


            }
        }

        static void updateBarbarianCamp_Dugath()

        {



            
            var dugath_camp = library.Get<BlueprintUnit>("9c0490bc771782a43b42bebb5f1f07d4");
            var clericClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var divine_power = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var searing_light = library.Get<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var heal = library.Get<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");
            var constrictingcoils = library.Get<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var divinefavor = library.Get<BlueprintAbility>("9d5d2d3ffdd73c648af3eb3e585b1113");
            var prayer = library.Get<BlueprintAbility>("faabd2cc67efa4646ac58c7bb3e40fcc");
            var bless = library.Get<BlueprintAbility>("90e59f4a4ada87243b7b3535a06d0638");
            var righteousmight = library.Get<BlueprintAbility>("90810e5cf53bf854293cbd5ea1066252");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");


            {

                dugath_camp.AddFacts = dugath_camp.AddFacts.AddToArray(quicken);

                var clericLevels = dugath_camp.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericClass);
                var newclericLevels = clericLevels.CreateCopy();
                newclericLevels.CharacterClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
                newclericLevels.Levels = 13;
                var spell_list = newclericLevels.MemorizeSpells.AddToArray(righteousmight,heal,divine_power, constrictingcoils, prayer, bless, holdperson);
                newclericLevels.MemorizeSpells = spell_list;
                dugath_camp.ReplaceComponent(clericLevels, newclericLevels);

                var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
                auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);




                var brain = dugath_camp.Brain;
                brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
                brain.Actions = brain.Actions.AddToArray(AiActions.righteousmightdugath,
                                                     AiActions.holdpersondelay,
                                                     AiActions.constrictingcoilszombie,
                                                     AiActions.prayergoblinshaman,
                                                     AiActions.blesscast,
                                                     AiActions.divine_power_first,
                                                     AiActions.healspell,
                                                     AiActions.cleave);
            }
        }

        static void updateBarbarianCamp_ElderSister()

        {



            var nymphclass = library.Get<BlueprintCharacterClass>("9a20b40b57f4e684fa20d17c0edfd5ba");
            var eldersister_barbcamp = library.Get<BlueprintUnit>("00ac5f0e63a76ce49af4bab27599f75b");
            var firedomain = library.Get<BlueprintFeature>("9dc5863168155854fa8daf4a780f6663");
            var firedomainprogressdruid = library.Get<BlueprintProgression>("562567d7c244fae43ac61df3d55547ca");
            var firedomainspelllistfeaturedruid = library.Get<BlueprintFeature>("bb87f638c058cd9468e0a0e25fa9a1a9");
            var controlledfireball = library.Get<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");
            var firedomainresist = library.Get<BlueprintFeature>("24700a71dd3dc844ea585345f6dd18f6");
            var greaterdispel = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
            var volcanicstorm = library.Get<BlueprintAbility>("16ce660837fb2544e96c3b7eaad73c63");
            var summonnaturesallyIV = library.Get<BlueprintAbility>("c83db50513abdf74ca103651931fac4b");
            var flamestrikeaiaction = library.Get<BlueprintAiCastSpell>("4f48fd03d530f86439657e4d93bffc89");
            var calllightning = library.Get<BlueprintAbility>("2a9ef0e0b5822a24d88b16673a267456");
            var stoneskincommunal = library.Get<BlueprintAbility>("7c5d556b9a5883048bf030e20daebe31");



            {





                eldersister_barbcamp.AddFacts = eldersister_barbcamp.AddFacts.AddToArray(firedomainresist, controlledfireball);

                var nymphLevels2 = eldersister_barbcamp.ComponentsArray
               .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == nymphclass);
                var newAddClassLevels3 = nymphLevels2.CreateCopy();
                foreach (var selection in newAddClassLevels3.Selections)
                {
                    selection.Features = selection.Features.AddToArray(firedomain, firedomainprogressdruid, firedomainspelllistfeaturedruid);

                }
                eldersister_barbcamp.ReplaceComponent(nymphLevels2, newAddClassLevels3);

                var nymphLevels = eldersister_barbcamp.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels = nymphLevels.CreateCopy();
                newnymphLevels.Levels = 11;
                var spell_list = newnymphLevels.MemorizeSpells.AddToArray(stoneskincommunal, greaterdispel, firesnake, firesnake, volcanicstorm, calllightning, calllightning);
                newnymphLevels.MemorizeSpells = spell_list;
                eldersister_barbcamp.ReplaceComponent(nymphLevels, newnymphLevels);

                var nymphLevels3 = eldersister_barbcamp.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels3 = nymphLevels3.CreateCopy();
                var spell_list2 = newnymphLevels3.MemorizeSpells.RemoveFromArray(summonnaturesallyIV);
                newnymphLevels3.MemorizeSpells = spell_list2;
                eldersister_barbcamp.ReplaceComponent(nymphLevels3, newnymphLevels3);

                var brain = eldersister_barbcamp.Brain;
                brain.Actions = brain.Actions.RemoveFromArray(flamestrikeaiaction);
                brain.Actions = brain.Actions.AddToArray(AiActions.stoneskincommunal,
                                                         AiActions.castcontrolledfireballsister,
                                                         AiActions.castgreaterdispellsister,
                                                         AiActions.castfiresnakesister,
                                                         AiActions.castvolcanicstorm,
                                                         AiActions.castflamestrikesister,
                                                         AiActions.calllightningsister);
            }
        }

        static void updateElderSister()

        {


            var nymphclass = library.Get<BlueprintCharacterClass>("9a20b40b57f4e684fa20d17c0edfd5ba");
            var eldersister_barbcamp = library.Get<BlueprintUnit>("32f96cce54118064aaace10822fea0a9");
            var stormbolt = library.Get<BlueprintAbility>("7cfbefe0931257344b2cb7ddc4cdff6f");
            var firedomain = library.Get<BlueprintFeature>("9dc5863168155854fa8daf4a780f6663");
            var firedomainprogressdruid = library.Get<BlueprintProgression>("562567d7c244fae43ac61df3d55547ca");
            var firedomainspelllistfeaturedruid = library.Get<BlueprintFeature>("bb87f638c058cd9468e0a0e25fa9a1a9");
            var controlledfireball = library.Get<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");
            var firedomainresist = library.Get<BlueprintFeature>("24700a71dd3dc844ea585345f6dd18f6");
            var greaterdispel = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
            var volcanicstorm = library.Get<BlueprintAbility>("16ce660837fb2544e96c3b7eaad73c63");
            var summonnaturesallyIV = library.Get<BlueprintAbility>("c83db50513abdf74ca103651931fac4b");
            var flamestrikeaiaction = library.Get<BlueprintAiCastSpell>("4f48fd03d530f86439657e4d93bffc89");
            var calllightning = library.Get<BlueprintAbility>("2a9ef0e0b5822a24d88b16673a267456");
            var calllightningstorm = library.Get<BlueprintAbility>("d5a36a7ee8177be4f848b953d1c53c84");
            var stoneskincommunal = library.Get<BlueprintAbility>("7c5d556b9a5883048bf030e20daebe31");

            {





                eldersister_barbcamp.AddFacts = eldersister_barbcamp.AddFacts.AddToArray(firedomainresist, controlledfireball);

                var nymphLevels2 = eldersister_barbcamp.ComponentsArray
               .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == nymphclass);
                var newAddClassLevels3 = nymphLevels2.CreateCopy();
                foreach (var selection in newAddClassLevels3.Selections)
                {
                    selection.Features = selection.Features.AddToArray(firedomain, firedomainprogressdruid, firedomainspelllistfeaturedruid);

                }
                eldersister_barbcamp.ReplaceComponent(nymphLevels2, newAddClassLevels3);

                var nymphLevels = eldersister_barbcamp.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels = nymphLevels.CreateCopy();
                newnymphLevels.Levels = 12;
                var spell_list = newnymphLevels.MemorizeSpells.AddToArray(stoneskincommunal,greaterdispel, firesnake, firesnake, volcanicstorm, calllightning, calllightning);
                newnymphLevels.MemorizeSpells = spell_list;
                eldersister_barbcamp.ReplaceComponent(nymphLevels, newnymphLevels);

                var nymphLevels3 = eldersister_barbcamp.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels3 = nymphLevels3.CreateCopy();
                var spell_list2 = newnymphLevels3.MemorizeSpells.RemoveFromArray(summonnaturesallyIV);
                newnymphLevels3.MemorizeSpells = spell_list2;
                eldersister_barbcamp.ReplaceComponent(nymphLevels3, newnymphLevels3);

                var brain = eldersister_barbcamp.Brain;
                brain.Actions = brain.Actions.RemoveFromArray(flamestrikeaiaction);
                brain.Actions = brain.Actions.AddToArray(AiActions.stoneskincommunal,
                                                         AiActions.castcontrolledfireballsister,
                                                         AiActions.castgreaterdispellsister,
                                                         AiActions.castfiresnakesister,
                                                         AiActions.castvolcanicstorm,
                                                         AiActions.castflamestrikesister,
                                                         AiActions.calllightningsister);
            }
        }

        static void updateBarbarianCamp_YoungerSister()

        {

            var nymphclass = library.Get<BlueprintCharacterClass>("9a20b40b57f4e684fa20d17c0edfd5ba");
            var youngersister_barbcamp = library.Get<BlueprintUnit>("1d17d32dbe086d64395b5338ad29ab7e");
            var waterdomain = library.Get<BlueprintFeature>("4c21ad24f55f64d4fb722f40720d9ab0");
            var waterdomainprogressdruid = library.Get<BlueprintProgression>("e48425d6fdafdba449beec54fe158339");
            var waterdomainspelllistfeaturedruid = library.Get<BlueprintFeature>("3a264a4d254827a4298925b32a312994");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            var waterdomainresist = library.Get<BlueprintFeature>("daf27e1f12e736d4294b525489e99de4");
            var greaterdispel = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
            var volcanicstorm = library.Get<BlueprintAbility>("16ce660837fb2544e96c3b7eaad73c63");
            var summonnaturesallyIV = library.Get<BlueprintAbility>("c83db50513abdf74ca103651931fac4b");
            var flamestrikeaiaction = library.Get<BlueprintAiCastSpell>("4f48fd03d530f86439657e4d93bffc89");
            var calllightning = library.Get<BlueprintAbility>("2a9ef0e0b5822a24d88b16673a267456");
            var calllightningstorm = library.Get<BlueprintAbility>("d5a36a7ee8177be4f848b953d1c53c84");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            var empower = library.Get<BlueprintFeature>("a1de1e4f92195b442adb946f0e2b9d4e");
            var burstofnettles = library.Get<BlueprintAbility>("af0092cbb9cacd74aadfe6bf4ebcdebf");
            var flamestrike = library.Get<BlueprintAbility>("f9910c76efc34af41b6e43d5d8752f0f");
            var flurryofsnowballs = library.Get<BlueprintAbility>("390e16e9595f4e4696ca90d18b803092");
            var poxpostules = library.Get<BlueprintAbility>("bc153808ef4884a4594bc9bec2299b69");

            {





                youngersister_barbcamp.AddFacts = youngersister_barbcamp.AddFacts.AddToArray(waterdomainresist,acidarrow,empower);

                var nymphLevels2 = youngersister_barbcamp.ComponentsArray
               .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == nymphclass);
                var newAddClassLevels3 = nymphLevels2.CreateCopy();
                foreach (var selection in newAddClassLevels3.Selections)
                {
                    selection.Features = selection.Features.AddToArray(waterdomain, waterdomainprogressdruid, waterdomainspelllistfeaturedruid);

                }
                youngersister_barbcamp.ReplaceComponent(nymphLevels2, newAddClassLevels3);

                var nymphLevels = youngersister_barbcamp.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels = nymphLevels.CreateCopy();
                newnymphLevels.Levels = 9;
                var spell_list = newnymphLevels.MemorizeSpells.AddToArray(snowball,snowball,flurryofsnowballs,burstofnettles,burstofnettles,poxpostules,poxpostules);
                newnymphLevels.MemorizeSpells = spell_list;
                youngersister_barbcamp.ReplaceComponent(nymphLevels, newnymphLevels);

                var nymphLevels3 = youngersister_barbcamp.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels3 = nymphLevels3.CreateCopy();
                var spell_list2 = newnymphLevels3.MemorizeSpells.RemoveFromArray(summonnaturesallyIV);
                newnymphLevels3.MemorizeSpells = spell_list2;
                youngersister_barbcamp.ReplaceComponent(nymphLevels3, newnymphLevels3);

                var nymphLevels4 = youngersister_barbcamp.ComponentsArray
              .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels4 = nymphLevels4.CreateCopy();
                var spell_list3 = newnymphLevels4.MemorizeSpells.RemoveFromArray(flamestrike);
                newnymphLevels4.MemorizeSpells = spell_list3;
                youngersister_barbcamp.ReplaceComponent(nymphLevels4, newnymphLevels4);

                var auto_metamgic = library.Get<BlueprintFeature>("4250bd8c29ba9dd48a1ad69deca4db40");
                auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.snowball);


                var brain = youngersister_barbcamp.Brain;
                brain.Actions = brain.Actions.RemoveFromArray(flamestrikeaiaction);
                brain.Actions = brain.Actions.AddToArray(
                                                         AiActions.calllightningsister,
                                                         AiActions.castsnowballsister,
                                                         AiActions.castflurryofsnowballs,
                                                         AiActions.castburstofnettles,
                                                         AiActions.castflamestrikesister,
                                                         AiActions.castpoxpostules);
            }
        }

        static void updateBarbarianCamp_SisterFromTomb()

        {

            var nymphclass = library.Get<BlueprintCharacterClass>("9a20b40b57f4e684fa20d17c0edfd5ba");
            var SisterFromTomb_barbcamp = library.Get<BlueprintUnit>("6f700b4b7e1ac984fba3be976113d2aa");
            var waterdomain = library.Get<BlueprintFeature>("4c21ad24f55f64d4fb722f40720d9ab0");
            var waterdomainprogressdruid = library.Get<BlueprintProgression>("e48425d6fdafdba449beec54fe158339");
            var waterdomainspelllistfeaturedruid = library.Get<BlueprintFeature>("3a264a4d254827a4298925b32a312994");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            var waterdomainresist = library.Get<BlueprintFeature>("daf27e1f12e736d4294b525489e99de4");
            var greaterdispel = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
            var volcanicstorm = library.Get<BlueprintAbility>("16ce660837fb2544e96c3b7eaad73c63");
            var summonnaturesallyIV = library.Get<BlueprintAbility>("c83db50513abdf74ca103651931fac4b");
            var flamestrikeaiaction = library.Get<BlueprintAiCastSpell>("4f48fd03d530f86439657e4d93bffc89");
            var calllightning = library.Get<BlueprintAbility>("2a9ef0e0b5822a24d88b16673a267456");
            var calllightningstorm = library.Get<BlueprintAbility>("d5a36a7ee8177be4f848b953d1c53c84");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            var empower = library.Get<BlueprintFeature>("a1de1e4f92195b442adb946f0e2b9d4e");
            var burstofnettles = library.Get<BlueprintAbility>("af0092cbb9cacd74aadfe6bf4ebcdebf");
            var flamestrike = library.Get<BlueprintAbility>("f9910c76efc34af41b6e43d5d8752f0f");
            var flurryofsnowballs = library.Get<BlueprintAbility>("390e16e9595f4e4696ca90d18b803092");
            var poxpostules = library.Get<BlueprintAbility>("bc153808ef4884a4594bc9bec2299b69");

            {

                SisterFromTomb_barbcamp.AddFacts = SisterFromTomb_barbcamp.AddFacts.AddToArray(waterdomainresist, acidarrow, empower);

                var nymphLevels2 = SisterFromTomb_barbcamp.ComponentsArray
               .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == nymphclass);
                var newAddClassLevels3 = nymphLevels2.CreateCopy();
                foreach (var selection in newAddClassLevels3.Selections)
                {
                    selection.Features = selection.Features.AddToArray(waterdomain, waterdomainprogressdruid, waterdomainspelllistfeaturedruid);

                }
                SisterFromTomb_barbcamp.ReplaceComponent(nymphLevels2, newAddClassLevels3);

                var nymphLevels = SisterFromTomb_barbcamp.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels = nymphLevels.CreateCopy();
                newnymphLevels.Levels = 9;
                var spell_list = newnymphLevels.MemorizeSpells.AddToArray(snowball, snowball, flurryofsnowballs, burstofnettles, burstofnettles, poxpostules, poxpostules);
                newnymphLevels.MemorizeSpells = spell_list;
                SisterFromTomb_barbcamp.ReplaceComponent(nymphLevels, newnymphLevels);

                var nymphLevels3 = SisterFromTomb_barbcamp.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels3 = nymphLevels3.CreateCopy();
                var spell_list2 = newnymphLevels3.MemorizeSpells.RemoveFromArray(summonnaturesallyIV);
                newnymphLevels3.MemorizeSpells = spell_list2;
                SisterFromTomb_barbcamp.ReplaceComponent(nymphLevels3, newnymphLevels3);

                var nymphLevels4 = SisterFromTomb_barbcamp.ComponentsArray
              .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == nymphclass);
                var newnymphLevels4 = nymphLevels4.CreateCopy();
                var spell_list3 = newnymphLevels4.MemorizeSpells.RemoveFromArray(flamestrike);
                newnymphLevels4.MemorizeSpells = spell_list3;
                SisterFromTomb_barbcamp.ReplaceComponent(nymphLevels4, newnymphLevels4);

                var auto_metamgic = library.Get<BlueprintFeature>("4250bd8c29ba9dd48a1ad69deca4db40");
                auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.snowball);


                var brain = SisterFromTomb_barbcamp.Brain;
                brain.Actions = brain.Actions.RemoveFromArray(flamestrikeaiaction);
                brain.Actions = brain.Actions.AddToArray(
                                                         AiActions.calllightningsister,
                                                         AiActions.castsnowballsister,
                                                         AiActions.castflurryofsnowballs,
                                                         AiActions.castburstofnettles,
                                                         AiActions.castflamestrikesister,
                                                         AiActions.castpoxpostules);
            }
        }





        static void changeDaemonGuardian()
        {



            var daemonguardian = library.Get<BlueprintUnit>("bd685eb1e99dbb3478bcf3612a8044e0");
            var outsiderclass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var vampireshield = library.Get<BlueprintAbility>("a34921035f2a6714e9be5ca76c5e34b5");

            var vampirictouchastral = library.Get<BlueprintAbility>("5db2468da97174048bfb0b3096d01fd6");

            var energydrain = library.Get<BlueprintAbility>("37302f72b06ced1408bf5bb965766d46");
            var fingerofdeath = library.Get<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe");
            var natarmor12 = library.Get<BlueprintUnitFact>("0b2d92c6aac8093489dfdadf1e448280");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var enervation = library.Get<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var dr5 = library.Get<BlueprintFeature>("f4b3dfedcc150d249be42c0d12302b20");






            daemonguardian.AddFacts = daemonguardian.AddFacts.RemoveFromArray(enervation);
            daemonguardian.AddFacts = daemonguardian.AddFacts.RemoveFromArray(energydrain);
            daemonguardian.AddFacts = daemonguardian.AddFacts.RemoveFromArray(natarmor12);
            daemonguardian.AddFacts = daemonguardian.AddFacts.AddToArray(natarmor14, quicken, toughness, dr5, displacement);

            var outsiderLevels = daemonguardian.ComponentsArray
                       .OfType<AddClassLevels>()
                          .First(c => c.CharacterClass == outsiderclass);
            var newAddClassLevels = outsiderLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            newAddClassLevels.Levels = 18;
            daemonguardian.ReplaceComponent(outsiderLevels, newAddClassLevels);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);







            var brain = daemonguardian.Brain;

            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai, AiActions.castfingerofdeathastraldaemonguard);


        }

        static void changeCephalLorentus()
        {



            var Cephal = library.Get<BlueprintUnit>("bcef8ede9659d704db2d3b40f78cfcd2");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var enervation = library.Get<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var precisebomb = library.Get<BlueprintFeature>("5c396342f614dd644a48c3af08d79701");
            var fastbomb = library.Get<BlueprintFeature>("128c5fccec5ca724281a4907b1f0ac83");
            var fastbombbuff = library.Get<BlueprintBuff>("c42ae8f9652bbc14eb13b31d12d20f8a");
            var blindbomb = library.Get<BlueprintFeature>("c3da68b2222768b4f9352fefd29ad15c");
            var grenadier = library.Get<BlueprintArchetype>("6af888a7800b3e949a40f558ff204aae");
            var preserveorgans = library.Get<BlueprintFeature>("76b4bb8e54f3f5c418f421684c76ef4e");
            var preciseshot = library.Get<BlueprintFeature>("8f3d1e6b4be006f4d896081f2f889665");
            var explosivebombfeature = library.Get<BlueprintFeature>("1d0e812131f345742adca6431d5bc4fe");
            var explosivebombbuff = library.Get<BlueprintBuff>("63063a8ab91bcbc44a13294227580e84");
            var acidbomb = library.Get<BlueprintFeature>("1ee30ffd28843b84282b04e5d4e8bc7b");
            var acidbombbuff = library.Get<BlueprintBuff>("4e15565b830d4b841b59e701d3395371");
            var cursedbombs = library.Get<BlueprintFeature>("bf8f80f3a492e7946924e1cd9c4b0867");
            var GreaterCogIntellBuff = library.Get<BlueprintBuff>("1c2fdba3b33dacd41afd5b74d84c7332");
            var GreaterCogIntell = library.Get<BlueprintAbility>("7fe18aed4a7a8f44289d1b262f432c16");
            var GreaterCogFeature = library.Get<BlueprintFeature>("18eb29676492e844eb5a55d1c855ce69");
            var GreaterMutFeature = library.Get<BlueprintFeature>("76c61966afdd82048911f3d63c6fe0bc");
            var GreaterMutDexBuff = library.Get<BlueprintBuff>("84ae955af09809b4ea31a2c719c68377");
            var GreaterMutDexell = library.Get<BlueprintAbility>("73b97114bf2f9914bba305fc3f032468");
            var infusion = library.Get<BlueprintFeature>("57d5077b301ade749b840b0ea9230bb9");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var heroism = library.Get<BlueprintAbility>("5ab0d42fb68c9e34abae4921822b9d63");
            var extrabomb = library.Get<BlueprintFeature>("54c57ce67fa1d9044b1b3edc459e05e2");



            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");



            Cephal.AddFacts = Cephal.AddFacts.RemoveFromArray(enervation);
            Cephal.AddFacts = Cephal.AddFacts.RemoveFromArray(magearmorbuff);
            Cephal.AddFacts = Cephal.AddFacts.RemoveFromArray(mirrorimage);
            Cephal.AddFacts = Cephal.AddFacts.AddToArray(precisebomb, fastbombbuff, preciseshot, preserveorgans,
                acidbomb, acidbombbuff, cursedbombs, GreaterCogFeature, GreaterCogIntell, GreaterCogIntellBuff, GreaterMutFeature,
                GreaterMutDexell, GreaterMutDexBuff, infusion, displacement, haste, extrabomb, extrabomb);





            var alchemistLevels = Cephal.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            newAddClassLevels.Levels = 16;
            var archetype = newAddClassLevels.Archetypes.AddToArray(grenadier);
            newAddClassLevels.Archetypes = archetype;
            Cephal.ReplaceComponent(alchemistLevels, newAddClassLevels);






            var undeadLevels = Cephal.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels4 = undeadLevels.CreateCopy();
            newAddClassLevels4.Levels = 2;
            Cephal.ReplaceComponent(undeadLevels, newAddClassLevels4);




            Cephal.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("156f5345eaea2a942a98d7526c87ffbc"); //repeatingcrossbow plus 3

            Cephal.Body.PrimaryHandAlternative1 = library.Get<BlueprintItemWeapon>("4b6fe376ec6af3247805fb9aba2665b3"); //staff

            Cephal.Body.Armor = library.Get<BlueprintItemArmor>("91973844b871531419c5aa35afa0b4bb"); //Grenadier




            var brain = Cephal.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.throwcursedbombdeter, AiActions.throwacidbomb, AiActions.casthaste, AiActions.displacement_first, AiActions.castheroism);


        }

        static void changeDreadZombieFighterFerocius()
        {

            var dread_zombie = library.Get<BlueprintUnit>("3fefbe1243265274f89e0280fb87a31b");
            var dread_zombieoldfeature = library.Get<BlueprintFeature>("653d1afcb01ca694a9c867a65efe7f84");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var magusClass = library.Get<BlueprintCharacterClass>("45a4607686d96a1498891b3286121780");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var frigidtouch = library.Get<BlueprintAbility>("b6010dda6333bcf4093ce20f0063cd41");
            var shockinggrasp = library.Get<BlueprintAbility>("ab395d2335d3f384e99dddee8562978f");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var phantasmalkiller = library.Get<BlueprintAbility>("6717dbaef00c0eb4897a1c908a75dfe5");
            var vampirictouch = library.Get<BlueprintAbility>("8a28a811ca5d20d49a863e832c31cce1");
            var StoneskinBuffCL11 = library.Get<BlueprintBuff>("6215b25fbc1a36748b5606ebc0092074");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var catsgrace = library.Get<BlueprintAbility>("de7a025d48ad5da4991e7d3c682cf69d");
            var dimensionstrikefeat = library.Get<BlueprintFeature>("cb6916027e3c25e4185de068249254dc");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var greatcleavefeat = library.Get<BlueprintFeature>("cc9c862ef2e03af4f89be5088851ea35");
            var cleavefeat = library.Get<BlueprintFeature>("d809b6c4ff2aaff4fa70d712a70f7d7b");
            var ImprovedCleavingFinish = library.Get<BlueprintFeature>("ffa1b373190af4f4db7a5501904a1983");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");



            dread_zombie.AddFacts = dread_zombie.AddFacts.AddToArray(StoneskinBuffCL11, dimensionstrikefeat);


            dread_zombie.Strength = 20;


            dread_zombie.Intelligence = 16;

            dread_zombie.LocalizedName = Helpers.Create<SharedStringAsset>(c => c.String = Helpers.CreateString($"{dread_zombie.name}.name", "Dread Zombie Cyclop Lorekeeper"));


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)dread_zombie.AddFacts[0], "dread_lorekeeperfeatures", "f8f00119b6c440c683c6673972a6361b");
            dread_zombie.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var dread_lorekeeperfeatures = library.Get<BlueprintFeature>("f8f00119b6c440c683c6673972a6361b");




            var druidLevels = dread_lorekeeperfeatures.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = druidLevels.CreateCopy();
            newAddClassLevels.Levels = 0;
            dread_lorekeeperfeatures.ReplaceComponent(druidLevels, newAddClassLevels);

            var magusLevels = dread_lorekeeperfeatures.GetComponent<AddClassLevels>();
            var newmagusLevels = magusLevels.CreateCopy();
            newmagusLevels.CharacterClass = library.Get<BlueprintCharacterClass>("45a4607686d96a1498891b3286121780");
            newmagusLevels.Levels = 11;
            foreach (var selection in newmagusLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            dread_lorekeeperfeatures.AddComponent(newmagusLevels);





            var druidLevels2 = dread_lorekeeperfeatures.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == magusClass);
            var newAddClassLevels2 = druidLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(frigidtouch, frigidtouch, frigidtouch, displacement,
                                                                             mirrorimage, shockinggrasp, shockinggrasp, shockinggrasp, phantasmalkiller, vampirictouch, vampirictouch, catsgrace);
            newAddClassLevels2.MemorizeSpells = spell_list;
            dread_lorekeeperfeatures.ReplaceComponent(druidLevels2, newAddClassLevels2);

            var druidLevels4 = dread_lorekeeperfeatures.ComponentsArray
     .OfType<AddClassLevels>()
     .First(c => c.CharacterClass == magusClass);
            var newAddClassLevels4 = druidLevels4.CreateCopy();
            var spell_list4 = newAddClassLevels4.SelectSpells.AddToArray(frigidtouch, displacement, shockinggrasp, phantasmalkiller, vampirictouch, mirrorimage, catsgrace);
            newAddClassLevels4.SelectSpells = spell_list4;
            dread_lorekeeperfeatures.ReplaceComponent(druidLevels4, newAddClassLevels4);




            var undeadLevels = dread_lorekeeperfeatures.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels3 = undeadLevels.CreateCopy();
            newAddClassLevels3.Levels = 2;
            dread_lorekeeperfeatures.ReplaceComponent(undeadLevels, newAddClassLevels3);



            dread_zombie.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2618c8c4e4be9bc48acdbcc7d92d6dc1"); //battleaxe +1


            dread_zombie.AddFacts = dread_zombie.AddFacts.RemoveFromArray(greatcleavefeat);
            dread_zombie.AddFacts = dread_zombie.AddFacts.RemoveFromArray(cleavefeat);
            dread_zombie.AddFacts = dread_zombie.AddFacts.RemoveFromArray(ImprovedCleavingFinish);



            



            var brain = dread_zombie.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castfrigidtouch,AiActions.castphantasmalkiller,AiActions.castvampirictouch,
                                                    AiActions.mirrorimagecyclop,AiActions.displacementvordakai,AiActions.castcatsgrace,AiActions.castshockgrasp,AiActions.usedimensionstrike);


        }

        static void fixThickSkinnedZombieCyclopFighter()
        {
            var thickskinnedzombie = library.Get<BlueprintUnit>("037c02096637e864ebe2da0fc1122f70");
            var oldfeaturelist = library.Get<BlueprintFeature>("653d1afcb01ca694a9c867a65efe7f84");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var weapontrainingaxes = library.Get<BlueprintFeature>("1b18d6a1297950f4bba9d121cfc735e9");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var powerattackfeature = library.Get<BlueprintFeature>("9972f33f977fc724c838e59641b2fca5");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var Alertness = library.Get<BlueprintFeature>("1c04fe9a13a22bc499ffac03e6f79153");
            var cleavefeature = library.Get<BlueprintFeature>("d809b6c4ff2aaff4fa70d712a70f7d7b");
            var greatercleavefeature = library.Get<BlueprintFeature>("cc9c862ef2e03af4f89be5088851ea35");








            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)thickskinnedzombie.AddFacts[0], "thickskinneddreadzombiechanges", "9ed0ada376bd4fe9bb9738f2c72b8f2c");
            thickskinnedzombie.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var thickskinzombiefeatures = library.Get<BlueprintFeature>("9ed0ada376bd4fe9bb9738f2c72b8f2c");



            var fighterLevels = thickskinzombiefeatures.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(weapontrainingaxes,cornugon,dodge,powerattackfeature,toughness,Alertness,cleavefeature,greatercleavefeature);

            }
            thickskinzombiefeatures.ReplaceComponent(fighterLevels, newAddClassLevels);

          

            var undeadLevels = thickskinzombiefeatures.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels2 = undeadLevels.CreateCopy();
            newAddClassLevels2.Levels = 4;
            thickskinzombiefeatures.ReplaceComponent(undeadLevels, newAddClassLevels2);



            var brain = thickskinnedzombie.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);


        }

        static void fixdreadzombieCR8()
        {
            var dreadzombieCR8 = library.Get<BlueprintUnit>("ccc5faf34b4788b429b9dacbfbcfdc43");
            var oldfeaturelist = library.Get<BlueprintFeature>("b813fa8623e6398428e059354ad46204");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var weapontrainingaxes = library.Get<BlueprintFeature>("1b18d6a1297950f4bba9d121cfc735e9");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)dreadzombieCR8.AddFacts[0], "dreadzombieCR8changes", "785bfc33d03a404e827a0bfe7bf27ca0");
            dreadzombieCR8.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var dreadzombieCR8features = library.Get<BlueprintFeature>("785bfc33d03a404e827a0bfe7bf27ca0");





            var fighterLevels = dreadzombieCR8features.GetComponent<AddClassLevels>();
            var newfighterLevels = fighterLevels.CreateCopy();
            newfighterLevels.CharacterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            newfighterLevels.Levels = 8;
            foreach (var selection in newfighterLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(weapontrainingaxes);

            }
            dreadzombieCR8features.AddComponent(newfighterLevels);



            var undeadLevels = dreadzombieCR8features.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels2 = undeadLevels.CreateCopy();
            newAddClassLevels2.Levels = 4;
            dreadzombieCR8features.ReplaceComponent(undeadLevels, newAddClassLevels2);



            var brain = dreadzombieCR8.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);


        }

        static void fixdreadzombieCR9()
        {
            var dreadzombieCR9 = library.Get<BlueprintUnit>("8d03bafee9a97b84a97ab85275b1e74a");
            var oldfeaturelist = library.Get<BlueprintFeature>("b813fa8623e6398428e059354ad46204");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var weapontrainingaxes = library.Get<BlueprintFeature>("1b18d6a1297950f4bba9d121cfc735e9");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)dreadzombieCR9.AddFacts[0], "dreadzombieCR9changes", "89fb0e51c04040068f5ba5407fb23ab0");
            dreadzombieCR9.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var dreadzombieCR8features = library.Get<BlueprintFeature>("89fb0e51c04040068f5ba5407fb23ab0");



            var fighterLevels = dreadzombieCR8features.GetComponent<AddClassLevels>();
            var newfighterLevels = fighterLevels.CreateCopy();
            newfighterLevels.CharacterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            newfighterLevels.Levels = 8;
            foreach (var selection in newfighterLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(weapontrainingaxes);

            }
            dreadzombieCR8features.AddComponent(newfighterLevels);




            var undeadLevels = dreadzombieCR8features.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels2 = undeadLevels.CreateCopy();
            newAddClassLevels2.Levels = 4;
            dreadzombieCR8features.ReplaceComponent(undeadLevels, newAddClassLevels2);



            var brain = dreadzombieCR9.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);


        }

        static void fixdreadgreaterbarbarian()
        {
            var dreadgreaterbarbarian = library.Get<BlueprintUnit>("ce2d24dec712e094d94c336053abeb57");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var guardedstance = library.Get<BlueprintFeature>("efb97e482f53f064dab85a9eeaf01085");
            var protectvitals = library.Get<BlueprintFeature>("efd53fe2887c3a54d86b99f4bba61dd6");
            var lesseratavismtotem = library.Get<BlueprintFeature>("ecbb5b8b2c354ee89949f8f163982ef7");
            var lesseratavismtotembuff = library.Get<BlueprintBuff>("3858dd3e9a94f0b41abdc58387d68ccf");



            dreadgreaterbarbarian.Strength = 34;


            dreadgreaterbarbarian.AddFacts = dreadgreaterbarbarian.AddFacts.AddToArray(lesseratavismtotembuff);


            var fighterLevels = dreadgreaterbarbarian.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 13;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(guardedstance,protectvitals,lesseratavismtotem);

            }
            dreadgreaterbarbarian.ReplaceComponent(fighterLevels, newAddClassLevels);



            var undeadLevels = dreadgreaterbarbarian.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels2 = undeadLevels.CreateCopy();
            newAddClassLevels2.Levels = 4;
            dreadgreaterbarbarian.ReplaceComponent(undeadLevels, newAddClassLevels2);



            var brain = dreadgreaterbarbarian.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);


        }

        static void fixDreadZombieCleric()
        {
            var cleric = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var dread_cleric = library.Get<BlueprintUnit>("fe662d20a0272bb4ea66bef675b4b52d");
            var unit = library.Get<BlueprintFeature>("82662ebad000b1349baf02e2f8e86748");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var boneshaker = library.Get<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
            var hold_person = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var inflictmoderatewoundmass = library.Get<BlueprintAbility>("03944622fbe04824684ec29ff2cec6a7");
            var darknessdomain = library.Get<BlueprintFeature>("9dc5863168155854fa8daf4a780f6663");
            var darknessdomainprog = library.Get<BlueprintProgression>("1e1b4128290b11a41ba55280ede90d7d");
            var DarknessDomainSpellListFeature = library.Get<BlueprintFeature>("e931fdb1aa59d2c4fac3d32634b983e5");
            var umbralstrike = library.Get<BlueprintAbility>("474ed0aa656cc38499cc9a073d113716");
            var DarknessDomainSpellList = library.Get<BlueprintSpellList>("fa79e8d1fe20b0e43bf3ebca4cef93b9");
            var constrictingcoils = library.Get<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
            var bullstrength = library.Get<BlueprintAbility>("4c3d08935262b6544ae97599b3a9556d");
            var holdpersonai = library.Get<BlueprintAiCastSpell>("093e88ae36b09d941aee8c1d4d628156");
            var bullsmass = library.Get<BlueprintAbility>("6a234c6dcde7ae94e94e9c36fd1163a7");


            var add_class_levels = dread_cleric.GetComponent<AddAbilityToCharacterComponent>();

            var ability_list = add_class_levels.Abilities.RemoveFromArray(hold_person);

            add_class_levels.Abilities = ability_list;


            var clericLevels2 = unit.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == cleric);
            var newAddClassLevels3 = clericLevels2.CreateCopy();
            foreach (var selection in newAddClassLevels3.Selections)
            {
                selection.Features = selection.Features.AddToArray(darknessdomain, darknessdomainprog, DarknessDomainSpellListFeature);

            }
            unit.ReplaceComponent(clericLevels2, newAddClassLevels3);

            var clericLevels = unit.ComponentsArray
    .OfType<AddClassLevels>()
    .First(c => c.CharacterClass == cleric);
            var newclericLevels = clericLevels.CreateCopy();
            newclericLevels.Levels = 12;
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(boneshaker, boneshaker,
                inflictmoderatewoundmass, umbralstrike, constrictingcoils, constrictingcoils, bullsmass);
            newclericLevels.MemorizeSpells = spell_list;
            unit.ReplaceComponent(clericLevels, newclericLevels);

            var clericLevels5 = unit.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == cleric);
            var newclericLevels5 = clericLevels5.CreateCopy();
            var spell_list5 = newclericLevels5.MemorizeSpells.RemoveFromArray(bullstrength);
            newclericLevels5.MemorizeSpells = spell_list5;
            unit.ReplaceComponent(clericLevels5, newclericLevels5);

            var undeadLevels = unit.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels2 = undeadLevels.CreateCopy();
            newAddClassLevels2.Levels = 4;
            unit.ReplaceComponent(undeadLevels, newAddClassLevels2);



            var brain = dread_cleric.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(holdpersonai);
            brain.Actions = brain.Actions.AddToArray(
                                                     AiActions.castboneshaker,
                                                     AiActions.castmoonfire,
                                                     AiActions.inflictmoderatemass,
                                                     AiActions.holdpersondelay,
                                                     AiActions.constrictingcoilszombie,
                                                     AiActions.castbullsmass);


        }

        static void fixundeadcyclopspriest()
        {

            var dread_cleric = library.Get<BlueprintUnit>("f0a4efcaa7173bd43ba7fcf1f576e484");

            var hold_person = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");



            var add_class_levels = dread_cleric.GetComponent<AddAbilityToCharacterComponent>();

            var ability_list = add_class_levels.Abilities.RemoveFromArray(hold_person);

            add_class_levels.Abilities = ability_list;


        }

        static void updateHoragnamon()
        {
            var animal = library.Get<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");
            var Horag = library.Get<BlueprintUnit>("b99ff85753335824885876f8e5ea8e4c");
            var unit = library.Get<BlueprintFeature>("d241d8ea987476c438db67fe24ae04d3");




            var animalLevels = unit.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == animal);
            var newanimalLevels = animalLevels.CreateCopy();
            newanimalLevels.Levels = 16;
            unit.ReplaceComponent(animalLevels, newanimalLevels);

      


        }

        static void updateVordakai()


        {

            var vordakai_feature = library.Get<BlueprintFeature>("1e873037c4cc3804abcfb7ea369e59aa");
            var vordakai_spells = library.Get<BlueprintFeature>("b3f49646e5c68124db58fbcabbde5a28");
            var vordakai = library.Get<BlueprintUnit>("f66d7df4dc3c7e04d9f357935e95f9e9");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var summon_monster_8 = library.Get<BlueprintAbility>("d3ac756a229830243a72e84f3ab050d0");
            var horrid_wilting = library.Get<BlueprintAbility>("08323922485f7e246acb3d2276515526");
            var summoncyclops = library.Get<BlueprintAbility>("4089fb0f36bb4ca2a459a4420279ff87");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var dr5 = library.Get<BlueprintFeature>("f4b3dfedcc150d249be42c0d12302b20");
            var greaterdispel = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
            var slow = library.Get<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
            var VampiricTouchCast = library.Get<BlueprintAbility>("8a28a811ca5d20d49a863e832c31cce1");
            var magearmor = library.Get<BlueprintAbility>("9e1ad5d6f87d19e4d8883d63a6e35568");
            var fingerofdeath = library.Get<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe");



            {

                vordakai.MaxHP = 1;
                vordakai.AddFacts = vordakai.AddFacts.AddToArray(quicken,summoncyclops,dr5);
              


                var wizardLevels = vordakai_feature.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
                var newwizardLevels = wizardLevels.CreateCopy();
                newwizardLevels.Levels = 16;
                var spell_list = newwizardLevels.MemorizeSpells.AddToArray(summon_monster_8,horrid_wilting,displacement,greaterdispel,slow,slow,fingerofdeath,fingerofdeath,magearmor);
                newwizardLevels.MemorizeSpells = spell_list;
                vordakai_feature.ReplaceComponent(wizardLevels, newwizardLevels);

                var wizardLevels2 = vordakai_spells.ComponentsArray
                   .OfType<LearnSpells>()
                   .First(c => c.CharacterClass == wizardClass);
                var newwizardLevels2 = wizardLevels2.CreateCopy();
                var spell_list2 = newwizardLevels2.Spells.AddToArray(summon_monster_8,horrid_wilting,displacement,greaterdispel,slow,slow, fingerofdeath, fingerofdeath,magearmor);
                newwizardLevels2.Spells = spell_list2;
                vordakai_spells.ReplaceComponent(wizardLevels2, newwizardLevels2);

                var wizardLevels3 = vordakai_feature.ComponentsArray
    .OfType<AddClassLevels>()
    .First(c => c.CharacterClass == wizardClass);
                var newwizardLevels3 = wizardLevels3.CreateCopy();
                var spell_list3 = newwizardLevels3.MemorizeSpells.RemoveFromArray(VampiricTouchCast);
                newwizardLevels3.MemorizeSpells = spell_list3;
                vordakai_feature.ReplaceComponent(wizardLevels3, newwizardLevels3);

                var wizardLevels4 = vordakai_feature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
                var newwizardLevels4 = wizardLevels4.CreateCopy();
                var spell_list4 = newwizardLevels4.MemorizeSpells.RemoveFromArray(VampiricTouchCast);
                newwizardLevels4.MemorizeSpells = spell_list4;
                vordakai_feature.ReplaceComponent(wizardLevels4, newwizardLevels4);

                var undeadLevels = vordakai_feature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == undeadClass);
                var newAddClassLevels2 = undeadLevels.CreateCopy();
                newAddClassLevels2.Levels = 8;
                vordakai_feature.ReplaceComponent(undeadLevels, newAddClassLevels2);

                var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
                auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);
                auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.magearmor);


                var ai_action = library.CopyAndAdd<BlueprintAiCastSpell>("7768e7b1d652b1545940c4f7426f3c2a", "LostlarnGhostMage_SummonMonsterVIII_AiAction", "");
                var ai_action2 = library.CopyAndAdd<BlueprintAiCastSpell>("4e7b7b939da6de14491c687409adcdf1", "FingerOfDeathVordakaiAIAction", "");
                var brain = vordakai.Brain;
                brain.Actions = brain.Actions.RemoveFromArray(ai_action2);
                brain.Actions = brain.Actions.AddToArray(AiActions.summoncyclops,AiActions.horridwilting,
                    AiActions.displacementvordakai,AiActions.greaterdispelvordakai, AiActions.castslowvordakai,AiActions.castmagearmorvordakai,AiActions.castfingerofdeathvordakai);

                



            }
        }

        //CHAPTER 4


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
            var neutralfaction = library.Get<BlueprintFaction>("d8de50cc80eb4dc409a983991e0b77ad");
            




            cleric_gorum.AddFacts = cleric_gorum.AddFacts.AddToArray(quicken);
            cleric_gorum.FactionOverrides.AttackFactionsToRemove = cleric_gorum.FactionOverrides.AttackFactionsToRemove.AddToArray(neutralfaction);


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
            newclericLevels.Levels = 14;
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(searing_light, heal, hellfireray, constrictingcoils);
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
            brain.Actions = brain.Actions.AddToArray(ai_action, ai_action2, AiActions.hellfire_ray, AiActions.constrictingcoils,AiActions.castcommand);






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


        static void updateArmag()
        {
            
            
            var armag = library.Get<BlueprintUnit>("0c5fbd2adcf609b45b91455bf7b68b35");
            var summonclerics = library.Get<BlueprintAbility>("5a1c766d3a5948bf98001e417e76ef0d");


            
            armag.AddFacts = armag.AddFacts.AddToArray(summonclerics);

           var brain = armag.Brain;
           brain.Actions = brain.Actions.AddToArray(AiActions.summonclerics);

        }


        //CHAPTER 5

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
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);


        }

        static void changeriverbladetransmuter()
        {



            var riverbladestransmuter = library.Get<BlueprintUnit>("788603e0561b435eacdcaf510efb78cb");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)riverbladestransmuter.AddFacts[0], "RiverBladeTransmuterFeatures", "0ed35cf630884e5db43ca51292ea7b25");
            riverbladestransmuter.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var RiverBladeTransmuterFeatures = library.Get<BlueprintFeature>("0ed35cf630884e5db43ca51292ea7b25");





            var wizardLevels = RiverBladeTransmuterFeatures.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == wizardClass);
            var newwizardLevels = wizardLevels.CreateCopy();
            newwizardLevels.Levels = 18;
            RiverBladeTransmuterFeatures.ReplaceComponent(wizardLevels, newwizardLevels);




        }

        

        //CHAPTER 6

        static void updateWrigglingMan()
        {


            var vermin = library.Get<BlueprintCharacterClass>("d1a15612d1a96334d94edf5f1d3b8d29");
            var wrigglingman = library.Get<BlueprintUnit>("baf4cbd8e093b314ea73b9315551af33");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var wizardclass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var fireball = library.Get<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3");
            var fireresist15 = library.Get<BlueprintFeature>("24700a71dd3dc844ea585345f6dd18f6");
            var greatfortitude  = library.Get<BlueprintFeature>("79042cb55f030614ea29956177977c52");
            var dr15 = library.Get<BlueprintFeature>("a1477ed71c2329d4088192cac8d4e3bd");
            

       
            wrigglingman.AddFacts = wrigglingman.AddFacts.AddToArray(fireresist15,dr15);
            

            wrigglingman.Constitution = 14;
            wrigglingman.Intelligence = 24;
            wrigglingman.Dexterity = 18;





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

            var wizardLevels4 = wrigglingman.ComponentsArray
    .OfType<AddClassLevels>()
    .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels4 = wizardLevels4.CreateCopy();
            foreach (var selection in newAddClassLevels4.Selections)
            {
                selection.Features = selection.Features.RemoveFromArray(greatfortitude);

            }
            wrigglingman.ReplaceComponent(wizardLevels4, newAddClassLevels4);

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








        //Magical Prison Encounters

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
            brain.Actions = brain.Actions.AddToArray(AiActions.umbral_strike,AiActions.trueseeing);



           
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


            evil_druid.Prefab = new UnitViewLink() { AssetId = "ef812b46145eada41980f6c97cd7e56b" };

            


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

            var outsiderLevels = wicked_omen.ComponentsArray
           .OfType<AddClassLevels>()
              .First(c => c.CharacterClass == outsiderclass);
            var newAddClassLevels = outsiderLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            newAddClassLevels.Levels = 18;
            wicked_omen.ReplaceComponent(outsiderLevels, newAddClassLevels);





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

            patient_shadow.AddFacts = patient_shadow.AddFacts.RemoveFromArray(natarmor14);
            patient_shadow.AddFacts = patient_shadow.AddFacts.AddToArray(natarmor18, quicken, trueseeing);




            patient_shadow.Charisma = 1;
            patient_shadow.Intelligence = 30;
            patient_shadow.Constitution = 30;
            patient_shadow.Strength = 28;

            var outsiderLevels = patient_shadow.ComponentsArray
                       .OfType<AddClassLevels>()
                          .First(c => c.CharacterClass == outsiderclass);
            var newAddClassLevels = outsiderLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            newAddClassLevels.Levels = 20;
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
            brain.Actions = brain.Actions.AddToArray(AiActions.frightfulaspect, AiActions.bansheeblast);





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


        //Tenebrious Depths

        static void updatespawnofrovagug()

        {

            var spawnofrovagug = library.Get<BlueprintUnit>("b9f65b155af23ac4e8687101d0b6377c");
            var deflectionarmor6 = library.Get<BlueprintUnitFact>("a7771abd8ff02124dbbc0e1936992b7b");
            var deflectionarmor15 = library.Get<BlueprintUnitFact>("ff6bc97b289d73044ba244872df8f120");
            var natarmor26 = library.Get<BlueprintUnitFact>("6f92384d2a6de5f4799b100571570f01");
            var natarmor19 = library.Get<BlueprintUnitFact>("fa6089e0f74bb5e4c9ff9025f2d00cbc");



            spawnofrovagug.AddFacts = spawnofrovagug.AddFacts.RemoveFromArray(deflectionarmor6);
            spawnofrovagug.AddFacts = spawnofrovagug.AddFacts.RemoveFromArray(natarmor26);
            spawnofrovagug.AddFacts = spawnofrovagug.AddFacts.AddToArray(deflectionarmor15, natarmor19);


            
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
