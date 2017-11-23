using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared;

using IronPython.Hosting;
using IronPython.Runtime;
using IronPython.Runtime.Types;
using IronPython;

namespace PythonConnector
{
    public class Server
    {
        //public static PythonType API = DynamicHelpers.GetPythonTypeFromType(typeof(API));
        public static API API = new API();
        public static PythonType Vector3 = DynamicHelpers.GetPythonTypeFromType(typeof(GrandTheftMultiplayer.Shared.Math.Vector3));
        public static PythonType Quaternion = DynamicHelpers.GetPythonTypeFromType(typeof(GrandTheftMultiplayer.Shared.Math.Quaternion));
        public static PythonType Matrix4 = DynamicHelpers.GetPythonTypeFromType(typeof(GrandTheftMultiplayer.Shared.Math.Matrix4));

        public static PythonType WeaponHash = DynamicHelpers.GetPythonTypeFromType(typeof(WeaponHash));
        public static PythonType VehicleHash = DynamicHelpers.GetPythonTypeFromType(typeof(VehicleHash));
    }
}
