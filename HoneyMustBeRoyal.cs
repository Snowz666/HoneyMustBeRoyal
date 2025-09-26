using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;

using HarmonyLib;

namespace HoneyMustBeRoyal;


[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class HoneyPlugin : BasePlugin
{
    internal static new ManualLogSource Log;

    private Harmony _harmony;
    public override void Load()
    {
        Log = base.Log;
        _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        _harmony.PatchAll();

        try
        {
            _harmony.PatchAll();
            Log.LogDebug("Apply Harmony patch successed.");
        }
        catch (System.Exception ex)
        {
            Log.LogError($"Apply Harmony patch failed: {ex.Message}");
            Log.LogDebug($"Exception msg: {ex}");
        }

        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
}
