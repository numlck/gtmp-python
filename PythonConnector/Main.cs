using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Util;
using GrandTheftMultiplayer;

using IronPython.Hosting;
using IronPython.Runtime;
using IronPython.Runtime.Types;
using IronPython;
using Microsoft.Scripting.Hosting;

namespace PythonConnector
{
    public class Connector : Script
    {
        static ScriptEngine engine = Python.CreateEngine();
        ScriptScope scope = engine.CreateScope();
        public Connector()
        {
            API.onServerResourceStart += OnServerResourceStart;
            API.onServerResourceStop += OnServerResourceStop;

            API.onResourceStart += Init;
            API.onResourceStop += OnResourceStop;

            API.onPlayerBeginConnect += OnPlayerBeginConnect;

            API.onChatCommand += OnChatCommand;
            API.onChatMessage += OnChatMessage;

            API.onClientEventTrigger += OnClientEventTrigger;

            API.onPlayerBeginConnect += OnPlayerBeginConnect;
            API.onPlayerConnected += OnPlayerConnected;
            API.onPlayerDisconnected += OnPlayerDisconnected;
            API.onPlayerFinishedDownload += OnPlayerFinishedDownload;

            API.onUpdate += OnUpdate;

            API.onEntityDataChange += OnEntityDataChange;
            API.onEntityEnterColShape += OnEntityEnterColShape;
            API.onEntityExitColShape += OnEntityExitColShape;
            API.onEntityMovingPositionFinished += OnEntityMovingPositionFinished;
            API.onEntityMovingRotationFinished += OnEntityMovingRotationFinished;
            API.onPickupRespawn += OnPickupRespawn;
            API.onMapChange += OnMapChange;
            API.onPlayerArmorChange += OnPlayerArmorChange;
            API.onPlayerDeath += OnPlayerDeath;
            API.onPlayerDetonateStickies += OnPlayerDetonateStickies;
            API.onPlayerEnterVehicle += OnPlayerEnterVehicle;
            API.onPlayerExitVehicle += OnPlayerExitVehicle;

            API.onPlayerHealthChange += OnPlayerHealthChange;
            API.onPlayerModelChange += OnPlayerModelChange;
            API.onPlayerPickup += OnPlayerPickup;
            API.onPlayerRespawn += OnPlayerRespawn;
            API.onPlayerWeaponAmmoChange += OnPlayerWeaponAmmoChange;
            API.onPlayerWeaponSwitch += OnPlayerWeaponSwitch;
            API.onPlayerChangeVehicleSeat += OnPlayerChangeVehicleSeat;

            API.onVehicleDeath += OnVehicleDeath;
            API.onVehicleDoorBreak += OnVehicleDoorBreak;
            API.onVehicleHealthChange += OnVehicleHealthChange;
            API.onVehicleSirenToggle += OnVehicleSirenToggle;
            API.onVehicleTrailerChange += OnVehicleTrailerChange;
            API.onVehicleTyreBurst += OnVehicleTyreBurst;
            API.onVehicleWindowSmash += OnVehicleWindowSmash;

        }
        private void OnPlayerChangeVehicleSeat(Client player, NetHandle vehicle, int oldSeat, int newSeat)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerChangeVehicleSeat");
                f(player, vehicle, oldSeat, newSeat);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnMapChange(string mapName, XmlGroup map)
        {
            try
            {
                var f = scope.GetVariable("OnMapChange");
                f(mapName, map);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnEntityMovingPositionFinished(NetHandle entity)
        {
            try
            {
                var f = scope.GetVariable("OnEntityMovingPositionFinished");
                f(entity);
            }
            catch (System.MissingMemberException e)
            {

            }

        }
       
        private void OnEntityMovingRotationFinished(NetHandle entity)
        {
            try
            {
                var f = scope.GetVariable("OnEntityMovingRotationFinished");
                f(entity);
            }
            catch (System.MissingMemberException e)
            {

            }

        }
        private void OnVehicleWindowSmash(NetHandle entity, int index)
        {
            try
            {
                var f = scope.GetVariable("OnVehicleWindowSmash");
                f(entity, index);
            }
            catch (System.MissingMemberException e)
            {

            }
 
        }

        private void OnVehicleTyreBurst(NetHandle entity, int index)
        {
            try
            {
                var f = scope.GetVariable("OnVehicleTyreBurst");
                f(entity, index);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnVehicleTrailerChange(NetHandle tower, NetHandle trailer)
        {
            try
            {
                var f = scope.GetVariable("OnVehicleTrailerChange");
                f(tower, trailer);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnVehicleSirenToggle(NetHandle entity, bool oldValue)
        {
            try
            {
                var f = scope.GetVariable("OnVehicleSirenToggle");
                f(entity, oldValue);
            }
            catch (System.MissingMemberException e)
            {

            }
        }

        private void OnVehicleHealthChange(NetHandle entity, float oldValue)
        {
            try
            {
                var f = scope.GetVariable("OnVehicleHealthChange");
                f(entity, oldValue);
            }
            catch (System.MissingMemberException e)
            {

            }


        }

        private void OnVehicleDoorBreak(NetHandle entity, int index)
        {
            try
            {
                var f = scope.GetVariable("OnVehicleDoorBreak");
                f(entity, index);
            }
            catch (System.MissingMemberException e)
            {

            }


        }

        private void OnVehicleDeath(NetHandle entity)
        {
            try
            {
                var f = scope.GetVariable("OnVehicleDeath");
                f(entity);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPlayerWeaponSwitch(Client player, WeaponHash oldValue)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerWeaponSwitch");
                f(player, oldValue);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPlayerWeaponAmmoChange(Client player, WeaponHash weapon, int oldValue)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerWeaponAmmoChange");
                f(player, weapon, oldValue);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPlayerRespawn(Client player)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerRespawn");
                f(player);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPlayerPickup(Client pickupee, NetHandle pickupHandle)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerPickup");
                f(pickupee, pickupHandle);
            }
            catch (System.MissingMemberException e)
            {

            }
        }

        private void OnPlayerModelChange(Client player, int oldValue)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerModelChange");
                f(player, oldValue);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPlayerHealthChange(Client player, int oldValue)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerHealthChange");
                f(player, oldValue);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPlayerFinishedDownload(Client player)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerFinishedDownload");
                f(player);
            }
            catch (System.MissingMemberException e)
            {

            }

    
        }

        private void OnPlayerExitVehicle(Client player, NetHandle vehicle, int targetSeat)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerExitVehicle");
                f(player, vehicle, targetSeat);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPlayerEnterVehicle(Client player, NetHandle vehicle, int targetSeat)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerEnterVehicle");
                f(player, vehicle, targetSeat);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPlayerDetonateStickies(Client player)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerDetonateStickies");
                f(player);
            }
            catch (System.MissingMemberException e)
            {

            }
        }

        private void OnPlayerDeath(Client player, NetHandle entityKiller, int weapon)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerDeath");
                f(player, entityKiller, weapon);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

 
        private void OnPlayerArmorChange(Client player, int oldValue)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerArmorChange");
                f(player, oldValue);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPickupRespawn(NetHandle entity)
        {
            try
            {
                var f = scope.GetVariable("OnPickupRespawn");
                f(entity);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnEntityExitColShape(ColShape colshape, NetHandle entity)
        {
            try
            {
                var f = scope.GetVariable("OnEntityExitColShape");
                f(colshape, entity);
            }
            catch (System.MissingMemberException e)
            {

            }
        }

        private void OnEntityEnterColShape(ColShape colshape, NetHandle entity)
        {
            try
            {
                var f = scope.GetVariable("OnEntityEnterColShape");
                f(colshape, entity);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnEntityDataChange(NetHandle entity, string key, object oldValue)
        {
            try
            {
                var f = scope.GetVariable("OnEntityDataChange");
                f(entity, key, oldValue);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnUpdate()
        {
            try
            {
                var f = scope.GetVariable("OnUpdate");
                f();
            }
            catch (System.MissingMemberException e)
            {

            }
        }

        private void OnPlayerConnected(Client player)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerConnected");
                f(player);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnPlayerDisconnected(Client player, string reason)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerDisconnected");
                f(player, reason);
            }
            catch (System.MissingMemberException e)
            {

            }

        }

        private void OnClientEventTrigger(Client sender, string eventName, object[] arguments)
        {
            try
            {
                var f = scope.GetVariable("OnClientEventTrigger");
                f(sender, eventName, arguments);
            }
            catch (System.MissingMemberException e)
            {

            }
        }

        private void OnChatMessage(Client sender, string message, CancelEventArgs cancel)
        {
            try
            {
                var f = scope.GetVariable("OnChatMessage");
                f(sender, message, cancel);
            }
            catch (System.MissingMemberException e)
            {

            }
        }

        private void OnChatCommand(Client sender, string command, CancelEventArgs cancel)
        {
            try
            {
                var f = scope.GetVariable("OnChatCommand");
                f(sender, command, cancel);
            }
            catch (System.MissingMemberException e)
            {

            }
        }

        private void OnPlayerBeginConnect(Client player, CancelEventArgs cancelConnection)
        {
            try
            {
                var f = scope.GetVariable("OnPlayerBeginConnect");
                f(player, cancelConnection);
            }
            catch (System.MissingMemberException e)
            {

            }
        }
        private void OnResourceStop()
        {
            try
            {
                var f = scope.GetVariable("OnResourceStop");
                f();
            }
            catch (System.MissingMemberException e)
            {

            }
        }
        private void OnServerResourceStart(string resource)
        {
            try
            {
                var f = scope.GetVariable("OnServerResourceStart");
                f(resource);
            }
            catch (System.MissingMemberException e)
            {

            }
        }
        private void OnServerResourceStop(string resource)
        {
            try
            {
                var f = scope.GetVariable("OnResourceStop");
                f(resource);
            }
            catch (System.MissingMemberException e)
            {

            }
        }
        public void Init()
        {
            API.consoleOutput("Starting \"PythonConnector\" Script!");
            ScriptEngine engine = Python.CreateEngine();
            string initFilePath = API.getSetting<string>("pythonstart");

            var paths = engine.GetSearchPaths();
            paths.Add("C:/Program Files (x86)/IronPython 2.7/Lib");
            paths.Add("resources/PythonConnector");
            paths.Add(new FileInfo("resources/PythonConnector/" + initFilePath).Directory.FullName);
            engine.SetSearchPaths(paths);

            string initFile = File.ReadAllText("resources/PythonConnector/"+initFilePath);

            ScriptSource source = engine.CreateScriptSourceFromString(initFile);
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("scope", scope);
            scope.SetVariable("API", API);
            scope.SetVariable("Vector3", DynamicHelpers.GetPythonTypeFromType(typeof(GrandTheftMultiplayer.Shared.Math.Vector3)));
            scope.SetVariable("Quaternion", DynamicHelpers.GetPythonTypeFromType(typeof(GrandTheftMultiplayer.Shared.Math.Quaternion)));
            scope.SetVariable("Matrix4", DynamicHelpers.GetPythonTypeFromType(typeof(GrandTheftMultiplayer.Shared.Math.Matrix4)));

            scope.SetVariable("WeaponHash", DynamicHelpers.GetPythonTypeFromType(typeof(WeaponHash)));
            scope.SetVariable("VehicleHash", DynamicHelpers.GetPythonTypeFromType(typeof(VehicleHash)));
            try
            {
                source.Execute(scope);
            }
            catch (System.Exception e)
            {
                API.consoleOutput(engine.GetService<ExceptionOperations>().FormatException(e));
            }
        }
    }
}
