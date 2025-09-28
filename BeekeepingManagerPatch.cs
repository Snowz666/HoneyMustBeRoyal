using BokuMono;
using BokuMono.Data;
using HarmonyLib;
using Il2CppSystem.Collections.Generic;
using HoneyMustBeRoyal;

[HarmonyPatch(typeof(BeekeepingManager))]
public class BeekeepingManagerPatch
{

    [HarmonyPatch("AddCollectableFlowerInfo")]
    [HarmonyPrefix]
    static void PrefixAddCollectableFlowerInfo(ref BeekeepingManager.HarvestFlowerInfo info)
    {
        HoneyPlugin.Log.LogDebug($"Modify RandomValue : {info.RandomValue} -> 1.");
        info.RandomValue = 1;
    }
    

    [HarmonyPatch("TryCollectHoneycombFromFlowerInfo")]
    [HarmonyPostfix]
    static void PostfixTryCollectHoneycomb(BeekeepingManager.HarvestFlowerInfo info, ref Dictionary<uint, List<ItemData>> itemDataDic, ref List<ItemData> extras, ref bool __result)
    {
        __result = true;
        
        if (extras != null)
        {
            HoneyPlugin.Log.LogDebug($"RandomValue={info.RandomValue}, Result: {__result}, Royal Count = {extras.Count}");
        }
        else
        {
            HoneyPlugin.Log.LogWarning($"Variable 'extras' is null! ");
        }
        
    }
}