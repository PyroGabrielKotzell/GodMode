using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;

namespace GodMode
{
    [BepInPlugin("fenicemaster.GodMode", "GodMode", "1.0.0")]
    public class GodMode : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("fenicemaster.GodMode");
        public static GodMode instance;
        internal ManualLogSource mls;
        public static ConfigEntry<bool> immortality;
        public static ConfigEntry<bool> health_patch;
        public static ConfigEntry<int> health_number;

        void Awake()
        {
            GodMode.immortality = base.Config.Bind<bool>("GodMode", "Disable death", true, "Disable player death.");
            GodMode.health_patch = base.Config.Bind<bool>("GodMode", "Modify health", true, "Every update the health is set to the specified amount.");
            GodMode.health_number = base.Config.Bind<int>("GodMode", "Health amount", 1000, "The amount of health to have");
            if (instance == null) instance = this;
            mls = BepInEx.Logging.Logger.CreateLogSource("fenicemaster.GodMode");
            harmony.PatchAll(typeof(GodMode));
            harmony.PatchAll(typeof(Patcher));
            mls.LogInfo("GodMode is loaded");
        }

        public ManualLogSource GetManualLogSource() { return mls; }
    }
}
