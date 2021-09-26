using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace IMIRT.SaveSystem.Assets._2DGamekit.Libs.SaveSystem.Editor
{
    public class ChangePCStore
    {
#if UNITY_STANDALONE && !STEAM_BUILD
        [MenuItem("Build/Switch to Steam")]
#endif
        public static void SwitchToSteam()
        {
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            defines = AddCompilerDefines(defines, "STEAM_BUILD");
            defines = AddCompilerDefines(defines, "SAVE_TO_PREFS");
            defines = RemoveCompilerDefines(defines, "GOG_BUILD");

            UnityEngine.Debug.Log("Compiling with DEFINE: '" + defines + "'");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, defines);
        }

#if UNITY_STANDALONE && !GOG_BUILD
        [MenuItem("Build/Switch to GOG")]
#endif
        public static void SwitchToGOG()
        {
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            defines = AddCompilerDefines(defines, "GOG_BUILD");
            defines = RemoveCompilerDefines(defines, "STEAM_BUILD");

            UnityEngine.Debug.Log("Compiling with DEFINE: '" + defines + "'");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, defines);
        }

#if UNITY_STANDALONE && (STEAM_BUILD || GOG_BUILD)
  [MenuItem("Build/Switch to No Platform")]
#endif
        public static void SwitchToNoPlatform()
        {
            string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
            defines = RemoveCompilerDefines(defines, "STEAM_BUILD", "GOG_BUILD");

            UnityEngine.Debug.Log("Compiling with DEFINE: '" + defines + "'");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, defines);
        }

        private static string AddCompilerDefines(string defines, params string[] toAdd)
        {
            List<string> splitDefines = new List<string>(defines.Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries));
            foreach (var add in toAdd)
                if (!splitDefines.Contains(add))
                    splitDefines.Add(add);

            return string.Join(";", splitDefines.ToArray());
        }

        private static string RemoveCompilerDefines(string defines, params string[] toRemove)
        {
            List<string> splitDefines = new List<string>(defines.Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries));
            foreach (var remove in toRemove)
                splitDefines.Remove(remove);

            return string.Join(";", splitDefines.ToArray());
        }
    }
}
