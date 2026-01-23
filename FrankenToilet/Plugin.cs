using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using FrankenToilet.Core;
using HarmonyLib;
using UnityEngine;
using static FrankenToilet.Core.LogHelper;

namespace FrankenToilet;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public sealed class Plugin : BaseUnityPlugin
{
    internal new static ManualLogSource Logger { get; private set; } = null!;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        gameObject.hideFlags = HideFlags.DontSaveInEditor;
        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        var startupPatchers = typeof(Plugin).Assembly
                      .GetTypes()
                      .Where(static t => t.GetCustomAttribute<PatchOnEntryAttribute>() != null);
        foreach (var startupPatcher in startupPatchers)
            harmony.PatchAll(startupPatcher);
        LogInfo("Patches applied");
    }
}