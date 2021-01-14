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
        static Consideration TargetOther = library.Get<TargetSelfConsideration>("f4be6fc6f46b61044a44715f99f1918d");
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
        static Consideration NoBuffHoldMonster = library.Get<BuffConsideration>("e937ffe62a732c04c9bff79276e4de05");
        static Consideration NoBuffCrushingDespair = library.Get<BuffConsideration>("755cb11326d32854d958c7c001712d95");
        static Consideration TouchInMeleeConsideration = library.Get<InRangeConsideration>("9928ebc923fca0744ba6ef1947d5e027");
        static Consideration NoBuffReducePerson = library.Get<BuffConsideration>("f92e863a3106a6f4b8cd7088df916725");
        static Consideration NoBuffsickened = library.Get<BuffConsideration>("96c6d0223d81012499b14fd16645f5c8");
        static Consideration NoBuffSunder = library.Get<BuffConsideration>("b11013b50f1c48a41af0ebe377601089");
        static Consideration AlliesNoBuff_OwlsWisdom = library.Get<BuffsAroundConsideration>("0914ece191a2cde44a319df8ed5a7e33");
        static Consideration NoBuffBullStrength = library.Get<BuffConsideration>("8196fc3abebf54749b0e9fce09a63b97");
        static Consideration AlliesNoBuff_EnlargePerson = library.Get<BuffsAroundConsideration>("b72a7de89582d4d48ab8eda367b2e282");
        static Consideration NoBuffMirrorImage = library.Get<BuffConsideration>("db074912aa8072c469b527f6c111e82c");
        static Consideration NoBuffBalefulPolymorph = library.Get<BuffConsideration>("881bcb09ccf53074d88c5dec9f2fcaa9");
        static Consideration InjuryAround = library.Get<HealthAroundConsideration>("2a2cfff1d585f3142aadaafe0c1a74e6");
        static Consideration NoBuffShieldofFaith = library.Get<BuffConsideration>("14698bcd142fb924bbb912d57c3fe712");
        static Consideration NoBuffInvisibilityGreater = library.Get<BuffConsideration>("2fc05579e43f56146a1cdaaa82e5119c");
        static Consideration AlliesNoBuff_Aid = library.Get<BuffsAroundConsideration>("d0abaad453732d040a035eb85f9d96af");
        static Consideration NoBuffShaken = library.Get<BuffConsideration>("e2ec459247a67e444a89da48e3f02005");
        static Consideration NoBuffFrightened = library.Get<BuffConsideration>("79e318942b12b8443b30e05e7f9198ce");
        static Consideration NoCaster = library.Get<FactConsideration>("22d91eb7dceec4249810c476ab7d5a56");
        static Consideration NoBuffInsanity = library.Get<BuffConsideration>("07683df074e29a54f803fab3500187ae");
        static Consideration NoBuffConfusion = library.Get<BuffConsideration>("ae9a969accfe096438bbe83e0c05e086");
        static Consideration NoBuffOverwhelmingGrief = library.Get<BuffConsideration>("5299d9a6db21c7e49bb03b314976c806");
        static Consideration AlliesNoBuff_FreedomOfMovement = library.Get<BuffsAroundConsideration>("ce945999d5ae86946922515e330dd256");
        static Consideration AnimalConsideration = library.Get<TargetClassConsideration>("ae38d3f18cc6265478f2df0917f6880c");



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
            public static BlueprintAbility summonelementalmediumfire = library.Get<BlueprintAbility>("7b30211b83d55194db872b6c9c0d9cc1");
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
            public static BlueprintAbility chokebomb = library.Get<BlueprintAbility>("0fcbed386deb18b428825605796d5a15");
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
            public static BlueprintAbility dragonsbreathgold = library.Get<BlueprintAbility>("e6f5453df86bd714fa33b14c994739f3");
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
            public static BlueprintAbility summonelementalgreatwater = library.Get<BlueprintAbility>("cfa3ff71a42ab8a4c8a8a4b5db3f04d4");
            public static BlueprintAbility summonelementalhuge = library.Get<BlueprintAbility>("766ec978fa993034f86a372c8eb1fc10");
            public static BlueprintAbility summonelementalhugeair = library.Get<BlueprintAbility>("2c26e78ca33e83843b1aa3f6783877bd");
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
            public static BlueprintAbility summonghosts2 = library.Get<BlueprintAbility>("2cbda65cde8f462baf8994af02854d4e");
            public static BlueprintAbility summonundeadfriends = library.Get<BlueprintAbility>("119a6fc4756c45a7a329859f030836c2");
            public static BlueprintAbility wavesoffatigue = library.Get<BlueprintAbility>("8878d0c46dfbd564e9d5756349d5e439");
            public static BlueprintAbility blindness = library.Get<BlueprintAbility>("46fd02ad56c35224c9c91c88cd457791");
            public static BlueprintAbility crushingdespair = library.Get<BlueprintAbility>("4baf4109145de4345861fe0f2209d903");
            public static BlueprintAbility summonelementallarge = library.Get<BlueprintAbility>("89404dd71edc1aa42962824b44156fe5");
            public static BlueprintAbility summonelementallargeair = library.Get<BlueprintAbility>("16fff43f034133a4a86e914a523e021f");
            public static BlueprintAbility slayliving = library.Get<BlueprintAbility>("4fbd47525382517419c66fb548fe9a67");
            public static BlueprintAbility bane = library.Get<BlueprintAbility>("8bc64d869456b004b9db255cdd1ea734");
            public static BlueprintAbility explosivebomb = library.Get<BlueprintAbility>("2b76e3bd89b4fa0419853a69fec0785f");
            public static BlueprintAbility standartbomb = library.Get<BlueprintAbility>("5fa0111ac60ed194db82d3110a9d0352");
            public static BlueprintAbility reduceperson = library.Get<BlueprintAbility>("4e0e9aba6447d514f88eff1464cc4763");
            public static BlueprintAbility dispel = library.Get<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
            public static BlueprintAbility dispeltarget = library.Get<BlueprintAbility>("143775c49ae6b7446b805d3b2e702298");
            public static BlueprintAbility rayofsickening = library.Get<BlueprintAbility>("fa3078b9976a5b24caf92e20ee9c0f54");
            public static BlueprintAbility sunderarmor = library.Get<BlueprintAbility>("fa9bfb9fd997faf49a108c4b17a00504");
            public static BlueprintAbility web = library.Get<BlueprintAbility>("134cb6d492269aa4f8662700ef57449f");
            public static BlueprintAbility acidicspray = library.Get<BlueprintAbility>("c543eef6d725b184ea8669dd09b3894c");
            public static BlueprintAbility coneofcold = library.Get<BlueprintAbility>("e7c530f8137630f4d9d7ee1aa7b1edc0");
            public static BlueprintAbility spikestones = library.Get<BlueprintAbility>("d1afa8bc28c99104da7d784115552de5");
            public static BlueprintAbility burningarc = library.Get<BlueprintAbility>("eaac3d36e0336cb479209a6f65e25e7c");
            public static BlueprintAbility fireball = library.Get<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3");
            public static BlueprintAbility soundburst = library.Get<BlueprintAbility>("c3893092a333b93499fd0a21845aa265");
            public static BlueprintAbility owlswisdom = library.Get<BlueprintAbility>("f0455c9295b53904f9e02fc571dd2ce1");
            public static BlueprintAbility EnlargePersonMass = library.Get<BlueprintAbility>("66dc49bf154863148bd217287079245e");
            public static BlueprintAbility WildshapeBear = library.Get<BlueprintAbility>("3f7873efe4ca499bae86489d1d993442");
            public static BlueprintAbility bullsstrength = library.Get<BlueprintAbility>("4c3d08935262b6544ae97599b3a9556d");
            public static BlueprintAbility phantasmalweb = library.Get<BlueprintAbility>("12fb4a4c22549c74d949e2916a2f0b6a");
            public static BlueprintAbility balefulpolymorph = library.Get<BlueprintAbility>("3105d6e9febdc3f41a08d2b7dda1fe74");
            public static BlueprintAbility summonmonsterIV = library.Get<BlueprintAbility>("7ed74a3ec8c458d4fb50b192fd7be6ef");
            public static BlueprintAbility summonmonsterIVsingle = library.Get<BlueprintAbility>("efa433a38e9c7c14bb4e780f8a3fe559");
            public static BlueprintAbility channelnegativeenergyharmbase = library.Get<BlueprintAbility>("1daa4e1ca1d24a14a36e4b3f20b27985");
            public static BlueprintAbility channelnegativeenergy = library.Get<BlueprintAbility>("89df18039ef22174b81052e2e419c728");
            public static BlueprintAbility channelpositivehealbase = library.Get<BlueprintAbility>("507ba29b9238431baf0ff39c215b5899");
            public static BlueprintAbility channelpositiveenergy = library.Get<BlueprintAbility>("f5fc9a1a2a3c1a946a31b320d1dd31b2");
            public static BlueprintAbility searing_light = library.Get<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
            public static BlueprintAbility shieldoffaith = library.Get<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
            public static BlueprintAbility InvisibilityGreater = library.Get<BlueprintAbility>("ecaa0def35b38f949bd1976a6c9539e0");
            public static BlueprintAbility fester = library.Get<BlueprintAbility>("2dbe271c979d9104c8e2e6b42e208e32");
            public static BlueprintAbility aid = library.Get<BlueprintAbility>("03a9630394d10164a9410882d31572f0");
            public static BlueprintAbility serenity = library.Get<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7");
            public static BlueprintAbility boneshatter = library.Get<BlueprintAbility>("f2f1efac32ea2884e84ecaf14657298b");
            public static BlueprintAbility causefear = library.Get<BlueprintAbility>("bd81a3931aa285a4f9844585b5d97e51");
            public static BlueprintAbility colorspray = library.Get<BlueprintAbility>("91da41b9793a4624797921f221db653c");
            public static BlueprintAbility auraofdoom = library.Get<BlueprintAbility>("3244b350df4c474084de760c2aaf7974");
            public static BlueprintAbility confusion = library.Get<BlueprintAbility>("cf6c901fb7acc904e85c63b342e9c949");
            public static BlueprintAbility overwhelminggrief = library.Get<BlueprintAbility>("dd2918e4a77c50044acba1ac93494c36");
            public static BlueprintAbility greatershout = library.Get<BlueprintAbility>("fd0d3840c48cafb44bb29e8eb74df204");
            public static BlueprintAbility icyprison = library.Get<BlueprintAbility>("65e8d23aef5e7784dbeb27b1fca40931");
            public static BlueprintAbility profanenimbus = library.Get<BlueprintAbility>("b56521d58f996cd4299dab3f38d5fe31");
            public static BlueprintAbility wildshapesmilodon = library.Get<BlueprintAbility>("32f1f208ad635224f89ef158140ab509");
            public static BlueprintAbility greatermagicfang = library.Get<BlueprintAbility>("f1100650705a69c4384d3edd88ba0f52");
            public static BlueprintAbility thornbody = library.Get<BlueprintAbility>("2daf9c5112f16d54ab3cd6904c705c59");
            public static BlueprintAbility aspectofthewolf = library.Get<BlueprintAbility>("6126b36fe22291543ad72f8b9f0d53a7");
            public static BlueprintAbility aspectofthebear = library.Get<BlueprintAbility>("a4ad1b8fa11e7c347a608c004efce9d5");
            public static BlueprintAbility calllightningstorm = library.Get<BlueprintAbility>("d5a36a7ee8177be4f848b953d1c53c84");
            public static BlueprintAbility calllightningstormlightning = library.Get<BlueprintAbility>("cad052ef098f9f247ab73ae4c37ac687");
            public static BlueprintAbility freedomofmovement = library.Get<BlueprintAbility>("0087fc2d64b6095478bc7b8d7d512caf");
            public static BlueprintAbility animalgrowth = library.Get<BlueprintAbility>("56923211d2ac95e43b8ac5031bab74d8");
            public static BlueprintAbility instantenemy = library.Get<BlueprintAbility>("42c78009dd5cb8e429b27c13d92152b7");
            public static BlueprintAbility quarry = library.Get<BlueprintAbility>("e93dfca6f025e6d4e9583e688c147aca");
           
        }



        static class AiActions
        {
            static public BlueprintAiCastSpell cape_of_wasps_cast_first = createCastSpellAction("CastCapeOfWaspsBuff", Spells.cape_of_wasps,
                                                                                     new Consideration[] { },
                                                                                     new Consideration[] { },
                                                                                     base_score: 10.0f, combat_count: 1);


            static public BlueprintAiCastSpell castanimalgrowth = createCastSpellAction("CastAnimalGrowth", Spells.animalgrowth,
                                                                         new Consideration[] { },
                                                                         new Consideration[] {AnimalConsideration },
                                                                         base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell usequarry = createCastSpellAction("CastQuarry", Spells.quarry,
                                                                        new Consideration[] { },
                                                                        new Consideration[] { attacktargetspriority },
                                                                        base_score: 20.0f, cooldown_rounds: 4);

            static public BlueprintAiCastSpell castgreatermagicfang = createCastSpellAction("castgreatermagicfang", Spells.greatermagicfang,
                                                                         new Consideration[] { },
                                                                         new Consideration[] {TargetSelf },
                                                                         base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell castthornbody = createCastSpellAction("castthornbody", Spells.thornbody,
                                                             new Consideration[] { },
                                                             new Consideration[] { },
                                                             base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell castspikestones = createCastSpellAction("castspikestones", Spells.spikestones,
                                                 new Consideration[] { },
                                                 new Consideration[] { attacktargetspriority,AOE_ChooseMoreEnemies},
                                                 base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell castaspectwolf = createCastSpellAction("castaspectwolf", Spells.aspectofthewolf,
                                                 new Consideration[] { },
                                                 new Consideration[] { },
                                                 base_score: 10.0f, combat_count: 1);


            static public BlueprintAiCastSpell castaspectbear = createCastSpellAction("castaspectbear", Spells.aspectofthebear,
                                                 new Consideration[] { },
                                                 new Consideration[] {TargetSelf },
                                                 base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell castfreedomofmovement = createCastSpellAction("castfreedomofmovement", Spells.freedomofmovement,
                                     new Consideration[] { AlliesNoBuff_FreedomOfMovement},
                                     new Consideration[] { TargetSelf },
                                     base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell castauraofdoom = createCastSpellAction("CastAuraodDoom", Spells.auraofdoom,
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
                                                                                     new Consideration[] { NoBuffDisplacement, TargetSelf },
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

            static public BlueprintAiCastSpell castcausefeardelay = createCastSpellAction("castcausefeardelay", Spells.causefear,
  new Consideration[] { },
  new Consideration[] { attacktargetspriority,NoBuffShaken,NoBuffFrightened,NoCaster},
  base_score: 10.0f, combat_count: 1, cooldown_rounds: 2, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell castfearwitch = createCastSpellAction("CastFearwitch", Spells.fear,
  new Consideration[] { },
  new Consideration[] { AOE_ChooseMoreEnemies },
  base_score: 10.0f, cooldown_rounds: 2, start_cooldown_rounds: 5);


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
                new Consideration[] {NoBuffMirrorImage },
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

            static public BlueprintAiCastSpell summonelementalmediumfire = createCastSpellAction("CastSummonelementalfire", Spells.summonelementalmedium,
    new Consideration[] { },
    new Consideration[] { },
    base_score: 20.0f, variant: Spells.summonelementalmediumfire, combat_count: 1);

            static public BlueprintAiCastSpell summonelementalhugeair = createCastSpellAction("summonelementalhugeair", Spells.summonelementalhuge,
new Consideration[] { },
new Consideration[] { },
base_score: 40.0f, variant: Spells.summonelementalhugeair, combat_count: 1);

            static public BlueprintAiCastSpell stonecall = createCastSpellAction("Caststonecall", Spells.stonecall,
                 new Consideration[] { },
                 new Consideration[] { AOE_ChooseMoreEnemies },
                 base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell calllightningthirdturn = createCastSpellAction("calllightningthirdturn", Spells.calllightning,
                 new Consideration[] { },
                 new Consideration[] { attacktargetspriority},
                base_score: 3.0f, combat_count: 2, cooldown_rounds: 1, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell calllightningstorm = createCastSpellAction("calllightningstorm", Spells.calllightningstorm,
     new Consideration[] { },
     new Consideration[] { attacktargetspriority },
    base_score: 3.0f,  cooldown_rounds: 1, start_cooldown_rounds: 4);

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
                              base_score: 60.0f, combat_count: 1);

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
            base_score: 20.0f, combat_count: 4, start_cooldown_rounds: 1, cooldown_rounds: 1);

            static public BlueprintAiCastSpell castsearinglight = createCastSpellAction("castsearinglight", Spells.searing_light,
                new Consideration[] { },
                new Consideration[] { attacktargetspriority },
                base_score: 20.0f, combat_count: 4, start_cooldown_rounds: 2, cooldown_rounds: 1);

            static public BlueprintAiCastSpell summoncyclops = createCastSpellAction("Castsummoncyclops", Spells.summoncyclops,
            new Consideration[] { },
            new Consideration[] { },
            base_score: 20.0f, combat_count: 2, cooldown_rounds: 12);

            static public BlueprintAiCastSpell throwblindbomb = createCastSpellAction("throwblindbomb", Spells.blindbomb,
            new Consideration[] { },
             new Consideration[] { AOE_ChooseMoreEnemies },
            base_score: 20.0f, combat_count: 2, cooldown_rounds: 4, start_cooldown_rounds: 1);

            static public BlueprintAiCastSpell throwchokebomb = createCastSpellAction("throwchokebomb", Spells.chokebomb,
new Consideration[] { },
 new Consideration[] { AOE_ChooseMoreEnemies },
base_score: 20.0f, combat_count: 2, cooldown_rounds: 4, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell casthaste = createCastSpellAction("casthaste", Spells.haste,
            new Consideration[] { },
            new Consideration[] { AlliesNoBuff_Haste },
            base_score: 30.0f, combat_count: 2, cooldown_rounds: 2);

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
            base_score: 10.0f,  cooldown_rounds: 4);

            static public BlueprintAiCastSpell chainlightning = createCastSpellAction("castchainlightning", Spells.chainlightning,
                new Consideration[] { },
                new Consideration[] { attacktargetspriority},
                base_score: 20.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell magicmissleswift = createCastSpellAction("castmagicmissleswift", Spells.magicmissleswift,
                new Consideration[] { },
               new Consideration[] { attacktargetspriority, NoBuffShield },
            base_score: 20.0f, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell castmagicmissle = createCastSpellAction("castmagicmissle", Spells.magicmissle,
    new Consideration[] { },
   new Consideration[] { attacktargetspriority, NoBuffShield },
base_score: 20.0f, cooldown_rounds: 1);

            static public BlueprintAiCastSpell castmagicmissletransmuter = createCastSpellAction("castmagicmissletransmuter", Spells.magicmissle,
new Consideration[] { },
new Consideration[] { attacktargetspriority, NoBuffShield },
base_score: 20.0f, cooldown_rounds: 1, start_cooldown_rounds: 5);

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

            static public BlueprintAiCastSpell hurricanebowbandittransmuter = createCastSpellAction("hurricanebowbandittransmuter", Spells.hurricanebow,
new Consideration[] { NoBuffHurricaneBow },
    new Consideration[] { },
base_score: 3.0f, combat_count:1);

            static public BlueprintAiCastSpell summonelementalgreatearth = createCastSpellAction("CastSummonelementalgreat", Spells.summonelementalgreat,
                new Consideration[] { },
                new Consideration[] { },
             base_score: 20.0f, variant: Spells.summonelementalgreatearth, combat_count: 1, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell summonelementalgreatwatermoray = createCastSpellAction("summonelementalgreatwatermoray", Spells.summonelementalgreatwater,
    new Consideration[] { },
    new Consideration[] { },
 base_score: 20.0f, combat_count: 1);

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

            static public BlueprintAiCastSpell holdpersondelaybanditcleric = createCastSpellAction("Castholdpersonbanditdelay", Spells.holdperson,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 3.0f, combat_count: 3, cooldown_rounds: 1, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castshieldoffaith = createCastSpellAction("Castshieldoffaith", Spells.shieldoffaith,
new Consideration[] { },
new Consideration[] { TargetSelf, NoBuffShieldofFaith },
base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell castshieldoffaithgorum = createCastSpellAction("castshieldoffaithgorum", Spells.shieldoffaith,
new Consideration[] { },
new Consideration[] { TargetSelf,  },
base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell blurcast = createCastSpellAction("Castblur", Spells.blur,
             new Consideration[] { },
             new Consideration[] { NoBuffBlur , TargetSelf},
          base_score: 90.0f, combat_count: 1);

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
            base_score: 50.0f, variant: Spells.greaterdispelarea, combat_count: 1);

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

            static public BlueprintAiCastSpell castowlswisdom = createCastSpellAction("Castowlswisdom", Spells.owlswisdom,
                                                 new Consideration[] { },
                                                 new Consideration[] {AlliesNoBuff_OwlsWisdom,TargetSelf },
                                                 base_score: 20.0f, start_cooldown_rounds: 3);

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

            static public BlueprintAiCastSpell castcontrolledfireballwyvern = createCastSpellAction("castcontrolledfireballwyvern", Spells.controlledfireball,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 30.0f,  cooldown_rounds: 5);

            static public BlueprintAiCastSpell castcontrolledfireballstrongwyvern = createCastSpellAction("castcontrolledfireballstrongwyvern", Spells.controlledfireball,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 30.0f, cooldown_rounds: 4);

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
                 base_score: 30.0f, cooldown_rounds: 1, start_cooldown_rounds: 3);


            static public BlueprintAiCastSpell usedisarm = createCastSpellAction("usedisarm", Spells.disarm,
                     new Consideration[] { },
                 new Consideration[] { attacktargetspriority, NoDisarmBuff },
                base_score: 20.0f, combat_count: 1, cooldown_rounds: 3, start_cooldown_rounds: 2);

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

            static public BlueprintAiCastSpell castfrigidtouchlostsister = createCastSpellAction("castfrigidtouchlostsister", Spells.frigidtouch,
new Consideration[] { },
new Consideration[] { attacktargetspriority, NoBuffStaggered },
base_score: 40.0f, cooldown_rounds: 1, start_cooldown_rounds: 10);

            static public BlueprintAiCastSpell castvampirictouch = createCastSpellAction("castvampirictouch", Spells.vampirictouch,
new Consideration[] { NoBuffVampiricTouch },
new Consideration[] { attacktargetspriority, NotUndead},
base_score: 40.0f, cooldown_rounds: 3, combat_count: 2, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell castvampirictouchowlbear = createCastSpellAction("castvampirictouchowlbear", Spells.vampirictouch,
new Consideration[] { NoBuffVampiricTouch },
new Consideration[] { attacktargetspriority, NotUndead },
base_score: 40.0f, cooldown_rounds: 3);

            static public BlueprintAiCastSpell mirrorimageowlbear = createCastSpellAction("Castmirrorimageowlbear", Spells.mirrorimage,
new Consideration[] { },
new Consideration[] { NoBuffMirrorImage },
base_score: 20.0f, cooldown_rounds: 6, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castfiresnakeowlbear = createCastSpellAction("castfiresnakeowlbear", Spells.firesnake,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 20.0f, cooldown_rounds: 4);

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
    new Consideration[] {NoBuffMirrorImage },
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

            static public BlueprintAiCastSpell castfireballtartuk = createCastSpellAction("castfireballtartuk", Spells.fireball,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 30.0f, combat_count: 1, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castfireball = createCastSpellAction("castfireball", Spells.fireball,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies,AoE_AvoidFriends },
base_score: 30.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell casthastetartuk = createCastSpellAction("casthastetartuk", Spells.haste,
new Consideration[] { },
new Consideration[] { AlliesNoBuff_Haste },
base_score: 30.0f, combat_count: 2, cooldown_rounds: 3);

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

            static public BlueprintAiCastSpell calllightninglostsister = createCastSpellAction("calllightninglostsister", Spells.calllightningstormlightning,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 20.0f, cooldown_rounds: 1, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castsnowballsister = createCastSpellAction("castsnowballsister", Spells.snowball,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 3.0f, combat_count: 3, cooldown_rounds: 2);

            static public BlueprintAiCastSpell castsnowballlostsister = createCastSpellAction("castsnowballlostsister", Spells.snowball,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 3.0f,  cooldown_rounds: 1, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castsnowballwitch = createCastSpellAction("castsnowballwitch", Spells.snowball,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 3.0f,  cooldown_rounds: 1);



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

            static public BlueprintAiCastSpell usesummonghosts2 = createCastSpellAction("usesummonghosts2", Spells.summonghosts2,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell usesummonundeadfriends = createCastSpellAction("usesummonundeadfriends", Spells.summonundeadfriends,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f, combat_count: 1);



            static public BlueprintAiCastSpell usedisarmspectre = createCastSpellAction("usedisarmspectre", Spells.disarm,
         new Consideration[] { },
     new Consideration[] { attacktargetspriority, NoDisarmBuff },
    base_score: 20.0f, combat_count: 1, cooldown_rounds: 4, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell castfingerofdeathastraldaemon = createCastSpellAction("castfingerofdeathastraldaemon", Spells.fingerofdeath,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 20.0f, cooldown_rounds: 5, combat_count: 3);

            static public BlueprintAiCastSpell castfearthanadaemon = createCastSpellAction("castfearthanadaemon", Spells.fear,
  new Consideration[] { },
  new Consideration[] { AOE_ChooseMoreEnemies },
  base_score: 10.0f, cooldown_rounds: 5);

            static public BlueprintAiCastSpell castwavesoffatigue = createCastSpellAction("castwavesoffatigue", Spells.wavesoffatigue,
new Consideration[] { },
new Consideration[] { AOE_ChooseMoreEnemies },
base_score: 10.0f, combat_count: 2, cooldown_rounds: 5, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell castblindness = createCastSpellAction("castblindness", Spells.blindness,
new Consideration[] { },
new Consideration[] { attacktargetspriority,ChaoticBehavior,NoBuffHoldMonster },
base_score: 10.0f,  cooldown_rounds: 3, start_cooldown_rounds: 5);


            static public BlueprintAiCastSpell castblindnesswitch = createCastSpellAction("castblindnesswitch", Spells.blindness,
new Consideration[] { },
new Consideration[] { attacktargetspriority, ArcaneCasterFocusConsiderationVordakai, NoBuffHoldMonster },
base_score: 10.0f, cooldown_rounds: 2, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castcrushingdespair = createCastSpellAction("castcrushingdespair", Spells.crushingdespair,
new Consideration[] { },
new Consideration[] { attacktargetspriority, NoBuffCrushingDespair,AOE_ChooseMoreEnemies },
base_score: 10.0f, cooldown_rounds: 2, start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell castcrushingdespairwyvern = createCastSpellAction("castcrushingdespairwyvern", Spells.crushingdespair,
new Consideration[] { },
new Consideration[] { attacktargetspriority, NoBuffCrushingDespair, AOE_ChooseMoreEnemies },
base_score: 10.0f, cooldown_rounds: 5 );

            static public BlueprintAiCastSpell castconfusionwyvern = createCastSpellAction("castconfusionwyvern", Spells.confusion,
new Consideration[] { },
new Consideration[] { attacktargetspriority, NoBuffInsanity,NoBuffConfusion, AOE_ChooseMoreEnemies },
base_score: 10.0f, cooldown_rounds: 5);

            static public BlueprintAiCastSpell summonelementallargeair = createCastSpellAction("Castsummonelementallargeair", Spells.summonelementallarge,
    new Consideration[] { },
    new Consideration[] { },
    base_score: 20.0f, variant: Spells.summonelementallargeair, combat_count: 1, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell castboneshakerzombiewizard = createCastSpellAction("castboneshakerzombiewizard", Spells.boneshaker,
                                                             new Consideration[] { },
                                                             new Consideration[] { LongRange },
                                                             base_score: 10.0f, start_cooldown_rounds: 4, cooldown_rounds: 2);

            static public BlueprintAiCastSpell castboneshatter = createCastSpellAction("castboneshatter", Spells.boneshatter,
                                                 new Consideration[] { },
                                                 new Consideration[] { LongRange },
                                                 base_score: 10.0f, start_cooldown_rounds: 2, cooldown_rounds: 2);

            static public BlueprintAiCastSpell castslayliving = createCastSpellAction("castslayliving", Spells.slayliving,
                                                 new Consideration[] { },
                                                 new Consideration[] {TouchInMeleeConsideration},
                                                 base_score: 10.0f, start_cooldown_rounds: 10);

            static public BlueprintAiCastSpell holdpersonzombiecleric = createCastSpellAction("Castholdpersonzombiecleric", Spells.holdperson,
        new Consideration[] { },
        new Consideration[] { attacktargetspriority, ChaoticBehavior },
        base_score: 20.0f, combat_count: 3, cooldown_rounds: 2, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell castbane = createCastSpellAction("Castbane", Spells.bane,
                         new Consideration[] { },
                         new Consideration[] { },
                         base_score: 10.0f, combat_count: 1);

            static public BlueprintAiCastSpell throwexplosivebombgoblin = createCastSpellAction("throwexplosivebombgoblin", Spells.explosivebomb,
 new Consideration[] { },
 new Consideration[] { AOE_ChooseMoreEnemies, ChaoticBehavior },
base_score: 20.0f,  start_cooldown_rounds: 4);

            static public BlueprintAiCastSpell throwblindbombgoblin = createCastSpellAction("throwblindbombgoblin", Spells.blindbomb,
new Consideration[] { },
 new Consideration[] { AOE_ChooseMoreEnemies },
base_score: 20.0f, combat_count: 2, cooldown_rounds: 4, start_cooldown_rounds: 5);


            static public BlueprintAiCastSpell casthastegoblin = createCastSpellAction("casthastegoblin", Spells.haste,
new Consideration[] { },
new Consideration[] { AlliesNoBuff_Haste },
base_score: 20.0f,  start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castthrowbomb = createCastSpellAction("castthrowbomb", Spells.standartbomb,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f, cooldown_rounds: 2, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castshieldgoblin = createCastSpellAction("castshieldgoblin", Spells.shield,
new Consideration[] { },
new Consideration[] { NoBuffShieldBuff },
base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell castreducepersongoblin = createCastSpellAction("castreducepersongoblin", Spells.reduceperson,
new Consideration[] { },
new Consideration[] { NoBuffReducePerson, TargetSelf },
base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell castdisplacementgoblin = createCastSpellAction("castdisplacementgoblin", Spells.displacement,
                                                                         new Consideration[] { },
                                                                         new Consideration[] { NoBuffDisplacement },
                                                                         base_score: 20.0f);

            static public BlueprintAiCastSpell dispel = createCastSpellAction("CastDispeltarget", Spells.dispel,
    new Consideration[] { },
    new Consideration[] { ChaoticBehavior },
    base_score: 19.0f, variant: Spells.dispeltarget, cooldown_rounds: 3, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castrayofsickening = createCastSpellAction("castrayofsickening", Spells.rayofsickening,
new Consideration[] { },
new Consideration[] { attacktargetspriority,NoBuffsickened },
base_score: 19.0f, cooldown_rounds: 2, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell usesunderarmorzombiebarb = createCastSpellAction("usesunderarmorzombiebarb", Spells.sunderarmor,
new Consideration[] { },
new Consideration[] { attacktargetspriority,  NoBuffSunder, heavy_armor_consideration },
base_score: 20.0f, cooldown_rounds: 4, start_cooldown_rounds: 1);

            static public BlueprintAiCastSpell useweb = createCastSpellAction("Castweb", Spells.web,
     new Consideration[] { },
      new Consideration[] { AOE_ChooseMoreEnemies,LongRange },
     base_score: 50.0f, combat_count: 1);

            static public BlueprintAiCastSpell usephantasmalwebwitch = createCastSpellAction("usephantasmalwebwitch", Spells.phantasmalweb,
new Consideration[] { },
new Consideration[] { AOE_ChooseMoreEnemies },
base_score: 50.0f, combat_count: 1);

            static public BlueprintAiCastSpell chainlightningelderair = createCastSpellAction("castchainlightningelderair", Spells.chainlightning,
    new Consideration[] { },
    new Consideration[] { attacktargetspriority },
    base_score: 20.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell acidicsprayelderearth = createCastSpellAction("castacidicsprayelderearth", Spells.acidicspray,
new Consideration[] { },
new Consideration[] { attacktargetspriority,AOE_ChooseMoreEnemies,AoE_AvoidFriends },
base_score: 20.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell firesnakeelderfire = createCastSpellAction("Castfiresnakeelderfire", Spells.firesnake,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 20.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell coneofcoldelderwater = createCastSpellAction("coneofcoldelderwater", Spells.coneofcold,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
base_score: 20.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell lightningboltairelemental = createCastSpellAction("castlightningboltairelemental", Spells.lightningbolt,
     new Consideration[] { },
     new Consideration[] { attacktargetspriority, AoE_AvoidFriends },
base_score: 3.0f, combat_count: 3, cooldown_rounds: 4 );

            static public BlueprintAiCastSpell dragonsbreathearthelemental = createCastSpellAction("Castdragonsbreathearthelemental", Spells.dragonsbreathgreen,
                new Consideration[] { },
                new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
            base_score: 20.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell controlledfireballfireelemental = createCastSpellAction("castcontrolledfireballfireelemental", Spells.controlledfireball,
    new Consideration[] { },
    new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
    base_score: 30.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell dragonsbreathwaterelemental = createCastSpellAction("Castdragonswaterearthelemental", Spells.dragonsbreathsilver,
                new Consideration[] { },
                new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
            base_score: 40.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell dragonsbreathsilverhydra = createCastSpellAction("Castdragonsbreathsilverhydra", Spells.dragonsbreathsilver,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
base_score: 40.0f, cooldown_rounds: 3);

            static public BlueprintAiCastSpell dragonsbreathgoldhydra = createCastSpellAction("Castdragonsbreathgoldhydra", Spells.dragonsbreathgold,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
base_score: 40.0f, cooldown_rounds: 4);


            static public BlueprintAiCastSpell dragonsbreathgoldwyvern = createCastSpellAction("Castdragonsbreathgoldwyvern", Spells.dragonsbreathgold,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
base_score: 40.0f, cooldown_rounds: 4);

            static public BlueprintAiCastSpell acidarrowearthelemental = createCastSpellAction("Castacidarrowearthelemental", Spells.acidarrow,
       new Consideration[] { },
      new Consideration[] { attacktargetspriority },
     base_score: 3.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell burninarcfireelemental = createCastSpellAction("Castburninarcfireelemental", Spells.burningarc,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 3.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell castsnowballwaterelemental = createCastSpellAction("castsnowballwaterelemental", Spells.snowball,
new Consideration[] { },
new Consideration[] { attacktargetspriority },
base_score: 3.0f, combat_count: 2, cooldown_rounds: 4);

            static public BlueprintAiCastSpell castsoundburst = createCastSpellAction("castsoundburst", Spells.soundburst,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
base_score: 3.0f, combat_count: 2, cooldown_rounds: 2, start_cooldown_rounds: 3);



            static public BlueprintAiCastSpell usedirtytrickblinddovan = createCastSpellAction("usedirtytrickblinddovan", Spells.dirtytrickblindness,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f, cooldown_rounds: 3, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell throwexplosivebombbandit = createCastSpellAction("throwexplosivebombbandit", Spells.explosivebomb,
new Consideration[] { },
new Consideration[] { AOE_ChooseMoreEnemies, ChaoticBehavior },
base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell castenlargemass = createCastSpellAction("Castenlargemass", Spells.EnlargePersonMass,
               new Consideration[] { },
               new Consideration[] { AlliesNoBuff_EnlargePerson},
               base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell usewildshapebear = createCastSpellAction("usewildshapebear", Spells.WildshapeBear,
               new Consideration[] { },
               new Consideration[] { },
               base_score: 20.0f, combat_count: 1);

            static public BlueprintAiCastSpell castbullsstrength= createCastSpellAction("Castbullsstrength", Spells.bullsstrength,
                                     new Consideration[] { },
                                     new Consideration[] { NoBuffBullStrength, TargetSelf },
                                     base_score: 20.0f);

            static public BlueprintAiCastSpell castbalefulpolymorphwitch = createCastSpellAction("castbalefulpolymorphwitch", Spells.balefulpolymorph,
                         new Consideration[] { },
                         new Consideration[] { NoBuffBalefulPolymorph, ArcaneCasterFocusConsiderationVordakai,attacktargetspriority },
                         base_score: 20.0f, combat_count: 1, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castsummonmonsterIV = createCastSpellAction("CastSummonMonsterIVSingle", Spells.summonmonsterIV,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f, variant: Spells.summonmonsterIVsingle, combat_count: 1);

            static public BlueprintAiCastSpell castnegativeenergyghostcleric = createCastSpellAction("castnegativeenergyghostcleric", Spells.channelnegativeenergyharmbase,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f, variant: Spells.channelnegativeenergy, combat_count: 9, cooldown_rounds: 2, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castchannelpositivecleric = createCastSpellAction("castchannelpositivecleric", Spells.channelpositivehealbase,
new Consideration[] { },
new Consideration[] {},
base_score: 20.0f, variant: Spells.channelpositiveenergy, combat_count: 6, cooldown_rounds: 2, start_cooldown_rounds: 3);

            static public BlueprintAiCastSpell castinvisibilitygreater = createCastSpellAction("castinvisibilitygreater", Spells.InvisibilityGreater,
new Consideration[] { },
new Consideration[] { NoBuffInvisibilityGreater, TargetSelf },
base_score: 40.0f, combat_count: 1);

            static public BlueprintAiCastSpell castaid = createCastSpellAction("castaid", Spells.aid,
new Consideration[] { },
new Consideration[] { AlliesNoBuff_Aid, TargetSelf },
base_score: 40.0f, combat_count: 1);

            static public BlueprintAiCastSpell castfester = createCastSpellAction("castfester", Spells.fester,
new Consideration[] { },
new Consideration[] { ArcaneCasterFocusConsiderationVordakai, attacktargetspriority },
base_score: 40.0f, combat_count: 1, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell castserenity = createCastSpellAction("castserenity", Spells.serenity,
new Consideration[] { },
new Consideration[] { },
base_score: 40.0f, combat_count: 1, start_cooldown_rounds: 1);

            static public BlueprintAiCastSpell castcolorspray = createCastSpellAction("castcolorspray", Spells.colorspray,
new Consideration[] { },
new Consideration[] {attacktargetspriority, AoE_AvoidFriends, AOE_ChooseMoreEnemies },
base_score: 40.0f, combat_count: 1, start_cooldown_rounds: 1);

            static public BlueprintAiCastSpell scorchingraydelaydryad = createCastSpellAction("castscorchingraydelaydryad", Spells.scorchingray,
       new Consideration[] { },
      new Consideration[] { attacktargetspriority },
     base_score: 30.0f, cooldown_rounds: 1, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell earpiercedryad = createCastSpellAction("castearpiercedryad", Spells.earpiercescream,
new Consideration[] { },
 new Consideration[] { attacktargetspriority },
base_score: 20.0f, combat_count: 4, start_cooldown_rounds: 2, cooldown_rounds: 1);

            static public BlueprintAiCastSpell dragonsbreathgreenhydra = createCastSpellAction("Castdragonsbreathgreenhydra", Spells.dragonsbreath,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
base_score: 20.0f, variant: Spells.dragonsbreathgreen, cooldown_rounds: 4);

            static public BlueprintAiCastSpell dragonsbreathgreenwyvern = createCastSpellAction("Castdragonsbreathgreenwyvern", Spells.dragonsbreath,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies, AoE_AvoidFriends },
base_score: 20.0f, variant: Spells.dragonsbreathgreen, cooldown_rounds: 4);

            static public BlueprintAiCastSpell castoverwhelminggriefmanticore = createCastSpellAction("castoverwhelminggriefmanticore", Spells.overwhelminggrief,
new Consideration[] { },
new Consideration[] { attacktargetspriority, NoBuffOverwhelmingGrief },
base_score: 20.0f, cooldown_rounds: 4);

            static public BlueprintAiCastSpell castoverwhelminggriefzombie = createCastSpellAction("castoverwhelminggriefzombie", Spells.overwhelminggrief,
new Consideration[] { },
new Consideration[] { attacktargetspriority, NoBuffOverwhelmingGrief },
base_score: 20.0f, cooldown_rounds: 2, start_cooldown_rounds: 5);

            static public BlueprintAiCastSpell usegreatershoutbird = createCastSpellAction("usegreatershoutbird", Spells.greatershout,
new Consideration[] { },
new Consideration[] { attacktargetspriority, AOE_ChooseMoreEnemies },
base_score: 20.0f, cooldown_rounds: 8);


            static public BlueprintAiCastSpell casticyprison = createCastSpellAction("casticyprison", Spells.icyprison,
new Consideration[] { },
new Consideration[] { attacktargetspriority, SupporCasterFocusConsideration },
base_score: 20.0f, start_cooldown_rounds: 2);

            static public BlueprintAiCastSpell castprofanenimbus = createCastSpellAction("castprofanenimbus", Spells.profanenimbus,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f);

            static public BlueprintAiCastSpell usewildshapesmilidon = createCastSpellAction("usewildshapesmilidon", Spells.wildshapesmilodon,
new Consideration[] { },
new Consideration[] { },
base_score: 20.0f);



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
            updateTartukinSycamore();
            updateSycamoreSpiderBoss();
            updateMiteQueen();
            updateMiteSineshal();
            updateMiteCleric();
            updateKoboldKing();
            updateKoboldHerald();
            updateCR1_BanditBard();
            updateCR2_BanditPostiveCleric();
            updateDovan();
            updateStaglordDovan();
            updateStaglordDovanB();
            updateStaglordDovanC();
            updateDovanHighLevel();
            updateAuch();
            updatestaglordAuch();
            updateStagLord();
            updateStaglordLoyalistMage();
            updateStaglordLoyalist();
            updateNugrah();


            //Chapter 2 Trolls

            updateCR3_BanditAlchemist();
            updateCR6_BanditTransmuter();
            updatebanditroguerangedRW();
            updatebanditroguemeleeRW();
            updatebanditfighterRW();
            updatebanditfighterRangedRW();
            updatebanditfighterLH();
            updatebanditfighterRangedLH();
            updatebanditconjurerLH();
            updatebanditarmoredleader();

            updateKoboldTeacher();
            updateKoboldKeyKeeper();
            updateKoboldBladeCR3B();
            updateKoboldOnMarchShaman();
            updateKoboldEvokerTrollbold();
            updateKoboldBoomsayer();
            updateKoboldBladeCR3();
            updateKoboldHunter();
            updateKoboldAlchemistCR4();
            updateBoneShaman();
            updateJazon();
            updateJazonEarly();
            updateNagrundi();
            updateNagrundiTrollHound();
            fixTartuk();
            fixHargulka();


            //Chapter 2 Season of Bloom

            updateSwampWitch();
            changeLonelyGhoul();
            changeSwampWerewolf();
            updateGhostPriest();
            updateGhostStandard();
            changeNarlmarshscythetree();
            

            changeLonelyBarrowSkeletonCR2();
            changeLonelyBarrowSkeletonCR3();
            changeEasyBanditArcher();
            changeEasyBanditMelee();
            changeHardBanditMelee();
            changeHardBanditRanged();
            changeGraveRobber();
            changeLoneWarrior();

            changeKingVesket();
            changeLizardRattler();
            changeLizardRangedHard();
            changeLizardMeleeHard();

            //Beasts

            updatehuntedhydra();
            updatecapitalhydra();
            updateCR12PoisonousHydra();
            updateCR14PoisonousHydra();
            updateHydraStandard();
            updateHydraAdvanced();
            updateHydraAdvancedCR7();
            updateHydraquickling();
            updateHydrabloom();
            updateHydravenom();
            updateOwlbearillusion();
            updateOwlbearnecro();
            updateStrongOwlbearevocation();
            updateStrongOwlbearnecro();
            updateStrongOwlbeartreant();
            updateSecretOwlbear();
            updateenragedowlbeartreant();
            updateBloominfusedspider();
            updatequicklingspider();
            updatedoomspider();
            updatespidermatriarch();
            updatestandardwyvern();
            updateadvancedwyvern();
            updateenchantmentwyvern();
            updateevocationwyvern();
            updatestrongenchantmentwyvern();
            updatetransmutationwyvern();
            updatetreantwyvern();
            updatewyvernforked();
            updateManticoreStandard();
            updateManticoreAdvanced();
            updateManticoreTransmutation();
            updateManticoreEnchantment();
            updateManticoreVenom();
            updateManticorebloominfused();
            updateManticoreMature();
            updateFlyTrapStandard();
            updateFlyTrapadvanced();
            updateFlyTrapbloominfused();

            //Talon Peak

            updateAncientRoc();
            updateTalonPeakAlchemist();
            updateTalonPeakFighter();
            updateTalonPeakRogue();

            //Silverstep

            updatesilverstepsmalltatzylwyrm();
            updateLargeTatzlwyrm();
            updatesilverstepfrogs();
            changeSilverstepWerewolf();
            changesilverstepbanditleader();
            updatesilverstepbanditmelee();
            changesilverstepbanditArcher();
            changesilverstepbanditRogue();


            fixLizardWilloWispBoss();

            updatefakestaglord(); 

            updatecraglinnorm();

            fixCandlemereWilloWispBoss();
            fixCandlemerePriest();

            fixnixieprankster();
            fixnereidstandard();


            //Goblins 

            fixGoblinSentry();
            fixGoblinDogcutter();
            fixGoblinHorseslayer();
            fixGoblinHorseslayerb();
            fixGoblinCommando();
            fixGoblinCommandob();
            fixGoblinGuardNeutral();

            fixGoblinRogueCR7();
            fixGoblinRogueCR7Ambush();
            fixGoblinRogueCR9();
            fixGoblinRogueCR9Ambush();

            fixGoblinSlyEye();
            fixGoblinDeadEye();
            fixGoblinDeathEye();
            fixGoblinEagleEye();
            fixGoblinEagleEyeB();
            fixGoblinLynxEye();
            fixGoblinLynxEyeB();
            fixGoblinLynxEyeC();
            fixGoblinArcherCR9Ambush();
            fixGoblinArcherCR7Ambush();

            fixGoblinGuardAlchemit();
            fixGoblinAlchemistCR7();
            fixGoblinAlchemistCR6();
            fixGoblinAlchemistCR5();
            fixGoblinAlchemistCR4();
            fixGoblinAlchemistCR1();

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
            updateBarbarianmeleeLevel7();
            updateBarbfighter();
            updateBarbranger();
            updateBolga();

            changeholloweyearchers();
            changeholloweyerogues();
            changeholloweyealchemist();
            updateholloweyeFighterA();
            updateholloweyeFighterB();
            updateholloweyeBrawler();
            updateholloweyeBard();

            updateDunswardTombSorcerer();
            updateDunswardTombCleric();
            updateDunswardTombFighter();
            updateDunswardTombArcher();
            updateDunswardTombBarbarian();


            changeDaemonGuardian();
            changeAstraDaemonstandard();
            changeThanadaemon();
            updateVordakaiWillasGundarson();
            updateSpectreStandard();
            changeCephalLorentus();
            updateVordakai();
            updateHoragnamon();
            changeDreadZombieFighterFerocius();
            fixThickSkinnedZombieCyclopFighter();
            fixdreadzombieCR8();
            fixdreadzombieCR9();
            fixdreadgreaterbarbarian();

            fixDreadZombieCleric();
            fixundeadcyclopspriest();



            //Chapter 4

            //Flintlock Grasslands

            updateCR6_VandalPositiveClericLevel7();
            updateCR8_VandalPositiveClericLevel9();
            updateCR9_VandalDruidWildshapeLevel10();
            updateCR7_VandalDruidWildShapeLevel8();
            updateCR11_VandalMeleeBarbarianLevel12();
            updateCR9_VandalMeleeBarbarianLevel10();
            updateCR8_VandalMeleeRangerLevel9();
            updateCR6_VandalMeleeRangerLevel7();
            updateCR9_VandalRangedFighterLevel10();
            updateCR7_VandalRangedFighterLevel8();
            updateCR7_VandalMeleeFighterGreataxeLevel8();
            updateCR6_VandalMeleeFighterGreataxeLevel7();
            updateCR6_VandalMeleeFighterGreatswordLevel7();
            updateCR7_VandalMeleeFighterGreatswordLevel8();
            updateVandalRanged_BrevoyBad();
            updateVandalHillGiant();
            updateVandalwolf_brevoybad();

            //Abandoned Keep
            updateDefacedSisterAbandonedKeep();

            updateClericGorum();
            //updateArmag();
            updateClericGorumArmags();



            //Chapter 5

            updateDwarfMagus();
            updateTrollGuard();
            changeriverbladetransmuter();



            //Chapter 6

            updateWrigglingMan();


            //Bald Hilltop (Ancient Curses)

            changebloodmoondryad();
            changebloodmoonnymph();
            changebloodmoonnereid();

            //Elementals

            updateElderAirElemental();
            updateGreaterAirElemental();
            updateHugeAirElemental();
            updateLargeAirElemental();
            updateMediumAirElemental();
            updateSmallAirElemental();

            updateSummonedElderAirElemental();
            updateSummonedGreaterAirElemental();
            updateSummonedHugeAirElemental();
            updateSummonedLargeAirElemental();
            updateSummonedMediumAirElemental();
            updateSummonedSmallAirElemental();

            updateElderFireElemental();
            updateGreaterFireElemental();
            updateHugeFireElemental();
            updateLargeFireElemental();
            updateMediumFireElemental();
            updateSmallFireElemental();

            updateSummonedElderFireElemental();
            updateSummonedGreaterFireElemental();
            updateSummonedHugeFireElemental();
            updateSummonedLargeFireElemental();
            updateSummonedMediumFireElemental();
            updateSummmonedSmallFireElemental();

            updateElderWaterElemental();
            updateGreaterWaterElemental();
            updateHugeWaterElemental();
            updateLargeWaterElemental();
            updateMediumWaterElemental();
            updateSmallWaterElemental();


            updateSummonedElderWaterElemental();
            updateSummonedGreaterWaterElemental();
            updateSummonedHugeWaterElemental();
            updateSummonedLargeWaterElemental();
            updateSummonedMediumWaterElemental();
            updateSummonedSmallWaterElemental();


            updateElderEarthElemental();
            updateGreaterEarthElemental();
            updateHugeEarthElemental();
            updateLargeEarthElemental();
            updateMediumEarthElemental();
            updateSmallEarthElemental();

            updateSummonedElderEarthElemental();
            updateSummonedGreaterEarthElemental();
            updateSummonedHugeEarthElemental();
            updateSummonedLargeEarthElemental();
            updateSummonedMediumEarthElemental();
            updateSummonedSmallEarthElemental();

            //ExtraHealthToNPCs

            updateBartholomew();
            updateBartholomewBefore();
            updateBartholomewFinal();
            updateBartholomewPacking();
            updateBartholomewWOwhip();
            updateBartholomewPrisonAsylum();
            updateBartholomewHub();
            updateBartholomewFW();
            updateBartholomewCapital();

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
            var bluritem = library.Get<BlueprintFeature>("dcc369a22b95ddf409071e88a3dca448");
            


            Kalannah.AddFacts = Kalannah.AddFacts.AddToArray(bluritem,blur);

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

        static void updateTartukinSycamore()
        {

            var TartukSycamore = library.Get<BlueprintUnit>("203d8959cd0b23b46b20014d8e537255");
            var sorcererclass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var TartukFireballAi = library.Get<BlueprintAiAction>("9ca807e0788499a47a8c2bee13af0b0b");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");

            TartukSycamore.AddFacts = TartukSycamore.AddFacts.AddToArray(blurbuff,quicken);





            var sorcererLevels = TartukSycamore.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == sorcererclass);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(haste);
            newAddClassLevels.SelectSpells = spell_list;
            TartukSycamore.ReplaceComponent(sorcererLevels, newAddClassLevels);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);

            var brain = TartukSycamore.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(TartukFireballAi);
            brain.Actions = brain.Actions.AddToArray(AiActions.casthastetartuk,AiActions.castfireballtartuk);


        }

        static void updateSycamoreSpiderBoss()
        {

            var SycamoreSpiderBoss = library.Get<BlueprintUnit>("36fe14f64d7746f429d30f9dd7b2e652");
            var vermin = library.Get<BlueprintCharacterClass>("d1a15612d1a96334d94edf5f1d3b8d29");
            var web = library.Get<BlueprintAbility>("134cb6d492269aa4f8662700ef57449f");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");


            SycamoreSpiderBoss.Charisma = 6;
            SycamoreSpiderBoss.MaxHP = 50;


            SycamoreSpiderBoss.AddFacts = SycamoreSpiderBoss.AddFacts.AddToArray(web);

            var verminLevels = SycamoreSpiderBoss.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == vermin);
            var newverminLevels = verminLevels.CreateCopy();
            newverminLevels.Levels = 8;
            SycamoreSpiderBoss.ReplaceComponent(verminLevels, newverminLevels);

            SycamoreSpiderBoss.Body.AdditionalLimbs = SycamoreSpiderBoss.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            SycamoreSpiderBoss.Body.AdditionalLimbs = SycamoreSpiderBoss.Body.AdditionalLimbs.AddToArray(bite3d6);



            var brain = SycamoreSpiderBoss.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.useweb);

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
            newAddClassLevels.Levels = 4;
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

        static void updateStaglordLoyalist()
        {

            var staglordloyalist = library.Get<BlueprintUnit>("d007ec20dc97ffc49a9ef579efce4a04");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");





            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)staglordloyalist.AddFacts[0], "staglordloyalistfeature", "7a76cd20f8da44be92dd4616c718d651");
            staglordloyalist.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();

           


            var staglordloyalistfeature = library.Get<BlueprintFeature>("7a76cd20f8da44be92dd4616c718d651");




            var fighterLevels = staglordloyalistfeature.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 6;

            staglordloyalistfeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            




        }

        static void updateStaglordLoyalistMage()
        {

            var StaglordLoyalistMage = library.Get<BlueprintUnit>("5a4ec98e24b3af94a9f0e46d12e22d91");
            var clericClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var shielfoffaith = library.Get<BlueprintBuff>("5274ddc289f4a7447b7ace68ad8bebb0");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var protcommunal = library.Get<BlueprintAbility>("2cadf6c6350e4684baa109d067277a45");
            var owlswisdom = library.Get<BlueprintAbility>("f0455c9295b53904f9e02fc571dd2ce1");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)StaglordLoyalistMage.AddFacts[0], "StaglordLoyalistMageFeature", "6f9f225ff8c042b2b97936700ee085bd");
            StaglordLoyalistMage.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();





            var StaglordLoyalistMageFeature = library.Get<BlueprintFeature>("6f9f225ff8c042b2b97936700ee085bd");


            StaglordLoyalistMage.AddFacts = StaglordLoyalistMage.AddFacts.AddToArray(shielfoffaith, combatcasting, quicken);


            var clericLevels = StaglordLoyalistMageFeature.ComponentsArray
               .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            var spell_list = newAddClassLevels.MemorizeSpells.RemoveFromArray(holdperson);
            newAddClassLevels.MemorizeSpells = spell_list;
            StaglordLoyalistMageFeature.ReplaceComponent(clericLevels, newAddClassLevels);

            var clericLevels2 = StaglordLoyalistMageFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels2 = clericLevels2.CreateCopy();
            var spell_list2 = newAddClassLevels2.MemorizeSpells.RemoveFromArray(protcommunal);
            newAddClassLevels2.MemorizeSpells = spell_list2;
            StaglordLoyalistMageFeature.ReplaceComponent(clericLevels2, newAddClassLevels2);

            var clericLevels3 = StaglordLoyalistMageFeature.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.MemorizeSpells.AddToArray(owlswisdom);
            newAddClassLevels3.MemorizeSpells = spell_list3;
            StaglordLoyalistMageFeature.ReplaceComponent(clericLevels3, newAddClassLevels3);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinefavor);



            var brain = StaglordLoyalistMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.summonmonsterIIIsingle, AiActions.divinefavor, AiActions.holdpersondelay,AiActions.castowlswisdom);


        }

        static void updateDovan()
        {

            var Dovan = library.Get<BlueprintUnit>("fe46840b544d73849b21e5f8988b15cc");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var pirahanastrike = library.Get<BlueprintFeature>("6a556375036ac8b4ebd80e74d308d108");
            var improvedunarmstrike = library.Get<BlueprintFeature>("7812ad3672a4b9a4fb894ea402095167");
            var combatexpertise = library.Get<BlueprintFeature>("4c44724ffa8844f4d9bedb5bb27d144a");

            

            Dovan.Dexterity = 16;

            var rogueLevels = Dovan.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Dovan.ReplaceComponent(rogueLevels, newAddClassLevels);

            Dovan.AddFacts = Dovan.AddFacts.AddToArray(pirahanastrike);

            Dovan.AddFacts = Dovan.AddFacts.RemoveFromArray(improvedunarmstrike);

            var brain = Dovan.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedisarm);


        }

        static void updateStaglordDovan()
        {

            var Dovan = library.Get<BlueprintUnit>("7ef9d1cac7c6c9641962efffbdbc8397");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var pirahanastrike = library.Get<BlueprintFeature>("6a556375036ac8b4ebd80e74d308d108");
            var improvedunarmstrike = library.Get<BlueprintFeature>("7812ad3672a4b9a4fb894ea402095167");
            var combatexpertise = library.Get<BlueprintFeature>("4c44724ffa8844f4d9bedb5bb27d144a");



            Dovan.Dexterity = 16;

            var rogueLevels = Dovan.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Dovan.ReplaceComponent(rogueLevels, newAddClassLevels);

            Dovan.AddFacts = Dovan.AddFacts.AddToArray(pirahanastrike);

            Dovan.AddFacts = Dovan.AddFacts.RemoveFromArray(improvedunarmstrike);

            var brain = Dovan.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedisarm);


        }

        static void updateStaglordDovanB()
        {

            var Dovan = library.Get<BlueprintUnit>("50763f48a8d0d734f915e6b7941c0ac7");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var pirahanastrike = library.Get<BlueprintFeature>("6a556375036ac8b4ebd80e74d308d108");
            var improvedunarmstrike = library.Get<BlueprintFeature>("7812ad3672a4b9a4fb894ea402095167");
            var combatexpertise = library.Get<BlueprintFeature>("4c44724ffa8844f4d9bedb5bb27d144a");



            Dovan.Dexterity = 16;

            var rogueLevels = Dovan.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Dovan.ReplaceComponent(rogueLevels, newAddClassLevels);

            Dovan.AddFacts = Dovan.AddFacts.AddToArray(pirahanastrike);

            Dovan.AddFacts = Dovan.AddFacts.RemoveFromArray(improvedunarmstrike);

            var brain = Dovan.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedisarm);


        }

        static void updateStaglordDovanC()
        {

            var Dovan = library.Get<BlueprintUnit>("443d8093d172d5047b1b81ac320568fa");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            
            var pirahanastrike = library.Get<BlueprintFeature>("6a556375036ac8b4ebd80e74d308d108");
            var improvedunarmstrike = library.Get<BlueprintFeature>("7812ad3672a4b9a4fb894ea402095167");
            var combatexpertise = library.Get<BlueprintFeature>("4c44724ffa8844f4d9bedb5bb27d144a");



            Dovan.Dexterity = 16;

            var rogueLevels = Dovan.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Dovan.ReplaceComponent(rogueLevels, newAddClassLevels);

            Dovan.AddFacts = Dovan.AddFacts.AddToArray(pirahanastrike);

            Dovan.AddFacts = Dovan.AddFacts.RemoveFromArray(improvedunarmstrike);

            var brain = Dovan.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedisarm);


        }

        static void updateDovanHighLevel()
        {

            var Dovan = library.Get<BlueprintUnit>("d7cf42578e4f08e469ba5d1bc5678b2a");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var disarmfeat = library.Get<BlueprintFeature>("63d8e3a9ab4d72e4081a7862d7246a79");
            var improvedunarmstrike = library.Get<BlueprintFeature>("7812ad3672a4b9a4fb894ea402095167");
            var combatexpertise = library.Get<BlueprintFeature>("4c44724ffa8844f4d9bedb5bb27d144a");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");


            var rogueLevels = Dovan.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 5;

            Dovan.ReplaceComponent(rogueLevels, newAddClassLevels);

            Dovan.AddFacts = Dovan.AddFacts.AddToArray(dirtytrick);

            Dovan.AddFacts = Dovan.AddFacts.RemoveFromArray(improvedunarmstrike);

            var brain = Dovan.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedirtytrickblinddovan);


        }

        static void updateAuch()
        {

            var Auch = library.Get<BlueprintUnit>("a892528af321d4945a64c4e10af1d6e4");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var cleave = library.Get<BlueprintFeature>("d809b6c4ff2aaff4fa70d712a70f7d7b");




            var fighterLevels = Auch.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            Auch.ReplaceComponent(fighterLevels, newAddClassLevels);

            Auch.AddFacts = Auch.AddFacts.AddToArray(cleave);



            var brain = Auch.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig);


        }

        static void updatestaglordAuch()
        {

            var Auch = library.Get<BlueprintUnit>("75e613e0a8edf654387f072a06985403");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var cleave = library.Get<BlueprintFeature>("d809b6c4ff2aaff4fa70d712a70f7d7b");




            var fighterLevels = Auch.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            Auch.ReplaceComponent(fighterLevels, newAddClassLevels);

            Auch.AddFacts = Auch.AddFacts.AddToArray(cleave);



            var brain = Auch.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig);


        }

        static void updateNugrah()
        {

            var Nugrah = library.Get<BlueprintUnit>("f9d8cbf3340d7a24e96bb498732bf531");
            var naturalspell = library.Get<BlueprintFeature>("c806103e27cce6f429e5bf47067966cf");
            var calllightningability = library.Get<BlueprintAbility>("0bd54216d38852947930320f6269a9d7");
            var StoneFistBuffMedium = library.Get<BlueprintBuff>("af56c42a31a264648b42d725f362c18d");
            var druidClass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var bullsstrength = library.Get<BlueprintAbility>("4c3d08935262b6544ae97599b3a9556d");


            Nugrah.AddFacts = Nugrah.AddFacts.AddToArray(naturalspell,StoneFistBuffMedium);
            Nugrah.AddFacts = Nugrah.AddFacts.RemoveFromArray(calllightningability);

            var druidLevels = Nugrah.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == druidClass);
            var newAddClassLevels = druidLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(bullsstrength);
            newAddClassLevels.MemorizeSpells = spell_list;
            Nugrah.ReplaceComponent(druidLevels, newAddClassLevels);

            Nugrah.AddFacts = Nugrah.AddFacts.AddToArray(quicken);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.bullsstrength);

            var brain = Nugrah.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usewildshapebear,AiActions.castbullsstrength);


        }


        //CHAPTER 2 Trolls

        static void updateCR3_BanditAlchemist()
        {

            var CR3_BanditAlchemist = library.Get<BlueprintUnit>("cc8ae19574fd7354a81374bd8b0353d1");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var BanditAlchemistSpellListLevel4 = library.Get<BlueprintFeature>("9daac666e6d017c48be9e83553095541");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var BanditAlchemistFeatureListLevel4 = library.Get<BlueprintFeature>("f59abbee17aa3614db41404ea6524edf");
            var ExplosiveBombsFeature = library.Get<BlueprintFeature>("1d0e812131f345742adca6431d5bc4fe");
            var ExplosiveBombsBuff = library.Get<BlueprintBuff>("63063a8ab91bcbc44a13294227580e84");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var heroism = library.Get<BlueprintAbility>("5ab0d42fb68c9e34abae4921822b9d63");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var mephitbluraiaction = library.Get<BlueprintAiCastSpell>("0c1367bfc61f76a4ca331ce53c6fc608");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");

            CR3_BanditAlchemist.AddFacts = CR3_BanditAlchemist.AddFacts.AddToArray(ExplosiveBombsFeature,blurbuff);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)CR3_BanditAlchemist.AddFacts[0], "CR3_BanditAlchemistFeatureNew", "ebfe793e2c6f46c6b0918cfc8f291a27");
            CR3_BanditAlchemist.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BanditAlchemistFeatureListLevel4.GetComponent<AddFacts>().Facts[0], "CR3_BanditAlchemistSpellListNew", "46e8ffaf7fb64dfda6da920a6d8ed874");
            BanditAlchemistFeatureListLevel4.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var CR3_BanditAlchemistFeatureNew = library.Get<BlueprintFeature>("ebfe793e2c6f46c6b0918cfc8f291a27");
            var CR3_BanditAlchemistSpellsNew = library.Get<BlueprintFeature>("46e8ffaf7fb64dfda6da920a6d8ed874");



            var alchemistLevels = CR3_BanditAlchemistFeatureNew.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(haste,blur);
            newAddClassLevels.MemorizeSpells = spell_list;
            CR3_BanditAlchemistFeatureNew.ReplaceComponent(alchemistLevels, newAddClassLevels);

            var alchemistLevels3 = CR3_BanditAlchemistFeatureNew.ComponentsArray
 .OfType<AddClassLevels>()
    .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels3 = alchemistLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.MemorizeSpells.RemoveFromArray(heroism);
            newAddClassLevels3.MemorizeSpells = spell_list3;
            CR3_BanditAlchemistFeatureNew.ReplaceComponent(alchemistLevels3, newAddClassLevels3);

            var alchemistLevels4 = CR3_BanditAlchemistFeatureNew.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels4 = alchemistLevels4.CreateCopy();
            var spell_list4 = newAddClassLevels4.MemorizeSpells.RemoveFromArray(displacement);
            newAddClassLevels4.MemorizeSpells = spell_list4;
            CR3_BanditAlchemistFeatureNew.ReplaceComponent(alchemistLevels4, newAddClassLevels4);

            var AlchemistLevels2 = CR3_BanditAlchemistSpellsNew.ComponentsArray
        .OfType<LearnSpells>()
          .First(c => c.CharacterClass == alchemistClass);
            var newbardLevels2 = AlchemistLevels2.CreateCopy();
            var spell_list2 = newbardLevels2.Spells.AddToArray(haste,blur);
            newbardLevels2.Spells = spell_list2;
            CR3_BanditAlchemistSpellsNew.ReplaceComponent(AlchemistLevels2, newbardLevels2);

            var alchemistLevels5 = CR3_BanditAlchemistFeatureNew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels5 = alchemistLevels5.CreateCopy();
            newAddClassLevels5.Levels = 7;
            var spell_list5 = newAddClassLevels5.SelectSpells.AddToArray(haste, blur);
            newAddClassLevels5.SelectSpells = spell_list5;
            CR3_BanditAlchemistFeatureNew.ReplaceComponent(alchemistLevels5, newAddClassLevels5);



            var brain = CR3_BanditAlchemist.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.casthaste,AiActions.blurcast);


        }

        static void updateCR6_BanditTransmuter()
        {

            var CR6_BanditTransmuter = library.Get<BlueprintUnit>("865cf4ef10f04168a340eaf879f72a15");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var BanditTransmuterSpellListLevel7 = library.Get<BlueprintFeature>("82b3f9c8fbf3a6c42b12f363e579eef3");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var BanditTransmuterFeatureListLevel7 = library.Get<BlueprintFeature>("8bcac5e1bd4f254438fa8797337137a6");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var EnlargePersonMass = library.Get<BlueprintAbility>("66dc49bf154863148bd217287079245e");
            var catsgrace = library.Get<BlueprintAbility>("de7a025d48ad5da4991e7d3c682cf69d");
            var slowaiaction = library.Get<BlueprintAiAction>("d67858e438dd8834f9e61a1cb1c592a6");
            var bullsstrength = library.Get<BlueprintAbility>("4c3d08935262b6544ae97599b3a9556d");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var enlargeperson = library.Get<BlueprintAbility>("c60969e7f264e6d4b84a1499fdcf9039");
            var hurricanebow = library.Get<BlueprintAbility>("3e9d1119d43d07c4c8ba9ebfd1671952");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var AcidSplashAiAction = library.Get<BlueprintAiAction>("8cf4732cf870f8f4cbf760331c8f2696");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");


            CR6_BanditTransmuter.Dexterity = 16;

            CR6_BanditTransmuter.AddFacts = CR6_BanditTransmuter.AddFacts.AddToArray(blurbuff,quicken);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)CR6_BanditTransmuter.AddFacts[0], "CR6_BanditTransmuterFeatureNew", "84e1c48c976d420e8300238b0b04d43c");
            CR6_BanditTransmuter.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BanditTransmuterFeatureListLevel7.GetComponent<AddFacts>().Facts[1], "CR6_BanditTransmuterSpellListNew", "258bcc72946849d492999b041ac9f442");
            BanditTransmuterFeatureListLevel7.GetComponent<AddFacts>().Facts[1] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var CR6_BanditTransmuterFeatureNew = library.Get<BlueprintFeature>("84e1c48c976d420e8300238b0b04d43c");
            var CR6_BanditTransmuterSpellsNew = library.Get<BlueprintFeature>("258bcc72946849d492999b041ac9f442");



            var wizardLevels = CR6_BanditTransmuterFeatureNew.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels = wizardLevels.CreateCopy();
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray( mirrorimage,hurricanebow,magicmissle, magicmissle, magicmissle);
            newAddClassLevels.MemorizeSpells = spell_list;
            CR6_BanditTransmuterFeatureNew.ReplaceComponent(wizardLevels, newAddClassLevels);

            var wizardLevels3 = CR6_BanditTransmuterFeatureNew.ComponentsArray
 .OfType<AddClassLevels>()
    .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels3 = wizardLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.MemorizeSpells.RemoveFromArray(bullsstrength);
            newAddClassLevels3.MemorizeSpells = spell_list3;
            CR6_BanditTransmuterFeatureNew.ReplaceComponent(wizardLevels3, newAddClassLevels3);

            var wizardLevels4 = CR6_BanditTransmuterFeatureNew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels4 = wizardLevels4.CreateCopy();
            var spell_list4 = newAddClassLevels4.MemorizeSpells.RemoveFromArray(enlargeperson);
            newAddClassLevels4.MemorizeSpells = spell_list4;
            CR6_BanditTransmuterFeatureNew.ReplaceComponent(wizardLevels4, newAddClassLevels4);

            var wizardLevels6 = CR6_BanditTransmuterFeatureNew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels6 = wizardLevels6.CreateCopy();
            var spell_list6 = newAddClassLevels6.MemorizeSpells.RemoveFromArray(enlargeperson);
            newAddClassLevels6.MemorizeSpells = spell_list4;
            CR6_BanditTransmuterFeatureNew.ReplaceComponent(wizardLevels6, newAddClassLevels6);


            var wizardLevels2 = CR6_BanditTransmuterSpellsNew.ComponentsArray
        .OfType<LearnSpells>()
          .First(c => c.CharacterClass == wizardClass);
            var newbardLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newbardLevels2.Spells.AddToArray(haste, blur,hurricanebow,magicmissle);
            newbardLevels2.Spells = spell_list2;
            CR6_BanditTransmuterSpellsNew.ReplaceComponent(wizardLevels2, newbardLevels2);

            var wizardLevels5 = CR6_BanditTransmuterFeatureNew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels5 = wizardLevels5.CreateCopy();
            var spell_list5 = newAddClassLevels5.SelectSpells.AddToArray(mirrorimage,hurricanebow,magicmissle, magicmissle, magicmissle);
            newAddClassLevels5.SelectSpells = spell_list5;
            CR6_BanditTransmuterFeatureNew.ReplaceComponent(wizardLevels5, newAddClassLevels5);


            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.hurricanebow);

            var dumbmonsterbrain = library.Get<BlueprintBrain>("5abc8884c6f15204c8604cb01a2efbab");

            var new_actions = dumbmonsterbrain.Actions;

            CR6_BanditTransmuter.Brain.Actions = new_actions;


            var brain = CR6_BanditTransmuter.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.mirrorimage, AiActions.castenlargemass,
                                                    AiActions.castslow, AiActions.hurricanebowbandittransmuter,AiActions.casthaste,AiActions.castmagicmissletransmuter);


        }

        static void updatebanditroguemeleeRW()
        {

            var banditrogueRW = library.Get<BlueprintUnit>("8c4e5cdd770c4add814b2c0e3a765811");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var invisibilitybuff = library.Get<BlueprintBuff>("525f980cb29bc2240b93e953974cb325");



            banditrogueRW.AddFacts = banditrogueRW.AddFacts.AddToArray(invisibilitybuff);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)banditrogueRW.AddFacts[0], "banditroguemeleeRWfeature", "59caa6d922c84958a19e284332b611cb");
            banditrogueRW.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var banditrogueRWnew = library.Get<BlueprintFeature>("59caa6d922c84958a19e284332b611cb");



            var fighterLevels = banditrogueRWnew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            banditrogueRWnew.ReplaceComponent(fighterLevels, newAddClassLevels);






            var brain = banditrogueRW.Brain;
            brain.Actions = brain.Actions.AddToArray();


        }

        static void updatebanditroguerangedRW()
        {

            var banditrogueRW = library.Get<BlueprintUnit>("d53d5ec6942848d1bf0a4b778ba08a83");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var invisibilitybuff = library.Get<BlueprintBuff>("525f980cb29bc2240b93e953974cb325");



            banditrogueRW.AddFacts = banditrogueRW.AddFacts.AddToArray(invisibilitybuff);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)banditrogueRW.AddFacts[0], "banditroguerangedRWfeature", "4e1591dbd19d4468aeb0b480dec0777f");
            banditrogueRW.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var banditrogueRWnew = library.Get<BlueprintFeature>("4e1591dbd19d4468aeb0b480dec0777f");



            var fighterLevels = banditrogueRWnew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            banditrogueRWnew.ReplaceComponent(fighterLevels, newAddClassLevels);






            var brain = banditrogueRW.Brain;
            brain.Actions = brain.Actions.AddToArray();


        }

        static void updatebanditfighterRW()
        {

            var banditfighterRW = library.Get<BlueprintUnit>("057aaf8db6bc4bc2bf963bbe1a11e316");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");

            

            banditfighterRW.AddFacts = banditfighterRW.AddFacts.AddToArray(disarm);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)banditfighterRW.AddFacts[0], "banditfighterRWfeature", "fdd50427e27c424c92306fe7f1e5cbcf");
            banditfighterRW.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var banditfighterRWnew = library.Get<BlueprintFeature>("fdd50427e27c424c92306fe7f1e5cbcf");


            var fighterLevels = banditfighterRWnew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            banditfighterRWnew.ReplaceComponent(fighterLevels, newAddClassLevels);


            var brain = banditfighterRW.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedisarm,AiActions.cleave);


        }

        static void updatebanditfighterLH()
        {

            var banditfighterLH = library.Get<BlueprintUnit>("c85030f5bd794e9e8878d364edc624e6");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");

            banditfighterLH.AddFacts = banditfighterLH.AddFacts.AddToArray(disarm);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)banditfighterLH.AddFacts[0], "banditfighterLHfeature", "a8f73e21beda4334b7cb201dab8a94aa");
            banditfighterLH.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var banditfighterLHnew = library.Get<BlueprintFeature>("a8f73e21beda4334b7cb201dab8a94aa");


            var fighterLevels = banditfighterLHnew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            banditfighterLHnew.ReplaceComponent(fighterLevels, newAddClassLevels);


            var brain = banditfighterLH.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedisarm,AiActions.cleave);


        }

        static void updatebanditfighterRangedRW()
        {

            var banditfighterrangedRW = library.Get<BlueprintUnit>("b6eda239cb1d48d5935e9472a2a926a7");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)banditfighterrangedRW.AddFacts[0], "banditfighterrangedRuinWatchfeature", "02c1171e1525412081dafbe2e8b25a8d");
            banditfighterrangedRW.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var banditfighterRWnew = library.Get<BlueprintFeature>("02c1171e1525412081dafbe2e8b25a8d");


            var fighterLevels = banditfighterRWnew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            banditfighterRWnew.ReplaceComponent(fighterLevels, newAddClassLevels);


            var brain = banditfighterrangedRW.Brain;
            brain.Actions = brain.Actions.AddToArray();


        }

        static void updatebanditfighterRangedLH()
        {

            var banditfighterrangedLH = library.Get<BlueprintUnit>("cba50ae6db564bd5b128199e1833be3e");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)banditfighterrangedLH.AddFacts[0], "banditfighterrangedLHfeature", "daa658a370cf4c18a854836501f714d4");
            banditfighterrangedLH.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var banditfighterLHnew = library.Get<BlueprintFeature>("daa658a370cf4c18a854836501f714d4");


            var fighterLevels = banditfighterLHnew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            banditfighterLHnew.ReplaceComponent(fighterLevels, newAddClassLevels);


            var brain = banditfighterrangedLH.Brain;
            brain.Actions = brain.Actions.AddToArray();


        }

        static void updatebanditconjurerLH()
        {

            var banditconjurerLH = library.Get<BlueprintUnit>("16a4df6a38a54280b4819703d255136b");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var BanditConjurationFeatureListLevel7 = library.Get<BlueprintFeature>("d10e5863b15db1b4f93da585e1d4a9fb");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var EnlargePersonMass = library.Get<BlueprintAbility>("66dc49bf154863148bd217287079245e");
            var catsgrace = library.Get<BlueprintAbility>("de7a025d48ad5da4991e7d3c682cf69d");
            var slowaiaction = library.Get<BlueprintAiAction>("d67858e438dd8834f9e61a1cb1c592a6");
            var bullsstrength = library.Get<BlueprintAbility>("4c3d08935262b6544ae97599b3a9556d");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var enlargeperson = library.Get<BlueprintAbility>("c60969e7f264e6d4b84a1499fdcf9039");
            var hurricanebow = library.Get<BlueprintAbility>("3e9d1119d43d07c4c8ba9ebfd1671952");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var AcidSplashAiAction = library.Get<BlueprintAiAction>("8cf4732cf870f8f4cbf760331c8f2696");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var summonmonsterIV = library.Get<BlueprintAbility>("7ed74a3ec8c458d4fb50b192fd7be6ef");
            var summonelementalmedium = library.Get<BlueprintAbility>("e42b1dbff4262c6469a9ff0a6ce730e3");
            var summonmonsterIII = library.Get<BlueprintAbility>("5d61dde0020bbf54ba1521f7ca0229dc");
            var fireball = library.Get<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            var summonmonsterII = library.Get<BlueprintAbility>("1724061e89c667045a6891179ee2e8e7");
            var summonmonsterI = library.Get<BlueprintAbility>("8fd74eddd9b6c224693d9ab241f25e84");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");

            banditconjurerLH.Dexterity = 16;

            banditconjurerLH.AddFacts = banditconjurerLH.AddFacts.AddToArray(blurbuff, quicken,combatcasting);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)banditconjurerLH.AddFacts[0], "banditconjurerLHfeature", "2b0c420fa6654a27b0df27b6b7c44246");
            banditconjurerLH.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BanditConjurationFeatureListLevel7.GetComponent<AddFacts>().Facts[1], "banditconjurerLHfeatureListNew", "0c68b796efd1498f9979a1e9dd463587");
            BanditConjurationFeatureListLevel7.GetComponent<AddFacts>().Facts[1] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var banditconjurerLHFeatureNew = library.Get<BlueprintFeature>("2b0c420fa6654a27b0df27b6b7c44246");
            var banditconjurerLHSpellsNew = library.Get<BlueprintFeature>("0c68b796efd1498f9979a1e9dd463587");



            var wizardLevels = banditconjurerLHFeatureNew.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels = wizardLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(mirrorimage, magicmissle, magicmissle, magicmissle, summonelementalmedium, summonmonsterIV,haste,fireball,acidarrow,acidarrow,snowball);
            newAddClassLevels.MemorizeSpells = spell_list;
            banditconjurerLHFeatureNew.ReplaceComponent(wizardLevels, newAddClassLevels);

            var wizardLevels3 = banditconjurerLHFeatureNew.ComponentsArray
 .OfType<AddClassLevels>()
    .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels3 = wizardLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.MemorizeSpells.RemoveFromArray(summonmonsterIV);
            newAddClassLevels3.MemorizeSpells = spell_list3;
            banditconjurerLHFeatureNew.ReplaceComponent(wizardLevels3, newAddClassLevels3);

            var wizardLevels6 = banditconjurerLHFeatureNew.ComponentsArray
           .OfType<AddClassLevels>()
           .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels6 = wizardLevels6.CreateCopy();
            var spell_list6 = newAddClassLevels6.MemorizeSpells.RemoveFromArray(summonmonsterIII);
            newAddClassLevels6.MemorizeSpells = spell_list6;
            banditconjurerLHFeatureNew.ReplaceComponent(wizardLevels6, newAddClassLevels6);

            var wizardLevels7 = banditconjurerLHFeatureNew.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels7 = wizardLevels7.CreateCopy();
            var spell_list7 = newAddClassLevels7.MemorizeSpells.RemoveFromArray(summonmonsterIII);
            newAddClassLevels7.MemorizeSpells = spell_list7;
            banditconjurerLHFeatureNew.ReplaceComponent(wizardLevels7, newAddClassLevels7);

            var wizardLevels8 = banditconjurerLHFeatureNew.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels8 = wizardLevels7.CreateCopy();
            var spell_list8 = newAddClassLevels8.MemorizeSpells.RemoveFromArray(summonmonsterII);
            newAddClassLevels8.MemorizeSpells = spell_list8;
            banditconjurerLHFeatureNew.ReplaceComponent(wizardLevels8, newAddClassLevels8);

            var wizardLevels9 = banditconjurerLHFeatureNew.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels9 = wizardLevels9.CreateCopy();
            var spell_list9 = newAddClassLevels9.MemorizeSpells.RemoveFromArray(summonmonsterII);
            newAddClassLevels9.MemorizeSpells = spell_list9;
            banditconjurerLHFeatureNew.ReplaceComponent(wizardLevels9, newAddClassLevels9);

            var wizardLevels10 = banditconjurerLHFeatureNew.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels10 = wizardLevels10.CreateCopy();
            var spell_list10 = newAddClassLevels10.MemorizeSpells.RemoveFromArray(summonmonsterI);
            newAddClassLevels10.MemorizeSpells = spell_list10;
            banditconjurerLHFeatureNew.ReplaceComponent(wizardLevels10, newAddClassLevels10);

            var wizardLevels4 = banditconjurerLHFeatureNew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels4 = wizardLevels4.CreateCopy();
            var spell_list4 = newAddClassLevels4.MemorizeSpells.RemoveFromArray(summonmonsterIV);
            newAddClassLevels4.MemorizeSpells = spell_list4;
            banditconjurerLHFeatureNew.ReplaceComponent(wizardLevels4, newAddClassLevels4);

            var wizardLevels2 = banditconjurerLHSpellsNew.ComponentsArray
        .OfType<LearnSpells>()
          .First(c => c.CharacterClass == wizardClass);
            var newbardLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newbardLevels2.Spells.AddToArray(haste, blur, magicmissle, summonelementalmedium, summonmonsterIV,fireball,acidarrow, snowball);
            newbardLevels2.Spells = spell_list2;
            banditconjurerLHSpellsNew.ReplaceComponent(wizardLevels2, newbardLevels2);

            var wizardLevels5 = banditconjurerLHFeatureNew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels5 = wizardLevels5.CreateCopy();
            var spell_list5 = newAddClassLevels5.SelectSpells.AddToArray(mirrorimage, magicmissle, magicmissle, magicmissle, summonelementalmedium, summonmonsterIV,haste,fireball,acidarrow,acidarrow,snowball);
            newAddClassLevels5.SelectSpells = spell_list5;
            banditconjurerLHFeatureNew.ReplaceComponent(wizardLevels5, newAddClassLevels5);




            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);

            var dumbmonsterbrain = library.Get<BlueprintBrain>("5abc8884c6f15204c8604cb01a2efbab");

            var new_actions = dumbmonsterbrain.Actions;

            banditconjurerLH.Brain.Actions = new_actions;


            var brain = banditconjurerLH.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.mirrorimage, AiActions.castsummonmonsterIV,
                                                     AiActions.casthaste, AiActions.castmagicmissletransmuter,AiActions.summonelementalmediumfire, AiActions.castfireball,AiActions.castsnowballwitch);


        }

        static void updatebanditarmoredleader()
        {

            var banditarmor = library.Get<BlueprintUnit>("ca7a15c017b96ae48839f08158aa3302");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var sunder = library.Get<BlueprintFeature>("9719015edcbf142409592e2cbaab7fe1");

            banditarmor.AddFacts = banditarmor.AddFacts.AddToArray(sunder);


            var fighterLevels = banditarmor.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            banditarmor.ReplaceComponent(fighterLevels, newAddClassLevels);


            var brain = banditarmor.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usesunderarmorzombiebarb);


        }



        static void updateKoboldKeyKeeper()
        {

            var koboldkeykeeper = library.Get<BlueprintUnit>("787131e823d4c954cb7a156b69b17f03");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var natarmor1 = library.Get<BlueprintUnitFact>("10c7c5e3c5806bc4ca676e22d6fbf17e");
            var natarmor3 = library.Get<BlueprintUnitFact>("f6e106931f95fec4eb995f0d0629fb84");
            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");
            var koboldfeature4 = library.Get<BlueprintFeature>("c23e5bc94a8eb674a82c3ff88af8ce85");
            var koboldfeature2 = library.Get<BlueprintFeature>("17ac7f44b2f29334e953db0bc5a9e1be");

            koboldkeykeeper.AddFacts = koboldkeykeeper.AddFacts.RemoveFromArray(natarmor1);
            koboldkeykeeper.AddFacts = koboldkeykeeper.AddFacts.RemoveFromArray(koboldfeature2);
            koboldkeykeeper.AddFacts = koboldkeykeeper.AddFacts.AddToArray(koboldfeature4, natarmor3, trip);

            koboldkeykeeper.Dexterity = 18;

            koboldkeykeeper.Prefab = new UnitViewLink() { AssetId = "0496c6ca245b6be4494eb337a162ec49" };


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)koboldkeykeeper.AddFacts[0], "koboldkeykeeperfeaturenew", "da3b7618967147f09bd24e663684e571");
            koboldkeykeeper.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            koboldkeykeeper.LocalizedName = Helpers.Create<SharedStringAsset>(c => c.String = Helpers.CreateString($"{koboldkeykeeper.name}.name", "Kobold Blade"));


            var koboldkeykeeperfeaturenew = library.Get<BlueprintFeature>("da3b7618967147f09bd24e663684e571");



            var fighterLevels = koboldkeykeeperfeaturenew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            koboldkeykeeperfeaturenew.ReplaceComponent(fighterLevels, newAddClassLevels);


            koboldkeykeeper.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("455c6750aac8fa94f8ab19f385c73ae7");//masterwork shortsword
            koboldkeykeeper.Body.SecondaryHand = null;
            koboldkeykeeper.Body.SecondaryHand = library.Get<BlueprintItemShield>("a85d51d0fb905f940b951eec60388bac");
            koboldkeykeeper.Body.Armor = library.Get<BlueprintItemArmor>("9809987cc12d94545a64ff20e6fdb216");


            var brain = koboldkeykeeper.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }

        static void updateKoboldBladeCR3()
        {

            var koboldbladeCR3 = library.Get<BlueprintUnit>("3b5011e421ea0f54f93695b26c43ce33");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var natarmor1 = library.Get<BlueprintUnitFact>("10c7c5e3c5806bc4ca676e22d6fbf17e");
            var natarmor3 = library.Get<BlueprintUnitFact>("f6e106931f95fec4eb995f0d0629fb84");
            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");
            

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

        static void updateKoboldBladeCR3B()
        {

            var koboldbladeCR3 = library.Get<BlueprintUnit>("9c5720dd841249eaa2627bca7326cd40");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var natarmor1 = library.Get<BlueprintUnitFact>("10c7c5e3c5806bc4ca676e22d6fbf17e");
            var natarmor3 = library.Get<BlueprintUnitFact>("f6e106931f95fec4eb995f0d0629fb84");
            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");
            var koboldfeature4 = library.Get<BlueprintFeature>("c23e5bc94a8eb674a82c3ff88af8ce85");
            var koboldfeature2 = library.Get<BlueprintFeature>("17ac7f44b2f29334e953db0bc5a9e1be");

            koboldbladeCR3.AddFacts = koboldbladeCR3.AddFacts.RemoveFromArray(natarmor1);
            koboldbladeCR3.AddFacts = koboldbladeCR3.AddFacts.RemoveFromArray(koboldfeature2);
            koboldbladeCR3.AddFacts = koboldbladeCR3.AddFacts.AddToArray(koboldfeature4,natarmor3, trip);

            koboldbladeCR3.Dexterity = 18;

            koboldbladeCR3.Prefab = new UnitViewLink() { AssetId = "0496c6ca245b6be4494eb337a162ec49" };


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)koboldbladeCR3.AddFacts[0], "koboldbladeCR3featurenewB", "3d8b1fefe54e422ba589291b3160f9b9");
            koboldbladeCR3.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var koboldbladeCR3new = library.Get<BlueprintFeature>("3d8b1fefe54e422ba589291b3160f9b9");



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


            koboldbladeCR3.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("455c6750aac8fa94f8ab19f385c73ae7");//masterwork shortsword
            koboldbladeCR3.Body.SecondaryHand = null;
            koboldbladeCR3.Body.SecondaryHand = library.Get<BlueprintItemShield>("a85d51d0fb905f940b951eec60388bac");
            koboldbladeCR3.Body.Armor = library.Get<BlueprintItemArmor>("9809987cc12d94545a64ff20e6fdb216");
            

            var brain = koboldbladeCR3.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }

        static void updateKoboldHunter()
        {

            var koboldarcher = library.Get<BlueprintUnit>("bd58fd5e18aa48d891045e42fe5f2afc");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var koboldfeaturearcher5 = library.Get<BlueprintFeature>("967acc8bcc56c424b88227a70be86579");
            var koboldfeaturearcher2 = library.Get<BlueprintFeature>("eb991372af2e14840a73c699ae4937fc");



            koboldarcher.AddFacts = koboldarcher.AddFacts.RemoveFromArray(koboldfeaturearcher2);
            koboldarcher.AddFacts = koboldarcher.AddFacts.AddToArray(koboldfeaturearcher5);


            


        }

        static void updateKoboldEvokerTrollbold()
        {

            var koboldevoker = library.Get<BlueprintUnit>("7c2e6cbfc0644d1c80a13c6f4d8aa294");
            var natarmor1 = library.Get<BlueprintUnitFact>("10c7c5e3c5806bc4ca676e22d6fbf17e");
            var natarmor3 = library.Get<BlueprintUnitFact>("f6e106931f95fec4eb995f0d0629fb84");
            var KoboldShamanFeatureListLevel5 = library.Get<BlueprintFeature>("451774fee21d0d14db1a9f10c1c886d9");
            var sorcerer = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var fireball = library.Get<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3");






            koboldevoker.AddFacts = koboldevoker.AddFacts.AddToArray(combatcasting,blurbuff);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)koboldevoker.AddFacts[0], "koboldevokertroboldfeature", "11d6fde1de9342eebec2b89cfd8121f5");
            koboldevoker.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)KoboldShamanFeatureListLevel5.GetComponent<AddFacts>().Facts[0], "KoboldEvokerSpellListnew", "1bd437b495544e0dbcf8c8e20dde406e");
            KoboldShamanFeatureListLevel5.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var koboldonmarchshamanfeature = library.Get<BlueprintFeature>("11d6fde1de9342eebec2b89cfd8121f5");
            var koboldonmarchshamanspelllist = library.Get<BlueprintFeature>("1bd437b495544e0dbcf8c8e20dde406e");

            var sorcererLevels = koboldonmarchshamanfeature.ComponentsArray
           .OfType<AddClassLevels>()
           .First(c => c.CharacterClass == sorcerer);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.Levels = 6;

            koboldonmarchshamanfeature.ReplaceComponent(sorcererLevels, newAddClassLevels);



            var sorcererLevels2 = koboldonmarchshamanspelllist.ComponentsArray
     .OfType<LearnSpells>()
    .First(c => c.CharacterClass == sorcerer);
            var newsorcererLevels2 = sorcererLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.Spells.AddToArray(haste, fireball);
            newsorcererLevels2.Spells = spell_list2;
            koboldonmarchshamanspelllist.ReplaceComponent(sorcererLevels2, newsorcererLevels2);


            var brain = koboldevoker.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castfireball,AiActions.casthastegoblin,AiActions.mirrorimage,AiActions.scorchingraydelay);

        }

        static void updateKoboldOnMarchShaman()
        {

            var koboldonmarchshaman = library.Get<BlueprintUnit>("8d5c0bf59f438734aad7396dce8ab4a0");
            var natarmor1 = library.Get<BlueprintUnitFact>("10c7c5e3c5806bc4ca676e22d6fbf17e");
            var natarmor3 = library.Get<BlueprintUnitFact>("f6e106931f95fec4eb995f0d0629fb84");
            var KoboldShamanFeatureListLevel5 = library.Get<BlueprintFeature>("451774fee21d0d14db1a9f10c1c886d9");
            var sorcerer = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");





            koboldonmarchshaman.AddFacts = koboldonmarchshaman.AddFacts.RemoveFromArray(natarmor1);
            koboldonmarchshaman.AddFacts = koboldonmarchshaman.AddFacts.AddToArray(natarmor3, KoboldShamanFeatureListLevel5, combatcasting, blurbuff);
            koboldonmarchshaman.AddFacts = koboldonmarchshaman.AddFacts.AddToArray(combatcasting, blurbuff);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)koboldonmarchshaman.AddFacts[6], "koboldonmarchshamanfeature", "057a726f59574304a14523cd3cb6d80c");
            koboldonmarchshaman.AddFacts[6] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)KoboldShamanFeatureListLevel5.GetComponent<AddFacts>().Facts[0], "KoboldOnMarchSpellList", "fe2498ed843e4bdcb381959e031037e8");
            KoboldShamanFeatureListLevel5.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var koboldonmarchshamanfeature = library.Get<BlueprintFeature>("057a726f59574304a14523cd3cb6d80c");
            var koboldonmarchshamanspelllist = library.Get<BlueprintFeature>("fe2498ed843e4bdcb381959e031037e8");

            var sorcererLevels = koboldonmarchshamanfeature.ComponentsArray
           .OfType<AddClassLevels>()
           .First(c => c.CharacterClass == sorcerer);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.Levels = 2;

            koboldonmarchshamanfeature.ReplaceComponent(sorcererLevels, newAddClassLevels);



            var sorcererLevels2 = koboldonmarchshamanspelllist.ComponentsArray
     .OfType<LearnSpells>()
    .First(c => c.CharacterClass == sorcerer);
            var newsorcererLevels2 = sorcererLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.Spells.AddToArray(haste, lightningbolt);
            newsorcererLevels2.Spells = spell_list2;
            koboldonmarchshamanspelllist.ReplaceComponent(sorcererLevels2, newsorcererLevels2);


            var brain = koboldonmarchshaman.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltairelemental, AiActions.casthastegoblin, AiActions.mirrorimage, AiActions.scorchingraydelay);

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
            var web = library.Get<BlueprintAbility>("134cb6d492269aa4f8662700ef57449f");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var slow = library.Get<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
            var stinkycloud = library.Get<BlueprintAbility>("68a9e6d7256f1354289a39003a46d826");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");

            boneshaman.AddFacts = boneshaman.AddFacts.AddToArray(blurbuff,magearmorbuff);

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
            var spell_list = newsorcererLevels.SelectSpells.AddToArray(haste, slow, web,magicmissle);
            newsorcererLevels.SelectSpells = spell_list;
            boneshamanfeature.ReplaceComponent(sorcererLevels, newsorcererLevels);

            var sorcererLevels2 = boneshamanspells.ComponentsArray
                .OfType<LearnSpells>()
              .First(c => c.CharacterClass == sorcerer);
            var newsorcererLevels2 = sorcererLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.Spells.AddToArray(haste, slow, web,magicmissle);
            newsorcererLevels2.Spells = spell_list2;
            boneshamanspells.ReplaceComponent(sorcererLevels2, newsorcererLevels2);

           



            

            var brain = boneshaman.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.casthastetartuk, AiActions.castslow,AiActions.useweb,AiActions.castmagicmissletransmuter);

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

        static void fixHargulka()
        {

            var hargulka = library.Get<BlueprintUnit>("e83f8b843d2bbb24ea9cc13094e817c1");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");

            hargulka.Strength = 24;
            hargulka.Constitution = 26;


            hargulka.Skills.Diplomacy = 5;

            hargulka.AddFacts = hargulka.AddFacts.AddToArray(cornugon);


            var brain = hargulka.Brain;
            brain.Actions = brain.Actions.AddToArray();


        }



        //CHAPTER 2 Season of Bloom

        //Swamp

        static void updateSwampWitch()
        {



            var SwampWitch = library.Get<BlueprintUnit>("8a8040cb628dbfe4c97b4d4e19898de3");
            var SwampWitchFeatureList = library.Get<BlueprintFeature>("cdc61df598aef7a4db2bfa911367be32");
            var SwampWitchOldSpells = library.Get<BlueprintFeature>("d4678d07c09f4804c8d342fe5454bd34");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var blindness = library.Get<BlueprintAbility>("46fd02ad56c35224c9c91c88cd457791");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var phantasmalweb = library.Get<BlueprintAbility>("12fb4a4c22549c74d949e2916a2f0b6a");
            var balefulpolymorph = library.Get<BlueprintAbility>("3105d6e9febdc3f41a08d2b7dda1fe74");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            var boneshaker = library.Get<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
            var ZombieFearAIAction = library.Get<BlueprintAiAction>("7cff1a10bbe680f4b835017c4671704a");
            var CephalMirrorImageAI = library.Get<BlueprintAiAction>("92aa06fa558317741aaa49ef312508cc");
            var SlowAiAction = library.Get<BlueprintAiAction>("d67858e438dd8834f9e61a1cb1c592a6");
            var RivalBlindnessAI = library.Get<BlueprintAiAction>("5ddad52f0ff6a6e4bb6c824ea62aa227");



        var wizardLevels = SwampWitchFeatureList.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newwizardLevels = wizardLevels.CreateCopy();
            newwizardLevels.Levels = 10;
            var spell_list = newwizardLevels.MemorizeSpells.AddToArray(haste, displacement,phantasmalweb,mirrorimage,balefulpolymorph,snowball,snowball,snowball,snowball,boneshaker,boneshaker);
            newwizardLevels.MemorizeSpells = spell_list;
            SwampWitchFeatureList.ReplaceComponent(wizardLevels, newwizardLevels);

            var wizardLevels3 = SwampWitchFeatureList.ComponentsArray
        .OfType<AddClassLevels>()
        .First(c => c.CharacterClass == wizardClass);
            var newwizardLevels3 = wizardLevels3.CreateCopy();
            var spell_list3 = newwizardLevels3.MemorizeSpells.RemoveFromArray(blindness);
            newwizardLevels3.MemorizeSpells = spell_list3;
            SwampWitchFeatureList.ReplaceComponent(wizardLevels3, newwizardLevels3);

            var wizardLevels4 = SwampWitchFeatureList.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newwizardLevels4 = wizardLevels4.CreateCopy();
            var spell_list4 = newwizardLevels4.MemorizeSpells.RemoveFromArray(blindness);
            newwizardLevels4.MemorizeSpells = spell_list4;
            SwampWitchFeatureList.ReplaceComponent(wizardLevels4, newwizardLevels4);


            var wizardLevels5 = SwampWitchFeatureList.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newwizardLevels5 = wizardLevels5.CreateCopy();
            var spell_list5 = newwizardLevels5.MemorizeSpells.RemoveFromArray(blindness);
            newwizardLevels5.MemorizeSpells = spell_list5;
            SwampWitchFeatureList.ReplaceComponent(wizardLevels5, newwizardLevels5);

            var wizardLevels6 = SwampWitchFeatureList.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newwizardLevels6 = wizardLevels6.CreateCopy();
            var spell_list6 = newwizardLevels6.MemorizeSpells.RemoveFromArray(blindness);
            newwizardLevels6.MemorizeSpells = spell_list6;
            SwampWitchFeatureList.ReplaceComponent(wizardLevels6, newwizardLevels6);

     

            var wizardLevels2 = SwampWitchOldSpells.ComponentsArray
                 .OfType<LearnSpells>()
                .First(c => c.CharacterClass == wizardClass);
            var newwizardLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newwizardLevels2.Spells.AddToArray(haste, displacement,phantasmalweb,mirrorimage,balefulpolymorph, snowball, boneshaker);
            newwizardLevels2.Spells = spell_list2;
            SwampWitchOldSpells.ReplaceComponent(wizardLevels2, newwizardLevels2);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);


            SwampWitch.AddFacts = SwampWitch.AddFacts.AddToArray(quicken);

            var brain = SwampWitch.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(ZombieFearAIAction);
            brain.Actions = brain.Actions.RemoveFromArray(CephalMirrorImageAI);
            brain.Actions = brain.Actions.RemoveFromArray(SlowAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(RivalBlindnessAI);
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai,AiActions.usephantasmalwebwitch,
                                                     AiActions.castslowvordakai,AiActions.castbalefulpolymorphwitch,
                                                     AiActions.castslow,AiActions.mirrorimage,AiActions.castblindnesswitch,AiActions.castfearwitch,AiActions.castsnowballwitch,AiActions.castboneshaker);



        }

        static void changeSwampWerewolf()
        {
            var SwampWerewolf = library.Get<BlueprintUnit>("59d1d038c06d81248b0cb453f39eaed3");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");


            SwampWerewolf.AddFacts = SwampWerewolf.AddFacts.AddToArray(cornugon);

            SwampWerewolf.Skills.Diplomacy = 8;



            var fighterLevels = SwampWerewolf.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 9;

            SwampWerewolf.ReplaceComponent(fighterLevels, newAddClassLevels);




            var brain = SwampWerewolf.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig);



        }

        static void changeLonelyGhoul()
        {
            var LonelyGhoul = library.Get<BlueprintUnit>("7f283b7e1a9275c43854b1d78654de5f");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var LonelyGhoulFeature = library.Get<BlueprintFeature>("6abb5d86a51793045ae32fcd96127e5e");
            var sunder = library.Get<BlueprintFeature>("9719015edcbf142409592e2cbaab7fe1");
            var greatfort = library.Get<BlueprintFeature>("79042cb55f030614ea29956177977c52");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var summonundeadfriends = library.Get<BlueprintAbility>("119a6fc4756c45a7a329859f030836c2");

            LonelyGhoul.AddFacts = LonelyGhoul.AddFacts.AddToArray(summonundeadfriends);


            var fighterLevels = LonelyGhoulFeature.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 10;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(sunder,greatfort,cornugon);

            }
            LonelyGhoulFeature.ReplaceComponent(fighterLevels, newAddClassLevels);
            

            LonelyGhoul.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2618c8c4e4be9bc48acdbcc7d92d6dc1"); //Handaxe +1
            LonelyGhoul.Body.SecondaryHand = library.Get<BlueprintItemShield>("5c7b898a1bfb6cb4f8c14a0ebc143abe"); //heavy shield +1

            var brain = LonelyGhoul.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usesunderarmorzombiebarb,AiActions.usesummonundeadfriends);



        }

        static void changeNarlmarshscythetree()
        {
            var Narlmarshscythetree = library.Get<BlueprintUnit>("4071046a044c91d4fa60300d90d52012");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            Narlmarshscythetree.Strength = 30;

            Narlmarshscythetree.MaxHP = 80;
            Narlmarshscythetree.AddFacts = Narlmarshscythetree.AddFacts.AddToArray(toughness);

            var cyclopbrain = library.Get<BlueprintBrain>("f87e097ef7ce1804a95dd6b9ba5fb77e");

            var new_actions = cyclopbrain.Actions;

            Narlmarshscythetree.Brain.Actions = new_actions;

            var brain = Narlmarshscythetree.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);



        }

        static void updateGhostPriest()

        {


            var Priestghost = library.Get<BlueprintUnit>("5b75febc11656504d9737dce197acb73");
            var clericclass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var boneshaker = library.Get<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var slayliving = library.Get<BlueprintAbility>("4fbd47525382517419c66fb548fe9a67");
            var bane = library.Get<BlueprintAbility>("8bc64d869456b004b9db255cdd1ea734");
            var HoldPersonAiAction = library.Get<BlueprintAiCastSpell>("093e88ae36b09d941aee8c1d4d628156");
            var divinepower = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var Resistenergycommunal = library.Get<BlueprintAbility>("7bb0c402f7f789d4d9fae8ca87b4c7e2");
            var dispel = library.Get<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
            var rayofsickening = library.Get<BlueprintAbility>("fa3078b9976a5b24caf92e20ee9c0f54");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var channelnegativeenergyfeature = library.Get<BlueprintFeature>("3adb2c906e031ee41a01bfc1d5fb7eea");
            var channelnegativeenergy = library.Get<BlueprintAbility>("89df18039ef22174b81052e2e419c728");
            var weaponfinesse = library.Get<BlueprintFeature>("90e54424d682d104ab36436bd527af09");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            
            var summonghosts2 = library.Get<BlueprintAbility>("2cbda65cde8f462baf8994af02854d4e");
            


        Priestghost.AddFacts = Priestghost.AddFacts.AddToArray(quicken,channelnegativeenergyfeature,combatcasting,summonghosts2);

            Priestghost.Dexterity = 26;

            Priestghost.Strength = 20;

            var fighterLevels = Priestghost.ComponentsArray
            .OfType<AddClassLevels>()
              .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 2;
            Priestghost.ReplaceComponent(fighterLevels, newAddClassLevels);



            var wizardLevels = Priestghost.GetComponent<AddClassLevels>();
            var newwizardLevels = wizardLevels.CreateCopy();
            newwizardLevels.CharacterClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            newwizardLevels.Levels = 10;
            Priestghost.AddComponent(newwizardLevels);



            var wizardLevels5 = Priestghost.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericclass);
            var newsorcererLevels5 = wizardLevels5.CreateCopy();
            var spell_list5 = newsorcererLevels5.MemorizeSpells.AddToArray(boneshaker, boneshaker, slayliving, slayliving, bane, divinepower, dispel, dispel);
            newsorcererLevels5.MemorizeSpells = spell_list5;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(weaponfinesse);

            }
            Priestghost.ReplaceComponent(wizardLevels5, newsorcererLevels5);


            Priestghost.Body.DisableHands = false;

            Priestghost.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("5fe90cd1d77d8f446ac955dec7c8759f"); //dagger +1



            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);

            var brain = Priestghost.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(HoldPersonAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castbane, AiActions.castslayliving, AiActions.divine_power_first,
                                                     AiActions.castresistfirecommunal, AiActions.castboneshaker, AiActions.dispel, AiActions.castrayofsickening,
                                                     AiActions.holdpersonzombiecleric,AiActions.castnegativeenergyghostcleric,
                                                     AiActions.usesummonghosts2);

        }

        static void updateGhostStandard()

        {


            var standardghost = library.Get<BlueprintUnit>("655ac57b330918c4aadc78a00fb2ccaf");
            
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var improvedinitiative = library.Get<BlueprintFeature>("797f25d709f559546b29e7bcb181cc74");
            var weaponfinesse = library.Get<BlueprintFeature>("90e54424d682d104ab36436bd527af09");
            var unholygrace = library.Get<BlueprintFeature>("2334cca051360914d970839e81b1f7d9");

            standardghost.Dexterity = 22;

            standardghost.Strength = 18;


            {

                var wizardLevels = standardghost.GetComponent<AddClassLevels>();
                var newwizardLevels = wizardLevels.CreateCopy();
                newwizardLevels.CharacterClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
                newwizardLevels.Levels = 1;
                standardghost.AddComponent(newwizardLevels);





                standardghost.AddFacts = standardghost.AddFacts.AddToArray(weaponfinesse);
                standardghost.AddFacts = standardghost.AddFacts.RemoveFromArray(unholygrace);


                standardghost.Body.DisableHands = false;

                standardghost.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("03d706655c07d804cb9d5a5583f9aec5"); //longsword +1
                



                var brain = standardghost.Brain;
                brain.Actions = brain.Actions.AddToArray();


            }
        }


        //Lonely Barrow

        static void changeEasyBanditArcher()
        {
            var EasyArcher = library.Get<BlueprintUnit>("1c606a085e0d5d640b19ec180ab88ac2");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var WeaponFocusHeavyCrossbow  = library.Get<BlueprintFeature>("6cbf2c8b9e642874e8146900f4e1db6e");
            

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)EasyArcher.AddFacts[0], "EasyArcherFeature", "4dd378fada6f4fc194302bd32201df3a");
            EasyArcher.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            EasyArcher.AddFacts = EasyArcher.AddFacts.AddToArray(WeaponFocusHeavyCrossbow);

            var EasyArcherfeature = library.Get<BlueprintFeature>("4dd378fada6f4fc194302bd32201df3a");

            

            var fighterLevels = EasyArcherfeature.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            EasyArcherfeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            EasyArcher.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("e8aa3f5ca26027b4b846de538b01ee50");

            EasyArcher.GetComponent<Experience>().CR = 6;

            var brain = EasyArcher.Brain;
            brain.Actions = brain.Actions.AddToArray();



        }

        static void changeEasyBanditMelee()
        {
            var EasyFighter = library.Get<BlueprintUnit>("1c606a085e0d5d640b19ec180ab88ac2");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var armortraining = library.Get<BlueprintFeature>("3c380607706f209499d951b29d3c44f3");

            EasyFighter.AddFacts = EasyFighter.AddFacts.AddToArray(disarm,armortraining);

            EasyFighter.MaxHP = 20;


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)EasyFighter.AddFacts[0], "EasyFighterFeature", "42687f0bebf3414d8c02ac55b9bd4333");
            EasyFighter.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var EasyFighterfeature = library.Get<BlueprintFeature>("42687f0bebf3414d8c02ac55b9bd4333");



            var fighterLevels = EasyFighterfeature.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            EasyFighterfeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            EasyFighter.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("03d706655c07d804cb9d5a5583f9aec5"); //longsword +1
            EasyFighter.Body.Armor = library.Get<BlueprintItemArmor>("1638fa11f5af1814191cf6c05cdcf2b6"); //Banded Armor

            EasyFighter.GetComponent<Experience>().CR = 6;


            var brain = EasyFighter.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave,AiActions.usedisarm);



        }

        static void changeHardBanditMelee()
        {
            var HardFighter = library.Get<BlueprintUnit>("25ad4b197154ee142a866fc6621eda58");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var clericClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var banditclericfeature = library.Get<BlueprintFeature>("7e05ee6b9875c354aa88985490e64baf");
            var banditfeatureold = library.Get<BlueprintFeature>("0796e3cb41397014fa31f0f7b4089273");
            var divinepower = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var prayer = library.Get<BlueprintAbility>("faabd2cc67efa4646ac58c7bb3e40fcc");
            var summonmonsterIV = library.Get<BlueprintAbility>("7ed74a3ec8c458d4fb50b192fd7be6ef");
            var summonmonsterIII = library.Get<BlueprintAbility>("5d61dde0020bbf54ba1521f7ca0229dc");
            var searing_light = library.Get<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var shieldoffaith = library.Get<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
            
            

        HardFighter.AddFacts = HardFighter.AddFacts.RemoveFromArray(banditfeatureold);

            HardFighter.AddFacts = HardFighter.AddFacts.AddToArray(banditclericfeature,quicken,combatcasting);


            HardFighter.Wisdom = 17;
            HardFighter.Strength = 13;


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)HardFighter.AddFacts[0], "HardFighterFeature", "b3155989de1140548464d049a5f19ef1");
            HardFighter.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)banditclericfeature.GetComponent<AddFacts>().Facts[0], "banditclericSpellListnew", "eaa1e770e4954579b05ebc51bcf0a3a2");
            banditclericfeature.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            HardFighter.GetComponent<Experience>().CR = 6;


            var HardFighterFeature = library.Get<BlueprintFeature>("b3155989de1140548464d049a5f19ef1");

            var HardFighterSpelllist = library.Get<BlueprintFeature>("eaa1e770e4954579b05ebc51bcf0a3a2");


            var clericLevels = HardFighterFeature.ComponentsArray
 .OfType<AddClassLevels>()
   .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            HardFighterFeature.ReplaceComponent(clericLevels, newAddClassLevels);

            var clericLevels2 = HardFighterFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels2 = clericLevels2.CreateCopy();
            var spell_list2 = newAddClassLevels2.MemorizeSpells.AddToArray(divinepower,searing_light,searing_light,searing_light,shieldoffaith);
            newAddClassLevels2.MemorizeSpells = spell_list2;
            HardFighterFeature.ReplaceComponent(clericLevels2, newAddClassLevels2);

            var clericLevels3 = HardFighterFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericClass);
            var newAddClassLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.MemorizeSpells.RemoveFromArray(summonmonsterIV);
            newAddClassLevels3.MemorizeSpells = spell_list3;
            HardFighterFeature.ReplaceComponent(clericLevels3, newAddClassLevels3);

            var clericLevels6 = HardFighterFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericClass);
            var newAddClassLevels6 = clericLevels6.CreateCopy();
            var spell_list6 = newAddClassLevels6.MemorizeSpells.RemoveFromArray(summonmonsterIV);
            newAddClassLevels6.MemorizeSpells = spell_list6;
            HardFighterFeature.ReplaceComponent(clericLevels6, newAddClassLevels6);

            var clericLevels5 = HardFighterFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericClass);
            var newAddClassLevels5 = clericLevels5.CreateCopy();
            var spell_list5 = newAddClassLevels5.MemorizeSpells.RemoveFromArray(summonmonsterIII);
            newAddClassLevels5.MemorizeSpells = spell_list5;
            HardFighterFeature.ReplaceComponent(clericLevels5, newAddClassLevels5);

            var clericLevels7 = HardFighterFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericClass);
            var newAddClassLevels7 = clericLevels7.CreateCopy();
            var spell_list7 = newAddClassLevels7.MemorizeSpells.RemoveFromArray(summonmonsterIII);
            newAddClassLevels7.MemorizeSpells = spell_list7;
            HardFighterFeature.ReplaceComponent(clericLevels7, newAddClassLevels7);



            var clericLevels4 = HardFighterSpelllist.ComponentsArray
.OfType<LearnSpells>()
.First(c => c.CharacterClass == clericClass);
            var newAddClassLevels4 = clericLevels4.CreateCopy();
            var spell_list4 = newAddClassLevels4.Spells.AddToArray(searing_light);
            newAddClassLevels4.Spells = spell_list4;
            HardFighterSpelllist.ReplaceComponent(clericLevels4, newAddClassLevels4);



            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);

            HardFighter.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("86d5d758c2dd24747bad1c7b1f32e9df"); //Heavy Mace +1


            var brain = HardFighter.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.divine_power_first, AiActions.prayergoblinshaman,AiActions.castsearinglight,
                                                    AiActions.blesscast,AiActions.holdpersondelaybanditcleric,AiActions.castshieldoffaith, AiActions.castsummonmonsterIV,
                                                    AiActions.castchannelpositivecleric);



        }

        static void changeHardBanditRanged()
        {
            var HardRanged = library.Get<BlueprintUnit>("340ebab8143070446b9d9ae4177868e1");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var banditfeatureold = library.Get<BlueprintFeature>("90326b88260d3a347b19aa0dbe86c757");
            var BanditIllusionistFeatureListLevel7 = library.Get<BlueprintFeature>("79dedb8dc3602654d883d9581a821627");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var slowaiaction = library.Get<BlueprintAiAction>("d67858e438dd8834f9e61a1cb1c592a6");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var fireball = library.Get<BlueprintAbility>("2d81362af43aeac4387a3d4fced489c3");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var slow = library.Get<BlueprintAbility>("f492622e473d34747806bdb39356eb89");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");
            var WeaponFocusHeavyCrossbow = library.Get<BlueprintFeature>("6cbf2c8b9e642874e8146900f4e1db6e");




            HardRanged.AddFacts = HardRanged.AddFacts.RemoveFromArray(banditfeatureold);
            HardRanged.AddFacts = HardRanged.AddFacts.RemoveFromArray(WeaponFocusHeavyCrossbow);

            HardRanged.AddFacts = HardRanged.AddFacts.AddToArray(BanditIllusionistFeatureListLevel7, quicken, combatcasting);


            HardRanged.Intelligence= 17;
            HardRanged.Strength = 11;


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)HardRanged.AddFacts[0], "HardRangedFeature", "7ca17dd1f0c6410ab156670a7051c143");
            HardRanged.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();





            var HardRangedFeature = library.Get<BlueprintFeature>("7ca17dd1f0c6410ab156670a7051c143");




            var wizardLevels = HardRangedFeature.ComponentsArray
 .OfType<AddClassLevels>()
   .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels = wizardLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            HardRangedFeature.ReplaceComponent(wizardLevels, newAddClassLevels);

            var wizardLevels2 = HardRangedFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newAddClassLevels2.MemorizeSpells.AddToArray(haste,mirrorimage,lightningbolt,lightningbolt);
            newAddClassLevels2.MemorizeSpells = spell_list2;
            HardRangedFeature.ReplaceComponent(wizardLevels2, newAddClassLevels2);

            var clericLevels3 = HardRangedFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.SelectSpells.AddToArray(haste,lightningbolt);
            newAddClassLevels3.SelectSpells = spell_list3;
            HardRangedFeature.ReplaceComponent(clericLevels3, newAddClassLevels3);



            var clericLevels5 = HardRangedFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels5 = clericLevels5.CreateCopy();
            var spell_list5 = newAddClassLevels5.MemorizeSpells.RemoveFromArray(displacement);
            newAddClassLevels5.MemorizeSpells = spell_list5;
            HardRangedFeature.ReplaceComponent(clericLevels5, newAddClassLevels5);


            HardRanged.GetComponent<Experience>().CR = 6;



            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);

            HardRanged.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("f5528acb89757ab4fb9350f45cc4f3b4"); //LightCrossbow +1
            HardRanged.Body.Armor = null;

            var brain = HardRanged.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltfourturns,AiActions.displacementvordakai,AiActions.mirrorimage,
                                                     AiActions.scorchingraydelay,AiActions.magicmissledelay,AiActions.castphantasmalkiller,AiActions.castinvisibilitygreater,AiActions.casthaste);



        }

        static void changeGraveRobber()
        {
            var GraveRobberLead = library.Get<BlueprintUnit>("40d09f58188b10c46882ca40584086a7");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var inquisitorClass = library.Get<BlueprintCharacterClass>("f1a70d9e1b0b41e49874e1fa9052a1ce");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var StoneskinBuffCL11 = library.Get<BlueprintBuff>("6215b25fbc1a36748b5606ebc0092074");
            var heroism = library.Get<BlueprintAbility>("5ab0d42fb68c9e34abae4921822b9d63");
            var fester = library.Get<BlueprintAbility>("2dbe271c979d9104c8e2e6b42e208e32");
            var dispel = library.Get<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
            var aid = library.Get<BlueprintAbility>("03a9630394d10164a9410882d31572f0");
            var shieldoffaith = library.Get<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var HasteScroll = library.Get<BlueprintItemEquipmentUsable>("6b3f04dd5eb9675499f815d5086fe018");
            var AidBuffCL20 = library.Get<BlueprintBuff>("b2cc506571b5b91449851738f8a51e14");
            var ProtectionJudgementBuff = library.Get<BlueprintBuff>("99345ce7c0f8001438fee23db660d039");
            var JusticeJudgementBuff = library.Get<BlueprintBuff>("fc246eb29c8f95c449fd156759f421e9");
            var Natarmor2 = library.Get<BlueprintUnitFact>("45a52ce762f637f4c80cc741c91f58b7");
            var WeaponTrainingHeavyBlades = library.Get<BlueprintFeature>("2a0ce0186af38ed419f47fce16f93c2a");
            var WeaponSpecializationGreatsword = library.Get<BlueprintFeature>("e08b448686657bc4887584a9a47ea8f7");
            var WeaponFocusGreatsword = library.Get<BlueprintFeature>("1fe672a404d821144bdbdfdf5c244137");
            var PreciseStrike = library.Get<BlueprintFeature>("5662d1b793db90c4b9ba68037fd2a768");
            var ShakeItOff = library.Get<BlueprintFeature>("6337b37f2a7c11b4ab0831d6780bce2a");
            var ShieldWall = library.Get<BlueprintFeature>("8976de442862f82488a4b138a0a89907");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");

            var banefeature = library.Get<BlueprintFeature>("a0571cc93916dcf498bcea611e9d5573");

            




            GraveRobberLead.AddFacts = GraveRobberLead.AddFacts.RemoveFromArray(WeaponTrainingHeavyBlades);
            GraveRobberLead.AddFacts = GraveRobberLead.AddFacts.RemoveFromArray(WeaponSpecializationGreatsword);
            GraveRobberLead.AddFacts = GraveRobberLead.AddFacts.RemoveFromArray(WeaponFocusGreatsword);


            var add_class_levels = GraveRobberLead.GetComponent<AddAbilityToCharacterComponent>();

            var ability_list = add_class_levels.Abilities.RemoveFromArray(haste);

            add_class_levels.Abilities = ability_list;



            GraveRobberLead.AddFacts = GraveRobberLead.AddFacts.AddToArray(StoneskinBuffCL11,quicken,AidBuffCL20,
                                       ProtectionJudgementBuff,JusticeJudgementBuff,Natarmor2,PreciseStrike,ShakeItOff,ShieldWall,toughness,combatcasting,dodge,banefeature);

            GraveRobberLead.Strength = 16;
            GraveRobberLead.Dexterity = 13;
            GraveRobberLead.Wisdom = 16;


            var inquisitorLevels = GraveRobberLead.ComponentsArray
            .OfType<AddClassLevels>()
              .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = inquisitorLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("f1a70d9e1b0b41e49874e1fa9052a1ce");
            newAddClassLevels.Levels = 10;
            GraveRobberLead.ReplaceComponent(inquisitorLevels, newAddClassLevels);

            GraveRobberLead.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("0a09740e6ab28984a8cd0e39a63dd161"); //Corrosive Rapier +2
            GraveRobberLead.Body.Armor = library.Get<BlueprintItemArmor>("5041415db3e6c394a8b2173c39fd4ec4"); //Breastplate +1
            GraveRobberLead.Body.SecondaryHand = library.Get<BlueprintItemShield>("5c7b898a1bfb6cb4f8c14a0ebc143abe"); // Heavy Shield +1
            

            GraveRobberLead.StartingInventory = GraveRobberLead.StartingInventory.RemoveFromArray(HasteScroll);

            var wizardLevels2 = GraveRobberLead.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == inquisitorClass);
            var newAddClassLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newAddClassLevels2.SelectSpells.AddToArray(heroism, fester, dispel, aid, shieldoffaith);
            newAddClassLevels2.SelectSpells = spell_list2;
            GraveRobberLead.ReplaceComponent(wizardLevels2, newAddClassLevels2);

            var dumbmonsterbrain = library.Get<BlueprintBrain>("5abc8884c6f15204c8604cb01a2efbab");

            var new_actions = dumbmonsterbrain.Actions;

            GraveRobberLead.Brain.Actions = new_actions;

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.shieldoffaith);
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.heroism);

            GraveRobberLead.GetComponent<Experience>().CR = 8;

            var brain = GraveRobberLead.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castheroism,AiActions.dispel,AiActions.castshieldoffaith,AiActions.castfester);



        }

        static void changeLonelyBarrowSkeletonCR3()
        {
            var CR3_SkeletalChampion = library.Get<BlueprintUnit>("6f0122a6ec507dc49b217b75c42c5296");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var cleave = library.Get<BlueprintFeature>("d809b6c4ff2aaff4fa70d712a70f7d7b");

            CR3_SkeletalChampion.AddFacts = CR3_SkeletalChampion.AddFacts.AddToArray(cleave);

            var fighterLevels = CR3_SkeletalChampion.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            CR3_SkeletalChampion.ReplaceComponent(fighterLevels, newAddClassLevels);

            var undeadLevels = CR3_SkeletalChampion.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels2 = undeadLevels.CreateCopy();
            newAddClassLevels2.Levels = 1;
            CR3_SkeletalChampion.ReplaceComponent(undeadLevels, newAddClassLevels2);


            var brain = CR3_SkeletalChampion.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);



        }

        static void changeLonelyBarrowSkeletonCR2()
        {
            var CR2_SkeletalChampion = library.Get<BlueprintUnit>("f2917899f6976fc4ebc16724a592d0b7");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var undeadClass = library.Get<BlueprintCharacterClass>("19a2d9e58d916d04db4cd7ad2c7a3ee2");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var cleave = library.Get<BlueprintFeature>("d809b6c4ff2aaff4fa70d712a70f7d7b");

            

            CR2_SkeletalChampion.AddFacts = CR2_SkeletalChampion.AddFacts.AddToArray(cleave);

            var fighterLevels = CR2_SkeletalChampion.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            CR2_SkeletalChampion.ReplaceComponent(fighterLevels, newAddClassLevels);

            var undeadLevels = CR2_SkeletalChampion.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == undeadClass);
            var newAddClassLevels2 = undeadLevels.CreateCopy();
            newAddClassLevels2.Levels = 1;
            CR2_SkeletalChampion.ReplaceComponent(undeadLevels, newAddClassLevels2);


            var brain = CR2_SkeletalChampion.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);



        }

        static void changeLoneWarrior()
        {
            var LoneWarrior = library.Get<BlueprintUnit>("39ace3bd77efd5546ad85b9e9947a311");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var swiftfoot = library.Get<BlueprintFeature>("7df32d4e9bd2cdc48b0f69b03a57754a");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var InspireFerocityFeature = library.Get<BlueprintFeature>("32c4d277007aed74c905779cd04a6fed");

            LoneWarrior.AddFacts = LoneWarrior.AddFacts.AddToArray(cornugon,toughness,InspireFerocityFeature);

            


            var barbarianLevels = LoneWarrior.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = barbarianLevels.CreateCopy();
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.RemoveFromArray(swiftfoot);

            }
            LoneWarrior.ReplaceComponent(barbarianLevels, newAddClassLevels);

            LoneWarrior.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("b0545291dc59cd44083e22e06448762a"); //Greatsword frost +2

            LoneWarrior.GetComponent<Experience>().CR = 15;


            var brain = LoneWarrior.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);



        }

        //Lizardfolks


        static void changeKingVesket()
        {
            var Kingvesket = library.Get<BlueprintUnit>("5eb33299047235146936bb18a38a0af4");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var renewedvigor = library.Get<BlueprintFeature>("aad496a7c9bee224cbd01a3cf8e42061");
            var recklesstance = library.Get<BlueprintFeature>("cb502c65dab407b4e928f5d8355cafc9");
            var InspireFerocityFeature = library.Get<BlueprintFeature>("32c4d277007aed74c905779cd04a6fed");

            Kingvesket.AddFacts = Kingvesket.AddFacts.AddToArray(recklesstance, InspireFerocityFeature);
            Kingvesket.AddFacts = Kingvesket.AddFacts.RemoveFromArray(renewedvigor);



            var barbarianLevels = Kingvesket.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = barbarianLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            Kingvesket.ReplaceComponent(barbarianLevels, newAddClassLevels);







        }

        static void changeLizardRattler()
        {
            var LizardRattler = library.Get<BlueprintUnit>("dda36438b8ffc9843b832d01d040b773");
            var clericclass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var summonmonsterIV = library.Get<BlueprintAbility>("7ed74a3ec8c458d4fb50b192fd7be6ef");
            var summonmonsterIII = library.Get<BlueprintAbility>("5d61dde0020bbf54ba1521f7ca0229dc");
            var searing_light = library.Get<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var divinepower = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");

            LizardRattler.AddFacts = LizardRattler.AddFacts.AddToArray(combatcasting,quicken);

            LizardRattler.Wisdom = 19;




            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)LizardRattler.AddFacts[0], "LizardRattlerFeatureNew", "14ad70e90b2045e4ad9b4af57da0235e");
            LizardRattler.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();



            var LizardRattlerFeature = library.Get<BlueprintFeature>("14ad70e90b2045e4ad9b4af57da0235e");

            var clericLevels = LizardRattlerFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericclass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            LizardRattlerFeature.ReplaceComponent(clericLevels, newAddClassLevels);

            var clericLevels2 = LizardRattlerFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericclass);
            var newAddClassLevels2 = clericLevels2.CreateCopy();
            var spell_list2 = newAddClassLevels2.MemorizeSpells.AddToArray(divinepower, searing_light, searing_light);
            newAddClassLevels2.MemorizeSpells = spell_list2;
            LizardRattlerFeature.ReplaceComponent(clericLevels2, newAddClassLevels2);

            var clericLevels6 = LizardRattlerFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericclass);
            var newAddClassLevels6 = clericLevels6.CreateCopy();
            var spell_list6 = newAddClassLevels6.MemorizeSpells.RemoveFromArray(summonmonsterIV);
            newAddClassLevels6.MemorizeSpells = spell_list6;
            LizardRattlerFeature.ReplaceComponent(clericLevels6, newAddClassLevels6);

            var clericLevels5 = LizardRattlerFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericclass);
            var newAddClassLevels5 = clericLevels5.CreateCopy();
            var spell_list5 = newAddClassLevels5.MemorizeSpells.RemoveFromArray(summonmonsterIII);
            newAddClassLevels5.MemorizeSpells = spell_list5;
            LizardRattlerFeature.ReplaceComponent(clericLevels5, newAddClassLevels5);

            var clericLevels7 = LizardRattlerFeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericclass);
            var newAddClassLevels7 = clericLevels7.CreateCopy();
            var spell_list7 = newAddClassLevels7.MemorizeSpells.RemoveFromArray(summonmonsterIII);
            newAddClassLevels7.MemorizeSpells = spell_list7;
            LizardRattlerFeature.ReplaceComponent(clericLevels7, newAddClassLevels7);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);




            var brain = LizardRattler.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.divine_power_first, AiActions.prayergoblinshaman, AiActions.castsearinglight,
                                                    AiActions.blesscast, AiActions.holdpersondelaybanditcleric, AiActions.castshieldoffaith,
                                                    AiActions.castchannelpositivecleric);



        }

        static void changeLizardMeleeHard()
        {
            var LizardMeleeHard = library.Get<BlueprintUnit>("4d98f6f765a999f40b587ef22f79db95");
            var ChargeAbility = library.Get<BlueprintAbility>("c78506dd0e14f7c45a599990e4e65038");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");

            LizardMeleeHard.AddFacts = LizardMeleeHard.AddFacts.AddToArray(ChargeAbility);




            var fighterLevels = LizardMeleeHard.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            LizardMeleeHard.ReplaceComponent(fighterLevels, newAddClassLevels);

            var brain = LizardMeleeHard.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig, AiActions.bullrush, AiActions.charge);


        }

        static void changeLizardRangedHard()
        {
            var LizardRangedHard = library.Get<BlueprintUnit>("360e49982bff21d45938e0df51f807eb");
            var ChargeAbility = library.Get<BlueprintAbility>("c78506dd0e14f7c45a599990e4e65038");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");



            LizardRangedHard.AddFacts = LizardRangedHard.AddFacts.AddToArray(ChargeAbility);




            var fighterLevels = LizardRangedHard.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            LizardRangedHard.ReplaceComponent(fighterLevels, newAddClassLevels);

            var brain = LizardRangedHard.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig, AiActions.bullrush, AiActions.charge);


        }


        //Silverstep

        static void updatesilverstepfrogs()
        {

            var silverstepfrogs = library.Get<BlueprintUnit>("70266f804573468285cea8ae27437a8e");
            var AnimalClass = library.Get<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");
            
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var natrmor5 = library.Get<BlueprintUnitFact>("7661741dbb9604842a642457456fd0e4");
            var natrmor8 = library.Get<BlueprintUnitFact>("b9342e2a6dc5165489ba3412c50ca3d1");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");



            silverstepfrogs.AddFacts = silverstepfrogs.AddFacts.RemoveFromArray(natrmor5);
            silverstepfrogs.AddFacts = silverstepfrogs.AddFacts.AddToArray(dodge, toughness);

            var dragonLevels = silverstepfrogs.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == AnimalClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            silverstepfrogs.ReplaceComponent(dragonLevels, newAddClassLevels);


            silverstepfrogs.GetComponent<Experience>().CR = 5;


        }

        static void updatesilverstepsmalltatzylwyrm()
        {

            var silverstepsmalltatzylwyrm = library.Get<BlueprintUnit>("b1027467a67844e2914ab07f109035da");
            var dragonClass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");

            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var natrmor3 = library.Get<BlueprintUnitFact>("f6e106931f95fec4eb995f0d0629fb84");
            var natrmor4 = library.Get<BlueprintUnitFact>("16fc201a83edcde4cbd64c291ebe0d07");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var bite2d6 = library.Get<BlueprintItemWeapon>("9c20ebc9f7b701743944b1c76d4bf598");
            var bite1d8 = library.Get<BlueprintItemWeapon>("c988aa874d11ff84d873508ddc9b928f");
            var Claw1d6 = library.Get<BlueprintItemWeapon>("c76f72a862d168d44838206524366e1c");
            var quicklingfeature = library.Get<BlueprintFeature>("78ae3b88fd3a434489fa0731ba2eab42");
            var Claw1d4 = library.Get<BlueprintItemWeapon>("118fdd03e569a66459ab01a20af6811a");

            silverstepsmalltatzylwyrm.Strength = 18;
            silverstepsmalltatzylwyrm.Dexterity = 16;
            silverstepsmalltatzylwyrm.Constitution = 16;
            silverstepsmalltatzylwyrm.Intelligence = 10;
            silverstepsmalltatzylwyrm.Wisdom = 17;
            silverstepsmalltatzylwyrm.Charisma = 15;





            silverstepsmalltatzylwyrm.AddFacts = silverstepsmalltatzylwyrm.AddFacts.RemoveFromArray(natrmor3);
            silverstepsmalltatzylwyrm.AddFacts = silverstepsmalltatzylwyrm.AddFacts.AddToArray(dodge,natrmor4, toughness,quicklingfeature);

            var dragonLevels = silverstepsmalltatzylwyrm.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == dragonClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            silverstepsmalltatzylwyrm.ReplaceComponent(dragonLevels, newAddClassLevels);

            silverstepsmalltatzylwyrm.Body.AdditionalLimbs = silverstepsmalltatzylwyrm.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            silverstepsmalltatzylwyrm.Body.AdditionalLimbs = silverstepsmalltatzylwyrm.Body.AdditionalLimbs.RemoveFromArray(Claw1d4);
            silverstepsmalltatzylwyrm.Body.AdditionalLimbs = silverstepsmalltatzylwyrm.Body.AdditionalLimbs.RemoveFromArray(Claw1d4);
            silverstepsmalltatzylwyrm.Body.AdditionalLimbs = silverstepsmalltatzylwyrm.Body.AdditionalLimbs.AddToArray(bite2d6, Claw1d6, Claw1d6);



            silverstepsmalltatzylwyrm.GetComponent<Experience>().CR = 9;


        }

        static void updateLargeTatzlwyrm()
        {

            var Largetatzylwyrm = library.Get<BlueprintUnit>("7e9ff4d6b96af5a45846159bc249f50d");
            var dragonClass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");

            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");

            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");







            Largetatzylwyrm.AddFacts = Largetatzylwyrm.AddFacts.AddToArray(dodge, toughness);

            Largetatzylwyrm.MaxHP = 15;

            var dragonLevels = Largetatzylwyrm.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == dragonClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            Largetatzylwyrm.ReplaceComponent(dragonLevels, newAddClassLevels);




            Largetatzylwyrm.GetComponent<Experience>().CR = 8;


        }

        static void changesilverstepbanditleader()
        {
            var SilverstepLeader = library.Get<BlueprintUnit>("0fa332cc117c9034b9cf3657e9f30587");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var BanditNecromancerFeatureListLevel7 = library.Get<BlueprintFeature>("984e04d78ad20d14a965f7aabccb8900");
            var coneofcold = library.Get<BlueprintAbility>("e7c530f8137630f4d9d7ee1aa7b1edc0");
            var enervation = library.Get<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
            var vampirictouch = library.Get<BlueprintAbility>("8a28a811ca5d20d49a863e832c31cce1");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var boneshatter = library.Get<BlueprintAbility>("f2f1efac32ea2884e84ecaf14657298b");
            var fear = library.Get<BlueprintAbility>("d2aeac47450c76347aebbc02e4f463e0");
            var blindness = library.Get<BlueprintAbility>("46fd02ad56c35224c9c91c88cd457791");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var boneshaker = library.Get<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var blindnessaiaction = library.Get<BlueprintAiAction>("8919ec26e5eec864cbfdc8fa018f7b2e");
            var CauseFearAiAction = library.Get<BlueprintAiAction>("650e0cf00f552744e841bf9cc578ba34");


            SilverstepLeader.AddFacts = SilverstepLeader.AddFacts.AddToArray(quicken);



            SilverstepLeader.Intelligence = 20;


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)SilverstepLeader.AddFacts[0], "SilverstepLeaderFeature", "54f053b2f4c2483fad6423d4255f2d40");
            SilverstepLeader.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BanditNecromancerFeatureListLevel7.GetComponent<AddFacts>().Facts[1], "SilverstepLeaderSpellListnew", "d6037b584a8d46ce93541cf671029994");
            BanditNecromancerFeatureListLevel7.GetComponent<AddFacts>().Facts[1] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var SilverstepLeaderfeature = library.Get<BlueprintFeature>("54f053b2f4c2483fad6423d4255f2d40");
            var SilverstepLeaderspells = library.Get<BlueprintFeature>("d6037b584a8d46ce93541cf671029994");


            var wizardLevels = SilverstepLeaderfeature.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels = wizardLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            SilverstepLeaderfeature.ReplaceComponent(wizardLevels, newAddClassLevels);

            var wizardLevels2 = SilverstepLeaderfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newAddClassLevels2.MemorizeSpells.AddToArray(coneofcold,haste, mirrorimage, displacement,boneshatter,fear,holdperson,holdperson,boneshaker,magicmissle,magicmissle);
            newAddClassLevels2.MemorizeSpells = spell_list2;
            SilverstepLeaderfeature.ReplaceComponent(wizardLevels2, newAddClassLevels2);

            var clericLevels3 = SilverstepLeaderfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.SelectSpells.AddToArray(coneofcold,haste,displacement,boneshatter,fear,holdperson,holdperson,mirrorimage, boneshaker,magicmissle,magicmissle);
            newAddClassLevels3.SelectSpells = spell_list3;
            SilverstepLeaderfeature.ReplaceComponent(clericLevels3, newAddClassLevels3);

            var clericLevels4 = SilverstepLeaderfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels4 = clericLevels4.CreateCopy();
            var spell_list4 = newAddClassLevels4.MemorizeSpells.RemoveFromArray(vampirictouch);
            newAddClassLevels4.MemorizeSpells = spell_list4;
            SilverstepLeaderfeature.ReplaceComponent(clericLevels4, newAddClassLevels4);

            var clericLevels7 = SilverstepLeaderfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels7 = clericLevels7.CreateCopy();
            var spell_list7 = newAddClassLevels7.MemorizeSpells.RemoveFromArray(blindness);
            newAddClassLevels7.MemorizeSpells = spell_list7;
            SilverstepLeaderfeature.ReplaceComponent(clericLevels7, newAddClassLevels7);

            var clericLevelsA = SilverstepLeaderfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevelsA = clericLevelsA.CreateCopy();
            var spell_listA = newAddClassLevels7.MemorizeSpells.RemoveFromArray(blindness);
            newAddClassLevelsA.MemorizeSpells = spell_listA;
            SilverstepLeaderfeature.ReplaceComponent(clericLevelsA, newAddClassLevelsA);

            var clericLevels8 = SilverstepLeaderfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels8 = clericLevels8.CreateCopy();
            var spell_list8 = newAddClassLevels8.MemorizeSpells.RemoveFromArray(enervation);
            newAddClassLevels8.MemorizeSpells = spell_list8;
            SilverstepLeaderfeature.ReplaceComponent(clericLevels8, newAddClassLevels8);

            var clericLevels9 = SilverstepLeaderfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels9 = clericLevels9.CreateCopy();
            var spell_list9 = newAddClassLevels9.MemorizeSpells.RemoveFromArray(enervation);
            newAddClassLevels9.MemorizeSpells = spell_list9;
            SilverstepLeaderfeature.ReplaceComponent(clericLevels9, newAddClassLevels9);



            var clericLevels5 = SilverstepLeaderspells.ComponentsArray
.OfType<LearnSpells>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels5 = clericLevels5.CreateCopy();
            var spell_list5 = newAddClassLevels5.Spells.RemoveFromArray(enervation);
            newAddClassLevels5.Spells = spell_list5;
            SilverstepLeaderspells.ReplaceComponent(clericLevels5, newAddClassLevels5);

            var clericLevels6 = SilverstepLeaderspells.ComponentsArray
.OfType<LearnSpells>()
.First(c => c.CharacterClass == wizardClass);
            var newAddClassLevels6 = clericLevels6.CreateCopy();
            var spell_list6 = newAddClassLevels6.Spells.AddToArray(haste,displacement,mirrorimage,coneofcold,boneshaker,magicmissle);
            newAddClassLevels6.Spells = spell_list6;
            SilverstepLeaderspells.ReplaceComponent(clericLevels6, newAddClassLevels6);

            SilverstepLeader.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("f5528acb89757ab4fb9350f45cc4f3b4"); // Light Crossbow +1

            SilverstepLeader.GetComponent<Experience>().CR = 8;


            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);

            var brain = SilverstepLeader.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(blindnessaiaction);
            brain.Actions = brain.Actions.RemoveFromArray(CauseFearAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.coneofcoldelderwater,AiActions.displacementvordakai,
                                                     AiActions.casthastetartuk,AiActions.magicmissledelay,
                                                     AiActions.castboneshaker,AiActions.castboneshatter,
                                                     AiActions.mirrorimage,AiActions.castfearwitch,AiActions.castblindness,AiActions.castcausefeardelay);



        }

        static void updatesilverstepbanditmelee()
        {

            var Silverstepbanditmelee = library.Get<BlueprintUnit>("b3028bf95b5886c43af34e5ad3067b55");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            Silverstepbanditmelee.AddFacts = Silverstepbanditmelee.AddFacts.AddToArray(disarm);

            Silverstepbanditmelee.Constitution = 16;


            Silverstepbanditmelee.MaxHP = 15;

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)Silverstepbanditmelee.AddFacts[0], "SilverstepmeleeFeature", "f1a14bfae1554591b37d601f4eb3b58b");
            Silverstepbanditmelee.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var Silverstepbanditmeleefeature = library.Get<BlueprintFeature>("f1a14bfae1554591b37d601f4eb3b58b");



            var fighterLevels = Silverstepbanditmeleefeature.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            Silverstepbanditmeleefeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            Silverstepbanditmelee.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("03d706655c07d804cb9d5a5583f9aec5"); //longsword +1
            Silverstepbanditmelee.Body.Armor = library.Get<BlueprintItemArmor>("1638fa11f5af1814191cf6c05cdcf2b6"); //Banded Armor

            




            var brain = Silverstepbanditmelee.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave, AiActions.usedisarm);







        }

        static void changesilverstepbanditArcher()
        {
            var silverstepbanditArcher = library.Get<BlueprintUnit>("fc8f89cb21d70204bb1ba117a2701c04");


            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");

            var BanditRogueMeleeFeatureListLevel7 = library.Get<BlueprintFeature>("7e236e0a3ed53114bb30e4bd2c3c8505");
            var BanditFighterRangedFeatureListLevel5 = library.Get<BlueprintFeature>("2ce098266434c6947b9840b8a987cdc6");


            silverstepbanditArcher.AddFacts = silverstepbanditArcher.AddFacts.RemoveFromArray(BanditFighterRangedFeatureListLevel5);

            silverstepbanditArcher.AddFacts = silverstepbanditArcher.AddFacts.AddToArray(BanditRogueMeleeFeatureListLevel7);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)silverstepbanditArcher.AddFacts[0], "silverstepbanditroguenewFeature", "9f70e18aa2934b8abad02e222f7ce9fb");
            silverstepbanditArcher.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var silverstepbanditroguenewFeature = library.Get<BlueprintFeature>("9f70e18aa2934b8abad02e222f7ce9fb");



            var rogueLevels = silverstepbanditroguenewFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            silverstepbanditroguenewFeature.ReplaceComponent(rogueLevels, newAddClassLevels);

            silverstepbanditArcher.AddFacts = silverstepbanditArcher.AddFacts.AddToArray(dirtytrick);


            silverstepbanditArcher.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"); //Dagger +1

            silverstepbanditArcher.Body.SecondaryHand = library.Get<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"); //Dagger +1


            var brain = silverstepbanditArcher.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedirtytrickblind);


            



        }

        static void changesilverstepbanditRogue()
        {

            var silverstepbanditrogue = library.Get<BlueprintUnit>("e6f8bba279a316d4eafe74cebb4eee1d");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var BanditRogueRangedFeatureListLevel4 = library.Get<BlueprintFeature>("518a732c7e32bbd46b90fc297120e004");
            var BanditFighterRangedFeatureListLevel5 = library.Get<BlueprintFeature>("2ce098266434c6947b9840b8a987cdc6");

           

            silverstepbanditrogue.AddFacts = silverstepbanditrogue.AddFacts.RemoveFromArray(BanditRogueRangedFeatureListLevel4);

            silverstepbanditrogue.AddFacts = silverstepbanditrogue.AddFacts.AddToArray(BanditFighterRangedFeatureListLevel5);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)silverstepbanditrogue.AddFacts[0], "silverstepbanditnewarcherFeature", "5fed418fb9e34f89a987115596af951f");
            silverstepbanditrogue.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var silverstepbanditnewarcherFeature = library.Get<BlueprintFeature>("5fed418fb9e34f89a987115596af951f");


            var fighterLevels = silverstepbanditnewarcherFeature.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            silverstepbanditnewarcherFeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            silverstepbanditrogue.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("4de4658c0e9b0d146b9a08ed6f030f8a"); //Masterwork Composite Longbow

            silverstepbanditrogue.GetComponent<Experience>().CR = 5;

            var brain = silverstepbanditrogue.Brain;
            brain.Actions = brain.Actions.AddToArray();


        }

        static void changeSilverstepWerewolf()
        {
            var SilverstepWerewolf = library.Get<BlueprintUnit>("e79c357492dac0549b9546e1e4c6dd9b");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var armorfocuschainmail = library.Get<BlueprintFeature>("adb1548368313094ba608788befff12c");




            SilverstepWerewolf.AddFacts = SilverstepWerewolf.AddFacts.AddToArray(cornugon,armorfocuschainmail);

            SilverstepWerewolf.Constitution = 20;

            SilverstepWerewolf.Skills.Diplomacy = 10;


            SilverstepWerewolf.MaxHP = 15;


            var fighterLevels = SilverstepWerewolf.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            SilverstepWerewolf.ReplaceComponent(fighterLevels, newAddClassLevels);




            var brain = SilverstepWerewolf.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig);



        }



        //Miscellaneous Season of Bloom


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
            var slowai = library.Get<BlueprintAiCastSpell>("d67858e438dd8834f9e61a1cb1c592a6");
            

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
            brain.Actions = brain.Actions.RemoveFromArray(slowai);
            brain.Actions = brain.Actions.AddToArray(AiActions.mirrorimage, AiActions.displacement_first, AiActions.castshout, AiActions.casthaste, AiActions.hideouslaughternixie,AiActions.castslow);

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


            craglinnorm.GetComponent<Experience>().CR = 16;

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
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");


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
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");



            var sorcererLevels = nereidstandard.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == feyClass);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            newAddClassLevels.Levels = 10;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(icestorm,dragonsbreathsilver,stoneskincommunal,mirrorimage,lightningbolt,haste,displacement);
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

            brain.Actions = brain.Actions.AddToArray(AiActions.stoneskincommunal, AiActions.icestorm,AiActions.dragonsbreathsilver, AiActions.mirrorimage, AiActions.lightningboltfourturns,AiActions.casthaste,AiActions.castdisplacementgoblin);

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

        static void fixCandlemerePriest()
        {

            var CandlemerePriest = library.Get<BlueprintUnit>("94e420a47d8297149af91310c2b1ac5b");
            var clericClass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var summongreatair = library.Get<BlueprintAbility>("766ec978fa993034f86a372c8eb1fc10");
            var dispelgreater = library.Get<BlueprintAbility>("f0f761b808dc4b149b08eaf44b99f633");
            var righteousmight = library.Get<BlueprintAbility>("90810e5cf53bf854293cbd5ea1066252");
            var constrictcoils = library.Get<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
            var flamestrike = library.Get<BlueprintAbility>("f9910c76efc34af41b6e43d5d8752f0f");
            var divinepower = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var prayer = library.Get<BlueprintAbility>("faabd2cc67efa4646ac58c7bb3e40fcc");
            var superiorsummoning = library.Get<BlueprintFeature>("0477936c0f74841498b5c8753a8062a3");
            var SummonMonsterV = library.Get<BlueprintAbility>("0964bf88b582bed41b74e79596c4f6d9");
            var SummonMonsterVd3 = library.Get<BlueprintAbility>("715f208d545be2f4aa2d3693e6347a5a");
            var selectivechannel = library.Get<BlueprintFeature>("fd30c69417b434d47b6b03b9c1f568ff");
            var divinepowerai = library.Get<BlueprintAiCastSpell>("09de02db1b07d364795f412abb557de3");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var serenity = library.Get<BlueprintAbility>("d316d3d94d20c674db2c24d7de96f6a7");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var shieldoffaith = library.Get<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
            var bless = library.Get<BlueprintAbility>("90e59f4a4ada87243b7b3535a06d0638");

            CandlemerePriest.AddFacts = CandlemerePriest.AddFacts.RemoveFromArray(SummonMonsterV);
            CandlemerePriest.AddFacts = CandlemerePriest.AddFacts.RemoveFromArray(SummonMonsterVd3);
            CandlemerePriest.AddFacts = CandlemerePriest.AddFacts.RemoveFromArray(prayer);

            CandlemerePriest.AddFacts = CandlemerePriest.AddFacts.AddToArray(quicken,combatcasting);

            CandlemerePriest.Wisdom = 19;

            var clericLevels = CandlemerePriest.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericClass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.Levels = 12;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(summongreatair, serenity, dispelgreater, flamestrike, righteousmight, constrictcoils, constrictcoils, divinepower, prayer,shieldoffaith,bless);
            newAddClassLevels.MemorizeSpells = spell_list;
            CandlemerePriest.ReplaceComponent(clericLevels, newAddClassLevels);

            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.prayer);


            CandlemerePriest.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("e8aa3f5ca26027b4b846de538b01ee50"); //HeavyCrossbow +1

            

            var brain = CandlemerePriest.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(divinepowerai);
            brain.Actions = brain.Actions.AddToArray(AiActions.summonelementalhugeair, AiActions.castserenity,
                                                     AiActions.divine_power_first, AiActions.righteousmightgoblinshaman, 
                                                     AiActions.prayergoblinshaman, AiActions.constrictingcoils, AiActions.flamestrikegoblinshaman, AiActions.greaterdispel,AiActions.castshieldoffaith,AiActions.blesscast);




        }

        //Beasts

        static void updatehuntedhydra()
        {

            var huntedcryohydra = library.Get<BlueprintUnit>("96ee2234876249df872a4fae05cac478");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var PoisonousHydraBreathWeapon = library.Get<BlueprintAbility>("1f788b54e93751d43923596b8e09035d");
            var PoisonousHydraBreathWeaponCloud = library.Get<BlueprintAbility>("cd8bff58dabcc2f48b049c89af3a3a8f");
            var HasteBuff  = library.Get<BlueprintBuff>("03464790f40c3c24aa684b57155f3280");
            var BlurBuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var DRColdIronAndMagic10 = library.Get<BlueprintFeature>("b9a197673ec62dd49b15461d61bd2937");
            var dragonsbreathsilver = library.Get<BlueprintAbility>("45e0813484581514fbfcf49939ee050d");
            var freezefeaturelarge = library.Get<BlueprintFeature>("74218a69c8bed1c4c863361916637bcf");

            



            huntedcryohydra.AddFacts = huntedcryohydra.AddFacts.RemoveFromArray(PoisonousHydraBreathWeapon);
            huntedcryohydra.AddFacts = huntedcryohydra.AddFacts.RemoveFromArray(PoisonousHydraBreathWeaponCloud);

            huntedcryohydra.AddFacts = huntedcryohydra.AddFacts.AddToArray(HasteBuff,dodge,BlurBuff,DRColdIronAndMagic10,dragonsbreathsilver,freezefeaturelarge);

            var dragonLevels = huntedcryohydra.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 18;
            huntedcryohydra.ReplaceComponent(dragonLevels, newAddClassLevels);


            huntedcryohydra.GetComponent<Experience>().CR = 14;

            var brain = huntedcryohydra.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathsilverhydra);
        }

        static void updatecapitalhydra()
        {

            var capitalpyrohydra = library.Get<BlueprintUnit>("76706df8414046b59951e407666779f6");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var PoisonousHydraBreathWeapon = library.Get<BlueprintAbility>("1f788b54e93751d43923596b8e09035d");
            var PoisonousHydraBreathWeaponCloud = library.Get<BlueprintAbility>("cd8bff58dabcc2f48b049c89af3a3a8f");
            var HasteBuff = library.Get<BlueprintBuff>("03464790f40c3c24aa684b57155f3280");
            var BlurBuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var DRColdIronAndMagic10 = library.Get<BlueprintFeature>("b9a197673ec62dd49b15461d61bd2937");
            var dragonsbreathgold = library.Get<BlueprintAbility>("e6f5453df86bd714fa33b14c994739f3");
            var burnfeaturelarge = library.Get<BlueprintFeature>("3b423b497934aeb48a3676cca64b5b55");





            capitalpyrohydra.AddFacts = capitalpyrohydra.AddFacts.RemoveFromArray(PoisonousHydraBreathWeapon);
            capitalpyrohydra.AddFacts = capitalpyrohydra.AddFacts.RemoveFromArray(PoisonousHydraBreathWeaponCloud);

            capitalpyrohydra.AddFacts = capitalpyrohydra.AddFacts.AddToArray(HasteBuff, dodge, BlurBuff, DRColdIronAndMagic10, dragonsbreathgold, burnfeaturelarge);

            var dragonLevels = capitalpyrohydra.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 15;
            capitalpyrohydra.ReplaceComponent(dragonLevels, newAddClassLevels);


            capitalpyrohydra.GetComponent<Experience>().CR = 12;

            var brain = capitalpyrohydra.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathgoldhydra);
        }

        static void updateCR12PoisonousHydra()
        {

            var CR12PoisonousHydra = library.Get<BlueprintUnit>("101c479b6cd567b4497ce4283c6d5b3b");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var PoisonousHydraBreathWeapon = library.Get<BlueprintAbility>("1f788b54e93751d43923596b8e09035d");
            var PoisonousHydraBreathWeaponCloud = library.Get<BlueprintAbility>("cd8bff58dabcc2f48b049c89af3a3a8f");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var dragonsbreathgreen = library.Get<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");
            var poisonbite = library.Get<BlueprintFeature>("094714bb08f4e1943a8e9d2384ebe573");





            CR12PoisonousHydra.AddFacts = CR12PoisonousHydra.AddFacts.RemoveFromArray(PoisonousHydraBreathWeapon);
            CR12PoisonousHydra.AddFacts = CR12PoisonousHydra.AddFacts.RemoveFromArray(PoisonousHydraBreathWeaponCloud);

            CR12PoisonousHydra.AddFacts = CR12PoisonousHydra.AddFacts.AddToArray(dodge, poisonbite, dragonsbreathgreen);

            var dragonLevels = CR12PoisonousHydra.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 14;
            CR12PoisonousHydra.ReplaceComponent(dragonLevels, newAddClassLevels);




            var brain = CR12PoisonousHydra.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathgreenhydra);
        }

        static void updateCR14PoisonousHydra()
        {

            var CR14PoisonousHydra = library.Get<BlueprintUnit>("429b14ab29dd24548abf16506100fc83");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var PoisonousHydraBreathWeapon = library.Get<BlueprintAbility>("1f788b54e93751d43923596b8e09035d");
            var PoisonousHydraBreathWeaponCloud = library.Get<BlueprintAbility>("cd8bff58dabcc2f48b049c89af3a3a8f");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var dragonsbreathgreen = library.Get<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");
            var poisonbite = library.Get<BlueprintFeature>("094714bb08f4e1943a8e9d2384ebe573");





            CR14PoisonousHydra.AddFacts = CR14PoisonousHydra.AddFacts.RemoveFromArray(PoisonousHydraBreathWeapon);
            CR14PoisonousHydra.AddFacts = CR14PoisonousHydra.AddFacts.RemoveFromArray(PoisonousHydraBreathWeaponCloud);

            CR14PoisonousHydra.AddFacts = CR14PoisonousHydra.AddFacts.AddToArray(dodge, poisonbite, dragonsbreathgreen);

            var dragonLevels = CR14PoisonousHydra.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 16;
            CR14PoisonousHydra.ReplaceComponent(dragonLevels, newAddClassLevels);




            var brain = CR14PoisonousHydra.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathgreenhydra);
        }

        static void updateHydrabloom()
        {

            var Hydrabloom = library.Get<BlueprintUnit>("ac214470685b0884dada8d845de08137");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var bite2d6 = library.Get<BlueprintItemWeapon>("48647a4517e6512419e937f7a617ea5c");
            var bite1d8 = library.Get<BlueprintItemWeapon>("ec35ef997ed5a984280e1a6d87ae80a8");

            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydrabloom.Body.AdditionalLimbs = Hydrabloom.Body.AdditionalLimbs.AddToArray(bite2d6);



            Hydrabloom.AddFacts = Hydrabloom.AddFacts.AddToArray(dodge);

            var dragonLevels = Hydrabloom.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 12;
            Hydrabloom.ReplaceComponent(dragonLevels, newAddClassLevels);


        }

        static void updateHydraStandard()
        {

            var HydraStandard = library.Get<BlueprintUnit>("68e28734693629841a336655091c4de4");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");




            HydraStandard.AddFacts = HydraStandard.AddFacts.AddToArray(dodge);

            var dragonLevels = HydraStandard.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            HydraStandard.ReplaceComponent(dragonLevels, newAddClassLevels);


        }

        static void updateHydraAdvanced()
        {

            var HydraAdvanced = library.Get<BlueprintUnit>("00a10a2129fc7de45889a7f10e06ea92");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");




            HydraAdvanced.AddFacts = HydraAdvanced.AddFacts.AddToArray(dodge);

            var dragonLevels = HydraAdvanced.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 10;
            HydraAdvanced.ReplaceComponent(dragonLevels, newAddClassLevels);


        }

        static void updateHydraAdvancedCR7()
        {

            var HydraAdvanced = library.Get<BlueprintUnit>("e135463f804adb541b402bae3f657af4");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var bite2d6 = library.Get<BlueprintItemWeapon>("48647a4517e6512419e937f7a617ea5c");
            var bite1d8 = library.Get<BlueprintItemWeapon>("ec35ef997ed5a984280e1a6d87ae80a8");




            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.AddToArray(bite2d6);
            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.AddToArray(bite2d6);
            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.AddToArray(bite2d6);
            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.AddToArray(bite2d6);
            HydraAdvanced.Body.AdditionalLimbs = HydraAdvanced.Body.AdditionalLimbs.AddToArray(bite2d6);

            HydraAdvanced.AddFacts = HydraAdvanced.AddFacts.AddToArray(dodge);

            var dragonLevels = HydraAdvanced.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 12;
            HydraAdvanced.ReplaceComponent(dragonLevels, newAddClassLevels);


            HydraAdvanced.GetComponent<Experience>().CR = 8;



        }

        static void updateHydraquickling()
        {

            var Hydraquickling = library.Get<BlueprintUnit>("5930c69867e498d45bdac0a51fa90094");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var bite2d6 = library.Get<BlueprintItemWeapon>("48647a4517e6512419e937f7a617ea5c");
            var bite1d8 = library.Get<BlueprintItemWeapon>("ec35ef997ed5a984280e1a6d87ae80a8");


            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydraquickling.Body.AdditionalLimbs = Hydraquickling.Body.AdditionalLimbs.AddToArray(bite2d6);

            Hydraquickling.Strength = 18;

            Hydraquickling.AddFacts = Hydraquickling.AddFacts.AddToArray(dodge);

            var dragonLevels = Hydraquickling.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            Hydraquickling.ReplaceComponent(dragonLevels, newAddClassLevels);

            Hydraquickling.GetComponent<Experience>().CR = 7;
        }

        static void updateHydravenom()
        {

            var Hydravenom = library.Get<BlueprintUnit>("be58ef2cd41e73843a14895acf9eddcb");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var dodge = library.Get<BlueprintFeature>("97e216dbb46ae3c4faef90cf6bbe6fd5");
            var bite2d6 = library.Get<BlueprintItemWeapon>("48647a4517e6512419e937f7a617ea5c");
            var bite1d8 = library.Get<BlueprintItemWeapon>("ec35ef997ed5a984280e1a6d87ae80a8");


            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.RemoveFromArray(bite1d8);
            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.AddToArray(bite2d6);
            Hydravenom.Body.AdditionalLimbs = Hydravenom.Body.AdditionalLimbs.AddToArray(bite2d6);

            Hydravenom.Strength = 18;

            Hydravenom.AddFacts = Hydravenom.AddFacts.AddToArray(dodge);

            var dragonLevels = Hydravenom.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            Hydravenom.ReplaceComponent(dragonLevels, newAddClassLevels);

            Hydravenom.GetComponent<Experience>().CR = 7;
        }

        static void updateOwlbearnecro()
        {

            var Owlbearnecro = library.Get<BlueprintUnit>("7ae461f01f1b1684884e784341c0b36c");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var vampirictouch = library.Get<BlueprintAbility>("8a28a811ca5d20d49a863e832c31cce1");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var auraofdoom = library.Get<BlueprintAbility>("3244b350df4c474084de760c2aaf7974");

            Owlbearnecro.AddFacts = Owlbearnecro.AddFacts.AddToArray(vampirictouch,combatcasting,auraofdoom);

            var brain = Owlbearnecro.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castvampirictouchowlbear,AiActions.castauraofdoom);


        }

        static void updateOwlbearillusion()
        {

            var Owlbearillusion = library.Get<BlueprintUnit>("5889e9c222127a44a88a12903b6e0256");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");


            Owlbearillusion.AddFacts = Owlbearillusion.AddFacts.AddToArray(mirrorimage, combatcasting);

            var brain = Owlbearillusion.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.mirrorimageowlbear);


        }

        static void updateStrongOwlbearevocation()
        {

            var strongowlbearevocation = library.Get<BlueprintUnit>("ba6dc1b987e06a1499e5ec68f38619ef");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");
            var burningaiaction = library.Get<BlueprintAiCastSpell>("5dfe6689bf271874ab07a86e7946a61c");
            

            strongowlbearevocation.AddFacts = strongowlbearevocation.AddFacts.AddToArray(firesnake, combatcasting);

            var brain = strongowlbearevocation.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(burningaiaction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castfiresnakeowlbear);


        }

        static void updateStrongOwlbearnecro()
        {

            var strongowlbearnecro = library.Get<BlueprintUnit>("f9307a67be2d29c4a86edb03a9615463");
            var vampirictouch = library.Get<BlueprintAbility>("8a28a811ca5d20d49a863e832c31cce1");
            var auraofdoom = library.Get<BlueprintAbility>("3244b350df4c474084de760c2aaf7974");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var ThanadaemonEnergyDrainFeature = library.Get<BlueprintFeature>("f25bec0517daa9647998764862ddb3a4");
            


            strongowlbearnecro.AddFacts = strongowlbearnecro.AddFacts.AddToArray(vampirictouch, combatcasting, ThanadaemonEnergyDrainFeature,auraofdoom);

            var brain = strongowlbearnecro.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castvampirictouchowlbear,AiActions.castauraofdoom);




        }

        static void updateStrongOwlbeartreant()
        {

            var strongowlbeartreant = library.Get<BlueprintUnit>("466189c5dd11fa3459024da71d140143");
            var stunningblowaiaction = library.Get<BlueprintAiCastSpell>("b2428bdc1e519104f8eb08e2fd06eb02");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var natarmor11 = library.Get<BlueprintUnitFact>("fe38367139432294e8c229edc066e4ac");
            var RegenerationColdIronOrFire5 = library.Get<BlueprintBuff>("da6b266204fe2ac4d89786bf66dbe3a9");
            var bite2d6 = library.Get<BlueprintItemWeapon>("48647a4517e6512419e937f7a617ea5c");
            var ClawHuge2d6 = library.Get<BlueprintItemWeapon>("75254f19ca6e1d048a88b7545bb65221");
            var BiteLarge1d8 = library.Get<BlueprintItemWeapon>("ec35ef997ed5a984280e1a6d87ae80a8");
            var ClawLarge1d6 = library.Get<BlueprintItemWeapon>("c76f72a862d168d44838206524366e1c");



            strongowlbeartreant.Strength = 36;
            strongowlbeartreant.Dexterity = 12;
            strongowlbeartreant.Constitution = 36;
            strongowlbeartreant.Intelligence = 6;
            strongowlbeartreant.Wisdom = 16;
            strongowlbeartreant.Charisma = 14;


            strongowlbeartreant.Body.AdditionalLimbs = strongowlbeartreant.Body.AdditionalLimbs.RemoveFromArray(BiteLarge1d8);
            strongowlbeartreant.Body.AdditionalLimbs = strongowlbeartreant.Body.AdditionalLimbs.RemoveFromArray(ClawLarge1d6);
            strongowlbeartreant.Body.AdditionalLimbs = strongowlbeartreant.Body.AdditionalLimbs.RemoveFromArray(ClawLarge1d6);

            strongowlbeartreant.Body.AdditionalLimbs = strongowlbeartreant.Body.AdditionalLimbs.AddToArray(bite2d6);
            strongowlbeartreant.Body.AdditionalLimbs = strongowlbeartreant.Body.AdditionalLimbs.AddToArray(ClawHuge2d6);
            strongowlbeartreant.Body.AdditionalLimbs = strongowlbeartreant.Body.AdditionalLimbs.AddToArray(ClawHuge2d6);


            strongowlbeartreant.AddFacts = strongowlbeartreant.AddFacts.RemoveFromArray(natarmor11);
            strongowlbeartreant.AddFacts = strongowlbeartreant.AddFacts.AddToArray(natarmor14,RegenerationColdIronOrFire5);


            var brain = strongowlbeartreant.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(stunningblowaiaction);


        }

        static void updateSecretOwlbear()
        {

            var secretowlbear = library.Get<BlueprintUnit>("f7a107522d386a247ae5d7e2cdf88ef0");
            var stunningblowaiaction = library.Get<BlueprintAiCastSpell>("b2428bdc1e519104f8eb08e2fd06eb02");




            var brain = secretowlbear.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(stunningblowaiaction);


        }

        static void updateenragedowlbeartreant()
        {

            var enragedowlbeartreant = library.Get<BlueprintUnit>("502fa574f3c15f94ab5e03460870235f");
            var stunningblowaiaction = library.Get<BlueprintAiCastSpell>("b2428bdc1e519104f8eb08e2fd06eb02");




            var brain = enragedowlbeartreant.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(stunningblowaiaction);


        }

        static void updateBloominfusedspider()
        {

            var Bloominfusedspider = library.Get<BlueprintUnit>("a813d907bc55e734584d99a038c9211e");
            var vermin = library.Get<BlueprintCharacterClass>("d1a15612d1a96334d94edf5f1d3b8d29");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            var natarmor8 = library.Get<BlueprintUnitFact>("b9342e2a6dc5165489ba3412c50ca3d1");
            var natarmor11 = library.Get<BlueprintUnitFact>("fe38367139432294e8c229edc066e4ac");

            Bloominfusedspider.AddFacts = Bloominfusedspider.AddFacts.RemoveFromArray(natarmor8);
            Bloominfusedspider.AddFacts = Bloominfusedspider.AddFacts.AddToArray(natarmor11);

            var verminLevels = Bloominfusedspider.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == vermin);
            var newverminLevels = verminLevels.CreateCopy();
            newverminLevels.Levels = 12;
            Bloominfusedspider.ReplaceComponent(verminLevels, newverminLevels);

            Bloominfusedspider.Body.AdditionalLimbs = Bloominfusedspider.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            Bloominfusedspider.Body.AdditionalLimbs = Bloominfusedspider.Body.AdditionalLimbs.AddToArray(bite3d6);


        }

        static void updatequicklingspider()
        {

            var quicklingspider = library.Get<BlueprintUnit>("07467e9a29a215346ab66fec7963eb62");
            var magicalbeast = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");

            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            var natarmor6 = library.Get<BlueprintUnitFact>("987ba44303e88054c9504cb3083ba0c9");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");

            quicklingspider.AddFacts = quicklingspider.AddFacts.RemoveFromArray(natarmor6);
            quicklingspider.AddFacts = quicklingspider.AddFacts.AddToArray(natarmor9);





            var verminLevels = quicklingspider.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == magicalbeast);
            var newverminLevels = verminLevels.CreateCopy();
            newverminLevels.Levels = 10;
            quicklingspider.ReplaceComponent(verminLevels, newverminLevels);

            quicklingspider.Body.AdditionalLimbs = quicklingspider.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            quicklingspider.Body.AdditionalLimbs = quicklingspider.Body.AdditionalLimbs.AddToArray(bite3d6);


        }

        static void updatedoomspider()
        {

            var doomspider = library.Get<BlueprintUnit>("51c66b0783a748c4b9538f0f0678c4d7");
            var magicalbeast = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var web = library.Get<BlueprintAbility>("134cb6d492269aa4f8662700ef57449f");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            var natarmor6 = library.Get<BlueprintUnitFact>("987ba44303e88054c9504cb3083ba0c9");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");




            

            doomspider.AddFacts = doomspider.AddFacts.RemoveFromArray(natarmor6);
            doomspider.AddFacts = doomspider.AddFacts.AddToArray(natarmor9,web);





            var verminLevels = doomspider.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == magicalbeast);
            var newverminLevels = verminLevels.CreateCopy();
            newverminLevels.Levels = 10;
            doomspider.ReplaceComponent(verminLevels, newverminLevels);

            doomspider.Body.AdditionalLimbs = doomspider.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            doomspider.Body.AdditionalLimbs = doomspider.Body.AdditionalLimbs.AddToArray(bite3d6);

            var brain = doomspider.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.useweb);

        }

        static void updatespidermatriarch()
        {

            var spidermatriarch = library.Get<BlueprintUnit>("63897b4df57da2f4396ca8a6f34723e7");
            var magicalbeast = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var web = library.Get<BlueprintAbility>("134cb6d492269aa4f8662700ef57449f");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            var natarmor10 = library.Get<BlueprintUnitFact>("4179c5c08d606a6439a62bf178b738e1");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");






            spidermatriarch.AddFacts = spidermatriarch.AddFacts.RemoveFromArray(natarmor10);
            spidermatriarch.AddFacts = spidermatriarch.AddFacts.AddToArray(natarmor14, web);





            var verminLevels = spidermatriarch.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == magicalbeast);
            var newverminLevels = verminLevels.CreateCopy();
            newverminLevels.Levels = 15;
            spidermatriarch.ReplaceComponent(verminLevels, newverminLevels);

            spidermatriarch.Body.AdditionalLimbs = spidermatriarch.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            spidermatriarch.Body.AdditionalLimbs = spidermatriarch.Body.AdditionalLimbs.AddToArray(bite3d6);

            var brain = spidermatriarch.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.useweb);

        }

        static void updatestandardwyvern()
        {

            var standardwyvern = library.Get<BlueprintUnit>("ada72e12e8cd3014b80eb2162fbc7802");
            var dragonclass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");


            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");
            var natarmor12 = library.Get<BlueprintUnitFact>("0b2d92c6aac8093489dfdadf1e448280");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");





            standardwyvern.AddFacts = standardwyvern.AddFacts.RemoveFromArray(natarmor9);
            standardwyvern.AddFacts = standardwyvern.AddFacts.AddToArray(natarmor12,toughness);



            var dragonLevels = standardwyvern.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == dragonclass);
            var newverminLevels = dragonLevels.CreateCopy();
            newverminLevels.Levels = 9;
            standardwyvern.ReplaceComponent(dragonLevels, newverminLevels);




        }

        static void updateadvancedwyvern()
        {

            var advancedwyvern = library.Get<BlueprintUnit>("218d6bd8e05c9da4ea04599714ba088d");
            var dragonclass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");
            var natarmor11 = library.Get<BlueprintUnitFact>("fe38367139432294e8c229edc066e4ac");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");


            advancedwyvern.AddFacts = advancedwyvern.AddFacts.RemoveFromArray(natarmor11);
            advancedwyvern.AddFacts = advancedwyvern.AddFacts.AddToArray(natarmor14, toughness);

            advancedwyvern.Body.AdditionalLimbs = advancedwyvern.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            advancedwyvern.Body.AdditionalLimbs = advancedwyvern.Body.AdditionalLimbs.AddToArray(bite3d6);



            var dragonLevels = advancedwyvern.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == dragonclass);
            var newverminLevels = dragonLevels.CreateCopy();
            newverminLevels.Levels = 11;
            advancedwyvern.ReplaceComponent(dragonLevels, newverminLevels);

            advancedwyvern.GetComponent<Experience>().CR = 8;


        }

        static void updateenchantmentwyvern()
        {

            var enchantmentwyvern = library.Get<BlueprintUnit>("b5191d52e3e8b4249be444acb4925ed2");
            var dragonclass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            var crushingdespair = library.Get<BlueprintAbility>("4baf4109145de4345861fe0f2209d903");


            enchantmentwyvern.AddFacts = enchantmentwyvern.AddFacts.RemoveFromArray(natarmor9);
            enchantmentwyvern.AddFacts = enchantmentwyvern.AddFacts.AddToArray(natarmor14, toughness,crushingdespair);

            enchantmentwyvern.Body.AdditionalLimbs = enchantmentwyvern.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            enchantmentwyvern.Body.AdditionalLimbs = enchantmentwyvern.Body.AdditionalLimbs.AddToArray(bite3d6);



            var dragonLevels = enchantmentwyvern.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == dragonclass);
            var newverminLevels = dragonLevels.CreateCopy();
            newverminLevels.Levels = 11;
            enchantmentwyvern.ReplaceComponent(dragonLevels, newverminLevels);

            enchantmentwyvern.GetComponent<Experience>().CR = 9;

            var brain = enchantmentwyvern.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castcrushingdespairwyvern);
        }


        static void updateevocationwyvern()
        {

            var evocationwyvern = library.Get<BlueprintUnit>("f0b8589972d12d448983aab972bcdcef");
            var dragonclass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var controlledfireball = library.Get<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");
            var burningaiaction = library.Get<BlueprintAiCastSpell>("5dfe6689bf271874ab07a86e7946a61c");


            evocationwyvern.AddFacts = evocationwyvern.AddFacts.AddToArray(controlledfireball, combatcasting);




            evocationwyvern.AddFacts = evocationwyvern.AddFacts.RemoveFromArray(natarmor9);
            evocationwyvern.AddFacts = evocationwyvern.AddFacts.AddToArray(natarmor14, toughness, controlledfireball);

            evocationwyvern.Body.AdditionalLimbs = evocationwyvern.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            evocationwyvern.Body.AdditionalLimbs = evocationwyvern.Body.AdditionalLimbs.AddToArray(bite3d6);



            var dragonLevels = evocationwyvern.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == dragonclass);
            var newverminLevels = dragonLevels.CreateCopy();
            newverminLevels.Levels = 11;
            evocationwyvern.ReplaceComponent(dragonLevels, newverminLevels);

            evocationwyvern.GetComponent<Experience>().CR = 9;

            var brain = evocationwyvern.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(burningaiaction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castcontrolledfireballwyvern);
        }

        static void updatestrongenchantmentwyvern()
        {

            var strongenchantmentwyvern = library.Get<BlueprintUnit>("65b9f397b53ff0d48b9ea6f33e2f1d28");
            var dragonclass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            


            strongenchantmentwyvern.AddFacts = strongenchantmentwyvern.AddFacts.RemoveFromArray(natarmor9);
            strongenchantmentwyvern.AddFacts = strongenchantmentwyvern.AddFacts.AddToArray(natarmor14, toughness);

            strongenchantmentwyvern.Body.AdditionalLimbs = strongenchantmentwyvern.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            strongenchantmentwyvern.Body.AdditionalLimbs = strongenchantmentwyvern.Body.AdditionalLimbs.AddToArray(bite3d6);

            var dragonLevels = strongenchantmentwyvern.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == dragonclass);
            var newverminLevels = dragonLevels.CreateCopy();
            newverminLevels.Levels = 21;
            strongenchantmentwyvern.ReplaceComponent(dragonLevels, newverminLevels);



        }

        static void updatetransmutationwyvern()
        {

            var strongtransmutationwyvern = library.Get<BlueprintUnit>("c311734cc87b0f045aca5c282e9d0cd4");
            var dragonclass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            var confusion = library.Get<BlueprintAbility>("cf6c901fb7acc904e85c63b342e9c949");


        var dragonLevels = strongtransmutationwyvern.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == dragonclass);
            var newverminLevels = dragonLevels.CreateCopy();
            newverminLevels.Levels = 21;
            strongtransmutationwyvern.ReplaceComponent(dragonLevels, newverminLevels);

            strongtransmutationwyvern.AddFacts = strongtransmutationwyvern.AddFacts.RemoveFromArray(natarmor9);
            strongtransmutationwyvern.AddFacts = strongtransmutationwyvern.AddFacts.AddToArray(natarmor14, toughness);

            strongtransmutationwyvern.Body.AdditionalLimbs = strongtransmutationwyvern.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            strongtransmutationwyvern.Body.AdditionalLimbs = strongtransmutationwyvern.Body.AdditionalLimbs.AddToArray(bite3d6);




        }

        static void updatetreantwyvern()
        {

            var treantwyvern = library.Get<BlueprintUnit>("04153cb656ce4844c8f71d5db1f87d4e");
            var dragonclass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            var RegenerationColdIronOrFire5 = library.Get<BlueprintBuff>("da6b266204fe2ac4d89786bf66dbe3a9");
            var stunningblowaiaction = library.Get<BlueprintAiCastSpell>("b2428bdc1e519104f8eb08e2fd06eb02");
            var dragonsbreathgreen = library.Get<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");

            treantwyvern.Strength = 26;
            treantwyvern.Dexterity = 12;
            treantwyvern.Constitution = 30;
            treantwyvern.Intelligence = 6;
            treantwyvern.Wisdom = 16;
            treantwyvern.Charisma = 14;

            treantwyvern.AddFacts = treantwyvern.AddFacts.RemoveFromArray(natarmor9);
            treantwyvern.AddFacts = treantwyvern.AddFacts.AddToArray(natarmor14, toughness, RegenerationColdIronOrFire5,dragonsbreathgreen);

            treantwyvern.Body.AdditionalLimbs = treantwyvern.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            treantwyvern.Body.AdditionalLimbs = treantwyvern.Body.AdditionalLimbs.AddToArray(bite3d6);

            var dragonLevels = treantwyvern.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == dragonclass);
            var newverminLevels = dragonLevels.CreateCopy();
            newverminLevels.Levels = 21;
            treantwyvern.ReplaceComponent(dragonLevels, newverminLevels);

            var brain = treantwyvern.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(stunningblowaiaction);
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathgreenwyvern);

           
        }

        static void updatewyvernforked()
        {

            var forkedwyvern = library.Get<BlueprintUnit>("18e4f92f356983240b99b938c9a6b7fc");
            var dragonclass = library.Get<BlueprintCharacterClass>("01a754e7c1b7c5946ba895a5ff0faffc");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var dragonsbreathgold = library.Get<BlueprintAbility>("e6f5453df86bd714fa33b14c994739f3");


            forkedwyvern.LocalizedName = Helpers.Create<SharedStringAsset>(c => c.String = Helpers.CreateString($"{forkedwyvern.name}.name", "Giant Fork-Tailed Wyvern"));


            forkedwyvern.AddFacts = forkedwyvern.AddFacts.AddToArray(toughness, combatcasting,dragonsbreathgold);

            forkedwyvern.Body.AdditionalLimbs = forkedwyvern.Body.AdditionalLimbs.RemoveFromArray(bite2d6);
            forkedwyvern.Body.AdditionalLimbs = forkedwyvern.Body.AdditionalLimbs.AddToArray(bite3d6);

            var dragonLevels = forkedwyvern.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == dragonclass);
            var newverminLevels = dragonLevels.CreateCopy();
            newverminLevels.Levels = 18;
            forkedwyvern.ReplaceComponent(dragonLevels, newverminLevels);


            var brain = forkedwyvern.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castcontrolledfireballwyvern,AiActions.dragonsbreathgoldwyvern);
        }

        static void updateManticoreStandard()
        {

            var manticoreStandard = library.Get<BlueprintUnit>("da807351572c540478b703957d863e68");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");



            var dragonLevels = manticoreStandard.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 8;
            manticoreStandard.ReplaceComponent(dragonLevels, newAddClassLevels);


        }

        static void updateManticoreAdvanced()
        {

            var manticoreStandard = library.Get<BlueprintUnit>("37f79d70c8914324e909dbccb227704e");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");



            var dragonLevels = manticoreStandard.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = dragonLevels.CreateCopy();
            newAddClassLevels.Levels = 10;
            manticoreStandard.ReplaceComponent(dragonLevels, newAddClassLevels);


        }

        static void updateManticoreEnchantment()
        {

            var manticoreenchantment = library.Get<BlueprintUnit>("01f37ed680df5be4ba30a79b89f98072");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");
            var natarmor6 = library.Get<BlueprintUnitFact>("987ba44303e88054c9504cb3083ba0c9");
            var BiteLarge1d8 = library.Get<BlueprintItemWeapon>("ec35ef997ed5a984280e1a6d87ae80a8");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");
            var overwhelminggrief = library.Get<BlueprintAbility>("dd2918e4a77c50044acba1ac93494c36");



        manticoreenchantment.AddFacts = manticoreenchantment.AddFacts.RemoveFromArray(natarmor6);
            manticoreenchantment.AddFacts = manticoreenchantment.AddFacts.AddToArray(natarmor9,overwhelminggrief);



            manticoreenchantment.Body.AdditionalLimbs = manticoreenchantment.Body.AdditionalLimbs.RemoveFromArray(BiteLarge1d8);
            manticoreenchantment.Body.AdditionalLimbs = manticoreenchantment.Body.AdditionalLimbs.AddToArray(bite2d6);

            var magicalbeastLevels = manticoreenchantment.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = magicalbeastLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            manticoreenchantment.ReplaceComponent(magicalbeastLevels, newAddClassLevels);

            var brain = manticoreenchantment.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castoverwhelminggriefmanticore);

        }

        static void updateManticoreTransmutation()
        {

            var manticoretransmutation = library.Get<BlueprintUnit>("397aaf105780aaf479c3b49c3bc64027");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");
            var natarmor6 = library.Get<BlueprintUnitFact>("987ba44303e88054c9504cb3083ba0c9");
            var BiteLarge1d8 = library.Get<BlueprintItemWeapon>("ec35ef997ed5a984280e1a6d87ae80a8");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");




            manticoretransmutation.AddFacts = manticoretransmutation.AddFacts.RemoveFromArray(natarmor6);
            manticoretransmutation.AddFacts = manticoretransmutation.AddFacts.AddToArray(natarmor9 );



            manticoretransmutation.Body.AdditionalLimbs = manticoretransmutation.Body.AdditionalLimbs.RemoveFromArray(BiteLarge1d8);
            manticoretransmutation.Body.AdditionalLimbs = manticoretransmutation.Body.AdditionalLimbs.AddToArray(bite2d6);

            var magicalbeastLevels = manticoretransmutation.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = magicalbeastLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            manticoretransmutation.ReplaceComponent(magicalbeastLevels, newAddClassLevels);



        }

        static void updateManticoreVenom()
        {

            var manticorevenom = library.Get<BlueprintUnit>("d1e924177f4a9284e8c43a30719820e2");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var natarmor9 = library.Get<BlueprintUnitFact>("da6417809bdedfa468dd2fd0cc74be92");
            var natarmor6 = library.Get<BlueprintUnitFact>("987ba44303e88054c9504cb3083ba0c9");
            var BiteLarge1d8 = library.Get<BlueprintItemWeapon>("ec35ef997ed5a984280e1a6d87ae80a8");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");




            manticorevenom.AddFacts = manticorevenom.AddFacts.RemoveFromArray(natarmor6);
            manticorevenom.AddFacts = manticorevenom.AddFacts.AddToArray(natarmor9);



            manticorevenom.Body.AdditionalLimbs = manticorevenom.Body.AdditionalLimbs.RemoveFromArray(BiteLarge1d8);
            manticorevenom.Body.AdditionalLimbs = manticorevenom.Body.AdditionalLimbs.AddToArray(bite2d6);

            var magicalbeastLevels = manticorevenom.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = magicalbeastLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            manticorevenom.ReplaceComponent(magicalbeastLevels, newAddClassLevels);



        }

        static void updateManticoreMature()
        {

            var manticoreMature = library.Get<BlueprintUnit>("667749d27f772ff4ba6d9d03d5afed63");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var natarmor13= library.Get<BlueprintUnitFact>("97c198634abbea847982600593ea43ed");
            var natarmor10 = library.Get<BlueprintUnitFact>("4179c5c08d606a6439a62bf178b738e1");
            var BiteLarge1d8 = library.Get<BlueprintItemWeapon>("ec35ef997ed5a984280e1a6d87ae80a8");
            var bite2d6 = library.Get<BlueprintItemWeapon>("d2f99947db522e24293a7ec4eded453f");




            manticoreMature.AddFacts = manticoreMature.AddFacts.RemoveFromArray(natarmor10);
            manticoreMature.AddFacts = manticoreMature.AddFacts.AddToArray(natarmor13);



            manticoreMature.Body.AdditionalLimbs = manticoreMature.Body.AdditionalLimbs.RemoveFromArray(BiteLarge1d8);
            manticoreMature.Body.AdditionalLimbs = manticoreMature.Body.AdditionalLimbs.AddToArray(bite2d6);

            var magicalbeastLevels = manticoreMature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = magicalbeastLevels.CreateCopy();
            newAddClassLevels.Levels = 13;
            manticoreMature.ReplaceComponent(magicalbeastLevels, newAddClassLevels);



        }

        static void updateManticorebloominfused()
        {

            var manticorebloom = library.Get<BlueprintUnit>("8347f8e5bd919514f8629b2c92b5c249");
            var magicalbeastClass = library.Get<BlueprintCharacterClass>("b9e97f47cb86f2d45a0784a096ff8037");
            var natarmor13 = library.Get<BlueprintUnitFact>("97c198634abbea847982600593ea43ed");
            var natarmor10 = library.Get<BlueprintUnitFact>("4179c5c08d606a6439a62bf178b738e1");
            var ClawLarge1d6 = library.Get<BlueprintItemWeapon>("c76f72a862d168d44838206524366e1c");
            var ClawLarge2d4 = library.Get<BlueprintItemWeapon>("8afc47748d00b3e4a8aff2787d9ee350");




            manticorebloom.AddFacts = manticorebloom.AddFacts.RemoveFromArray(natarmor10);
            manticorebloom.AddFacts = manticorebloom.AddFacts.AddToArray(natarmor13);



            manticorebloom.Body.AdditionalLimbs = manticorebloom.Body.AdditionalLimbs.RemoveFromArray(ClawLarge1d6);
            manticorebloom.Body.AdditionalLimbs = manticorebloom.Body.AdditionalLimbs.RemoveFromArray(ClawLarge1d6);
            manticorebloom.Body.AdditionalLimbs = manticorebloom.Body.AdditionalLimbs.AddToArray(ClawLarge2d4);
            manticorebloom.Body.AdditionalLimbs = manticorebloom.Body.AdditionalLimbs.AddToArray(ClawLarge2d4);

            var magicalbeastLevels = manticorebloom.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == magicalbeastClass);
            var newAddClassLevels = magicalbeastLevels.CreateCopy();
            newAddClassLevels.Levels = 16;
            manticorebloom.ReplaceComponent(magicalbeastLevels, newAddClassLevels);



        }

        static void updateFlyTrapStandard()
        {

            var FlyTrapStandard = library.Get<BlueprintUnit>("fb824352b7968fb4d8103ac439644633");
            var plantClass = library.Get<BlueprintCharacterClass>("9393cc36ea29d084bab7433e3a28d40b");
            var natarmor13 = library.Get<BlueprintUnitFact>("97c198634abbea847982600593ea43ed");
            var natarmor10 = library.Get<BlueprintUnitFact>("4179c5c08d606a6439a62bf178b738e1");





            FlyTrapStandard.AddFacts = FlyTrapStandard.AddFacts.RemoveFromArray(natarmor10);
            FlyTrapStandard.AddFacts = FlyTrapStandard.AddFacts.AddToArray(natarmor13);





            var magicalbeastLevels = FlyTrapStandard.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == plantClass);
            var newAddClassLevels = magicalbeastLevels.CreateCopy();
            newAddClassLevels.Levels = 15;
            FlyTrapStandard.ReplaceComponent(magicalbeastLevels, newAddClassLevels);



        }

        static void updateFlyTrapadvanced()
        {

            var FlyTrapadvanced = library.Get<BlueprintUnit>("7640c8bb97e8e7b409c4dc42f64fbcc7");
            var plantClass = library.Get<BlueprintCharacterClass>("9393cc36ea29d084bab7433e3a28d40b");
            var natarmor15 = library.Get<BlueprintUnitFact>("72c294dca841e3944869fb087bacf272");
            var natarmor12 = library.Get<BlueprintUnitFact>("0b2d92c6aac8093489dfdadf1e448280");





            FlyTrapadvanced.AddFacts = FlyTrapadvanced.AddFacts.RemoveFromArray(natarmor12);
            FlyTrapadvanced.AddFacts = FlyTrapadvanced.AddFacts.AddToArray(natarmor15);





            var magicalbeastLevels = FlyTrapadvanced.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == plantClass);
            var newAddClassLevels = magicalbeastLevels.CreateCopy();
            newAddClassLevels.Levels = 19;
            FlyTrapadvanced.ReplaceComponent(magicalbeastLevels, newAddClassLevels);



        }

        static void updateFlyTrapbloominfused()
        {

            var FlyTrapadvanced = library.Get<BlueprintUnit>("9d2eb62e29d9ba943ab933898dd18882");
            var plantClass = library.Get<BlueprintCharacterClass>("9393cc36ea29d084bab7433e3a28d40b");






            var magicalbeastLevels = FlyTrapadvanced.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == plantClass);
            var newAddClassLevels = magicalbeastLevels.CreateCopy();
            newAddClassLevels.Levels = 17;
            FlyTrapadvanced.ReplaceComponent(magicalbeastLevels, newAddClassLevels);



        }

        //Talon Peak

        static void updateAncientRoc()
        {

            var ancientroc = library.Get<BlueprintUnit>("5c419d152e1a8ee47b53923cd4edda6e");
            var animalclass = library.Get<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");
            var greatershout = library.Get<BlueprintAbility>("fd0d3840c48cafb44bb29e8eb74df204");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");



            ancientroc.AddFacts = ancientroc.AddFacts.AddToArray(toughness,greatershout);



            var dragonLevels = ancientroc.ComponentsArray
             .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == animalclass);
            var newverminLevels = dragonLevels.CreateCopy();
            newverminLevels.Levels = 26;
            ancientroc.ReplaceComponent(dragonLevels, newverminLevels);

            var brain = ancientroc.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usegreatershoutbird);


        }

        static void updateTalonPeakAlchemist()
        {

            var TalonPeakAlchemist = library.Get<BlueprintUnit>("e41c61db59e0f8a40bf8610d25e24897");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var BanditAlchemistFeatureListLevel9 = library.Get<BlueprintFeature>("1d0f38d8f1f16b04784450a57e563ee6");
            var ExplosiveBombsFeature = library.Get<BlueprintFeature>("1d0e812131f345742adca6431d5bc4fe");
            var ExplosiveBombsBuff = library.Get<BlueprintBuff>("63063a8ab91bcbc44a13294227580e84");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var heroism = library.Get<BlueprintAbility>("5ab0d42fb68c9e34abae4921822b9d63");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var fastbomb = library.Get<BlueprintFeature>("128c5fccec5ca724281a4907b1f0ac83");
            var fastbombbuff = library.Get<BlueprintBuff>("c42ae8f9652bbc14eb13b31d12d20f8a");
            var chokebomb = library.Get<BlueprintAbility>("0fcbed386deb18b428825605796d5a15");
            var Cogintell = library.Get<BlueprintAbility>("14230cf35ac2b5b45a93b13cfe478585");
            var Cogintellbuff = library.Get<BlueprintBuff>("20e740104092b5e49bfb167f1670a9de");
            var StoneskinBuffCL11 = library.Get<BlueprintBuff>("6215b25fbc1a36748b5606ebc0092074");
            var InvisibilityGreater = library.Get<BlueprintAbility>("ecaa0def35b38f949bd1976a6c9539e0");
            var extrabomb = library.Get<BlueprintFeature>("54c57ce67fa1d9044b1b3edc459e05e2");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");


            TalonPeakAlchemist.AddFacts = TalonPeakAlchemist.AddFacts.AddToArray(ExplosiveBombsFeature,fastbombbuff,chokebomb,Cogintell,Cogintellbuff,StoneskinBuffCL11,extrabomb,quicken);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)TalonPeakAlchemist.AddFacts[0], "TalonPeakAlchemistFeatureNew", "a85b6efb3cb84f138f67092dfeaf6733");
            TalonPeakAlchemist.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BanditAlchemistFeatureListLevel9.GetComponent<AddFacts>().Facts[0], "TalonPeakAlchemistSpellListNew", "6f5105e7cba445048559c2d12807a85d");
            BanditAlchemistFeatureListLevel9.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var TalonPeakAlchemistFeatureNew = library.Get<BlueprintFeature>("a85b6efb3cb84f138f67092dfeaf6733");
            var TalonPeakAlchemistSpellsNew = library.Get<BlueprintFeature>("6f5105e7cba445048559c2d12807a85d");



            var alchemistLevels = TalonPeakAlchemistFeatureNew.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(haste, InvisibilityGreater);
            newAddClassLevels.MemorizeSpells = spell_list;
            TalonPeakAlchemistFeatureNew.ReplaceComponent(alchemistLevels, newAddClassLevels);



            var AlchemistLevels2 = TalonPeakAlchemistSpellsNew.ComponentsArray
        .OfType<LearnSpells>()
          .First(c => c.CharacterClass == alchemistClass);
            var newbardLevels2 = AlchemistLevels2.CreateCopy();
            var spell_list2 = newbardLevels2.Spells.AddToArray(haste, InvisibilityGreater);
            newbardLevels2.Spells = spell_list2;
            TalonPeakAlchemistSpellsNew.ReplaceComponent(AlchemistLevels2, newbardLevels2);

            var alchemistLevels5 = TalonPeakAlchemistFeatureNew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels5 = alchemistLevels5.CreateCopy();
            var spell_list5 = newAddClassLevels5.SelectSpells.AddToArray(haste, InvisibilityGreater);
            newAddClassLevels5.SelectSpells = spell_list5;
            TalonPeakAlchemistFeatureNew.ReplaceComponent(alchemistLevels5, newAddClassLevels5);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);

            TalonPeakAlchemist.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("f5528acb89757ab4fb9350f45cc4f3b4"); //Lightcrossbow +1

            


            var brain = TalonPeakAlchemist.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.casthaste,AiActions.castdisplacementgoblin,AiActions.throwchokebomb,AiActions.castinvisibilitygreater);


        }

        static void updateTalonPeakFighter()
        {

            var TalonPeakFighter = library.Get<BlueprintUnit>("3dbdc77212b405f448d863906d0c8366");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var sunder = library.Get<BlueprintFeature>("9719015edcbf142409592e2cbaab7fe1");
            var armortraining = library.Get<BlueprintFeature>("3c380607706f209499d951b29d3c44f3");
            var combatexpertise = library.Get<BlueprintFeature>("4c44724ffa8844f4d9bedb5bb27d144a");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            TalonPeakFighter.Strength = 20;
            TalonPeakFighter.Dexterity = 16;

            TalonPeakFighter.AddFacts = TalonPeakFighter.AddFacts.AddToArray(sunder,armortraining);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)TalonPeakFighter.AddFacts[0], "TalonPeakFighter", "b19ffe51cb2f41dfa3cc809925708416");
            TalonPeakFighter.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var TalonPeakFighterFeatureNew = library.Get<BlueprintFeature>("b19ffe51cb2f41dfa3cc809925708416");
            


            var alchemistLevels = TalonPeakFighterFeatureNew.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            TalonPeakFighterFeatureNew.ReplaceComponent(alchemistLevels, newAddClassLevels);

            TalonPeakFighter.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("03d706655c07d804cb9d5a5583f9aec5"); //longsword +1

            TalonPeakFighter.Body.Armor = library.Get<BlueprintItemArmor>("ed6bbd7ecd050c04690fe11d4c3b3f7d"); // Half plate

            TalonPeakFighter.Body.SecondaryHand = library.Get<BlueprintItemShield>("5c7b898a1bfb6cb4f8c14a0ebc143abe"); // Heavy Shield +1



            var brain = TalonPeakFighter.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.usesunderarmorzombiebarb);


        }

        static void updateTalonPeakRogue()
        {
            var TalonPeakRogue = library.Get<BlueprintUnit>("abe4997494bf44b4bb01de42a9a9b038");

            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");
            var oppurtunist = library.Get<BlueprintFeature>("5bb6dc5ce00550441880a6ff8ad4c968");
            var slowreaction = library.Get<BlueprintFeature>("7787030571e87704d9177401c595408e");


            TalonPeakRogue.Strength = 15;
            TalonPeakRogue.Dexterity = 20;

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)TalonPeakRogue.AddFacts[0], "TalonPeakRoguenewFeature", "03eb8a6b33b6425db4406540a1475b2c");
            TalonPeakRogue.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var TalonPeakRoguenewFeature = library.Get<BlueprintFeature>("03eb8a6b33b6425db4406540a1475b2c");



            var rogueLevels = TalonPeakRoguenewFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 10;
            TalonPeakRoguenewFeature.ReplaceComponent(rogueLevels, newAddClassLevels);

            TalonPeakRogue.AddFacts = TalonPeakRogue.AddFacts.AddToArray(dirtytrick, oppurtunist,slowreaction);


            TalonPeakRogue.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"); //Dagger +1

            TalonPeakRogue.Body.SecondaryHand = library.Get<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"); //Dagger +1


            var brain = TalonPeakRogue.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedirtytrickblind);






        }

        //Goblins

        static void fixGoblinDogcutter()
        {

            var goblinDogcutter = library.Get<BlueprintUnit>("9223046d50e815942a9f7338eafb88e9");

            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");


            goblinDogcutter.AddFacts = goblinDogcutter.AddFacts.AddToArray(trip);


            var brain = goblinDogcutter.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }

        static void fixGoblinGuardNeutral()
        {

            var goblinHorseslayer = library.Get<BlueprintUnit>("884d2d62ba4503e488204784ce1b2f7a");

            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");


            goblinHorseslayer.AddFacts = goblinHorseslayer.AddFacts.AddToArray(trip);


            var brain = goblinHorseslayer.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }

        static void fixGoblinHorseslayer()
        {

            var goblinHorseslayer = library.Get<BlueprintUnit>("b5a1c87ef17913d4c879a56af738c56c");

            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");


            goblinHorseslayer.AddFacts = goblinHorseslayer.AddFacts.AddToArray(trip);


            var brain = goblinHorseslayer.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }

        static void fixGoblinHorseslayerb()
        {

            var goblinHorseslayerb = library.Get<BlueprintUnit>("304d6ab456ad11e4ebeef6460b4bcf0e");

            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");


            goblinHorseslayerb.AddFacts = goblinHorseslayerb.AddFacts.AddToArray(trip);


            var brain = goblinHorseslayerb.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }

        static void fixGoblinCommando()
        {

            var goblinCommando = library.Get<BlueprintUnit>("0713685858b39bf4c9775669b8c3b2b1");

            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");


            goblinCommando.AddFacts = goblinCommando.AddFacts.AddToArray(trip);


            var brain = goblinCommando.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }

        static void fixGoblinCommandob()
        {

            var goblinCommandob = library.Get<BlueprintUnit>("60166a7c8a78b2844973549e60877566");

            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");


            goblinCommandob.AddFacts = goblinCommandob.AddFacts.AddToArray(trip);


            var brain = goblinCommandob.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }

        static void fixGoblinSentry()
        {

            var goblinsentry = library.Get<BlueprintUnit>("8f0f0b0bfaae479e9a70860e33be4961");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var trip = library.Get<BlueprintFeature>("0f15c6f70d8fb2b49aa6cc24239cc5fa");


            goblinsentry.AddFacts = goblinsentry.AddFacts.AddToArray(trip);

            goblinsentry.Dexterity = 16;



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinsentry.AddFacts[0], "goblinsentryfeature", "64e701a8d9e442eabb8e888488db643b");
            goblinsentry.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var goblinsentryfeature = library.Get<BlueprintFeature>("64e701a8d9e442eabb8e888488db643b");



            var fighterLevels = goblinsentryfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            goblinsentryfeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            goblinsentry.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("455c6750aac8fa94f8ab19f385c73ae7");//masterwork shortsword
            goblinsentry.Body.SecondaryHand = library.Get<BlueprintItemShield>("a85d51d0fb905f940b951eec60388bac"); 
            
            var brain = goblinsentry.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.trip);


        }


        static void fixGoblinRogueCR7()
        {

            var goblinrogueCR7 = library.Get<BlueprintUnit>("81c76d70bc4e03948b140973bc52bc67");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");





            var rogueLevels = goblinrogueCR7.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            goblinrogueCR7.ReplaceComponent(rogueLevels, newAddClassLevels);

            goblinrogueCR7.AddFacts = goblinrogueCR7.AddFacts.AddToArray(dirtytrick);


            var brain = goblinrogueCR7.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedirtytrickblind);


        }

        static void fixGoblinRogueCR9()
        {

            var goblinrogueCR9 = library.Get<BlueprintUnit>("131dd387827482d45882ebb2aeb2af8c");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");





            var rogueLevels = goblinrogueCR9.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            goblinrogueCR9.ReplaceComponent(rogueLevels, newAddClassLevels);

            goblinrogueCR9.AddFacts = goblinrogueCR9.AddFacts.AddToArray(dirtytrick);


            var brain = goblinrogueCR9.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedirtytrickblind);


        }

        static void fixGoblinRogueCR7Ambush()
        {

            var goblinrogueCR7Ambush = library.Get<BlueprintUnit>("7b6dabd480b7b0c4189800693daa31dd");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");





            var rogueLevels = goblinrogueCR7Ambush.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            goblinrogueCR7Ambush.ReplaceComponent(rogueLevels, newAddClassLevels);

            goblinrogueCR7Ambush.AddFacts = goblinrogueCR7Ambush.AddFacts.AddToArray(dirtytrick);


            var brain = goblinrogueCR7Ambush.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedirtytrickblind);


        }

        static void fixGoblinRogueCR9Ambush()
        {

            var goblinrogueCR9Ambush = library.Get<BlueprintUnit>("4b1ce5f9cafbd7145b4b66c632712a23");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");





            var rogueLevels = goblinrogueCR9Ambush.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = rogueLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            goblinrogueCR9Ambush.ReplaceComponent(rogueLevels, newAddClassLevels);

            goblinrogueCR9Ambush.AddFacts = goblinrogueCR9Ambush.AddFacts.AddToArray(dirtytrick);


            var brain = goblinrogueCR9Ambush.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedirtytrickblind);


        }


        static void fixGoblinDeathEye()
        {

            var goblinDeathEye = library.Get<BlueprintUnit>("aadfcc46082641d46ae547c12a3a21b8");
            var Featurelevel10 = library.Get<BlueprintFeature>("1aa7e35c2c9d97a43831ea67268d8ef2");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");


            goblinDeathEye.AddFacts = goblinDeathEye.AddFacts.AddToArray(rapidshot, rapidshotbuff);

            goblinDeathEye.Dexterity = 18;

            var fighterLevels = Featurelevel10.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Featurelevel10.ReplaceComponent(fighterLevels, newAddClassLevels);


        }

        static void fixGoblinDeadEye()
        {

            var goblinDeadEye = library.Get<BlueprintUnit>("1a1179e00db35394ea6474a8e28d2c21");
            var Featurelevel9 = library.Get<BlueprintFeature>("c6f9d9a2987778e4cb2f5931a5b1f804");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");


            goblinDeadEye.AddFacts = goblinDeadEye.AddFacts.AddToArray(rapidshot, rapidshotbuff);

            goblinDeadEye.Dexterity = 18;

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinDeadEye.AddFacts[0], "goblinDeadEyefeature", "48d4f5068dbe4b72a07ec2a4b396ff8a");
            goblinDeadEye.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var goblinDeadEyefeature = library.Get<BlueprintFeature>("48d4f5068dbe4b72a07ec2a4b396ff8a");

            var fighterLevels = goblinDeadEyefeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            goblinDeadEyefeature.ReplaceComponent(fighterLevels, newAddClassLevels);


        }

        static void fixGoblinEagleEye()
        {

            var GoblinEagleEye = library.Get<BlueprintUnit>("5816727d3277024469dec37adea3204c");
            var Featurelevel8 = library.Get<BlueprintFeature>("283fb4dc19edb11468eebcf159e8aa0b");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");


            GoblinEagleEye.AddFacts = GoblinEagleEye.AddFacts.AddToArray(rapidshot, rapidshotbuff);

            GoblinEagleEye.Dexterity = 18;

            var fighterLevels = Featurelevel8.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Featurelevel8.ReplaceComponent(fighterLevels, newAddClassLevels);


        }

        static void fixGoblinEagleEyeB()
        {

            var GoblinEagleEyeB = library.Get<BlueprintUnit>("132627ad9ea002e4aa6a16314cb3cf07");
            var Featurelevel7 = library.Get<BlueprintFeature>("8194ce5f060ddef48812948507f9da3b");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");


            GoblinEagleEyeB.AddFacts = GoblinEagleEyeB.AddFacts.AddToArray(rapidshot, rapidshotbuff);

            GoblinEagleEyeB.Dexterity = 18;

            var fighterLevels = Featurelevel7.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Featurelevel7.ReplaceComponent(fighterLevels, newAddClassLevels);


        }

        static void fixGoblinLynxEye()
        {

            var GoblinLynxEye = library.Get<BlueprintUnit>("5816727d3277024469dec37adea3204c");
            var Featurelevel6 = library.Get<BlueprintFeature>("f3192e0f1c22dfb478d2cd6e66a0c17a");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");


            GoblinLynxEye.AddFacts = GoblinLynxEye.AddFacts.AddToArray(rapidshot, rapidshotbuff);

            GoblinLynxEye.Dexterity = 18;

            var fighterLevels = Featurelevel6.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Featurelevel6.ReplaceComponent(fighterLevels, newAddClassLevels);


        }

        static void fixGoblinLynxEyeB()
        {

            var GoblinLynxEyeB = library.Get<BlueprintUnit>("7380afa2e42bd8e49acaf30d98afa66c");
            var Featurelevel5 = library.Get<BlueprintFeature>("0ee067ba2feab4a4fa212e04de52fd9b");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");


            GoblinLynxEyeB.AddFacts = GoblinLynxEyeB.AddFacts.AddToArray(rapidshot, rapidshotbuff);

            GoblinLynxEyeB.Dexterity = 18;

            var fighterLevels = Featurelevel5.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Featurelevel5.ReplaceComponent(fighterLevels, newAddClassLevels);


        }

        static void fixGoblinLynxEyeC()
        {

            var GoblinLynxEyeC = library.Get<BlueprintUnit>("f0b3188922bf71b47ab54e1425192fce");
            var Featurelevel4 = library.Get<BlueprintFeature>("819b7115ad4aac844807f296919baf27");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");


            GoblinLynxEyeC.AddFacts = GoblinLynxEyeC.AddFacts.AddToArray(rapidshot, rapidshotbuff);

            GoblinLynxEyeC.Dexterity = 18;

            var fighterLevels = Featurelevel4.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            Featurelevel4.ReplaceComponent(fighterLevels, newAddClassLevels);


        }

        static void fixGoblinSlyEye()
        {

            var goblinsentry = library.Get<BlueprintUnit>("8df02cfd6b0b4e9998c1dc1031dbaa34");
            var eagleeyefeaturelist = library.Get<BlueprintFeature>("283fb4dc19edb11468eebcf159e8aa0b");
            var slyeyefeaturelist = library.Get<BlueprintFeature>("7b4a72175700b5f47b6db3549bfa60f8");

            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");

           

            goblinsentry.AddFacts = goblinsentry.AddFacts.RemoveFromArray(slyeyefeaturelist);
            goblinsentry.AddFacts = goblinsentry.AddFacts.AddToArray(eagleeyefeaturelist, rapidshot, rapidshotbuff);

            goblinsentry.Dexterity = 18;


        }

        static void fixGoblinArcherCR9Ambush()
        {

            var goblinDeadEye = library.Get<BlueprintUnit>("47d18fdca0dd23e49908582ff721e0c2");
            var Featurelevel9 = library.Get<BlueprintFeature>("c6f9d9a2987778e4cb2f5931a5b1f804");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");


            goblinDeadEye.AddFacts = goblinDeadEye.AddFacts.AddToArray(rapidshot, rapidshotbuff);

            goblinDeadEye.Dexterity = 18;

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinDeadEye.AddFacts[0], "GoblinArcherCR9Ambushfeature", "d442edb5e9e24c2d9b1661a012b1034d");
            goblinDeadEye.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var goblinDeadEyefeature = library.Get<BlueprintFeature>("d442edb5e9e24c2d9b1661a012b1034d");

            var fighterLevels = goblinDeadEyefeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            goblinDeadEyefeature.ReplaceComponent(fighterLevels, newAddClassLevels);


        }

        static void fixGoblinArcherCR7Ambush()
        {

            var goblinDeadEye = library.Get<BlueprintUnit>("d65e481d3b473fc4b9a7219b4d78b2c3");
            var Featurelevel9 = library.Get<BlueprintFeature>("c6f9d9a2987778e4cb2f5931a5b1f804");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var rapidshot = library.Get<BlueprintFeature>("9c928dc570bb9e54a9649b3ebfe47a41");
            var rapidshotbuff = library.Get<BlueprintBuff>("0f310c1e709e15e4fa693db15a4baeb4");


            goblinDeadEye.AddFacts = goblinDeadEye.AddFacts.AddToArray(rapidshot, rapidshotbuff);

            goblinDeadEye.Dexterity = 18;

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinDeadEye.AddFacts[0], "GoblinArcherCR7Ambushfeature", "022e27f5ef994217a1e57a23f9eb7f43");
            goblinDeadEye.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var goblinDeadEyefeature = library.Get<BlueprintFeature>("022e27f5ef994217a1e57a23f9eb7f43");

            var fighterLevels = goblinDeadEyefeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 5;
            goblinDeadEyefeature.ReplaceComponent(fighterLevels, newAddClassLevels);


        }

        static void fixGoblinGuardAlchemit()
        {

            var goblinalchemistCR7 = library.Get<BlueprintUnit>("8cb0a2f6aa79b374ab8a94bf2e5e1437");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var precisebomb = library.Get<BlueprintFeature>("5c396342f614dd644a48c3af08d79701");
            var fastbomb = library.Get<BlueprintFeature>("128c5fccec5ca724281a4907b1f0ac83");
            var fastbombbuff = library.Get<BlueprintBuff>("c42ae8f9652bbc14eb13b31d12d20f8a");
            var blindbomb = library.Get<BlueprintFeature>("c3da68b2222768b4f9352fefd29ad15c");
            var AlchemistExplosiveBombAiAction = library.Get<BlueprintAiCastSpell>("b1e2b5351065e5042b12b1b4b9a7665e");
            var AlchemistBombAiAction = library.Get<BlueprintAiCastSpell>("da693ef36da820a4c938bb13a5ded163");

            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var GoblinAlchemistSpellListLevel7 = library.Get<BlueprintFeature>("23c87a062d96cd84abca665241de933c");
            var ReducepersonselfAiAction = library.Get<BlueprintAiCastSpell>("a8a89f28eeb5c5147b31c960bf518011");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");




            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinalchemistCR7.AddFacts[0], "goblinguardalchemistCR7feature", "8681ba04f9c44b11b920544472cd4cc6");
            goblinalchemistCR7.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var goblinalchemistCR7feature = library.Get<BlueprintFeature>("8681ba04f9c44b11b920544472cd4cc6");



            var alchemistLevels = goblinalchemistCR7feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(precisebomb, fastbomb, blindbomb);

            }
            goblinalchemistCR7feature.ReplaceComponent(alchemistLevels, newAddClassLevels);

            var alchemistlevels2 = goblinalchemistCR7feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels2 = alchemistlevels2.CreateCopy();
            var spell_list5 = newalchemistlevels2.MemorizeSpells.AddToArray(haste);
            newalchemistlevels2.MemorizeSpells = spell_list5;
            goblinalchemistCR7feature.ReplaceComponent(alchemistlevels2, newalchemistlevels2);

            var alchemistlevels4 = goblinalchemistCR7feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels4 = alchemistlevels4.CreateCopy();
            var spell_list = newalchemistlevels4.SelectSpells.AddToArray(haste);
            newalchemistlevels4.SelectSpells = spell_list;
            goblinalchemistCR7feature.ReplaceComponent(alchemistlevels4, newalchemistlevels4);


            var alchemistlevels3 = GoblinAlchemistSpellListLevel7.ComponentsArray
            .OfType<LearnSpells>()
            .First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels3 = alchemistlevels3.CreateCopy();
            var spell_list6 = newalchemistlevels3.Spells.AddToArray(displacement, haste);
            newalchemistlevels3.Spells = spell_list6;
            GoblinAlchemistSpellListLevel7.ReplaceComponent(alchemistlevels3, newalchemistlevels3);



            goblinalchemistCR7.AddFacts = goblinalchemistCR7.AddFacts.AddToArray(fastbombbuff, quicken);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);


            var brain = goblinalchemistCR7.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistExplosiveBombAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistBombAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castshieldgoblin, AiActions.castreducepersongoblin, AiActions.throwblindbombgoblin,
                AiActions.throwexplosivebombgoblin, AiActions.castdisplacementgoblin, AiActions.casthastegoblin);


        }

        static void fixGoblinAlchemistCR7()
        {

            var goblinalchemistCR7 = library.Get<BlueprintUnit>("7ae7e5868e33fa84084a15c8a94193a2");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var precisebomb = library.Get<BlueprintFeature>("5c396342f614dd644a48c3af08d79701");
            var fastbomb = library.Get<BlueprintFeature>("128c5fccec5ca724281a4907b1f0ac83");
            var fastbombbuff = library.Get<BlueprintBuff>("c42ae8f9652bbc14eb13b31d12d20f8a");
            var blindbomb = library.Get<BlueprintFeature>("c3da68b2222768b4f9352fefd29ad15c");
            var AlchemistExplosiveBombAiAction = library.Get<BlueprintAiCastSpell>("b1e2b5351065e5042b12b1b4b9a7665e");
            var AlchemistBombAiAction = library.Get<BlueprintAiCastSpell>("da693ef36da820a4c938bb13a5ded163");

            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var GoblinAlchemistSpellListLevel7 = library.Get<BlueprintFeature>("23c87a062d96cd84abca665241de933c");
            var ReducepersonselfAiAction = library.Get<BlueprintAiCastSpell>("a8a89f28eeb5c5147b31c960bf518011");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            



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

            var alchemistlevels2 = goblinalchemistCR7feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels2 = alchemistlevels2.CreateCopy();
            var spell_list5 = newalchemistlevels2.MemorizeSpells.AddToArray(haste);
            newalchemistlevels2.MemorizeSpells = spell_list5;
            goblinalchemistCR7feature.ReplaceComponent(alchemistlevels2, newalchemistlevels2);

            var alchemistlevels4 = goblinalchemistCR7feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels4 = alchemistlevels4.CreateCopy();
            var spell_list = newalchemistlevels4.SelectSpells.AddToArray( haste);
            newalchemistlevels4.SelectSpells = spell_list;
            goblinalchemistCR7feature.ReplaceComponent(alchemistlevels4, newalchemistlevels4);


            var alchemistlevels3 = GoblinAlchemistSpellListLevel7.ComponentsArray
            .OfType<LearnSpells>()
            .First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels3 = alchemistlevels3.CreateCopy();
            var spell_list6 = newalchemistlevels3.Spells.AddToArray(displacement,  haste);
            newalchemistlevels3.Spells = spell_list6;
            GoblinAlchemistSpellListLevel7.ReplaceComponent(alchemistlevels3, newalchemistlevels3);



            goblinalchemistCR7.AddFacts = goblinalchemistCR7.AddFacts.AddToArray(fastbombbuff,quicken);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);


            var brain = goblinalchemistCR7.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistExplosiveBombAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistBombAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castshieldgoblin,AiActions.castreducepersongoblin,AiActions.throwblindbombgoblin,
                AiActions.throwexplosivebombgoblin,AiActions.castdisplacementgoblin,AiActions.casthastegoblin);


        }

        static void fixGoblinAlchemistCR6()
        {

            var goblinalchemistCR6 = library.Get<BlueprintUnit>("a361c9772f1175b479c0e2b27afec373");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var precisebomb = library.Get<BlueprintFeature>("5c396342f614dd644a48c3af08d79701");
            var fastbomb = library.Get<BlueprintFeature>("128c5fccec5ca724281a4907b1f0ac83");
            var fastbombbuff = library.Get<BlueprintBuff>("c42ae8f9652bbc14eb13b31d12d20f8a");
            var blindbomb = library.Get<BlueprintFeature>("c3da68b2222768b4f9352fefd29ad15c");
            var AlchemistExplosiveBombAiAction = library.Get<BlueprintAiCastSpell>("b1e2b5351065e5042b12b1b4b9a7665e");
            var AlchemistBombAiAction = library.Get<BlueprintAiCastSpell>("da693ef36da820a4c938bb13a5ded163");

            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var GoblinAlchemistSpellListLevel7 = library.Get<BlueprintFeature>("ca9c54f183310834fb5c348ce926ed20");
            var ReducepersonselfAiAction = library.Get<BlueprintAiCastSpell>("a8a89f28eeb5c5147b31c960bf518011");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");




            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinalchemistCR6.AddFacts[0], "goblinalchemistCR6feature", "06ac76503ab24e7a8ae8193157252e32");
            goblinalchemistCR6.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var goblinalchemistCR6feature = library.Get<BlueprintFeature>("06ac76503ab24e7a8ae8193157252e32");



            var alchemistLevels = goblinalchemistCR6feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(precisebomb, fastbomb, blindbomb);

            }
            goblinalchemistCR6feature.ReplaceComponent(alchemistLevels, newAddClassLevels);

            var alchemistlevels2 = goblinalchemistCR6feature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels2 = alchemistlevels2.CreateCopy();
            var spell_list5 = newalchemistlevels2.MemorizeSpells.AddToArray(displacement,haste);
            newalchemistlevels2.MemorizeSpells = spell_list5;
            goblinalchemistCR6feature.ReplaceComponent(alchemistlevels2, newalchemistlevels2);

            var alchemistlevels4 = goblinalchemistCR6feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels4 = alchemistlevels4.CreateCopy();
            var spell_list = newalchemistlevels4.SelectSpells.AddToArray(displacement,haste);
            newalchemistlevels4.SelectSpells = spell_list;
            goblinalchemistCR6feature.ReplaceComponent(alchemistlevels4, newalchemistlevels4);


            var alchemistlevels3 = GoblinAlchemistSpellListLevel7.ComponentsArray
            .OfType<LearnSpells>()
            .First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels3 = alchemistlevels3.CreateCopy();
            var spell_list6 = newalchemistlevels3.Spells.AddToArray(displacement, haste);
            newalchemistlevels3.Spells = spell_list6;
            GoblinAlchemistSpellListLevel7.ReplaceComponent(alchemistlevels3, newalchemistlevels3);



            goblinalchemistCR6.AddFacts = goblinalchemistCR6.AddFacts.AddToArray(fastbombbuff, quicken);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);


            var brain = goblinalchemistCR6.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistExplosiveBombAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistBombAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castshieldgoblin, AiActions.castreducepersongoblin, AiActions.throwblindbombgoblin,
                AiActions.throwexplosivebombgoblin, AiActions.castdisplacementgoblin, AiActions.casthastegoblin);


        }

        static void fixGoblinAlchemistCR5()
        {

            var goblinalchemistCR5 = library.Get<BlueprintUnit>("bea48b5a19b2c344ba85c3e6224b7c78");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var precisebomb = library.Get<BlueprintFeature>("5c396342f614dd644a48c3af08d79701");
            var fastbomb = library.Get<BlueprintFeature>("128c5fccec5ca724281a4907b1f0ac83");
            var fastbombbuff = library.Get<BlueprintBuff>("c42ae8f9652bbc14eb13b31d12d20f8a");
            var blindbomb = library.Get<BlueprintFeature>("c3da68b2222768b4f9352fefd29ad15c");
            var AlchemistExplosiveBombAiAction = library.Get<BlueprintAiCastSpell>("b1e2b5351065e5042b12b1b4b9a7665e");
            var AlchemistBombAiAction = library.Get<BlueprintAiCastSpell>("da693ef36da820a4c938bb13a5ded163");

            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var GoblinAlchemistSpellListLevel7 = library.Get<BlueprintFeature>("23c87a062d96cd84abca665241de933c");
            var ReducepersonselfAiAction = library.Get<BlueprintAiCastSpell>("a8a89f28eeb5c5147b31c960bf518011");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");





            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinalchemistCR5.AddFacts[0], "goblinalchemistCR5feature", "b07656d827d94070bc7f899d105bf80a");
            goblinalchemistCR5.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var goblinalchemistCR5feature = library.Get<BlueprintFeature>("b07656d827d94070bc7f899d105bf80a");



            var alchemistLevels = goblinalchemistCR5feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(precisebomb, fastbomb);

            }
            goblinalchemistCR5feature.ReplaceComponent(alchemistLevels, newAddClassLevels);

            var alchemistlevels2 = goblinalchemistCR5feature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels2 = alchemistlevels2.CreateCopy();
            var spell_list5 = newalchemistlevels2.MemorizeSpells.AddToArray(displacement, haste);
            newalchemistlevels2.MemorizeSpells = spell_list5;
            goblinalchemistCR5feature.ReplaceComponent(alchemistlevels2, newalchemistlevels2);

            var alchemistlevels4 = goblinalchemistCR5feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newalchemistlevels4 = alchemistlevels4.CreateCopy();
            var spell_list = newalchemistlevels4.SelectSpells.AddToArray(displacement, haste);
            newalchemistlevels4.SelectSpells = spell_list;
            goblinalchemistCR5feature.ReplaceComponent(alchemistlevels4, newalchemistlevels4);






            goblinalchemistCR5.AddFacts = goblinalchemistCR5.AddFacts.AddToArray(fastbombbuff, quicken);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);


            var brain = goblinalchemistCR5.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistExplosiveBombAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistBombAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castshieldgoblin, AiActions.castreducepersongoblin, AiActions.throwblindbombgoblin,
                AiActions.throwexplosivebombgoblin, AiActions.castdisplacementgoblin, AiActions.casthastegoblin);





        }

        static void fixGoblinAlchemistCR4()
        {

            var goblinalchemistCR4 = library.Get<BlueprintUnit>("ee847b1e8f55c5f4b8eb23bbca23baa7");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var precisebomb = library.Get<BlueprintFeature>("5c396342f614dd644a48c3af08d79701");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var blindbomb = library.Get<BlueprintFeature>("c3da68b2222768b4f9352fefd29ad15c");
            var AlchemistExplosiveBombAiAction = library.Get<BlueprintAiCastSpell>("b1e2b5351065e5042b12b1b4b9a7665e");
            var AlchemistBombAiAction = library.Get<BlueprintAiCastSpell>("da693ef36da820a4c938bb13a5ded163");

            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var GoblinAlchemistSpellListLevel7 = library.Get<BlueprintFeature>("23c87a062d96cd84abca665241de933c");
            var ReducepersonselfAiAction = library.Get<BlueprintAiCastSpell>("a8a89f28eeb5c5147b31c960bf518011");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");






            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinalchemistCR4.AddFacts[0], "goblinalchemistCR4feature", "f7f4cb43cb6a4ed09315a98e4959b42c");
            goblinalchemistCR4.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var goblinalchemistCR4feature = library.Get<BlueprintFeature>("f7f4cb43cb6a4ed09315a98e4959b42c");



            var alchemistLevels = goblinalchemistCR4feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 6;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(precisebomb);

            }
            goblinalchemistCR4feature.ReplaceComponent(alchemistLevels, newAddClassLevels);



            goblinalchemistCR4.AddFacts = goblinalchemistCR4.AddFacts.AddToArray( quicken,blurbuff);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.shield);


            var brain = goblinalchemistCR4.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistExplosiveBombAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistBombAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castshieldgoblin, AiActions.castreducepersongoblin, 
                AiActions.throwexplosivebombgoblin);






        }

        static void fixGoblinAlchemistCR1()
        {

            var goblinalchemistCR1 = library.Get<BlueprintUnit>("710af85d0d25b4e448a776b7b501f685");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var precisebomb = library.Get<BlueprintFeature>("5c396342f614dd644a48c3af08d79701");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var blindbomb = library.Get<BlueprintFeature>("c3da68b2222768b4f9352fefd29ad15c");
            var AlchemistExplosiveBombAiAction = library.Get<BlueprintAiCastSpell>("b1e2b5351065e5042b12b1b4b9a7665e");
            var AlchemistBombAiAction = library.Get<BlueprintAiCastSpell>("da693ef36da820a4c938bb13a5ded163");

            var ReducepersonselfAiAction = library.Get<BlueprintAiCastSpell>("a8a89f28eeb5c5147b31c960bf518011");







            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)goblinalchemistCR1.AddFacts[0], "goblinalchemistCR1feature", "cd5a95e3d97c4405b8f53e6ddf84042e");
            goblinalchemistCR1.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var goblinalchemistCR1feature = library.Get<BlueprintFeature>("cd5a95e3d97c4405b8f53e6ddf84042e");



            var alchemistLevels = goblinalchemistCR1feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 4;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(precisebomb);

            }
            goblinalchemistCR1feature.ReplaceComponent(alchemistLevels, newAddClassLevels);

            goblinalchemistCR1.AddFacts = goblinalchemistCR1.AddFacts.AddToArray(blurbuff);




            var brain = goblinalchemistCR1.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistExplosiveBombAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(AlchemistBombAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castshieldgoblin, AiActions.castreducepersongoblin,
                AiActions.throwexplosivebombgoblin);








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

            goblinking.GetComponent<Experience>().CR = 12;


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
            var sprigganroguemelee = library.Get<BlueprintUnit>("c90e6e523ac6d0245bc1871d4426c7d3");
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
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");





            var barbarianLevels = sprigganbarboss.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = barbarianLevels.CreateCopy();
            newAddClassLevels.Levels = 13;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(cornugon);

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
            var weaponfinesse = library.Get<BlueprintFeature>("90e54424d682d104ab36436bd527af09");
            var finessedagger = library.Get<BlueprintFeature>("50c7baae70624e24089d32d090e9cdb6");
            var finesseselection = library.Get<BlueprintFeatureSelection>("b78d146cea711a84598f0acef69462ea");
            

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



                VordakaiWillasGundarson.AddFacts = VordakaiWillasGundarson.AddFacts.AddToArray(oppurtunist,summonghosts,disarm, improvedevasion, disorientedability, dirtytrick, doubledebiliation, weaponfinesse, finesseselection, finessedagger);



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
            var weaponfinesse = library.Get<BlueprintFeature>("90e54424d682d104ab36436bd527af09");
            var finessedagger = library.Get<BlueprintFeature>("50c7baae70624e24089d32d090e9cdb6");



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
                foreach (var selection in newAddClassLevels2.Selections)
                {
                    selection.Features = selection.Features.AddToArray(weaponfinesse, finessedagger);

                }
                standardspectre.ReplaceComponent(undeadLevels, newAddClassLevels2);



                standardspectre.AddFacts = standardspectre.AddFacts.AddToArray(disarm, improvedevasion,  dirtytrick);



                standardspectre.Body.DisableHands = false;

                standardspectre.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"); //dagger +1



                var brain = standardspectre.Brain;
                brain.Actions = brain.Actions.AddToArray(AiActions.usedisarmspectre, AiActions.usedirtytrickblind);


            }
        }


        //Bandits in Hollow Eyes

        static void changeholloweyearchers()
        {
            var holloweyearchers = library.Get<BlueprintUnit>("e19ab93e73984e0e9e65d7b06d766e5b");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
           


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)holloweyearchers.AddFacts[0], "holloweyearchersFeature", "096e65ce3eb34c07bd1a969f66b3a929");
            holloweyearchers.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

      

            var holloweyearchersfeature = library.Get<BlueprintFeature>("096e65ce3eb34c07bd1a969f66b3a929");



            var fighterLevels = holloweyearchersfeature.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            holloweyearchersfeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            holloweyearchers.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2753a0159681be94da3a5eeabc8c8d1a");

            holloweyearchers.GetComponent<Experience>().CR = 6;

   


        }

        static void changeholloweyerogues()
        {
            var holloweyerogue = library.Get<BlueprintUnit>("a305c49dc73fe9d419003d5469b50f93");
            var rogueClass = library.Get<BlueprintCharacterClass>("299aa766dee3cbf4790da4efb8c72484");
            var oppurtunist = library.Get<BlueprintFeature>("5bb6dc5ce00550441880a6ff8ad4c968");
            var dirtytrick = library.Get<BlueprintFeature>("ed699d64870044b43bb5a7fbe3f29494");

            holloweyerogue.AddFacts = holloweyerogue.AddFacts.AddToArray(oppurtunist, dirtytrick);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)holloweyerogue.AddFacts[0], "holloweyerogueFeature", "bca30168face4334ade2224a2229c360");
            holloweyerogue.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var holloweyeroguefeature = library.Get<BlueprintFeature>("bca30168face4334ade2224a2229c360");



            var fighterLevels = holloweyeroguefeature.ComponentsArray
             .OfType<AddClassLevels>()
               .First(c => c.CharacterClass == rogueClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 10;
            holloweyeroguefeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            holloweyerogue.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"); //Dagger +1

            holloweyerogue.Body.SecondaryHand = library.Get<BlueprintItemWeapon>("2a45458f776442e43bba57de65f9b738"); //Dagger +1



            var brain = holloweyerogue.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedirtytrickblind);



        }

        static void changeholloweyealchemist()
        {

            var holloweyealchemist = library.Get<BlueprintUnit>("ca2c980779cb93742aee2cc991556847");
            var alchemistClass = library.Get<BlueprintCharacterClass>("0937bec61c0dabc468428f496580c721");
            var BanditAlchemistFeatureListLevel5 = library.Get<BlueprintFeature>("acc08519fae83e345862495a86b12fc6");
            var ExplosiveBombsFeature = library.Get<BlueprintFeature>("1d0e812131f345742adca6431d5bc4fe");
            var ExplosiveBombsBuff = library.Get<BlueprintBuff>("63063a8ab91bcbc44a13294227580e84");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var heroism = library.Get<BlueprintAbility>("5ab0d42fb68c9e34abae4921822b9d63");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var fastbomb = library.Get<BlueprintFeature>("128c5fccec5ca724281a4907b1f0ac83");
            var fastbombbuff = library.Get<BlueprintBuff>("c42ae8f9652bbc14eb13b31d12d20f8a");
            var chokebomb = library.Get<BlueprintAbility>("0fcbed386deb18b428825605796d5a15");
            var Cogintell = library.Get<BlueprintAbility>("14230cf35ac2b5b45a93b13cfe478585");
            var Cogintellbuff = library.Get<BlueprintBuff>("20e740104092b5e49bfb167f1670a9de");
            var InvisibilityGreater = library.Get<BlueprintAbility>("ecaa0def35b38f949bd1976a6c9539e0");
            var extrabomb = library.Get<BlueprintFeature>("54c57ce67fa1d9044b1b3edc459e05e2");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");


            holloweyealchemist.AddFacts = holloweyealchemist.AddFacts.AddToArray(ExplosiveBombsFeature, fastbombbuff, chokebomb, Cogintell, Cogintellbuff, quicken);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)holloweyealchemist.AddFacts[0], "holloweyealchemistFeatureNew", "556968505e854520913b88b8a2e3293c");
            holloweyealchemist.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BanditAlchemistFeatureListLevel5.GetComponent<AddFacts>().Facts[0], "holloweyealchemistSpellListNew", "fa0049cdc22c4c8ea7922fba28dd4147");
            BanditAlchemistFeatureListLevel5.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var holloweyealchemistFeatureNew = library.Get<BlueprintFeature>("556968505e854520913b88b8a2e3293c");
            var holloweyealchemistSpellsNew = library.Get<BlueprintFeature>("fa0049cdc22c4c8ea7922fba28dd4147");



            var alchemistLevels = holloweyealchemistFeatureNew.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 9;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(haste);
            newAddClassLevels.MemorizeSpells = spell_list;
            holloweyealchemistFeatureNew.ReplaceComponent(alchemistLevels, newAddClassLevels);



            var AlchemistLevels2 = holloweyealchemistSpellsNew.ComponentsArray
        .OfType<LearnSpells>()
          .First(c => c.CharacterClass == alchemistClass);
            var newbardLevels2 = AlchemistLevels2.CreateCopy();
            var spell_list2 = newbardLevels2.Spells.AddToArray(haste);
            newbardLevels2.Spells = spell_list2;
            holloweyealchemistSpellsNew.ReplaceComponent(AlchemistLevels2, newbardLevels2);

            var alchemistLevels5 = holloweyealchemistFeatureNew.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == alchemistClass);
            var newAddClassLevels5 = alchemistLevels5.CreateCopy();
            var spell_list5 = newAddClassLevels5.SelectSpells.AddToArray(haste, InvisibilityGreater);
            newAddClassLevels5.SelectSpells = spell_list5;
            holloweyealchemistFeatureNew.ReplaceComponent(alchemistLevels5, newAddClassLevels5);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);

            holloweyealchemist.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("f5528acb89757ab4fb9350f45cc4f3b4"); //Lightcrossbow +1




            var brain = holloweyealchemist.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.casthaste, AiActions.castdisplacementgoblin, AiActions.throwchokebomb);


        }

        static void updateholloweyeFighterA()
        {

            var holloweyeFighterA = library.Get<BlueprintUnit>("dc6e7077127a4326aa7d63cd04523161");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var sunder = library.Get<BlueprintFeature>("9719015edcbf142409592e2cbaab7fe1");
            var armortraining = library.Get<BlueprintFeature>("3c380607706f209499d951b29d3c44f3");
            var combatexpertise = library.Get<BlueprintFeature>("4c44724ffa8844f4d9bedb5bb27d144a");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");



            holloweyeFighterA.Strength = 20;
            holloweyeFighterA.Dexterity = 16;

            holloweyeFighterA.AddFacts = holloweyeFighterA.AddFacts.AddToArray(sunder,armortraining,combatexpertise);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)holloweyeFighterA.AddFacts[0], "holloweyeFighterA", "bf39e88f2091476fb05d66bd1f881ea9");
            holloweyeFighterA.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var holloweyeFighterAFeatureNew = library.Get<BlueprintFeature>("bf39e88f2091476fb05d66bd1f881ea9");



            var alchemistLevels = holloweyeFighterAFeatureNew.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            holloweyeFighterAFeatureNew.ReplaceComponent(alchemistLevels, newAddClassLevels);

            holloweyeFighterA.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("03d706655c07d804cb9d5a5583f9aec5"); //longsword +1

            holloweyeFighterA.Body.Armor = library.Get<BlueprintItemArmor>("ed6bbd7ecd050c04690fe11d4c3b3f7d"); // Half plate

            holloweyeFighterA.Body.SecondaryHand = library.Get<BlueprintItemShield>("5c7b898a1bfb6cb4f8c14a0ebc143abe"); // Heavy Shield +1



            var brain = holloweyeFighterA.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.usesunderarmorzombiebarb,AiActions.cleave);


        }

        static void updateholloweyeFighterB()
        {

            var holloweyeFighterA = library.Get<BlueprintUnit>("19e9d35272a947be8a0e2a3ac648d033");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var sunder = library.Get<BlueprintFeature>("9719015edcbf142409592e2cbaab7fe1");
            var armortraining = library.Get<BlueprintFeature>("3c380607706f209499d951b29d3c44f3");
            var combatexpertise = library.Get<BlueprintFeature>("4c44724ffa8844f4d9bedb5bb27d144a");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            holloweyeFighterA.Strength = 20;
            holloweyeFighterA.Dexterity = 16;

            holloweyeFighterA.AddFacts = holloweyeFighterA.AddFacts.AddToArray(sunder,armortraining,combatexpertise);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)holloweyeFighterA.AddFacts[0], "holloweyeFighterB", "faa717e18bdd40afa3d6ee5b104a989e");
            holloweyeFighterA.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();


            var holloweyeFighterAFeatureNew = library.Get<BlueprintFeature>("faa717e18bdd40afa3d6ee5b104a989e");



            var alchemistLevels = holloweyeFighterAFeatureNew.ComponentsArray
             .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = alchemistLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            holloweyeFighterAFeatureNew.ReplaceComponent(alchemistLevels, newAddClassLevels);

            holloweyeFighterA.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("03d706655c07d804cb9d5a5583f9aec5"); //longsword +1

            holloweyeFighterA.Body.Armor = library.Get<BlueprintItemArmor>("ed6bbd7ecd050c04690fe11d4c3b3f7d"); // Half plate

            holloweyeFighterA.Body.SecondaryHand = library.Get<BlueprintItemShield>("5c7b898a1bfb6cb4f8c14a0ebc143abe"); // Heavy Shield +1



            var brain = holloweyeFighterA.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.usesunderarmorzombiebarb, AiActions.cleave);


        }

        static void updateholloweyeBrawler()
        {

            var holloweyeBrawler = library.Get<BlueprintUnit>("5099b31194dc484d8c2774ab949f4875");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var lesseratavismtotem = library.Get<BlueprintFeature>("ecbb5b8b2c354ee89949f8f163982ef7");
            var lesseratavismtotembuff = library.Get<BlueprintBuff>("3858dd3e9a94f0b41abdc58387d68ccf");
            var InspireFerocityFeature = library.Get<BlueprintFeature>("32c4d277007aed74c905779cd04a6fed");
            var InspireFerocityBuff = library.Get<BlueprintBuff>("9ec69854596674a4ba40802e6337894d");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var greatcleavefeat = library.Get<BlueprintFeature>("cc9c862ef2e03af4f89be5088851ea35");
            var cleavefeat = library.Get<BlueprintFeature>("d809b6c4ff2aaff4fa70d712a70f7d7b");

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)holloweyeBrawler.AddFacts[0], "holloweyeBrawlerfeature", "578793477cfc4e3db7a76a635f9932df");
            holloweyeBrawler.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var holloweyeBrawlerfeature = library.Get<BlueprintFeature>("578793477cfc4e3db7a76a635f9932df");



            holloweyeBrawler.AddFacts = holloweyeBrawler.AddFacts.AddToArray(lesseratavismtotembuff, InspireFerocityBuff,cornugon);



            var fighterLevels = holloweyeBrawlerfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(lesseratavismtotem, InspireFerocityFeature);

            }
            holloweyeBrawlerfeature.ReplaceComponent(fighterLevels, newAddClassLevels);


            holloweyeBrawler.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("e4925df9c7ab2714793cd5834e0a3039"); //greatsword +1


            var brain = holloweyeBrawler.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);


       


        }

        static void updateholloweyeBard()
        {

            var holloweyeBard = library.Get<BlueprintUnit>("3f2672c1a9877244cab3caf16e221507");
            var bardClass = library.Get<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var shout = library.Get<BlueprintAbility>("f09453607e683784c8fca646eec49162");
            var holloweyeBardfeaturelist = library.Get<BlueprintFeature>("2b77a7aef84c68c478ddc69fa1d2c30d");
            var hideouslaughterai = library.Get<BlueprintAiCastSpell>("8b944da00906b6f4f9b1d73c80e46b8c");
            var slowai = library.Get<BlueprintAiCastSpell>("d67858e438dd8834f9e61a1cb1c592a6");


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)holloweyeBard.AddFacts[0], "holloweyeBardfeaturenewlist", "698f6f4058724d26a95bda80b989e0f4");
            holloweyeBard.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
               .Select(c => c.CreateCopy())
               .ToArray();

            var clone2 = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)holloweyeBardfeaturelist.GetComponent<AddFacts>().Facts[0], "holloweyeBardSpellListNew", "35f35b6a763548b09942edfdd6f5d6a5");
            holloweyeBardfeaturelist.GetComponent<AddFacts>().Facts[0] = clone2;
            clone2.ComponentsArray = clone2.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();

            var holloweyeBardfeaturenewlist = library.Get<BlueprintFeature>("698f6f4058724d26a95bda80b989e0f4");
            var holloweyeBardSpellListNew = library.Get<BlueprintFeature>("35f35b6a763548b09942edfdd6f5d6a5");

            var bardLevels = holloweyeBardfeaturenewlist.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == bardClass);
            var newAddClassLevels = bardLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(mirrorimage, shout, displacement);
            newAddClassLevels.SelectSpells = spell_list;
            holloweyeBardfeaturenewlist.ReplaceComponent(bardLevels, newAddClassLevels);

            var bardLevels2 = holloweyeBardSpellListNew.ComponentsArray
            .OfType<LearnSpells>()
            .First(c => c.CharacterClass == bardClass);
            var newbardLevels2 = bardLevels2.CreateCopy();
            var spell_list2 = newbardLevels2.Spells.AddToArray(mirrorimage, shout, displacement);
            newbardLevels2.Spells = spell_list2;
            holloweyeBardSpellListNew.ReplaceComponent(bardLevels, newAddClassLevels);



            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);

            holloweyeBard.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("f5528acb89757ab4fb9350f45cc4f3b4"); //Lightcrossbow +1




            holloweyeBard.AddFacts = holloweyeBard.AddFacts.AddToArray(quicken);


            var brain = holloweyeBard.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(hideouslaughterai);
            brain.Actions = brain.Actions.RemoveFromArray(slowai);
            brain.Actions = brain.Actions.AddToArray(AiActions.mirrorimage, AiActions.displacement_first, AiActions.castshout, AiActions.casthaste, AiActions.hideouslaughternixie,AiActions.castslow);

        }




        //Barbarian Camp

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

        static void updateBolga()

        {

            var bolga = library.Get<BlueprintUnit>("b18515bcc73857b4fa083562665ede66");
            var druidclass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            var barbarianclass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var barkskinbuff5 = library.Get<BlueprintBuff>("063773c63d55dd94a94f9ffe3e710f95");
            var greatermagicfang = library.Get<BlueprintAbility>("f1100650705a69c4384d3edd88ba0f52");
            var naturalspell = library.Get<BlueprintFeature>("c806103e27cce6f429e5bf47067966cf");
            var thornbody = library.Get<BlueprintAbility>("2daf9c5112f16d54ab3cd6904c705c59");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var powerattackfeature = library.Get<BlueprintFeature>("9972f33f977fc724c838e59641b2fca5");
            var freedomofmovementbuff = library.Get<BlueprintBuff>("235533b62159790499ced35860636bb2");
            var freedomofmovement = library.Get<BlueprintAbility>("0087fc2d64b6095478bc7b8d7d512caf");
            var aspectofthewolf = library.Get<BlueprintAbility>("6126b36fe22291543ad72f8b9f0d53a7");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");


            bolga.AddFacts = bolga.AddFacts.AddToArray(barkskinbuff5,naturalspell,quicken,freedomofmovementbuff,combatcasting);
            bolga.AddFacts = bolga.AddFacts.RemoveFromArray(powerattackfeature);

            bolga.Strength = 18;
            bolga.Dexterity = 15;
            bolga.Constitution = 16;
            bolga.Wisdom = 16;
            bolga.Charisma = 8;



            {

                var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)bolga.AddFacts[0], "BolgaFeature", "777b1345b16344899a0579fcc485944a");
                bolga.AddFacts[0] = clone;
                clone.ComponentsArray = clone.ComponentsArray
                    .Select(c => c.CreateCopy())
                    .ToArray();

                var BolgaFeature = library.Get<BlueprintFeature>("777b1345b16344899a0579fcc485944a");



                var druidLevels = BolgaFeature.ComponentsArray
                .OfType<AddClassLevels>()
                  .First(c => c.CharacterClass == barbarianclass);
                var newAddClassLevels = druidLevels.CreateCopy();
                newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
                newAddClassLevels.Levels = 12;
                BolgaFeature.ReplaceComponent(druidLevels, newAddClassLevels);

                var druidLevels2 = BolgaFeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == druidclass);
                var newAddClassLevels2 = druidLevels2.CreateCopy();
                var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(greatermagicfang,thornbody,aspectofthewolf,freedomofmovement);
                newAddClassLevels2.MemorizeSpells = spell_list;
                BolgaFeature.ReplaceComponent(druidLevels2, newAddClassLevels2);

                var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
                auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.thornbody);


                var brain = bolga.Brain;
                brain.Actions = brain.Actions.AddToArray(AiActions.usewildshapesmilidon,AiActions.castgreatermagicfang,AiActions.castthornbody,AiActions.castaspectwolf);
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

        static void updateBarbarianmeleeLevel7()

        {


            var BarbMeleeLevel7 = library.Get<BlueprintUnit>("d31740cc6179b6649b3397e6fc51e09a");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");
            var lesseratavismtotem = library.Get<BlueprintFeature>("ecbb5b8b2c354ee89949f8f163982ef7");
            var lesseratavismtotembuff = library.Get<BlueprintBuff>("3858dd3e9a94f0b41abdc58387d68ccf");
            var InspireFerocityFeature = library.Get<BlueprintFeature>("32c4d277007aed74c905779cd04a6fed");
            var InspireFerocityBuff = library.Get<BlueprintBuff>("9ec69854596674a4ba40802e6337894d");

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BarbMeleeLevel7.AddFacts[0], "BarbMeleeLevel7feature", "2819cf722b4347f7bc95e2e269a84b9f");
            BarbMeleeLevel7.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var BarbMeleeLevel7feature = library.Get<BlueprintFeature>("2819cf722b4347f7bc95e2e269a84b9f");



            BarbMeleeLevel7.AddFacts = BarbMeleeLevel7.AddFacts.AddToArray(lesseratavismtotembuff,InspireFerocityBuff);



            var fighterLevels = BarbMeleeLevel7feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 10;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(lesseratavismtotem,InspireFerocityFeature);

            }
            BarbMeleeLevel7feature.ReplaceComponent(fighterLevels, newAddClassLevels);


            BarbMeleeLevel7.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("e4925df9c7ab2714793cd5834e0a3039"); //compositelongbow +1


            var brain = BarbMeleeLevel7.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);


        }

        static void updateBarbfighter()

        {


            var Barbfighter = library.Get<BlueprintUnit>("ac331cf158eccf44889c257e03d9f079");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)Barbfighter.AddFacts[0], "Barbfighterfeature", "fe2f1a983a60494aa160518953f5932b");
            Barbfighter.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var Barbfighterfeature = library.Get<BlueprintFeature>("fe2f1a983a60494aa160518953f5932b");





            var fighterLevels = Barbfighterfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 10;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(cornugon);

            }
            Barbfighterfeature.ReplaceComponent(fighterLevels, newAddClassLevels);


            Barbfighter.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("03d706655c07d804cb9d5a5583f9aec5"); //Lonwsword +1



            var brain = Barbfighter.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.cleave);

        }

        static void updateBarbranger()

        {


            var Barbranger = library.Get<BlueprintUnit>("920803089e8ad754b8c8f09550cf37f8");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var manyshot = library.Get<BlueprintFeature>("adf54af2a681792489826f7fd1b62889");
            


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)Barbranger.AddFacts[0], "Barbrangerfeature", "883ede8be96c4cae8cbb89a0eaa1f17a");
            Barbranger.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var Barbrangerfeature = library.Get<BlueprintFeature>("883ede8be96c4cae8cbb89a0eaa1f17a");





            var fighterLevels = Barbrangerfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 10;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray(manyshot);

            }
            Barbrangerfeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            Barbranger.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2753a0159681be94da3a5eeabc8c8d1a"); //compositelongbow +1



            


        }

        static void updateDunswardTombSorcerer()

        {


            var DunswardSorcerer = library.Get<BlueprintUnit>("2d56a1dfd318bba4a880fa66edb0caa8");
            var wizardclass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var blindness = library.Get<BlueprintAbility>("46fd02ad56c35224c9c91c88cd457791");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var DunswardSpellList = library.Get<BlueprintFeature>("b712f3c37e6fcce4aa6024f293260753");
            var RivalBlindnessAI = library.Get<BlueprintAiCastSpell>("5ddad52f0ff6a6e4bb6c824ea62aa227");
            var fear = library.Get<BlueprintAbility>("d2aeac47450c76347aebbc02e4f463e0");
            var crushingdespair = library.Get<BlueprintAbility>("4baf4109145de4345861fe0f2209d903");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var summonelementallarge = library.Get<BlueprintAbility>("89404dd71edc1aa42962824b44156fe5");
            var flamearrowbuff = library.Get<BlueprintBuff>("0db933ed440346388c9f4ed034e7e4a0");
            var boneshaker = library.Get<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var icyprison = library.Get<BlueprintAbility>("65e8d23aef5e7784dbeb27b1fca40931");
            var StoneskinBuffCL11 = library.Get<BlueprintBuff>("6215b25fbc1a36748b5606ebc0092074");
            var overwhelminggrief = library.Get<BlueprintAbility>("dd2918e4a77c50044acba1ac93494c36");
            var shield = library.Get<BlueprintAbility>("ef768022b0785eb43a18969903c537c4");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var slow = library.Get<BlueprintAbility>("f492622e473d34747806bdb39356eb89");

            DunswardSorcerer.AddFacts = DunswardSorcerer.AddFacts.AddToArray(flamearrowbuff,quicken,StoneskinBuffCL11);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)DunswardSorcerer.AddFacts[0], "DunswardSorcererfeature", "5845838202804895831eb2dea5cc186c");
            DunswardSorcerer.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var DunswardSorcererfeature = library.Get<BlueprintFeature>("5845838202804895831eb2dea5cc186c");



            var wizardLevels = DunswardSorcererfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardclass);
            var newAddClassLevels = wizardLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            DunswardSorcererfeature.ReplaceComponent(wizardLevels, newAddClassLevels);

            var wizardLevels3 = DunswardSorcererfeature.ComponentsArray
    .OfType<AddClassLevels>()
    .First(c => c.CharacterClass == wizardclass);
            var newsorcererLevels = wizardLevels3.CreateCopy();
            var spell_list2 = newsorcererLevels.MemorizeSpells.RemoveFromArray(blindness);
            newsorcererLevels.MemorizeSpells = spell_list2;
            DunswardSorcererfeature.ReplaceComponent(wizardLevels3, newsorcererLevels);

            var wizardLevels4 = DunswardSorcererfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardclass);
            var newsorcererLevels3 = wizardLevels4.CreateCopy();
            var spell_list4 = newsorcererLevels.MemorizeSpells.RemoveFromArray(blindness);
            newsorcererLevels3.MemorizeSpells = spell_list4;
            DunswardSorcererfeature.ReplaceComponent(wizardLevels4, newsorcererLevels3);

            var wizardLevels5 = DunswardSorcererfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == wizardclass);
            var newsorcererLevels5 = wizardLevels5.CreateCopy();
            var spell_list5 = newsorcererLevels5.MemorizeSpells.AddToArray(displacement, crushingdespair, mirrorimage, summonelementallarge, 
                                                                           boneshaker,shield, boneshaker,icyprison,overwhelminggrief,overwhelminggrief,magicmissle,magicmissle,slow);
            newsorcererLevels5.MemorizeSpells = spell_list5;
            DunswardSorcererfeature.ReplaceComponent(wizardLevels5, newsorcererLevels5);

            var wizardLevels6 = DunswardSorcererfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == wizardclass);
            var newsorcererLevels6 = wizardLevels6.CreateCopy();
            var spell_list6 = newsorcererLevels6.MemorizeSpells.RemoveFromArray(blindness);
            newsorcererLevels6.MemorizeSpells = spell_list6;
            DunswardSorcererfeature.ReplaceComponent(wizardLevels6, newsorcererLevels6);

            var sorcererLevels2 = DunswardSpellList.ComponentsArray
                 .OfType<LearnSpells>()
                .First(c => c.CharacterClass == wizardclass);
            var newsorcererLevels2 = sorcererLevels2.CreateCopy();
            var spell_list3 = newsorcererLevels2.Spells.AddToArray(displacement,crushingdespair,mirrorimage,summonelementallarge,boneshaker,icyprison,overwhelminggrief,shield,magicmissle);
            newsorcererLevels2.Spells = spell_list3;
            DunswardSpellList.ReplaceComponent(sorcererLevels2, newsorcererLevels2);

            var sorcererLevels7 = DunswardSpellList.ComponentsArray
     .OfType<LearnSpells>()
    .First(c => c.CharacterClass == wizardclass);
            var newsorcererLevels7= sorcererLevels7.CreateCopy();
            var spell_list7 = newsorcererLevels2.Spells.RemoveFromArray(fear);
            newsorcererLevels7.Spells = spell_list7;
            DunswardSpellList.ReplaceComponent(sorcererLevels7, newsorcererLevels7);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);

            var brain = DunswardSorcerer.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(RivalBlindnessAI);
            brain.Actions = brain.Actions.AddToArray(AiActions.displacement_first,
                                    AiActions.castblindness,AiActions.castcrushingdespair,
                                    AiActions.summonelementallargeair, AiActions.castboneshaker,AiActions.casticyprison,AiActions.castoverwhelminggriefzombie,AiActions.castshieldsprig,AiActions.magicmissledelay);

        }

        static void updateDunswardTombCleric()

        {


            var DunswardCleric = library.Get<BlueprintUnit>("8039405a792372a469e5015d5a027890");
            var clericclass = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var boneshaker = library.Get<BlueprintAbility>("b7731c2b4fa1c9844a092329177be4c3");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var slayliving = library.Get<BlueprintAbility>("4fbd47525382517419c66fb548fe9a67");
            var bane = library.Get<BlueprintAbility>("8bc64d869456b004b9db255cdd1ea734");
            var HoldPersonAiAction = library.Get<BlueprintAiCastSpell>("093e88ae36b09d941aee8c1d4d628156");
            var divinepower = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var Resistenergycommunal = library.Get<BlueprintAbility>("7bb0c402f7f789d4d9fae8ca87b4c7e2");
            var dispel = library.Get<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
            var rayofsickening = library.Get<BlueprintAbility>("fa3078b9976a5b24caf92e20ee9c0f54");
            var profanenimbus = library.Get<BlueprintAbility>("b56521d58f996cd4299dab3f38d5fe31");
            

        DunswardCleric.AddFacts = DunswardCleric.AddFacts.AddToArray(quicken);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)DunswardCleric.AddFacts[0], "DunswardClericfeature", "d839f712aea842cf94131c52578c3e76");
            DunswardCleric.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var DunswardClericfeature = library.Get<BlueprintFeature>("d839f712aea842cf94131c52578c3e76");





            var clericLevels = DunswardClericfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericclass);
            var newAddClassLevels = clericLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            foreach (var selection in newAddClassLevels.Selections)
            {
                selection.Features = selection.Features.AddToArray();

            }
            DunswardClericfeature.ReplaceComponent(clericLevels, newAddClassLevels);

            var wizardLevels3 = DunswardClericfeature.ComponentsArray
    .OfType<AddClassLevels>()
    .First(c => c.CharacterClass == clericclass);
            var newsorcererLevels = wizardLevels3.CreateCopy();
            var spell_list2 = newsorcererLevels.MemorizeSpells.RemoveFromArray(holdperson);
            newsorcererLevels.MemorizeSpells = spell_list2;
            DunswardClericfeature.ReplaceComponent(wizardLevels3, newsorcererLevels);

            var wizardLevels4 = DunswardClericfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericclass);
            var newsorcererLevels3 = wizardLevels4.CreateCopy();
            var spell_list4 = newsorcererLevels.MemorizeSpells.RemoveFromArray(holdperson);
            newsorcererLevels3.MemorizeSpells = spell_list4;
            DunswardClericfeature.ReplaceComponent(wizardLevels4, newsorcererLevels3);

            var wizardLevels5 = DunswardClericfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == clericclass);
            var newsorcererLevels5 = wizardLevels5.CreateCopy();
            var spell_list5 = newsorcererLevels5.MemorizeSpells.AddToArray(profanenimbus,boneshaker, boneshaker, slayliving, bane, divinepower,Resistenergycommunal,dispel,dispel,rayofsickening,rayofsickening);
            newsorcererLevels5.MemorizeSpells = spell_list5;
            DunswardClericfeature.ReplaceComponent(wizardLevels5, newsorcererLevels5);

            var wizardLevels6 = DunswardClericfeature.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == clericclass);
            var newsorcererLevels6 = wizardLevels6.CreateCopy();
            var spell_list6 = newsorcererLevels6.MemorizeSpells.RemoveFromArray(holdperson);
            newsorcererLevels6.MemorizeSpells = spell_list6;
            DunswardClericfeature.ReplaceComponent(wizardLevels6, newsorcererLevels6);





            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);

            var brain = DunswardCleric.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(HoldPersonAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castbane,AiActions.castslayliving,AiActions.divine_power_first,
                                                     AiActions.castresistfirecommunal,AiActions.castboneshaker,AiActions.dispel,AiActions.castrayofsickening,AiActions.holdpersonzombiecleric,AiActions.castprofanenimbus);

        }

        static void updateDunswardTombFighter()

        {


            var DunswardFighter = library.Get<BlueprintUnit>("71dfa48d43fdc414c857f710d59d2f6b");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var towershieldprof = library.Get<BlueprintFeature>("6105f450bb2acbd458d277e71e19d835");
            var towershieldspecial = library.Get<BlueprintArchetype>("a599da9a8a6b9e54083b0a4d2a25db59");
            var heavybladespecialization = library.Get<BlueprintFeature>("2a0ce0186af38ed419f47fce16f93c2a");
            var disarm = library.Get<BlueprintAbility>("45d94c6db453cfc4a9b99b72d6afe6f6");
            var disarmfeat = library.Get<BlueprintFeature>("63d8e3a9ab4d72e4081a7862d7246a79");
            var greatfortitude = library.Get<BlueprintFeature>("79042cb55f030614ea29956177977c52");
            var lightningreflexes = library.Get<BlueprintFeature>("15e7da6645a7f3d41bdad7c8c4b9de1e");

            DunswardFighter.AddFacts = DunswardFighter.AddFacts.AddToArray(disarm,greatfortitude,lightningreflexes);

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)DunswardFighter.AddFacts[0], "DunswardFighterfeature", "4e564e8342134eee89f370c1348bb333");
            DunswardFighter.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var DunswardFighterfeature = library.Get<BlueprintFeature>("4e564e8342134eee89f370c1348bb333");





            var fighterLevels = DunswardFighterfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            var archetype = newAddClassLevels.Archetypes.AddToArray(towershieldspecial);
            newAddClassLevels.Archetypes = archetype;
            DunswardFighterfeature.ReplaceComponent(fighterLevels, newAddClassLevels);

            var fighterLevels2 = DunswardFighterfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels2 = fighterLevels2.CreateCopy();
            foreach (var selection in newAddClassLevels2.Selections)
            {
                selection.Features = selection.Features.RemoveFromArray(heavybladespecialization);

            }
            DunswardFighterfeature.ReplaceComponent(fighterLevels2, newAddClassLevels2);




            var brain = DunswardFighter.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usedisarmspectre);

        }

        static void updateDunswardTombArcher()

        {


            var DunswardArcher = library.Get<BlueprintUnit>("e5a1c3cb916861742808477a5d4f5540");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var lightningreflexes = library.Get<BlueprintFeature>("15e7da6645a7f3d41bdad7c8c4b9de1e");
            var blindfight = library.Get<BlueprintFeature>("4e219f5894ad0ea4daa0699e28c37b1d");
            

            DunswardArcher.AddFacts = DunswardArcher.AddFacts.AddToArray(lightningreflexes,blindfight);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)DunswardArcher.AddFacts[0], "DunswardArcherFeature", "8703b0e0b6fb4fd79df59d48408ac616");
            DunswardArcher.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var DunswardArcherfeature = library.Get<BlueprintFeature>("8703b0e0b6fb4fd79df59d48408ac616");





            var fighterLevels = DunswardArcherfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            DunswardArcherfeature.ReplaceComponent(fighterLevels, newAddClassLevels);

          



        }

        static void updateDunswardTombBarbarian()

        {


            var DunswardBarbarian = library.Get<BlueprintUnit>("783c06fcb8ecb0840a6ba5a0ff241cb2");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var sunder = library.Get<BlueprintFeature>("9719015edcbf142409592e2cbaab7fe1");
            var animalfury = library.Get<BlueprintFeature>("25954b1652bebc2409f9cb9d5728bceb");
            

            DunswardBarbarian.AddFacts = DunswardBarbarian.AddFacts.AddToArray(sunder,animalfury);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)DunswardBarbarian.AddFacts[0], "DunswardBarbarianFeature", "dca50a766dde4c77bba36ff7bda568b3");
            DunswardBarbarian.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var DunswardBarbarianfeature = library.Get<BlueprintFeature>("dca50a766dde4c77bba36ff7bda568b3");





            var barbLevels = DunswardBarbarianfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = barbLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            DunswardBarbarianfeature.ReplaceComponent(barbLevels, newAddClassLevels);


            var brain = DunswardBarbarian.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usesunderarmorzombiebarb);


        }


        static void changeAstraDaemonstandard()
        {



            var standardastra = library.Get<BlueprintUnit>("5acac84098a14f543822310ecfd0bb4a");
            var outsiderclass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var vampireshield = library.Get<BlueprintAbility>("a34921035f2a6714e9be5ca76c5e34b5");
            var AstradaemonFingerOfDeathAiAction = library.Get<BlueprintAiCastSpell>("f1a614b3719a7b24782e631eefcc1654");
            var vampirictouchastral = library.Get<BlueprintAbility>("5db2468da97174048bfb0b3096d01fd6");

            var energydrain = library.Get<BlueprintAbility>("37302f72b06ced1408bf5bb965766d46");
            var fingerofdeath = library.Get<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var enervation = library.Get<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");



            
            standardastra.AddFacts = standardastra.AddFacts.RemoveFromArray(enervation);
            standardastra.AddFacts = standardastra.AddFacts.RemoveFromArray(energydrain);
            standardastra.AddFacts = standardastra.AddFacts.AddToArray(quicken, toughness, displacement);

            var outsiderLevels = standardastra.ComponentsArray
                       .OfType<AddClassLevels>()
                          .First(c => c.CharacterClass == outsiderclass);
            var newAddClassLevels = outsiderLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            newAddClassLevels.Levels = 17;
            standardastra.ReplaceComponent(outsiderLevels, newAddClassLevels);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);







            var brain = standardastra.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(AstradaemonFingerOfDeathAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai, AiActions.castfingerofdeathastraldaemonguard);


        }

        static void changeDaemonGuardian()
        {



            var daemonguardian = library.Get<BlueprintUnit>("bd685eb1e99dbb3478bcf3612a8044e0");
            var outsiderclass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var vampireshield = library.Get<BlueprintAbility>("a34921035f2a6714e9be5ca76c5e34b5");
            var AstradaemonFingerOfDeathAiAction = library.Get<BlueprintAiCastSpell>("f1a614b3719a7b24782e631eefcc1654");
            var vampirictouchastral = library.Get<BlueprintAbility>("5db2468da97174048bfb0b3096d01fd6");

            var energydrain = library.Get<BlueprintAbility>("37302f72b06ced1408bf5bb965766d46");
            var fingerofdeath = library.Get<BlueprintAbility>("6f1dcf6cfa92d1948a740195707c0dbe");
            var natarmor12 = library.Get<BlueprintUnitFact>("0b2d92c6aac8093489dfdadf1e448280");
            var natarmor14 = library.Get<BlueprintUnitFact>("209a2920891b580418b4e5e80466e134");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var enervation = library.Get<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var dr5 = library.Get<BlueprintFeature>("f4b3dfedcc150d249be42c0d12302b20");





            daemonguardian.MaxHP = 70;
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
            brain.Actions = brain.Actions.RemoveFromArray(AstradaemonFingerOfDeathAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai, AiActions.castfingerofdeathastraldaemonguard);


        }

        static void changeThanadaemon()
        {



            var thanadaemon = library.Get<BlueprintUnit>("bc6b0477fba49e54e84e2c7ba3cf2144");
            var outsiderclass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            var fear = library.Get<BlueprintAbility>("d2aeac47450c76347aebbc02e4f463e0");
            var enervation = library.Get<BlueprintAbility>("f34fb78eaaec141469079af124bcfa0f");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var wavesoffatigue = library.Get<BlueprintAbility>("8878d0c46dfbd564e9d5756349d5e439");
           





            thanadaemon.AddFacts = thanadaemon.AddFacts.RemoveFromArray(enervation);

            thanadaemon.AddFacts = thanadaemon.AddFacts.AddToArray(toughness,fear,wavesoffatigue);

            var outsiderLevels = thanadaemon.ComponentsArray
                       .OfType<AddClassLevels>()
                          .First(c => c.CharacterClass == outsiderclass);
            var newAddClassLevels = outsiderLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("92ab5f2fe00631b44810deffcc1a97fd");
            newAddClassLevels.Levels = 15;
            thanadaemon.ReplaceComponent(outsiderLevels, newAddClassLevels);


            var brain = thanadaemon.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castfearthanadaemon,AiActions.castwavesoffatigue);


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
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");


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


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);

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


        //Flintlock Grasslands

        static void updateCR6_VandalPositiveClericLevel7()
        {
            var cleric_gorumA = library.Get<BlueprintUnit>("154aa5706ea3d4b4092017e3c2e8484d");
            var cleric = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var cleric_gorum_feature = library.Get<BlueprintFeature>("ca063d3e6c8576642a23fe74f2379ee0");
            var divine_power = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var searing_light = library.Get<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
            var sm5 = library.Get<BlueprintAbility>("630c8b85d9f07a64f917d79cb5905741");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var heal = library.Get<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");
            var hellfireray = library.Get<BlueprintAbility>("700cfcbd0cb2975419bcab7dbb8c6210");
            var constrictingcoils = library.Get<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var divinefavor = library.Get<BlueprintAbility>("9d5d2d3ffdd73c648af3eb3e585b1113");
            var righteousmight = library.Get<BlueprintAbility>("90810e5cf53bf854293cbd5ea1066252");
            var freedomofmovementbuff = library.Get<BlueprintBuff>("235533b62159790499ced35860636bb2");
            var freedomofmovement = library.Get<BlueprintAbility>("0087fc2d64b6095478bc7b8d7d512caf");
            var dispel = library.Get<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
            var shieldoffaith = library.Get<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
            var ShieldOfFaithAiAction = library.Get<BlueprintAiAction>("8ce28d8e7507dd24ab0ae81aebea58cf");
               

            cleric_gorumA.AddFacts = cleric_gorumA.AddFacts.AddToArray(quicken,freedomofmovementbuff);



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)cleric_gorumA.AddFacts[0], "ClericGorumAFeature", "2b133738ab664db7b7263f8ec98c7936");
            cleric_gorumA.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var clericgorumAfeature = library.Get<BlueprintFeature>("2b133738ab664db7b7263f8ec98c7936");



            var clericLevels = clericgorumAfeature.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == cleric);
            var newclericLevels = clericLevels.CreateCopy();
            newclericLevels.Levels = 11;
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(searing_light,searing_light, heal, constrictingcoils,righteousmight,freedomofmovement,dispel,shieldoffaith);
            newclericLevels.MemorizeSpells = spell_list;
            clericgorumAfeature.ReplaceComponent(clericLevels, newclericLevels);

            var clericLevels2 = clericgorumAfeature.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == cleric);
            var newclericLevels2 = clericLevels2.CreateCopy();
            var spell_list2 = newclericLevels2.MemorizeSpells.RemoveFromArray(sm5);
            newclericLevels2.MemorizeSpells = spell_list2;
            clericgorumAfeature.ReplaceComponent(clericLevels2, newclericLevels2);

            var clericLevels3 = clericgorumAfeature.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == cleric);
            var newclericLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newclericLevels3.MemorizeSpells.RemoveFromArray(holdperson);
            newclericLevels3.MemorizeSpells = spell_list3;
            clericgorumAfeature.ReplaceComponent(clericLevels3, newclericLevels3);

            var clericLevels4 = clericgorumAfeature.ComponentsArray
                 .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == cleric);
            var newclericLevels4 = clericLevels4.CreateCopy();
            var spell_list4 = newclericLevels4.MemorizeSpells.RemoveFromArray(divinefavor);
            newclericLevels4.MemorizeSpells = spell_list4;
            clericgorumAfeature.ReplaceComponent(clericLevels4, newclericLevels4);



            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.prayer);

            var auto_metamgic3 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.shieldoffaith);

            var brain = cleric_gorumA.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(ShieldOfFaithAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castsearinglight, AiActions.healspell, AiActions.hellfire_ray,
                                                    AiActions.constrictingcoils, AiActions.castshieldoffaithgorum,AiActions.righteousmightgoblinshaman,AiActions.castfreedomofmovement,AiActions.dispel);






        }

        static void updateCR8_VandalPositiveClericLevel9()
        {
            var cleric_gorumB = library.Get<BlueprintUnit>("b25993ac3690be546b659c438b42a785");
            var cleric = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var cleric_gorum_feature = library.Get<BlueprintFeature>("ca063d3e6c8576642a23fe74f2379ee0");
            var divine_power = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var searing_light = library.Get<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
            var sm5 = library.Get<BlueprintAbility>("630c8b85d9f07a64f917d79cb5905741");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var heal = library.Get<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");
            var hellfireray = library.Get<BlueprintAbility>("700cfcbd0cb2975419bcab7dbb8c6210");
            var constrictingcoils = library.Get<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var divinefavor = library.Get<BlueprintAbility>("9d5d2d3ffdd73c648af3eb3e585b1113");
            var righteousmight = library.Get<BlueprintAbility>("90810e5cf53bf854293cbd5ea1066252");
            var freedomofmovementbuff = library.Get<BlueprintBuff>("235533b62159790499ced35860636bb2");
            var freedomofmovement = library.Get<BlueprintAbility>("0087fc2d64b6095478bc7b8d7d512caf");
            var dispel = library.Get<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
            var shieldoffaith = library.Get<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
            var ShieldOfFaithAiAction = library.Get<BlueprintAiAction>("8ce28d8e7507dd24ab0ae81aebea58cf");


            cleric_gorumB.AddFacts = cleric_gorumB.AddFacts.AddToArray(quicken, freedomofmovementbuff);



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)cleric_gorumB.AddFacts[0], "ClericGorumBFeature", "463a37450abe4405b9ae751d145082ad");
            cleric_gorumB.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var clericgorumBfeature = library.Get<BlueprintFeature>("463a37450abe4405b9ae751d145082ad");



            var clericLevels = clericgorumBfeature.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == cleric);
            var newclericLevels = clericLevels.CreateCopy();
            newclericLevels.Levels = 11;
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(searing_light, searing_light, heal, constrictingcoils, righteousmight, freedomofmovement, dispel, shieldoffaith);
            newclericLevels.MemorizeSpells = spell_list;
            clericgorumBfeature.ReplaceComponent(clericLevels, newclericLevels);

            var clericLevels2 = clericgorumBfeature.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == cleric);
            var newclericLevels2 = clericLevels2.CreateCopy();
            var spell_list2 = newclericLevels2.MemorizeSpells.RemoveFromArray(sm5);
            newclericLevels2.MemorizeSpells = spell_list2;
            clericgorumBfeature.ReplaceComponent(clericLevels2, newclericLevels2);

            var clericLevels3 = clericgorumBfeature.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == cleric);
            var newclericLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newclericLevels3.MemorizeSpells.RemoveFromArray(holdperson);
            newclericLevels3.MemorizeSpells = spell_list3;
            clericgorumBfeature.ReplaceComponent(clericLevels3, newclericLevels3);

            var clericLevels4 = clericgorumBfeature.ComponentsArray
                 .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == cleric);
            var newclericLevels4 = clericLevels4.CreateCopy();
            var spell_list4 = newclericLevels4.MemorizeSpells.RemoveFromArray(divinefavor);
            newclericLevels4.MemorizeSpells = spell_list4;
            clericgorumBfeature.ReplaceComponent(clericLevels4, newclericLevels4);



            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.prayer);

            var auto_metamgic3 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.shieldoffaith);

            var brain = cleric_gorumB.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(ShieldOfFaithAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castsearinglight, AiActions.healspell, AiActions.hellfire_ray,
                                                    AiActions.constrictingcoils, AiActions.castshieldoffaithgorum, AiActions.righteousmightgoblinshaman, AiActions.castfreedomofmovement, AiActions.dispel);






        }

        static void updateCR9_VandalDruidWildshapeLevel10()
        {
            var vandaldruidA = library.Get<BlueprintUnit>("8b9b82fbdffb4fe4ea957f445cfc1e4d");
            var druid = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var greatermagicfang = library.Get<BlueprintAbility>("f1100650705a69c4384d3edd88ba0f52");
            var naturalspell = library.Get<BlueprintFeature>("c806103e27cce6f429e5bf47067966cf");
            var thornbody = library.Get<BlueprintAbility>("2daf9c5112f16d54ab3cd6904c705c59");
            var freedomofmovementbuff = library.Get<BlueprintBuff>("235533b62159790499ced35860636bb2");
            var freedomofmovement = library.Get<BlueprintAbility>("0087fc2d64b6095478bc7b8d7d512caf");
            var aspectofthewolf = library.Get<BlueprintAbility>("6126b36fe22291543ad72f8b9f0d53a7");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var barkskin = library.Get<BlueprintAbility>("5b77d7cc65b8ab74688e74a37fc2f553");
            var WildShapeSmilodonAiAction = library.Get<BlueprintAiAction>("a31e93cec5f301d42a101b158e46876d");
            

            vandaldruidA.AddFacts = vandaldruidA.AddFacts.AddToArray(quicken,combatcasting);



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)vandaldruidA.AddFacts[0], "VandaldruidAFeature", "d89b9c37d6644dfabafb60733dbbc7fc");
            vandaldruidA.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var VandaldruidAFeature = library.Get<BlueprintFeature>("d89b9c37d6644dfabafb60733dbbc7fc");



            var clericLevels = VandaldruidAFeature.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == druid);
            var newclericLevels = clericLevels.CreateCopy();
            newclericLevels.Levels = 12;
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(barkskin,greatermagicfang,aspectofthewolf);
            newclericLevels.MemorizeSpells = spell_list;
            VandaldruidAFeature.ReplaceComponent(clericLevels, newclericLevels);





            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.greatermagicfang);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.thornbody);

            var auto_metamgic3 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.aspectofthewolf);

            var brain = vandaldruidA.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(WildShapeSmilodonAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.usewildshapesmilidon,AiActions.barkskingoblinking,AiActions.castgreatermagicfang,AiActions.castaspectwolf,AiActions.castanimalgrowth);






        }

        static void updateCR7_VandalDruidWildShapeLevel8()
        {
            var vandaldruidB = library.Get<BlueprintUnit>("af43a2e2633bcff4388709ff83650abb");
            var druid = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var greatermagicfang = library.Get<BlueprintAbility>("f1100650705a69c4384d3edd88ba0f52");
            var naturalspell = library.Get<BlueprintFeature>("c806103e27cce6f429e5bf47067966cf");
            var thornbody = library.Get<BlueprintAbility>("2daf9c5112f16d54ab3cd6904c705c59");
            var freedomofmovementbuff = library.Get<BlueprintBuff>("235533b62159790499ced35860636bb2");
            var freedomofmovement = library.Get<BlueprintAbility>("0087fc2d64b6095478bc7b8d7d512caf");
            var aspectofthewolf = library.Get<BlueprintAbility>("6126b36fe22291543ad72f8b9f0d53a7");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var barkskin = library.Get<BlueprintAbility>("5b77d7cc65b8ab74688e74a37fc2f553");
            var WildShapeBearAiAction = library.Get<BlueprintAiAction>("5fd42f54e7fdcb84abf554187fd8d1c9");
            var animalgrowth = library.Get<BlueprintAbility>("56923211d2ac95e43b8ac5031bab74d8");
            var StoneskinBuffCL10 = library.Get<BlueprintBuff>("2856d69a084eb964793c0fee69433833");


        vandaldruidB.AddFacts = vandaldruidB.AddFacts.AddToArray(quicken, combatcasting,StoneskinBuffCL10);



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)vandaldruidB.AddFacts[0], "VandaldruidBFeature", "2d250970562b45f1809e87d3602de802");
            vandaldruidB.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var VandaldruidBFeature = library.Get<BlueprintFeature>("2d250970562b45f1809e87d3602de802");



            var clericLevels = VandaldruidBFeature.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == druid);
            var newclericLevels = clericLevels.CreateCopy();
            newclericLevels.Levels = 12;
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(barkskin, greatermagicfang, aspectofthewolf,animalgrowth,thornbody);
            newclericLevels.MemorizeSpells = spell_list;
            VandaldruidBFeature.ReplaceComponent(clericLevels, newclericLevels);





            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.greatermagicfang);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.thornbody);

            var auto_metamgic3 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.aspectofthewolf);

            var brain = vandaldruidB.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(WildShapeBearAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.usewildshapesmilidon, AiActions.barkskingoblinking, AiActions.castgreatermagicfang, AiActions.castaspectwolf, AiActions.castanimalgrowth);






        }

        static void updateCR11_VandalMeleeBarbarianLevel12()

        {


            var BarbMeleeLevel12 = library.Get<BlueprintUnit>("859fb37f4c9361146af3dce3262ca975");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");

            var sunder = library.Get<BlueprintFeature>("9719015edcbf142409592e2cbaab7fe1");

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BarbMeleeLevel12.AddFacts[0], "VandalMeleeBarbarianLevel12feature", "5ef09f52fbc347909b340f299cac77d5");
            BarbMeleeLevel12.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var VandalMeleeBarbarianLevel12feature = library.Get<BlueprintFeature>("5ef09f52fbc347909b340f299cac77d5");



            BarbMeleeLevel12.AddFacts = BarbMeleeLevel12.AddFacts.AddToArray(sunder);



            var fighterLevels = VandalMeleeBarbarianLevel12feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 13;
            VandalMeleeBarbarianLevel12feature.ReplaceComponent(fighterLevels, newAddClassLevels);


            BarbMeleeLevel12.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("f93a7882fb01963428b091f259b15d3a"); //flachion +1
            BarbMeleeLevel12.Body.Armor = library.Get<BlueprintItemArmor>("c147f25768aa5094e8494013aea3786b"); //Scalemail +1



            var brain = BarbMeleeLevel12.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usesunderarmorzombiebarb);

        }

        static void updateCR9_VandalMeleeBarbarianLevel10()

        {


            var BarbMeleeLevel10 = library.Get<BlueprintUnit>("d87f6d8e32be88e4596e279662485573");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var sunder = library.Get<BlueprintFeature>("9719015edcbf142409592e2cbaab7fe1");

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BarbMeleeLevel10.AddFacts[0], "VandalMeleeBarbarianLevel10feature", "61cdb13f4b7e4c5191b0570da7bcff1f");
            BarbMeleeLevel10.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var VandalMeleeBarbarianLevel10feature = library.Get<BlueprintFeature>("61cdb13f4b7e4c5191b0570da7bcff1f");



            BarbMeleeLevel10.AddFacts = BarbMeleeLevel10.AddFacts.AddToArray(sunder);



            var fighterLevels = VandalMeleeBarbarianLevel10feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            VandalMeleeBarbarianLevel10feature.ReplaceComponent(fighterLevels, newAddClassLevels);


            BarbMeleeLevel10.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("f93a7882fb01963428b091f259b15d3a"); //flachion +1
            BarbMeleeLevel10.Body.Armor = library.Get<BlueprintItemArmor>("c147f25768aa5094e8494013aea3786b"); //Scalemail +1



            var brain = BarbMeleeLevel10.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.usesunderarmorzombiebarb);

        }

        static void updateCR8_VandalMeleeRangerLevel9()

        {


            var RangerMeleeLevel11 = library.Get<BlueprintUnit>("c3546e0c53dbb5c478f1e4225d7b2e62");
            var rangerClass = library.Get<BlueprintCharacterClass>("cda0615668a6df14eb36ba19ee881af6");
            var powerattackfeature = library.Get<BlueprintFeature>("9972f33f977fc724c838e59641b2fca5");
            var leadblades = library.Get<BlueprintAbility>("779179912e6c6fe458fa4cfb90d96e10");


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)RangerMeleeLevel11.AddFacts[0], "VandalMeleeRangerLevel11feature", "19aa786b39bb41c7b93127645817df08");
            RangerMeleeLevel11.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var VandalMeleeRangerLevel11feature = library.Get<BlueprintFeature>("19aa786b39bb41c7b93127645817df08");



            RangerMeleeLevel11.AddFacts = RangerMeleeLevel11.AddFacts.AddToArray(powerattackfeature);



            var rangerLevels = VandalMeleeRangerLevel11feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rangerClass);
            var newAddClassLevels = rangerLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(leadblades);
            newAddClassLevels.MemorizeSpells = spell_list;
            VandalMeleeRangerLevel11feature.ReplaceComponent(rangerLevels, newAddClassLevels);


            RangerMeleeLevel11.Body.SecondaryHand = library.Get<BlueprintItemWeapon>("2618c8c4e4be9bc48acdbcc7d92d6dc1"); //Handaxe +1
            RangerMeleeLevel11.Body.Armor = library.Get<BlueprintItemArmor>("c147f25768aa5094e8494013aea3786b"); //Scalemail +1

            

            var brain = RangerMeleeLevel11.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.leadblades,AiActions.usequarry);

        }

        static void updateCR6_VandalMeleeRangerLevel7()

        {


            var RangerMeleeLevel11 = library.Get<BlueprintUnit>("6bfa8b72207f2cb4abcca22246fc6b69");
            var rangerClass = library.Get<BlueprintCharacterClass>("cda0615668a6df14eb36ba19ee881af6");
            var powerattackfeature = library.Get<BlueprintFeature>("9972f33f977fc724c838e59641b2fca5");
            var leadblades = library.Get<BlueprintAbility>("779179912e6c6fe458fa4cfb90d96e10");
            var BarkskinFixedBuff3 = library.Get<BlueprintBuff>("c1e39ff0ba314eb4a839cab29f49c76f");
           

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)RangerMeleeLevel11.AddFacts[0], "VandalMeleeRangerLevel11Bfeature", "d43892c4a62141359f04d9b44df4a7a7");
            RangerMeleeLevel11.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var VandalMeleeRangerLevel11feature = library.Get<BlueprintFeature>("d43892c4a62141359f04d9b44df4a7a7");



            RangerMeleeLevel11.AddFacts = RangerMeleeLevel11.AddFacts.AddToArray(powerattackfeature,BarkskinFixedBuff3);



            var rangerLevels = VandalMeleeRangerLevel11feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == rangerClass);
            var newAddClassLevels = rangerLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            var spell_list = newAddClassLevels.MemorizeSpells.AddToArray(leadblades);
            newAddClassLevels.MemorizeSpells = spell_list;
            VandalMeleeRangerLevel11feature.ReplaceComponent(rangerLevels, newAddClassLevels);

            RangerMeleeLevel11.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2618c8c4e4be9bc48acdbcc7d92d6dc1"); //Handaxe +1
            RangerMeleeLevel11.Body.SecondaryHand = library.Get<BlueprintItemWeapon>("2618c8c4e4be9bc48acdbcc7d92d6dc1"); //Handaxe +1
            RangerMeleeLevel11.Body.Armor = library.Get<BlueprintItemArmor>("c147f25768aa5094e8494013aea3786b"); //Scalemail +1


        
            var brain = RangerMeleeLevel11.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.leadblades, AiActions.usequarry);

        }

        static void updateCR9_VandalRangedFighterLevel10()

        {


            var RangedFighter10 = library.Get<BlueprintUnit>("db361d3fafe544e47aaa2ae1f2089abd");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var blindfight = library.Get<BlueprintFeature>("4e219f5894ad0ea4daa0699e28c37b1d");


            RangedFighter10.AddFacts = RangedFighter10.AddFacts.AddToArray(blindfight);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)RangedFighter10.AddFacts[0], "RangedFighter10Feature", "52e0e29c166046e58150366970a37b11");
            RangedFighter10.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var RangedFighter10feature = library.Get<BlueprintFeature>("52e0e29c166046e58150366970a37b11");





            var fighterLevels = RangedFighter10feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            RangedFighter10feature.ReplaceComponent(fighterLevels, newAddClassLevels);





        }

        static void updateCR7_VandalRangedFighterLevel8()

        {


            var RangedFighter10 = library.Get<BlueprintUnit>("c60222073a5897640a1b80daefd38408");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var blindfight = library.Get<BlueprintFeature>("4e219f5894ad0ea4daa0699e28c37b1d");


            RangedFighter10.AddFacts = RangedFighter10.AddFacts.AddToArray(blindfight);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)RangedFighter10.AddFacts[0], "RangedFighter10BFeature", "5c26252a0c684ea293ec3bb257a3074f");
            RangedFighter10.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var RangedFighter10feature = library.Get<BlueprintFeature>("5c26252a0c684ea293ec3bb257a3074f");





            var fighterLevels = RangedFighter10feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            RangedFighter10feature.ReplaceComponent(fighterLevels, newAddClassLevels);

            RangedFighter10.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2753a0159681be94da3a5eeabc8c8d1a"); //Composite Longbow +1
            RangedFighter10.Body.Armor = library.Get<BlueprintItemArmor>("91bf657f26eb80f4ba05b0b8440b1e8c"); //Chainshirt +1



        }

        static void updateVandalRanged_BrevoyBad()

        {


            var Vandalranged = library.Get<BlueprintUnit>("39955d0e5dbd30c4bb09abea5d8171c7");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var blindfight = library.Get<BlueprintFeature>("4e219f5894ad0ea4daa0699e28c37b1d");


            Vandalranged.AddFacts = Vandalranged.AddFacts.AddToArray(blindfight);


            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)Vandalranged.AddFacts[0], "VandalRanged_BrevoyBadFeature", "8b271878e9f0446799488cff910a54f9");
            Vandalranged.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var RangedFighter10feature = library.Get<BlueprintFeature>("8b271878e9f0446799488cff910a54f9");





            var fighterLevels = RangedFighter10feature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            RangedFighter10feature.ReplaceComponent(fighterLevels, newAddClassLevels);

            Vandalranged.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("2753a0159681be94da3a5eeabc8c8d1a"); //Composite Longbow +1
            Vandalranged.Body.Armor = library.Get<BlueprintItemArmor>("91bf657f26eb80f4ba05b0b8440b1e8c"); //Chainshirt +1



        }

        static void updateCR7_VandalMeleeFighterGreataxeLevel8()

        {


            var BarbFighterGreataxe = library.Get<BlueprintUnit>("c2927ff234f17c542b2e971152c8e487");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BarbFighterGreataxe.AddFacts[0], "VandalMeleeBarbFighterGreataxefeature", "4e6ef5f48e144be58970dea2a8ba12c5");
            BarbFighterGreataxe.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var VandalMeleeBarbFighterGreataxefeature = library.Get<BlueprintFeature>("4e6ef5f48e144be58970dea2a8ba12c5");


            var fighterLevels = VandalMeleeBarbFighterGreataxefeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            VandalMeleeBarbFighterGreataxefeature.ReplaceComponent(fighterLevels, newAddClassLevels);


            BarbFighterGreataxe.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("4f0704c1d4d53cf419bd200bdfc12a0a"); //Greataxe +1
            BarbFighterGreataxe.Body.Armor = library.Get<BlueprintItemArmor>("c147f25768aa5094e8494013aea3786b"); //Scalemail +1



            var brain = BarbFighterGreataxe.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig);

        }

        static void updateCR6_VandalMeleeFighterGreataxeLevel7()

        {


            var BarbFighterGreataxe = library.Get<BlueprintUnit>("84cd7adf7adcdc542944a13e8aea7f6e");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BarbFighterGreataxe.AddFacts[0], "VandalMeleeBarbFighterGreataxefeatureB", "01241745bd944e339daff5284061a0a2");
            BarbFighterGreataxe.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var VandalMeleeBarbFighterGreataxefeature = library.Get<BlueprintFeature>("01241745bd944e339daff5284061a0a2");


            var fighterLevels = VandalMeleeBarbFighterGreataxefeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            VandalMeleeBarbFighterGreataxefeature.ReplaceComponent(fighterLevels, newAddClassLevels);


            BarbFighterGreataxe.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("4f0704c1d4d53cf419bd200bdfc12a0a"); //Greataxe +1
            BarbFighterGreataxe.Body.Armor = library.Get<BlueprintItemArmor>("c147f25768aa5094e8494013aea3786b"); //Scalemail +1



            var brain = BarbFighterGreataxe.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig);

        }

        static void updateCR6_VandalMeleeFighterGreatswordLevel7()

        {


            var BarbFighterGreatsword = library.Get<BlueprintUnit>("39e1ad15b9e5b6a4cbc8cc262d6916dd");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BarbFighterGreatsword.AddFacts[0], "VandalMeleeBarbFighterGreatswordfeature", "b4727147656546148394a4d1ee287adc");
            BarbFighterGreatsword.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var VandalMeleeBarbFighterGreatswordfeature = library.Get<BlueprintFeature>("b4727147656546148394a4d1ee287adc");


            var fighterLevels = VandalMeleeBarbFighterGreatswordfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            VandalMeleeBarbFighterGreatswordfeature.ReplaceComponent(fighterLevels, newAddClassLevels);


            BarbFighterGreatsword.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("e4925df9c7ab2714793cd5834e0a3039"); //Greatsword +1
            BarbFighterGreatsword.Body.Armor = library.Get<BlueprintItemArmor>("c147f25768aa5094e8494013aea3786b"); //Scalemail +1



            var brain = BarbFighterGreatsword.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig);

        }

        static void updateCR7_VandalMeleeFighterGreatswordLevel8()

        {


            var BarbFighterGreatsword = library.Get<BlueprintUnit>("927321971846e274c96fc8d7e43825dd");
            var fighterClass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)BarbFighterGreatsword.AddFacts[0], "VandalMeleeBarbFighterGreatswordfeatureB", "250e8a8390ac42e8a2976c207c8bf99e");
            BarbFighterGreatsword.AddFacts[0] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();



            var VandalMeleeBarbFighterGreatswordfeature = library.Get<BlueprintFeature>("250e8a8390ac42e8a2976c207c8bf99e");


            var fighterLevels = VandalMeleeBarbFighterGreatswordfeature.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == fighterClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            VandalMeleeBarbFighterGreatswordfeature.ReplaceComponent(fighterLevels, newAddClassLevels);


            BarbFighterGreatsword.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("e4925df9c7ab2714793cd5834e0a3039"); //Greatsword +1
            BarbFighterGreatsword.Body.Armor = library.Get<BlueprintItemArmor>("c147f25768aa5094e8494013aea3786b"); //Scalemail +1



            var brain = BarbFighterGreatsword.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig);

        }

        static void updateVandalHillGiant()

        {


            var VandalHillgiant = library.Get<BlueprintUnit>("160d73363fc35ad4189328bc8ea00c3e");
            var barbarianClass = library.Get<BlueprintCharacterClass>("f7d7eb166b3dd594fb330d085df41853");
            var Cornugon = library.Get<BlueprintFeature>("ceea53555d83f2547ae5fc47e0399e14");
            var GreatCleaveAiAction = library.Get<BlueprintAiCastSpell>("4f9cd89dbe6ee6f41b7db1320efe032c");

            VandalHillgiant.Skills.Diplomacy = 8;




            VandalHillgiant.AddFacts = VandalHillgiant.AddFacts.AddToArray(Cornugon);



            var fighterLevels = VandalHillgiant.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == barbarianClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 4;
            VandalHillgiant.ReplaceComponent(fighterLevels, newAddClassLevels);

            VandalHillgiant.Body.PrimaryHand = library.Get<BlueprintItemWeapon>("41fdf5c9cb2dc0748ae4d71b6b5310a4"); //Greatclub +1
            VandalHillgiant.Body.Armor = library.Get<BlueprintItemArmor>("45e86ae29df5f4b48a66da15fde62217"); //Hide Leather +1



            var brain = VandalHillgiant.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(GreatCleaveAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.cleavesprig);

        }

        static void updateVandalwolf_brevoybad()

        {


            var VandalWolf = library.Get<BlueprintUnit>("e997d56406f3d7548992b33df572660d");
            var animalClass = library.Get<BlueprintCharacterClass>("4cd1757a0eea7694ba5c933729a53920");
            var natarmor4 = library.Get<BlueprintUnitFact>("16fc201a83edcde4cbd64c291ebe0d07");
            var natarmor7 = library.Get<BlueprintUnitFact>("e73864391ccf0894997928443a29d755");
            var BiteDragon1d6 = library.Get<BlueprintItemWeapon>("f3ff6972c32f22e4ba4c85c3982a03cf");
            var bite3d6 = library.Get<BlueprintItemWeapon>("a63315767e2bfe841959644dbe6383dc");

 


            VandalWolf.AddFacts = VandalWolf.AddFacts.RemoveFromArray(natarmor4);
            VandalWolf.AddFacts = VandalWolf.AddFacts.AddToArray(natarmor7);



            var fighterLevels = VandalWolf.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == animalClass);
            var newAddClassLevels = fighterLevels.CreateCopy();
            newAddClassLevels.Levels = 10;
            VandalWolf.ReplaceComponent(fighterLevels, newAddClassLevels);

            VandalWolf.Body.AdditionalLimbs = VandalWolf.Body.AdditionalLimbs.RemoveFromArray(BiteDragon1d6);
            VandalWolf.Body.AdditionalLimbs = VandalWolf.Body.AdditionalLimbs.AddToArray(bite3d6);

            VandalWolf.LocalizedName = Helpers.Create<SharedStringAsset>(c => c.String = Helpers.CreateString($"{VandalWolf.name}.name", "Great Ferocious Wolf"));

        }

        //Armags Tomb

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
            var righteousmight = library.Get<BlueprintAbility>("90810e5cf53bf854293cbd5ea1066252");
            var freedomofmovementbuff = library.Get<BlueprintBuff>("235533b62159790499ced35860636bb2");
            var freedomofmovement = library.Get<BlueprintAbility>("0087fc2d64b6095478bc7b8d7d512caf");
            var dispel = library.Get<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
            var shieldoffaith = library.Get<BlueprintAbility>("183d5bb91dea3a1489a6db6c9cb64445");
            var ShieldOfFaithBuff = library.Get<BlueprintBuff>("5274ddc289f4a7447b7ace68ad8bebb0");
            var ShieldOfFaithAiAction = library.Get<BlueprintAiAction>("8ce28d8e7507dd24ab0ae81aebea58cf");




            cleric_gorum.AddFacts = cleric_gorum.AddFacts.AddToArray(quicken,freedomofmovementbuff);



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
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(searing_light, searing_light, heal, hellfireray, constrictingcoils, righteousmight, freedomofmovement, dispel,shieldoffaith);
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

            var auto_metamgic3 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.shieldoffaith);

            var brain = cleric_gorum.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(ShieldOfFaithAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.castsearinglight, AiActions.healspell, AiActions.hellfire_ray,
                                                    AiActions.constrictingcoils, AiActions.castshieldoffaithgorum, AiActions.righteousmightgoblinshaman, AiActions.castfreedomofmovement, AiActions.dispel);






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

        static void updateClericGorumArmags()
        {
           
            
            var skeletalchange = library.Get<BlueprintUnit>("49903237b0c90b445ac1089dc89a7665");
            var cleric_gorum_feature = library.Get<BlueprintFeature>("ca063d3e6c8576642a23fe74f2379ee0");
            var cleric = library.Get<BlueprintCharacterClass>("67819271767a9dd4fbfd4ae700befea0");
            var divine_power = library.Get<BlueprintAbility>("ef16771cb05d1344989519e87f25b3c5");
            var searing_light = library.Get<BlueprintAbility>("bf0accce250381a44b857d4af6c8e10d");
            var sm5 = library.Get<BlueprintAbility>("630c8b85d9f07a64f917d79cb5905741");
            var holdperson = library.Get<BlueprintAbility>("c7104f7526c4c524f91474614054547e");
            var heal = library.Get<BlueprintAbility>("5da172c4c89f9eb4cbb614f3a67357d3");
            var hellfireray = library.Get<BlueprintAbility>("700cfcbd0cb2975419bcab7dbb8c6210");
            var constrictingcoils = library.Get<BlueprintAbility>("3fce8e988a51a2a4ea366324d6153001");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var divinefavor = library.Get<BlueprintAbility>("9d5d2d3ffdd73c648af3eb3e585b1113");
            var fighterclass = library.Get<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd");



            var fighterLevels = skeletalchange.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == fighterclass);
            var newfighterLevels = fighterLevels.CreateCopy();
            newfighterLevels.Levels = 0;
            skeletalchange.ReplaceComponent(fighterLevels, newfighterLevels);




            skeletalchange.AddFacts = skeletalchange.AddFacts.AddToArray(quicken,cleric_gorum_feature);



            var clone = library.CopyAndAdd<BlueprintFeature>((BlueprintFeature)skeletalchange.AddFacts[6], "SkeletalClericsofGorum", "6bcaae62502b491db68a91c24d0144fb");
            skeletalchange.AddFacts[6] = clone;
            clone.ComponentsArray = clone.ComponentsArray
                .Select(c => c.CreateCopy())
                .ToArray();




            var SkeletalClericsofGorum = library.Get<BlueprintFeature>("6bcaae62502b491db68a91c24d0144fb");



            var clericLevels = SkeletalClericsofGorum.ComponentsArray
                .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == cleric);
            var newclericLevels = clericLevels.CreateCopy();
            newclericLevels.Levels = 14;
            var spell_list = newclericLevels.MemorizeSpells.AddToArray(searing_light, heal, hellfireray, constrictingcoils);
            newclericLevels.MemorizeSpells = spell_list;
            SkeletalClericsofGorum.ReplaceComponent(clericLevels, newclericLevels);

            var clericLevels2 = SkeletalClericsofGorum.ComponentsArray
                .OfType<AddClassLevels>()
                .First(c => c.CharacterClass == cleric);
            var newclericLevels2 = clericLevels2.CreateCopy();

            var spell_list2 = newclericLevels2.MemorizeSpells.RemoveFromArray(sm5);
            newclericLevels2.MemorizeSpells = spell_list2;
            SkeletalClericsofGorum.ReplaceComponent(clericLevels2, newclericLevels2);

            var clericLevels3 = SkeletalClericsofGorum.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == cleric);
            var newclericLevels3 = clericLevels3.CreateCopy();
            var spell_list3 = newclericLevels3.MemorizeSpells.RemoveFromArray(holdperson);
            newclericLevels3.MemorizeSpells = spell_list3;
            SkeletalClericsofGorum.ReplaceComponent(clericLevels3, newclericLevels3);

            var clericLevels4 = SkeletalClericsofGorum.ComponentsArray
                 .OfType<AddClassLevels>()
                 .First(c => c.CharacterClass == cleric);
            var newclericLevels4 = clericLevels4.CreateCopy();
            var spell_list4 = newclericLevels4.MemorizeSpells.RemoveFromArray(divinefavor);
            newclericLevels4.MemorizeSpells = spell_list4;
            SkeletalClericsofGorum.ReplaceComponent(clericLevels4, newclericLevels4);



            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.divinepower);

            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.prayer);


            var brain = skeletalchange.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castsearinglight,AiActions.healspell, AiActions.hellfire_ray, AiActions.constrictingcoils, AiActions.castcommand);



            skeletalchange.GetComponent<AddTags>().UseInRandomEncounter = false;
            skeletalchange.GetComponent<AddTags>().UseInDungeon = false;

        }


        static void updateArmag()
        {
            
            
            var armag = library.Get<BlueprintUnit>("0c5fbd2adcf609b45b91455bf7b68b35");
            


            
        

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

        //Bald Hilltop

        static void changebloodmoondryad()
        {

            var silky = library.Get<BlueprintUnit>("82a6be0ba1d061243848871ce2feda27");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var feyClass = library.Get<BlueprintCharacterClass>("f2e6e760ead99fb48ade27c7e9d4ac94");
            var sorcererClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var scorchingray = library.Get<BlueprintAbility>("cdb106d53c65bbc4086183d54c3b97c7");
            var earpiercescream = library.Get<BlueprintAbility>("8e7cfa5f213a90549aadd18f8f6f4664");
            var blur = library.Get<BlueprintAbility>("14ec7a4e52e90fa47a4c8d63c69fd5c1");
            var blurbuff = library.Get<BlueprintBuff>("dd3ad347240624d46a11a092b4dd4674");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var shield = library.Get<BlueprintAbility>("ef768022b0785eb43a18969903c537c4");
            var colorspray = library.Get<BlueprintAbility>("91da41b9793a4624797921f221db653c");
            var MageShieldAiAction = library.Get<BlueprintAiCastSpell>("8df9d8605fa49554691de7d02b8397ed");
            var MagicMissileAiAction = library.Get<BlueprintAiCastSpell>("e689225185e99d3469052d9cce20316d");
            var HoldPersonAiAction = library.Get<BlueprintAiCastSpell>("aee2f46dfa119d44b8bd415d2f5ad339");
            var HideousLaughterAiAction = library.Get<BlueprintAiCastSpell>("8b944da00906b6f4f9b1d73c80e46b8c");
            var SpiderWebImmunity = library.Get<BlueprintFeature>("3051e7002c803fc47a11bcfa381b9fbd");


        silky.AddFacts = silky.AddFacts.AddToArray(blurbuff,toughness, SpiderWebImmunity);


            var sorcererLevels = silky.ComponentsArray
   .OfType<AddClassLevels>()
   .First(c => c.CharacterClass == sorcererClass);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.Levels = 7;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(scorchingray, blur, haste, earpiercescream, colorspray);
            newAddClassLevels.SelectSpells = spell_list;
            silky.ReplaceComponent(sorcererLevels, newAddClassLevels);




            var humanoidLevels = silky.ComponentsArray
            .OfType<AddClassLevels>()
              .First(c => c.CharacterClass == feyClass);
            var newhumanoidLevels = humanoidLevels.CreateCopy();
            newhumanoidLevels.Levels = 5;
            silky.ReplaceComponent(humanoidLevels, newhumanoidLevels);








            var brain = silky.Brain;
            brain.Actions = brain.Actions.RemoveFromArray(MageShieldAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(MagicMissileAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(HoldPersonAiAction);
            brain.Actions = brain.Actions.RemoveFromArray(HideousLaughterAiAction);
            brain.Actions = brain.Actions.AddToArray(AiActions.scorchingraydelaydryad,AiActions.casthaste,AiActions.castcolorspray,
                                                   AiActions.castmagicmissletransmuter,AiActions.holdpersonzombiecleric,AiActions.earpiercedryad);

        }

        static void changebloodmoonnymph()
        {

            var lostsister = library.Get<BlueprintUnit>("0bdeff53fd8249d478ff8276eb8a1658");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var nymphClass = library.Get<BlueprintCharacterClass>("9a20b40b57f4e684fa20d17c0edfd5ba");
            var druidclass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            var sorcererClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var barkskin = library.Get<BlueprintAbility>("5b77d7cc65b8ab74688e74a37fc2f553");
            var flamestrike = library.Get<BlueprintAbility>("f9910c76efc34af41b6e43d5d8752f0f");
            var spikestones = library.Get<BlueprintAbility>("d1afa8bc28c99104da7d784115552de5");
            var freedomofmovementbuff = library.Get<BlueprintBuff>("235533b62159790499ced35860636bb2");
            var dispel = library.Get<BlueprintAbility>("92681f181b507b34ea87018e8f7a528a");
            var calllightningability = library.Get<BlueprintAbility>("cad052ef098f9f247ab73ae4c37ac687");
            var calllightningstorm = library.Get<BlueprintAbility>("d5a36a7ee8177be4f848b953d1c53c84");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var aspectofthebear = library.Get<BlueprintAbility>("a4ad1b8fa11e7c347a608c004efce9d5");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");
            var frigidtouch = library.Get<BlueprintAbility>("b6010dda6333bcf4093ce20f0063cd41");
            var owlswisdombuff = library.Get<BlueprintBuff>("73fc1d19f14339042ba5af34872c1745");

            

            lostsister.AddFacts = lostsister.AddFacts.AddToArray(freedomofmovementbuff,quicken,calllightningability,owlswisdombuff);

            lostsister.Dexterity = 16;

            var druidLevels = lostsister.ComponentsArray
           .OfType<AddClassLevels>()
             .First(c => c.CharacterClass == sorcererClass);
            var newAddClassLevels = druidLevels.CreateCopy();
            newAddClassLevels.CharacterClass = library.Get<BlueprintCharacterClass>("610d836f3a3a9ed42a4349b62f002e96");
            newAddClassLevels.Levels = 10;
            lostsister.ReplaceComponent(druidLevels, newAddClassLevels);


            var druidLevels2 = lostsister.ComponentsArray
   .OfType<AddClassLevels>()
   .First(c => c.CharacterClass == druidclass);
            var newAddClassLevels2 = druidLevels2.CreateCopy();
            var spell_list = newAddClassLevels2.MemorizeSpells.AddToArray(barkskin,flamestrike,spikestones,dispel,aspectofthebear,calllightningstorm,snowball,snowball,snowball,frigidtouch,frigidtouch);
            newAddClassLevels2.MemorizeSpells = spell_list;
            lostsister.ReplaceComponent(druidLevels2, newAddClassLevels2);

            var druidLevels3 = lostsister.ComponentsArray
.OfType<AddClassLevels>()
.First(c => c.CharacterClass == druidclass);
            var newAddClassLevels3 = druidLevels3.CreateCopy();
            var spell_list3 = newAddClassLevels3.SelectSpells.AddToArray(barkskin, flamestrike, spikestones, dispel,aspectofthebear,calllightningstorm,snowball,frigidtouch,frigidtouch);
            newAddClassLevels3.SelectSpells = spell_list3;
            lostsister.ReplaceComponent(druidLevels3, newAddClassLevels3);


            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.barkskin);
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.aspectofthebear);

            var humanoidLevels = lostsister.ComponentsArray
            .OfType<AddClassLevels>()
              .First(c => c.CharacterClass == nymphClass);
            var newhumanoidLevels = humanoidLevels.CreateCopy();
            newhumanoidLevels.Levels = 4;
            lostsister.ReplaceComponent(humanoidLevels, newhumanoidLevels);








            var brain = lostsister.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castaspectbear,
                AiActions.barkskingoblinking,AiActions.calllightninglostsister,
                AiActions.calllightningstorm,AiActions.castspikestones,AiActions.dispel,AiActions.flamestrikegoblinshaman,AiActions.castsnowballlostsister,AiActions.castfrigidtouchlostsister);

        }

        static void changebloodmoonnereid()
        {

            var moray = library.Get<BlueprintUnit>("0ec270b3151e5fb4e889ef9c004dd366");
            var toughness = library.Get<BlueprintFeature>("d09b20029e9abfe4480b356c92095623");
            var feyClass = library.Get<BlueprintCharacterClass>("f2e6e760ead99fb48ade27c7e9d4ac94");
            var icestorm = library.Get<BlueprintAbility>("fcb028205a71ee64d98175ff39a0abf9");
            var sorcererClass = library.Get<BlueprintCharacterClass>("b3a505fb61437dc4097f43c3f8f9a4cf");
            var stoneskincommunal = library.Get<BlueprintAbility>("7c5d556b9a5883048bf030e20daebe31");
            var dragonsbreathsilver = library.Get<BlueprintAbility>("5e826bcdfde7f82468776b55315b2403");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");
            var mirrorimage = library.Get<BlueprintAbility>("3e4ab69ada402d145a5e0ad3ad4b8564");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            var SummonElementalHugeWater = library.Get<BlueprintAbility>("4695c4674e62eb3479fa03f0b47cc6a8");
            var SummonElementalGreaterWater = library.Get<BlueprintAbility>("cfa3ff71a42ab8a4c8a8a4b5db3f04d4");
            var haste = library.Get<BlueprintAbility>("486eaff58293f6441a5c2759c4872f98");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");

            moray.AddFacts = moray.AddFacts.RemoveFromArray(SummonElementalHugeWater);
            moray.AddFacts = moray.AddFacts.AddToArray(quicken,SummonElementalGreaterWater);
            moray.AddFacts = moray.AddFacts.AddToArray(quicken);

            var sorcererLevels = moray.ComponentsArray
           .OfType<AddClassLevels>()
           .First(c => c.CharacterClass == sorcererClass);
            var newAddClassLevels = sorcererLevels.CreateCopy();
            newAddClassLevels.Levels = 11;
            var spell_list = newAddClassLevels.SelectSpells.AddToArray(icestorm, dragonsbreathsilver, stoneskincommunal, mirrorimage, lightningbolt, haste, displacement);
            newAddClassLevels.SelectSpells = spell_list;
            moray.ReplaceComponent(sorcererLevels, newAddClassLevels);

            var feyLevels = moray.ComponentsArray
            .OfType<AddClassLevels>()
            .First(c => c.CharacterClass == feyClass);
            var newAddClassLevels2 = feyLevels.CreateCopy();
            newAddClassLevels2.Levels = 5;
            moray.ReplaceComponent(feyLevels, newAddClassLevels2);


            var auto_metamgic = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic.GetComponent<AutoMetamagic>().Abilities.Add(Spells.mirrorimage);





            var brain = moray.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.stoneskincommunal, AiActions.icestorm, AiActions.dragonsbreathsilver, AiActions.mirrorimage, 
                AiActions.summonelementalgreatwatermoray,AiActions.lightningboltfourturns,AiActions.casthastetartuk,AiActions.castdisplacementgoblin);

        }


        //Elementals

        static void updateElderAirElemental()
        {

            var ElderAir = library.Get<BlueprintUnit>("ddca501b2cc606741a513483d9c928dc");
            var chainlightning = library.Get<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58");


            ElderAir.AddFacts = ElderAir.AddFacts.AddToArray(chainlightning);


            var brain = ElderAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.chainlightningelderair);


        }

        static void updateGreaterAirElemental()
        {

            var GreaterAir = library.Get<BlueprintUnit>("cb8ff0a7ba777ba4291dabb6008767be");
            var chainlightning = library.Get<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58");


            GreaterAir.AddFacts = GreaterAir.AddFacts.AddToArray(chainlightning);


            var brain = GreaterAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.chainlightningelderair);


        }

        static void updateHugeAirElemental()
        {

            var HugeAir = library.Get<BlueprintUnit>("acfa5398635f1a746acd8035e9b98eab");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");


            HugeAir.AddFacts = HugeAir.AddFacts.AddToArray(lightningbolt);


            var brain = HugeAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltairelemental);


        }

        static void updateLargeAirElemental()
        {

            var LargeAir = library.Get<BlueprintUnit>("f968ae3c61d18c64e940c7b3ce09cca7");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");


            LargeAir.AddFacts = LargeAir.AddFacts.AddToArray(lightningbolt);


            var brain = LargeAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltairelemental);


        }

        static void updateMediumAirElemental()
        {

            var MediumAir = library.Get<BlueprintUnit>("f739047597b7a2849b14def122e1ee0d");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");


            MediumAir.AddFacts = MediumAir.AddFacts.AddToArray(lightningbolt);


            var brain = MediumAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltairelemental);


        }

        static void updateSmallAirElemental()
        {

            var SmallAir = library.Get<BlueprintUnit>("af7b264a209291740bdf105c1f5942a6");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");


            SmallAir.AddFacts = SmallAir.AddFacts.AddToArray(lightningbolt);


            var brain = SmallAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltairelemental);


        }

        static void updateSummonedElderAirElemental()
        {

            var ElderAir = library.Get<BlueprintUnit>("33bb90ffd13c87b4c8e45d920313752a");
            var chainlightning = library.Get<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58");


            ElderAir.AddFacts = ElderAir.AddFacts.AddToArray(chainlightning);


            var brain = ElderAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.chainlightningelderair);


        }

        static void updateSummonedGreaterAirElemental()
        {

            var GreaterAir = library.Get<BlueprintUnit>("e770cfbb96b528c4db258d7d03fe6533");
            var chainlightning = library.Get<BlueprintAbility>("645558d63604747428d55f0dd3a4cb58");


            GreaterAir.AddFacts = GreaterAir.AddFacts.AddToArray(chainlightning);


            var brain = GreaterAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.chainlightningelderair);


        }

        static void updateSummonedHugeAirElemental()
        {

            var HugeAir = library.Get<BlueprintUnit>("2e24256e459468743b91fbb9aa85e1ab");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");


            HugeAir.AddFacts = HugeAir.AddFacts.AddToArray(lightningbolt);


            var brain = HugeAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltairelemental);


        }

        static void updateSummonedLargeAirElemental()
        {

            var LargeAir = library.Get<BlueprintUnit>("3764b43791a00e1468257adbca43ce9b");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");


            LargeAir.AddFacts = LargeAir.AddFacts.AddToArray(lightningbolt);


            var brain = LargeAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltairelemental);


        }

        static void updateSummonedMediumAirElemental()
        {

            var MediumAir = library.Get<BlueprintUnit>("676f8b7d0a170674cb6e504e0e30b4f0");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");


            MediumAir.AddFacts = MediumAir.AddFacts.AddToArray(lightningbolt);


            var brain = MediumAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltairelemental);


        }

        static void updateSummonedSmallAirElemental()
        {

            var SmallAir = library.Get<BlueprintUnit>("04944455200bc224d955a8e9bbd64f3f");
            var lightningbolt = library.Get<BlueprintAbility>("d2cff9243a7ee804cb6d5be47af30c73");


            SmallAir.AddFacts = SmallAir.AddFacts.AddToArray(lightningbolt);


            var brain = SmallAir.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.lightningboltairelemental);


        }




        static void updateElderEarthElemental()
        {

            var ElderEarth = library.Get<BlueprintUnit>("672433d2f2e99764db2eadc6f595a2ba");
            var acidicspray = library.Get<BlueprintAbility>("c543eef6d725b184ea8669dd09b3894c");


            ElderEarth.AddFacts = ElderEarth.AddFacts.AddToArray(acidicspray);


            var brain = ElderEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.acidicsprayelderearth);


        }

        static void updateGreaterEarthElemental()
        {

            var GreaterEarth = library.Get<BlueprintUnit>("55f39411dc3c9ef43aa61c2d7fe3bfc9");
            var acidicspray = library.Get<BlueprintAbility>("c543eef6d725b184ea8669dd09b3894c");


            GreaterEarth.AddFacts = GreaterEarth.AddFacts.AddToArray(acidicspray);


            var brain = GreaterEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.acidicsprayelderearth);


        }

        static void updateHugeEarthElemental()
        {

            var HugeEarth = library.Get<BlueprintUnit>("3e447739c6b1e2d41b301ee477e41ba7");
            var dragonsbreathgreen = library.Get<BlueprintAbility>("48c4433acbcecae499d1d38a56f72f36");


            HugeEarth.AddFacts = HugeEarth.AddFacts.AddToArray(dragonsbreathgreen);


            var brain = HugeEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathearthelemental);


        }

        static void updateLargeEarthElemental()
        {

            var LargeEarth = library.Get<BlueprintUnit>("6345d091fc79e0840b14b908a4e65d4d");
            var dragonsbreathgreen = library.Get<BlueprintAbility>("48c4433acbcecae499d1d38a56f72f36");


            LargeEarth.AddFacts = LargeEarth.AddFacts.AddToArray(dragonsbreathgreen);


            var brain = LargeEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathearthelemental);


        }

        static void updateMediumEarthElemental()
        {

            var MediumEarth = library.Get<BlueprintUnit>("11d8e4b048acc0e4c8e42e76b8ab869d");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");


            MediumEarth.AddFacts = MediumEarth.AddFacts.AddToArray(acidarrow);


            var brain = MediumEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.acidarrowearthelemental);


        }

        static void updateSmallEarthElemental()
        {

            var SmallEarth = library.Get<BlueprintUnit>("a940662426e68524680bc06e1794fa8d");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");


            SmallEarth.AddFacts = SmallEarth.AddFacts.AddToArray(acidarrow);


            var brain = SmallEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.acidarrowearthelemental);


        }

        static void updateSummonedElderEarthElemental()
        {

            var ElderEarth = library.Get<BlueprintUnit>("6b4cb9b6116f2194192e1e7e379c48d7");
            var acidicspray = library.Get<BlueprintAbility>("c543eef6d725b184ea8669dd09b3894c");


            ElderEarth.AddFacts = ElderEarth.AddFacts.AddToArray(acidicspray);


            var brain = ElderEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.acidicsprayelderearth);


        }

        static void updateSummonedGreaterEarthElemental()
        {

            var GreaterEarth = library.Get<BlueprintUnit>("cda7013db24f4c547b79bfc5c617066b");
            var acidicspray = library.Get<BlueprintAbility>("c543eef6d725b184ea8669dd09b3894c");


            GreaterEarth.AddFacts = GreaterEarth.AddFacts.AddToArray(acidicspray);


            var brain = GreaterEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.acidicsprayelderearth);


        }

        static void updateSummonedHugeEarthElemental()
        {

            var HugeEarth = library.Get<BlueprintUnit>("3b86a449e7264174eaccef9b8f02fe20");
            var dragonsbreathgreen = library.Get<BlueprintAbility>("48c4433acbcecae499d1d38a56f72f36");


            HugeEarth.AddFacts = HugeEarth.AddFacts.AddToArray(dragonsbreathgreen);


            var brain = HugeEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathearthelemental);


        }

        static void updateSummonedLargeEarthElemental()
        {

            var LargeEarth = library.Get<BlueprintUnit>("d3d9ab560534bd948b10ac00abbff083");
            var dragonsbreathgreen = library.Get<BlueprintAbility>("48c4433acbcecae499d1d38a56f72f36");


            LargeEarth.AddFacts = LargeEarth.AddFacts.AddToArray(dragonsbreathgreen);


            var brain = LargeEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathearthelemental);


        }

        static void updateSummonedMediumEarthElemental()
        {

            var MediumEarth = library.Get<BlueprintUnit>("812c9a0348e004242ba4e46efa91e38e");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");


            MediumEarth.AddFacts = MediumEarth.AddFacts.AddToArray(acidarrow);


            var brain = MediumEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.acidarrowearthelemental);


        }

        static void updateSummonedSmallEarthElemental()
        {

            var SmallEarth = library.Get<BlueprintUnit>("651600a51edd20141adb67696986c582");
            var acidarrow = library.Get<BlueprintAbility>("9a46dfd390f943647ab4395fc997936d");


            SmallEarth.AddFacts = SmallEarth.AddFacts.AddToArray(acidarrow);


            var brain = SmallEarth.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.acidarrowearthelemental);


        }



        static void updateElderFireElemental()
        {

            var ElderFire = library.Get<BlueprintUnit>("d6b7b92ea00785f45b8e5a4bf8e87fa2");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");


            ElderFire.AddFacts = ElderFire.AddFacts.AddToArray(firesnake);


            var brain = ElderFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.firesnakeelderfire);


        }

        static void updateGreaterFireElemental()
        {

            var GreaterFire = library.Get<BlueprintUnit>("5b7fc5f74b0195e42ba17f1d7e21a3c9");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");


            GreaterFire.AddFacts = GreaterFire.AddFacts.AddToArray(firesnake);


            var brain = GreaterFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.firesnakeelderfire);


        }

        static void updateHugeFireElemental()
        {

            var HugeFire = library.Get<BlueprintUnit>("906b560315bb1bf4890431ce2676e485");
            var controlledfireball = library.Get<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");


            HugeFire.AddFacts = HugeFire.AddFacts.AddToArray(controlledfireball);


            var brain = HugeFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.controlledfireballfireelemental);


        }

        static void updateLargeFireElemental()
        {

            var LargeFire = library.Get<BlueprintUnit>("25f8ba0f46a1df74b88746872aace0ee");
            var controlledfireball = library.Get<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");


            LargeFire.AddFacts = LargeFire.AddFacts.AddToArray(controlledfireball);


            var brain = LargeFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.controlledfireballfireelemental);


        }

        static void updateMediumFireElemental()
        {

            var MediumFire = library.Get<BlueprintUnit>("37b3eb7ca48264247b3247c732007aef");
            var burningarc = library.Get<BlueprintAbility>("eaac3d36e0336cb479209a6f65e25e7c");


            MediumFire.AddFacts = MediumFire.AddFacts.AddToArray(burningarc);


            var brain = MediumFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.burninarcfireelemental);


        }

        static void updateSmallFireElemental()
        {

            var MediumFire = library.Get<BlueprintUnit>("42db8d382f3687a459ffde7921ccbbfc");
            var burningarc = library.Get<BlueprintAbility>("eaac3d36e0336cb479209a6f65e25e7c");


            MediumFire.AddFacts = MediumFire.AddFacts.AddToArray(burningarc);


            var brain = MediumFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.burninarcfireelemental);


        }

        static void updateSummonedElderFireElemental()
        {

            var ElderFire = library.Get<BlueprintUnit>("ea0f0bbc6e5e471428d535501b21eb26");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");


            ElderFire.AddFacts = ElderFire.AddFacts.AddToArray(firesnake);


            var brain = ElderFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.firesnakeelderfire);


        }

        static void updateSummonedGreaterFireElemental()
        {

            var GreaterFire = library.Get<BlueprintUnit>("b0b4091bdaebb464e903857a95189dea");
            var firesnake = library.Get<BlueprintAbility>("ebade19998e1f8542a1b55bd4da766b3");


            GreaterFire.AddFacts = GreaterFire.AddFacts.AddToArray(firesnake);


            var brain = GreaterFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.firesnakeelderfire);


        }

        static void updateSummonedHugeFireElemental()
        {

            var HugeFire = library.Get<BlueprintUnit>("640fb7efb7c916945837bbcab995267e");
            var controlledfireball = library.Get<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");


            HugeFire.AddFacts = HugeFire.AddFacts.AddToArray(controlledfireball);


            var brain = HugeFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.controlledfireballfireelemental);


        }

        static void updateSummonedLargeFireElemental()
        {

            var LargeFire = library.Get<BlueprintUnit>("ba5026596b06b204eb2efed2b411c5b9");
            var controlledfireball = library.Get<BlueprintAbility>("f72f8f03bf0136c4180cd1d70eb773a5");


            LargeFire.AddFacts = LargeFire.AddFacts.AddToArray(controlledfireball);


            var brain = LargeFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.controlledfireballfireelemental);


        }

        static void updateSummonedMediumFireElemental()
        {

            var MediumFire = library.Get<BlueprintUnit>("a0ab0c31b1a92554291a82e598f39ba4");
            var burningarc = library.Get<BlueprintAbility>("eaac3d36e0336cb479209a6f65e25e7c");


            MediumFire.AddFacts = MediumFire.AddFacts.AddToArray(burningarc);


            var brain = MediumFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.burninarcfireelemental);


        }

        static void updateSummmonedSmallFireElemental()
        {

            var MediumFire = library.Get<BlueprintUnit>("46cede83b1f34ad4fa46b8776e352b02");
            var burningarc = library.Get<BlueprintAbility>("eaac3d36e0336cb479209a6f65e25e7c");


            MediumFire.AddFacts = MediumFire.AddFacts.AddToArray(burningarc);


            var brain = MediumFire.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.burninarcfireelemental);


        }




        static void updateElderWaterElemental()
        {

            var ElderWater = library.Get<BlueprintUnit>("af612f1254e352641996915bc45d81b9");
            var coneofcold = library.Get<BlueprintAbility>("e7c530f8137630f4d9d7ee1aa7b1edc0");


            ElderWater.AddFacts = ElderWater.AddFacts.AddToArray(coneofcold);


            var brain = ElderWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.coneofcoldelderwater);


        }

        static void updateGreaterWaterElemental()
        {

            var GreaterWater = library.Get<BlueprintUnit>("dcb38324925468a4097f2f9f35399b2e");
            var coneofcold = library.Get<BlueprintAbility>("e7c530f8137630f4d9d7ee1aa7b1edc0");


            GreaterWater.AddFacts = GreaterWater.AddFacts.AddToArray(coneofcold);


            var brain = GreaterWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.coneofcoldelderwater);


        }

        static void updateHugeWaterElemental()
        {

            var HugeWater = library.Get<BlueprintUnit>("d2020789769c90f42ab780dcba70a6d4");
            var dragonsbreathsilver = library.Get<BlueprintAbility>("45e0813484581514fbfcf49939ee050d");


            HugeWater.AddFacts = HugeWater.AddFacts.AddToArray(dragonsbreathsilver);


            var brain = HugeWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathwaterelemental);


        }

        static void updateLargeWaterElemental()
        {

            var LargeWater = library.Get<BlueprintUnit>("f647c00b160966849bc5c282c8244a6f");
            var dragonsbreathsilver = library.Get<BlueprintAbility>("45e0813484581514fbfcf49939ee050d");


            LargeWater.AddFacts = LargeWater.AddFacts.AddToArray(dragonsbreathsilver);


            var brain = LargeWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathwaterelemental);


        }

        static void updateMediumWaterElemental()
        {

            var MediumWater = library.Get<BlueprintUnit>("9922c4c5d1ec4cf409cf3b4742c90b51");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");


            MediumWater.AddFacts = MediumWater.AddFacts.AddToArray(snowball);


            var brain = MediumWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castsnowballwaterelemental);


        }

        static void updateSmallWaterElemental()
        {

            var SmallWater = library.Get<BlueprintUnit>("92c6145373ee5b64fa9e2ec2a0d907db");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");


            SmallWater.AddFacts = SmallWater.AddFacts.AddToArray(snowball);


            var brain = SmallWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castsnowballwaterelemental);


        }


        static void updateSummonedElderWaterElemental()
        {

            var ElderWater = library.Get<BlueprintUnit>("3bd31a0b4d800f04a8c5b7b1a6d7061e");
            var coneofcold = library.Get<BlueprintAbility>("e7c530f8137630f4d9d7ee1aa7b1edc0");


            ElderWater.AddFacts = ElderWater.AddFacts.AddToArray(coneofcold);


            var brain = ElderWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.coneofcoldelderwater);


        }

        static void updateSummonedGreaterWaterElemental()
        {

            var GreaterWater = library.Get<BlueprintUnit>("fcc939e3acf355b458ddf9617d8c6c28");
            var coneofcold = library.Get<BlueprintAbility>("e7c530f8137630f4d9d7ee1aa7b1edc0");


            GreaterWater.AddFacts = GreaterWater.AddFacts.AddToArray(coneofcold);


            var brain = GreaterWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.coneofcoldelderwater);


        }

        static void updateSummonedHugeWaterElemental()
        {

            var HugeWater = library.Get<BlueprintUnit>("877c154a296ee8e45be1a00668319923");
            var dragonsbreathsilver = library.Get<BlueprintAbility>("45e0813484581514fbfcf49939ee050d");


            HugeWater.AddFacts = HugeWater.AddFacts.AddToArray(dragonsbreathsilver);


            var brain = HugeWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathwaterelemental);


        }

        static void updateSummonedLargeWaterElemental()
        {

            var LargeWater = library.Get<BlueprintUnit>("680b5b61c80af664daec46af7644486c");
            var dragonsbreathsilver = library.Get<BlueprintAbility>("45e0813484581514fbfcf49939ee050d");


            LargeWater.AddFacts = LargeWater.AddFacts.AddToArray(dragonsbreathsilver);


            var brain = LargeWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.dragonsbreathwaterelemental);


        }

        static void updateSummonedMediumWaterElemental()
        {

            var MediumWater = library.Get<BlueprintUnit>("62a3e860e6e72e6499c38bb8b2fe303e");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");


            MediumWater.AddFacts = MediumWater.AddFacts.AddToArray(snowball);


            var brain = MediumWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castsnowballwaterelemental);


        }

        static void updateSummonedSmallWaterElemental()
        {

            var SmallWater = library.Get<BlueprintUnit>("56372b0a2749c224392a5ee74105c534");
            var snowball = library.Get<BlueprintAbility>("9f10909f0be1f5141bf1c102041f93d9");


            SmallWater.AddFacts = SmallWater.AddFacts.AddToArray(snowball);


            var brain = SmallWater.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.castsnowballwaterelemental);


        }

        //ExtraHealthToNPCs

        static void updateBartholomew()
        {



            var SadisticMage = library.Get<BlueprintUnit>("85a0f58a844cf0d42940fdd2db741764");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var mageshieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            SadisticMage.MaxHP = 100;
            SadisticMage.Constitution = 18;

            SadisticMage.AddFacts = SadisticMage.AddFacts.AddToArray(magearmorbuff,mageshieldbuff,quicken,combatcasting);

            var wizardLevels = SadisticMage.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels = wizardLevels.CreateCopy();
            newsorcererLevels.Levels = 11;
            var spell_list = newsorcererLevels.MemorizeSpells.AddToArray(displacement,displacement);
            newsorcererLevels.MemorizeSpells = spell_list;
            SadisticMage.ReplaceComponent(wizardLevels, newsorcererLevels);

            var wizardLevels2 = SadisticMage.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.SelectSpells.AddToArray(displacement);
            newsorcererLevels2.SelectSpells = spell_list2;
            SadisticMage.ReplaceComponent(wizardLevels2, newsorcererLevels2);


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);



            var brain = SadisticMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai);



        }

        static void updateBartholomewBefore()
        {



            var SadisticMage = library.Get<BlueprintUnit>("e50a599961407de41a55b5cd87045364");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var mageshieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            SadisticMage.MaxHP = 100;
            SadisticMage.Constitution = 18;

            SadisticMage.AddFacts = SadisticMage.AddFacts.AddToArray(magearmorbuff, mageshieldbuff, quicken, combatcasting);

            var wizardLevels = SadisticMage.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels = wizardLevels.CreateCopy();
            newsorcererLevels.Levels = 11;
            var spell_list = newsorcererLevels.MemorizeSpells.AddToArray(displacement, displacement);
            newsorcererLevels.MemorizeSpells = spell_list;
            SadisticMage.ReplaceComponent(wizardLevels, newsorcererLevels);

            var wizardLevels2 = SadisticMage.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.SelectSpells.AddToArray(displacement);
            newsorcererLevels2.SelectSpells = spell_list2;
            SadisticMage.ReplaceComponent(wizardLevels2, newsorcererLevels2);


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);



            var brain = SadisticMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai);



        }

        static void updateBartholomewFinal()
        {



            var SadisticMage = library.Get<BlueprintUnit>("c6fba7281fbf4c34c953097bcd67e06e");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var mageshieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            SadisticMage.MaxHP = 100;
            SadisticMage.Constitution = 18;

            SadisticMage.AddFacts = SadisticMage.AddFacts.AddToArray(magearmorbuff, mageshieldbuff, quicken, combatcasting);

            var wizardLevels = SadisticMage.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels = wizardLevels.CreateCopy();
            newsorcererLevels.Levels = 11;
            var spell_list = newsorcererLevels.MemorizeSpells.AddToArray(displacement, displacement);
            newsorcererLevels.MemorizeSpells = spell_list;
            SadisticMage.ReplaceComponent(wizardLevels, newsorcererLevels);

            var wizardLevels2 = SadisticMage.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.SelectSpells.AddToArray(displacement);
            newsorcererLevels2.SelectSpells = spell_list2;
            SadisticMage.ReplaceComponent(wizardLevels2, newsorcererLevels2);


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);



            var brain = SadisticMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai);



        }

        static void updateBartholomewPacking()
        {



            var SadisticMage = library.Get<BlueprintUnit>("1eeffc7ae20bc6a408569a5606d18e83");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var mageshieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            SadisticMage.MaxHP = 100;
            SadisticMage.Constitution = 18;

            SadisticMage.AddFacts = SadisticMage.AddFacts.AddToArray(magearmorbuff, mageshieldbuff, quicken, combatcasting);

            var wizardLevels = SadisticMage.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels = wizardLevels.CreateCopy();
            newsorcererLevels.Levels = 11;
            var spell_list = newsorcererLevels.MemorizeSpells.AddToArray(displacement, displacement);
            newsorcererLevels.MemorizeSpells = spell_list;
            SadisticMage.ReplaceComponent(wizardLevels, newsorcererLevels);

            var wizardLevels2 = SadisticMage.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.SelectSpells.AddToArray(displacement);
            newsorcererLevels2.SelectSpells = spell_list2;
            SadisticMage.ReplaceComponent(wizardLevels2, newsorcererLevels2);


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);



            var brain = SadisticMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai);



        }

        static void updateBartholomewWOwhip()
        {



            var SadisticMage = library.Get<BlueprintUnit>("637d5457bd886ad4a9ba4045853cbd5d");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var mageshieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            SadisticMage.MaxHP = 100;
            SadisticMage.Constitution = 18;

            SadisticMage.AddFacts = SadisticMage.AddFacts.AddToArray(magearmorbuff, mageshieldbuff, quicken, combatcasting);

            var wizardLevels = SadisticMage.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels = wizardLevels.CreateCopy();
            newsorcererLevels.Levels = 11;
            var spell_list = newsorcererLevels.MemorizeSpells.AddToArray(displacement, displacement);
            newsorcererLevels.MemorizeSpells = spell_list;
            SadisticMage.ReplaceComponent(wizardLevels, newsorcererLevels);

            var wizardLevels2 = SadisticMage.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.SelectSpells.AddToArray(displacement);
            newsorcererLevels2.SelectSpells = spell_list2;
            SadisticMage.ReplaceComponent(wizardLevels2, newsorcererLevels2);


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);



            var brain = SadisticMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai);



        }

        static void updateBartholomewPrisonAsylum()
        {



            var SadisticMage = library.Get<BlueprintUnit>("7c1bb23864196714da9b95a3aeae3ace");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var mageshieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            SadisticMage.MaxHP = 100;
            SadisticMage.Constitution = 18;

            SadisticMage.AddFacts = SadisticMage.AddFacts.AddToArray(magearmorbuff, mageshieldbuff, quicken, combatcasting);

            var wizardLevels = SadisticMage.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels = wizardLevels.CreateCopy();
            newsorcererLevels.Levels = 11;
            var spell_list = newsorcererLevels.MemorizeSpells.AddToArray(displacement, displacement);
            newsorcererLevels.MemorizeSpells = spell_list;
            SadisticMage.ReplaceComponent(wizardLevels, newsorcererLevels);

            var wizardLevels2 = SadisticMage.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.SelectSpells.AddToArray(displacement);
            newsorcererLevels2.SelectSpells = spell_list2;
            SadisticMage.ReplaceComponent(wizardLevels2, newsorcererLevels2);


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);



            var brain = SadisticMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai);



        }

        static void updateBartholomewHub()
        {



            var SadisticMage = library.Get<BlueprintUnit>("d3061fa21b8c19847bc58b21831a68ae");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var mageshieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            SadisticMage.MaxHP = 100;
            SadisticMage.Constitution = 18;

            SadisticMage.AddFacts = SadisticMage.AddFacts.AddToArray(magearmorbuff, mageshieldbuff, quicken, combatcasting);

            var wizardLevels = SadisticMage.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels = wizardLevels.CreateCopy();
            newsorcererLevels.Levels = 11;
            var spell_list = newsorcererLevels.MemorizeSpells.AddToArray(displacement, displacement);
            newsorcererLevels.MemorizeSpells = spell_list;
            SadisticMage.ReplaceComponent(wizardLevels, newsorcererLevels);

            var wizardLevels2 = SadisticMage.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.SelectSpells.AddToArray(displacement);
            newsorcererLevels2.SelectSpells = spell_list2;
            SadisticMage.ReplaceComponent(wizardLevels2, newsorcererLevels2);


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);



            var brain = SadisticMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai);



        }

        static void updateBartholomewFW()
        {



            var SadisticMage = library.Get<BlueprintUnit>("9cb43eb67c428544187d1535901c4477");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var mageshieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            SadisticMage.MaxHP = 100;
            SadisticMage.Constitution = 18;

            SadisticMage.AddFacts = SadisticMage.AddFacts.AddToArray(magearmorbuff, mageshieldbuff, quicken, combatcasting);

            var wizardLevels = SadisticMage.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels = wizardLevels.CreateCopy();
            newsorcererLevels.Levels = 11;
            var spell_list = newsorcererLevels.MemorizeSpells.AddToArray(displacement, displacement);
            newsorcererLevels.MemorizeSpells = spell_list;
            SadisticMage.ReplaceComponent(wizardLevels, newsorcererLevels);

            var wizardLevels2 = SadisticMage.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.SelectSpells.AddToArray(displacement);
            newsorcererLevels2.SelectSpells = spell_list2;
            SadisticMage.ReplaceComponent(wizardLevels2, newsorcererLevels2);


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);



            var brain = SadisticMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai);



        }

        static void updateBartholomewCapital()
        {



            var SadisticMage = library.Get<BlueprintUnit>("884a076fe9a3e4b48ab60c5318caa4a3");
            var combatcasting = library.Get<BlueprintFeature>("06964d468fde1dc4aa71a92ea04d930d");
            var wizardClass = library.Get<BlueprintCharacterClass>("ba34257984f4c41408ce1dc2004e342e");
            var magicmissle = library.Get<BlueprintAbility>("4ac47ddb9fa1eaf43a1b6809980cfbd2");
            var displacement = library.Get<BlueprintAbility>("903092f6488f9ce45a80943923576ab3");
            var magearmorbuff = library.Get<BlueprintBuff>("a92acdf18049d784eaa8f2004f5d2304");
            var mageshieldbuff = library.Get<BlueprintBuff>("9c0fa9b438ada3f43864be8dd8b3e741");
            var quicken = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");



            SadisticMage.MaxHP = 100;
            SadisticMage.Constitution = 18;

            SadisticMage.AddFacts = SadisticMage.AddFacts.AddToArray(magearmorbuff, mageshieldbuff, quicken, combatcasting);

            var wizardLevels = SadisticMage.ComponentsArray
                    .OfType<AddClassLevels>()
                    .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels = wizardLevels.CreateCopy();
            newsorcererLevels.Levels = 11;
            var spell_list = newsorcererLevels.MemorizeSpells.AddToArray(displacement, displacement);
            newsorcererLevels.MemorizeSpells = spell_list;
            SadisticMage.ReplaceComponent(wizardLevels, newsorcererLevels);

            var wizardLevels2 = SadisticMage.ComponentsArray
         .OfType<AddClassLevels>()
         .First(c => c.CharacterClass == wizardClass);
            var newsorcererLevels2 = wizardLevels2.CreateCopy();
            var spell_list2 = newsorcererLevels2.SelectSpells.AddToArray(displacement);
            newsorcererLevels2.SelectSpells = spell_list2;
            SadisticMage.ReplaceComponent(wizardLevels2, newsorcererLevels2);


            var auto_metamgic2 = library.Get<BlueprintFeature>("f65fc9a042f5e7247a03702dca121936");
            auto_metamgic2.GetComponent<AutoMetamagic>().Abilities.Add(Spells.displacement);



            var brain = SadisticMage.Brain;
            brain.Actions = brain.Actions.AddToArray(AiActions.displacementvordakai);



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
