using GameNetcodeStuff;
using HarmonyLib;
using System.Runtime.CompilerServices;

namespace GodMode
{
    internal class Patcher
    {
        [HarmonyPatch(typeof(PlayerControllerB), "AllowPlayerDeath")]
        [HarmonyPrefix]
        private static bool NoDie() => false;

        [HarmonyPatch(typeof(PlayerControllerB), "Update")]
        [HarmonyPostfix]
        private static void update(ref int ___health) {
            ___health = 1000;
        }
    }
}
