using BepInEx.Configuration;
using GameNetcodeStuff;
using HarmonyLib;

namespace GodMode
{
    internal class PlayerPatch
    {
        private static bool nodie, health;
        private static int healthN;

        void Awake()
        {
            nodie = GodMode.immortality.Value;
            health = GodMode.health_patch.Value;
            healthN = GodMode.health_number.Value;
        }

        [HarmonyPatch(typeof(PlayerControllerB), "AllowPlayerDeath")]
        [HarmonyPrefix]
        private static bool NoDie(ref bool __result)
        {
            if (nodie)
            {
                __result = false;
                return false;
            }
            return true;
        }

        [HarmonyPatch(typeof(PlayerControllerB), "Update")]
        [HarmonyPostfix]
        private static void update(ref int ___health)
        {
            if (health) ___health = healthN;
        }
    }
}
