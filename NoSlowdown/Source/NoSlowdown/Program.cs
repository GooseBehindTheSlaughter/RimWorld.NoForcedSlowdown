using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;

public class Program : Mod
{
    public Program(ModContentPack content) : base(content)
    {
            Harmony harmony = new Harmony("TheGooseBehindTheSlaughter.FuckForceSlowdown");
            harmony.PatchAll();
    }

    //Verse.TimeSlower
    [HarmonyPatch]
    public static class SlowDown_Patch
    {
        [HarmonyPatch(typeof(TimeSlower), nameof(TimeSlower.SignalForceNormalSpeed))]
        [HarmonyPrefix]
        public static void SignalForceNormalSpeed(TimeSlower __instance)
        {
            DebugViewSettings.neverForceNormalSpeed = true;
        }

        [HarmonyPatch(typeof(TimeSlower), nameof(TimeSlower.SignalForceNormalSpeedShort))]
        [HarmonyPrefix]
        public static void SignalForceNormalSpeedShort(TimeSlower __instance)
        {
            DebugViewSettings.neverForceNormalSpeed = true;
        }
    }
}

