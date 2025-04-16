using HarmonyLib;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace NoBackgroundHover.Patches
{
    [HarmonyPatch(typeof(MenuButton))]
    internal class NoBackgroundHover_Stub : MonoBehaviour
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();

        private static bool IsGameFocused() => GetForegroundWindow() == GetActiveWindow();

        private static bool _initialized = false;
        public bool IsInitialized() => _initialized;

        [HarmonyPatch(typeof(MenuButton), "Awake")]
        [HarmonyPostfix]
        public static void Awake_Postfix(MenuButton __instance)
        {
            __instance.enabled = IsGameFocused();
            _initialized = true;
        }
    }
}
