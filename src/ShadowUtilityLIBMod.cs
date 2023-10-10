using Logger = ShadowUtilityLIB.logging.Logger;
using KSP.Game;
using KSP.Messages;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using ShadowUtilityLIB.UI;
using HarmonyLib;
using UitkForKsp2;
using UnityEngine.UIElements;
using KSP.Modding;
using BepInEx;
using SpaceWarp.API.Mods;
using SpaceWarp.API.Assets;
using SpaceWarp;

namespace ShadowUtilityLIB;
public class CoroutineExecuter : MonoBehaviour { }

[BepInPlugin("com.shadowdev.utilitylib", "shadowutilitylib", "0.0.7")]
[BepInDependency(SpaceWarpPlugin.ModGuid, SpaceWarpPlugin.ModVer)]
public sealed class ShadowUtilityLIBMod : BaseSpaceWarpPlugin
{
    public const string ModId = "shadowutilitylib";
    public static bool IsDev = false;
    private static Logger logger = new Logger(ModId, "0.1.0");
    private static CoroutineExecuter instance;
    public static bool Initilised = false;
    public static Texture2D MIcon { get; set; }
    public static bool runALlogo = false;
    
    public static void EnableDebugMode()
    {
        IsDev = true;
        logger.Debug("Debug Mode Enabled");
    }
    public static void RunCr(IEnumerator cr)
    {
        try
        {
            instance.StartCoroutine(cr);
        }
        catch (Exception e)
        {
            logger.Error($"{e}\n{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}\n{e.GetBaseException()}");
            instance = new GameObject("CoroutineExecuter").AddComponent<CoroutineExecuter>();
            instance.StartCoroutine(cr);
        }
        
    }
    void OnInitialized()
    {
        try
        {
            var panelSettings = AssetManager.GetAsset<PanelSettings>($"shadowutilitylib/shadowutilitylib/theme/panelsettings.asset");
            panelSettings.m_AtlasBlitShader = UitkForKsp2Plugin.PanelSettings.m_AtlasBlitShader;
            panelSettings.m_RuntimeShader = UitkForKsp2Plugin.PanelSettings.m_RuntimeShader;
            panelSettings.m_RuntimeWorldShader = UitkForKsp2Plugin.PanelSettings.m_RuntimeWorldShader;
            Manager.PanelSettings = panelSettings;

            instance = new GameObject("CoroutineExecuter").AddComponent<CoroutineExecuter>();
        }
        catch (Exception e)
        {
            logger.Error($"{e}\n{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}\n{e.GetBaseException()}");
        }
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
        foreach (var fi in new DirectoryInfo($"./logs/").GetFiles().OrderByDescending(x => x.LastWriteTime).Skip(5))
            fi.Delete();
        logger.Log($"Awake");
    }
}