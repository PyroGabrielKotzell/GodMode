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
        public static ConfigEntry<uint> health_number;

        public static ConfigEntry<bool> brackenSnap;
        public static ConfigEntry<bool> fleaWrap;
        public static ConfigEntry<bool> maskGrab;
        public static ConfigEntry<bool> giantGrab;

        void Awake()
        {
            configs();
            if (instance == null) instance = this;
            mls = BepInEx.Logging.Logger.CreateLogSource("fenicemaster.GodMode");
            harmony.PatchAll(typeof(GodMode));
            harmony.PatchAll(typeof(PlayerPatch));
            mls.LogInfo("GodMode is loaded");
        }

        void configs()
        {
            // players' mortality
            immortality = base.Config.Bind<bool>("Player", "Disable death", true, "Disable player death.");
            health_patch = base.Config.Bind<bool>("Player", "Modify health", true, "Every update the health is set to the specified amount.");
            health_number = base.Config.Bind<uint>("Player", "Health amount", 1000, "The amount of health to have");

            // monsters' colliders
            brackenSnap = base.Config.Bind<bool>("Monsters", "Bracken snap", true, "Disable bracken snapping your neck.");
            fleaWrap = base.Config.Bind<bool>("Monsters", "Flea wrap", true, "Disable flea wrapping on your head.");
            maskGrab = base.Config.Bind<bool>("Monsters", "Mask grab", true, "Disable mask grabbing you.");
            giantGrab = base.Config.Bind<bool>("Monsters", "Giant grab", true, "Disable giant grabbing you.");
        }

        public ManualLogSource GetManualLogSource() { return mls; }
    }
}
