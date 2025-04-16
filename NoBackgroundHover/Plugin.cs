using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace NoBackgroundHover 
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class NoBackgroundHoverBase : BaseUnityPlugin
    {
        private const string modGUID = "toejune.NoBackgroundHover";
        private const string modName = "NoBackgroundHover";
        private const string modVersion = "1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static NoBackgroundHoverBase Instance;

        internal static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("NoBackgroundHover started.");

            harmony.PatchAll(typeof(NoBackgroundHoverBase));
            harmony.PatchAll(typeof(NoBackgroundHover.Patches.NoBackgroundHover));
            harmony.PatchAll(typeof(NoBackgroundHover.Patches.NoBackgroundHover_Stub));
        }
    }
}
