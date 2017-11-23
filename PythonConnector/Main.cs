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
            API.onResourceStart += Init;
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
