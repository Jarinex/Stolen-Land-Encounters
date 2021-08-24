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

namespace Kingmaker.UnitLogic.Mechanics.Actions
{
    public class CustomContextActionSpawnMonster7 : ContextAction
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
            vector += new Vector3(1, 0, -1);
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
    public class CustomContextActionSpawnMonster8 : ContextAction
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
            vector += new Vector3(2, 0, 2);
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
    public class CustomContextActionSpawnMonster9 : ContextAction
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
            vector += new Vector3(0, 4, 2);
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
    public class CustomContextActionSpawnMonster10 : ContextAction
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
    public class CustomContextActionSpawnMonster11 : ContextAction
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
    public class CustomContextActionSpawnMonster12 : ContextAction
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
            vector += new Vector3(0, 8, 4);
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
    public class CustomContextActionSpawnMonster13 : ContextAction
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
    public class CustomContextActionSpawnMonster14 : ContextAction
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
            vector += new Vector3(-2, 0, -5);
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
    public class CustomContextActionSpawnMonster15 : ContextAction
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
            vector += new Vector3(1, 0, -6);
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
    public class CustomContextActionSpawnMonster16 : ContextAction
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
            vector += new Vector3(0, 0, 20);
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
    public class CustomContextActionSpawnMonster17 : ContextAction
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
            vector += new Vector3(6, 0, 10);
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
    public class CustomContextActionSpawnMonster18 : ContextAction
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
            vector += new Vector3(-4, 0, 15);
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
    public class CustomContextActionSpawnMonster19 : ContextAction
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
            vector += new Vector3(3, 0, 7);
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
    public class CustomContextActionSpawnMonster20 : ContextAction
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
            vector += new Vector3(1, 0, 7);
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
    public class CustomContextActionSpawnMonster21 : ContextAction
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
            vector += new Vector3(5, 0, 7);
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
            summondweomercat();
            callghostsdevourer();
            summonrangedfriends();
            callVenegefulghosts();
            callDamnedTrolls();
            callHATEOTFrostGiant();
            callErinyes();
            callPurpleWorms();
            callTreants();
            callbloodyboeastsdevourer();
            callThanaedaemonPlaceholder();
            callAstraldaemonSoulEaters();
            callElementals();
            callElementalsTwo();
            callDryadHelpers();
            callNeriedHelpers();
            callOozeHelpers();
            calldeva();

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
            summonghosts_resource2.SetFixedResource(1);

        }


        static void callghostsdevourer()
        {
            var VengefulSpectre = library.Get<BlueprintUnit>("b08095a9ede34f23aa6d829254fe14c5");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = VengefulSpectre),
               Helpers.Create<CustomContextActionSpawnMonster6>(c => c.Blueprint = VengefulSpectre));

            var ability = Helpers.CreateAbility("Summon Spectres",
                "Summon Spectres",
               "Summon spectres to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonSpectresresource = Helpers.CreateAbilityResource("SummonSpectresresource", "", "", "", null);
            SummonSpectresresource.SetFixedResource(1);

        }

        static void callVenegefulghosts()
        {
            var VengefulSpectre = library.Get<BlueprintUnit>("b08095a9ede34f23aa6d829254fe14c5");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = VengefulSpectre),
               Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = VengefulSpectre));

            var ability = Helpers.CreateAbility("Summon Vengeful Spectres",
                "Summon Vengeful Spectres",
               "Summon spectres to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonSpectresresource4 = Helpers.CreateAbilityResource("SummonSpectresresource4", "", "", "", null);
            SummonSpectresresource4.SetFixedResource(1);

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
            summonghosts_resource3.SetFixedResource(1);

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
            summonundead_resource3.SetFixedResource(1);

        }


        static void summondweomercat()
        {

            var dweomeradvanced = library.Get<BlueprintUnit>("729464361d706f8429e4f4ea9b4f952c");

            var actions = Helpers.CreateRunActions(
                Helpers.Create<CustomContextActionSpawnMonster7>(c => c.Blueprint = dweomeradvanced));

            var ability = Helpers.CreateAbility("Summon Advanced Dweomercat",
                "Summon Advanced Dweomercat",
               "Summon Advanced Dweomercat.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var summonAdvancedDweomercat_resource3 = Helpers.CreateAbilityResource("summonadvanceddweomercatResource", "", "", "", null);
            summonAdvancedDweomercat_resource3.SetFixedResource(1);

        }


        static void summonrangedfriends()
        {
            var riverbladeranged = library.Get<BlueprintUnit>("7bc81dc0338f4ff0a3096387c346857a");
            var riverblademelee = library.Get<BlueprintUnit>("1d3635f4e5ede9043a8fee43163cb490");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = riverbladeranged),//Spawns on his left (my right), move it down two units on the y axis
               Helpers.Create<CustomContextActionSpawnMonster6>(c => c.Blueprint = riverbladeranged)); //Spawns on his right (my left), move it down on the y axis

            var ability = Helpers.CreateAbility("Summon River Blade Archers",
                "Call for Aid",
               "Summon two River Blade Archers to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var summonrangedfriends_resource2 = Helpers.CreateAbilityResource("summonrangedfriendsResource2", "", "", "", null);
            summonrangedfriends_resource2.SetFixedResource(2);

        }


        static void callDamnedTrolls()
        {
            var DamnedTrolls = library.Get<BlueprintUnit>("1f35ffdfefb2442bb6f4d970831e44d6");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = DamnedTrolls),
               Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = DamnedTrolls));

            var ability = Helpers.CreateAbility("Summon Damned Trolls",
                "Summon Damned Trolls",
               "Summon Trolls to your side",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonDamnedTrollsresource4 = Helpers.CreateAbilityResource("SummonDamnedTrollsresource4", "", "", "", null);
            SummonDamnedTrollsresource4.SetFixedResource(1);

        }

        static void callHATEOTFrostGiant()
        {
            var HATEOTFrostGiant = library.Get<BlueprintUnit>("6828d36959036054895d1b9cc0094d96");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = HATEOTFrostGiant),
               Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = HATEOTFrostGiant));

            var ability = Helpers.CreateAbility("Summon Frost Giants",
                "Summon Frost Giants",
               "Summon Frost Giants to your side",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonHATEOTFrostGiantresource4 = Helpers.CreateAbilityResource("SummonHATEOTFrostGiantresource4", "", "", "", null);
            SummonHATEOTFrostGiantresource4.SetFixedResource(1);

        }

        static void callErinyes()
        {
            var Erinyes = library.Get<BlueprintUnit>("0f36e9346d3f43948596f6a2ae41a5b8");
            var HATEOTFrostGiant = library.Get<BlueprintUnit>("6828d36959036054895d1b9cc0094d96");

            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = Erinyes),
               Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = Erinyes),
               Helpers.Create<CustomContextActionSpawnMonster9>(c => c.Blueprint = Erinyes)); //Spawns on his right (my left), move it down on the y axis

            var ability = Helpers.CreateAbility("Summon Erinyes Devils",
                "Summon Erinyes Devils",
               "Summon Erinyes Devils to your side",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonErinyesDevilsresource = Helpers.CreateAbilityResource("SummonErinyesDevilsresource4", "", "", "", null);
            SummonErinyesDevilsresource.SetFixedResource(1);

        }

        static void callPurpleWorms()
        {
            var PurpleWorm = library.Get<BlueprintUnit>("f647bb3c11f1478cbb47f150bceb0a1e");



            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = PurpleWorm),
               Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = PurpleWorm));


            var ability = Helpers.CreateAbility("Summon Elder Worms",
                "Summon Elder Worms",
               "Summon Elder Worms to your side",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonElderWormsresource = Helpers.CreateAbilityResource("SummonElderWormsresource4", "", "", "", null);
            SummonElderWormsresource.SetFixedResource(1);

        }

        static void callTreants()
        {
            var Treant = library.Get<BlueprintUnit>("5c322493e13040c3a36981ed67d6f590");



            var actions = Helpers.CreateRunActions(
               Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = Treant),
               Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = Treant));


            var ability = Helpers.CreateAbility("Summon Treants",
                "Summon Treants",
               "Summon Treants to your side",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonTreantresource = Helpers.CreateAbilityResource("SummonTreantresource", "", "", "", null);
            SummonTreantresource.SetFixedResource(1);

        }


        static void callbloodyboeastsdevourer()
        {
            var BloodyBonesBeast = library.Get<BlueprintUnit>("f68391521a2175647ab311fc64108574");

            var actions = Helpers.CreateRunActions(
                 Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = BloodyBonesBeast),
               Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = BloodyBonesBeast),
               Helpers.Create<CustomContextActionSpawnMonster9>(c => c.Blueprint = BloodyBonesBeast)); //Spawns on his right (my left), move it down on the y axis

            var ability = Helpers.CreateAbility("Summon Bloody Bones Beast",
                "Summon Bloody Bones Beast",
               "Summon Bloody Bones Beast to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonBloodyresource = Helpers.CreateAbilityResource("SummonBloodyresource", "", "", "", null);
            SummonBloodyresource.SetFixedResource(1);

        }


        static void callThanaedaemonPlaceholder()
        {
            var Thanamelee = library.Get<BlueprintUnit>("4573a45ceb974197b192db5fb52ab8cd"); 
             var Thanaranged = library.Get<BlueprintUnit>("536c295c5f604b9ca3ffb03a945c5620"); 
            

             var actions = Helpers.CreateRunActions(
                 Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = Thanamelee),
                 Helpers.Create<CustomContextActionSpawnMonster2>(c => c.Blueprint = Thanaranged),
                 Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = Thanamelee),
                 Helpers.Create<CustomContextActionSpawnMonster>(c => c.Blueprint = Thanaranged)); //Spawns on his right (my left), move it down on the y axis

            var ability = Helpers.CreateAbility("Summon Undead Minions",
                "Summon Undead Minions",
               "Summon undead to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonUndeadMinionsresource = Helpers.CreateAbilityResource("SummonUndeadMinionsresource", "", "", "", null);
            SummonUndeadMinionsresource.SetFixedResource(1);

        }

        static void callAstraldaemonSoulEaters()
        {
            var Astrasoul = library.Get<BlueprintUnit>("4603223d326a4eb598b7da6cad633683");
     


            var actions = Helpers.CreateRunActions(
                Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = Astrasoul),
                Helpers.Create<CustomContextActionSpawnMonster2>(c => c.Blueprint = Astrasoul),
                Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = Astrasoul),
                Helpers.Create<CustomContextActionSpawnMonster>(c => c.Blueprint = Astrasoul)); //Spawns on his right (my left), move it down on the y axis

            var ability = Helpers.CreateAbility("Summon Ancient Soul Eaters",
                "Summon Ancient Soul Eaters",
               "Summon Ancient Soul Eaters to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonAstralSoulsresource = Helpers.CreateAbilityResource("SummonAstralSoulsresource", "", "", "", null);
            SummonAstralSoulsresource.SetFixedResource(1);

        }



        static void callElementals()
        {
            var Elderearth = library.Get<BlueprintUnit>("672433d2f2e99764db2eadc6f595a2ba");
            var Elderfire = library.Get<BlueprintUnit>("d6b7b92ea00785f45b8e5a4bf8e87fa2");
            var Elderwater = library.Get<BlueprintUnit>("af612f1254e352641996915bc45d81b9");
            var Elderair = library.Get<BlueprintUnit>("ddca501b2cc606741a513483d9c928dc");

            var actions = Helpers.CreateRunActions(
                Helpers.Create<CustomContextActionSpawnMonster10>(c => c.Blueprint = Elderearth),
                Helpers.Create<CustomContextActionSpawnMonster9>(c => c.Blueprint = Elderfire),
                Helpers.Create<CustomContextActionSpawnMonster11>(c => c.Blueprint = Elderwater),
                Helpers.Create<CustomContextActionSpawnMonster7>(c => c.Blueprint = Elderair)); //Spawns on his right (my left), move it down on the y axis

            var ability = Helpers.CreateAbility("Summon Elder Elementals",
                "Summon Elder Elementals",
               "Summon Elder Elementals to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonElderElementalsresource = Helpers.CreateAbilityResource("SummonElderElementalsresource", "", "", "", null);
            SummonElderElementalsresource.SetFixedResource(1);

        }

        static void callElementalsTwo()
        {

            var greatfire = library.Get<BlueprintUnit>("5b7fc5f74b0195e42ba17f1d7e21a3c9");
            var greatearth = library.Get<BlueprintUnit>("55f39411dc3c9ef43aa61c2d7fe3bfc9");

            var actions = Helpers.CreateRunActions(
                Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = greatearth),
                Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = greatfire));

            var ability = Helpers.CreateAbility("Summon Greater Elementals",
                "Summon Greater Elementals",
               "Summon Greater Elementals to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonGreaterElementalsresource = Helpers.CreateAbilityResource("SummonGreaterElementalsresource", "", "", "", null);
            SummonGreaterElementalsresource.SetFixedResource(1);

        }

        static void callDryadHelpers()
        {
            var DryadHelp = library.Get<BlueprintUnit>("42b38b9a9dbb4d55b28bdeda516eeedd");
            var CR17Treant = library.Get<BlueprintUnit>("3d4ca2bc4dd44a3683709c389e3ef0e3");

            var actions = Helpers.CreateRunActions(
                 Helpers.Create<CustomContextActionSpawnMonster5>(c => c.Blueprint = DryadHelp),
               Helpers.Create<CustomContextActionSpawnMonster8>(c => c.Blueprint = DryadHelp)); //Spawns on his right (my left), move it down on the y axis

            var ability = Helpers.CreateAbility("Aid of the Forest",
                "Aid of the Forest",
               "Summon Forest Helpers to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonForestresource = Helpers.CreateAbilityResource("SummonForestresource", "", "", "", null);
            SummonForestresource.SetFixedResource(1);

        }


        static void callNeriedHelpers()
        {
            var nereidHelp = library.Get<BlueprintUnit>("9a9b22c8d9024798a36ef6848da7c7a2");
            var elderwater = library.Get<BlueprintUnit>("993612e826514bc9b3c6caaff5adefaa");

            var actions = Helpers.CreateRunActions(
                 Helpers.Create<CustomContextActionSpawnMonster13>(c => c.Blueprint = nereidHelp),
                 Helpers.Create<CustomContextActionSpawnMonster15>(c => c.Blueprint = nereidHelp),
               Helpers.Create<CustomContextActionSpawnMonster14>(c => c.Blueprint = elderwater)); //Spawns on his right (my left), move it down on the y axis

            var ability = Helpers.CreateAbility("Aid of the Lake",
                "Aid of the Lake",
               "Summon Lake Helpers to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var SummonLakeresource = Helpers.CreateAbilityResource("SummonLakeresource", "", "", "", null);
            SummonLakeresource.SetFixedResource(1);




        }


        static void callOozeHelpers()
        {
            var oozea = library.Get<BlueprintUnit>("6216383fc3ea4b8a950c7bdfcb707547");


            var actions = Helpers.CreateRunActions(
                Helpers.Create<CustomContextActionSpawnMonster16>(c => c.Blueprint = oozea),
                Helpers.Create<CustomContextActionSpawnMonster17>(c => c.Blueprint = oozea),
               Helpers.Create<CustomContextActionSpawnMonster18>(c => c.Blueprint = oozea)); //Spawns on his right (my left), move it down on the y axis

            var ability = Helpers.CreateAbility("Split",
                "Split",
               "Split and make more oozes",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var Summonoozeresource = Helpers.CreateAbilityResource("Summonoozeresource", "", "", "", null);
            Summonoozeresource.SetFixedResource(1);
        }


        static void calldeva()
        {
            var deva = library.Get<BlueprintUnit>("051dce1d2c60412d92a4c29081e18c08");

            var actions = Helpers.CreateRunActions(


                  Helpers.Create<CustomContextActionSpawnMonster21>(c => c.Blueprint = deva),
                Helpers.Create<CustomContextActionSpawnMonster19>(c => c.Blueprint = deva),
               Helpers.Create<CustomContextActionSpawnMonster20>(c => c.Blueprint = deva));

            var ability = Helpers.CreateAbility("Call Fallen",
                "Call Fallen",
               "Summon Fallen Deva to your side.",
                "",
                null,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityType.Extraordinary,
                Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Swift,
                Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close,
                "",
                "",
                actions);

            var summondeva_resource2 = Helpers.CreateAbilityResource("summondevaResource2", "", "", "", null);
            summondeva_resource2.SetFixedResource(2);

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