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
        internal static ManualLogSource mls;
        // player
        internal static ConfigEntry<bool> immortality;
        internal static ConfigEntry<bool> setHealth;
        internal static ConfigEntry<int> healthNum;
        internal static ConfigEntry<bool> infStamina;

        // monsters
        internal static ConfigEntry<bool> brackenSnap;
        internal static ConfigEntry<bool> fleaWrap;
        internal static ConfigEntry<bool> maskGrab;
        internal static ConfigEntry<bool> giantGrab;

        void Awake()
        {
            configs();
            if (instance == null) instance = this;
            mls = BepInEx.Logging.Logger.CreateLogSource("fenicemaster.GodMode");
            harmony.PatchAll(typeof(GodMode));
            harmony.PatchAll(typeof(PlayerPatch));
            harmony.PatchAll(typeof(MonsterPatch));
            mls.LogInfo("GodMode is loaded");
        }

        void configs()
        {
            // players' mortality
            immortality = Config.Bind<bool>("Player", "Disable death", true, "Disable player death.");
            setHealth = Config.Bind<bool>("Player", "Modify health", true, "Every update the health is set to the specified amount.");
            healthNum = Config.Bind<int>("Player", "Health amount", 1000, "The amount of health to have");
            infStamina = Config.Bind<bool>("Player", "Infinite stamina", true, "The stamina bar won't go down.");

            // monsters' colliders
            brackenSnap = Config.Bind<bool>("Monsters", "Bracken snap", true, "Disable bracken snapping your neck.");
            fleaWrap = Config.Bind<bool>("Monsters", "Flea wrap", true, "Disable flea wrapping on your head.");
            maskGrab = Config.Bind<bool>("Monsters", "Mask grab", true, "Disable mask grabbing you.");
            giantGrab = Config.Bind<bool>("Monsters", "Giant grab", true, "Disable giant grabbing you.");
        }

        public ManualLogSource GetManualLogSource() { return mls; }
    }
}
