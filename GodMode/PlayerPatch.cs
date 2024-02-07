using BepInEx.Configuration;
using GameNetcodeStuff;
using HarmonyLib;

namespace GodMode
{
    internal class PlayerPatch
    {
        [HarmonyPatch(typeof(PlayerControllerB), "AllowPlayerDeath")]
        [HarmonyPrefix]
        private static bool NoDie(ref bool __result)
        {
            if (GodMode.immortality.Value)
            {
                __result = false;
                return false;
            }
            return true;
        }

        [HarmonyPatch(typeof(PlayerControllerB), "Update")]
        [HarmonyPostfix]
        private static void update(ref int ___health, ref float ___sprintMeter)
        {
            if (GodMode.setHealth.Value) ___health = GodMode.healthNum.Value;
            if (GodMode.infStamina.Value) ___sprintMeter = 1f;
        }

        /*
        InputAction inputAction = new InputAction(null, 0, "<Keyboard>/" + Plugin.cfgKeyBind.Value, null, null, null);
		inputAction.performed += this.OnInsertKeyPressed;
		inputAction.Enable();

        [HarmonyPatch(typeof(PlayerControllerB), "BeginGrabObject")]
        [HarmonyPostfix]
        static void UpdateBeginGrabObject(ref bool ___twoHanded)
        {
            ___twoHanded = false;
        }

        [HarmonyPatch(typeof(PlayerControllerB), "GrabObjectClientRpc")]
        [HarmonyPostfix]
        static void UpdateGrabObjectClientRpc(ref bool ___twoHanded)
        {
            ___twoHanded = false;
        }

        [HarmonyPatch(typeof(PlayerControllerB), "SwitchToItemSlot")]
        [HarmonyPostfix]
        static void UpdateSwitchToItemSlot(ref bool ___twoHanded)
        {
            ___twoHanded = false;
        }

         */
    }
}
