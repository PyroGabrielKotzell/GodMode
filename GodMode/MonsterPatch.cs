using HarmonyLib;

namespace GodMode
{
    internal class MonsterPatch
    {
        [HarmonyPatch(typeof(FlowermanAI), "OnCollideWithPlayer")]
        [HarmonyPrefix]
        private static bool brackenSnap()
        {
            return !GodMode.brackenSnap.Value;
        }

        [HarmonyPatch(typeof(CentipedeAI), "OnCollideWithPlayer")]
        [HarmonyPrefix]
        private static bool snareWrap()
        {
            return !GodMode.fleaWrap.Value;
        }
        
        [HarmonyPatch(typeof(MaskedPlayerEnemy), "OnCollideWithPlayer")]
        [HarmonyPrefix]
        private static bool maskGrab()
        {
            return !GodMode.maskGrab.Value;
        }

        [HarmonyPatch(typeof(ForestGiantAI), "OnCollideWithPlayer")]
        [HarmonyPrefix]
        private static bool giantWrap()
        {
            return !GodMode.giantGrab.Value;
        }
    }
}
