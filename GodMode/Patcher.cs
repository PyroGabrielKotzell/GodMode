using GameNetcodeStuff;
using HarmonyLib;

namespace GodMode
{
    internal class Patcher
    {
        [HarmonyPatch(typeof(PlayerControllerB), "AllowPlayerDeath")]
        [HarmonyPrefix]
        private static void NoDie(ref bool __result)
        {
            if (GodMode.immortality.Value) __result = false;
        }

        [HarmonyPatch(typeof(PlayerControllerB), "Update")]
        [HarmonyPostfix]
        private static void update(ref int ___health) {
            ___health = 1000;
        }
    }
}
