using HarmonyLib;

namespace GodMode
{
    internal class MonsterPatch
    {
        private static bool bracken, flea, masked, giant;

        void Awake()
        {
            bracken = GodMode.brackenSnap.Value;
            flea = GodMode.fleaWrap.Value;
            masked = GodMode.maskGrab.Value;
            giant = GodMode.giantGrab.Value;
        }

        [HarmonyPatch(typeof(FlowermanAI), "OnCollideWithPlayer")]
        [HarmonyPrefix]
        private static bool brackenSnap()
        {
            return !bracken;
        }

        [HarmonyPatch(typeof(CentipedeAI), "OnCollideWithPlayer")]
        [HarmonyPrefix]
        private static bool snareWrap()
        {
            return !flea;
        }
        
        [HarmonyPatch(typeof(MaskedPlayerEnemy), "OnCollideWithPlayer")]
        [HarmonyPrefix]
        private static bool maskGrab()
        {
            return !masked;
        }

        [HarmonyPatch(typeof(ForestGiantAI), "OnCollideWithPlayer")]
        [HarmonyPrefix]
        private static bool giantWrap()
        {
            return !giant;
        }
    }
}
