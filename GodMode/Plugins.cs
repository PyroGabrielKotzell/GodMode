using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace GodMode
{
    [BepInPlugin("fenicemaster.GodMode", "GodMode", "1.0.0")]
    public class GodMode : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("fenicemaster.GodMode");
        public static GodMode instance;
        internal ManualLogSource mls;
        void Awake()
        {
            if (instance == null) instance = this;
            mls = BepInEx.Logging.Logger.CreateLogSource("fenicemaster.GodMode");
            harmony.PatchAll(typeof(GodMode));
            harmony.PatchAll(typeof(Patcher));
            mls.LogInfo("GodMode is loaded");
        }
    }
}
