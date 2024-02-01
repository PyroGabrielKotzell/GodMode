using BepInEx.Configuration;
using GameNetcodeStuff;
using HarmonyLib;

namespace GodMode
{
    internal class Patcher
    {
        private static bool nodie, health;
        private static uint healthN;

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
            if (health) ___health = (int)healthN;
        }

        /*
         [HarmonyPatch(typeof(MaskedPlayerEnemy), "OnCollideWithPlayer")]
		[HarmonyPrefix]
		public static bool MaskedKillAnimationPatch()
		{
			return SyncedInstance<Config>.Instance.MaskedDup;
		}

		[HarmonyPatch(typeof(FlowermanAI), "OnCollideWithPlayer")]
		[HarmonyPrefix]
		public static bool BrackenKillAnimationPatch()
		{
			return SyncedInstance<Config>.Instance.BrackenKill;
		}

		[HarmonyPatch(typeof(CentipedeAI), "OnCollideWithPlayer")]
		[HarmonyPrefix]
		public static bool FleaKillAnimationPatch()
		{
			return SyncedInstance<Config>.Instance.FleaCling;
		}

		[HarmonyPatch(typeof(ForestGiantAI), "OnCollideWithPlayer")]
		[HarmonyPrefix]
		public static bool GiantKillAnimationPatch()
		{
			return SyncedInstance<Config>.Instance.GiantKill;
		}*/
    }
}
