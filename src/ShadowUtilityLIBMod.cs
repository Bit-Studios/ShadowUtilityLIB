﻿using SpaceWarp.API.Mods;
using SpaceWarp;
using BepInEx;
using Logger = ShadowUtilityLIB.logging.Logger;
using KSP.Game;
using KSP.Messages;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using SpaceWarp.API.Assets;
using ShadowUtilityLIB.UI;
using HarmonyLib;
using UitkForKsp2;
using UnityEngine.UIElements;

namespace ShadowUtilityLIB;
public class CoroutineExecuter : MonoBehaviour { }

[BepInPlugin("com.shadowdev.utilitylib", "Shadow Utility LIB", "0.0.4")]
[BepInDependency(SpaceWarpPlugin.ModGuid, SpaceWarpPlugin.ModVer)]
public sealed class ShadowUtilityLIBMod : BaseSpaceWarpPlugin
{
    public const string ModId = "com.shadowdev.utilitylib";
    public const string ModName = "Shadow Utility Lib";
    public const string ModVersion = "0.0.4";
    public static bool IsDev = false;
    private static Logger logger = new Logger(ModName, ModVersion);
    private static CoroutineExecuter instance;
    public static bool Initilised = false;
    public static Texture2D MIcon { get; set; }
    public static bool runALlogo = false;
    public override void OnInitialized()
    {
        var panelSettings = AssetManager.GetAsset<PanelSettings>($"{SpaceWarpMetadata.ModID}/shadowutilitylib/theme/panelsettings.asset");
        panelSettings.m_AtlasBlitShader = UitkForKsp2Plugin.PanelSettings.m_AtlasBlitShader;
        panelSettings.m_RuntimeShader = UitkForKsp2Plugin.PanelSettings.m_RuntimeShader;
        panelSettings.m_RuntimeWorldShader = UitkForKsp2Plugin.PanelSettings.m_RuntimeWorldShader;
        Manager.PanelSettings = panelSettings;

        instance = new GameObject("CoroutineExecuter").AddComponent<CoroutineExecuter>();
        try
        {
            Harmony.CreateAndPatchAll(typeof(DropdownUtils));
        }
        catch (Exception e)
        {
            logger.Error($"{e}\n{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}\n{e.GetBaseException()}");
        }
        GameManager.Instance.Game.Messages.Subscribe<GameStateChangedMessage>(AppBar.StateChange);

        logger.Log($"Initialized");


        Initilised = true;
    }
    public static void EnableDebugMode()
    {
        IsDev = true;
        logger.Debug("Debug Mode Enabled");
    }
    public static void RunCr(IEnumerator cr)
    {
        instance.StartCoroutine(cr);
    }
    void Awake()
    {

        try
        {
            if (Directory.Exists("./logs")) { }
            else
            {
                Directory.CreateDirectory("./logs");
            }

        }
        catch (Exception e)
        {
            logger.Error($"{e}\n{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}\n{e.GetBaseException()}");
        }
        foreach (string logFileLocation in Directory.GetFiles("./", "*.sl"))
        {
            File.Move($"./{logFileLocation}", $"./logs/{logFileLocation}{DateTime.Now.ToFileTimeUtc().ToString()}.sl");
            logger.Debug(logFileLocation);
        }

        logger.Log($"Awake");
    }
}