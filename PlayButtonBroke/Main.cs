using BepInEx;
using HarmonyLib;

namespace PlayButtonBroke
{
    [BepInPlugin("srxd.raoul1808.playbuttonbroke", "Play Button Broke", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Patches));
        }
    }

    class Patches
    {
        [HarmonyPatch(typeof(XDLevelSelectMenuBase), "PlayTrack")]
        [HarmonyPrefix]
        private static bool NoTrackPlayageForYou() => false;

        [HarmonyPatch(typeof(XDCustomLevelSelectMenu), "EditTrack")]
        [HarmonyPrefix]
        private static bool NoTrackEditageForYouEither() => false;
    }
}
