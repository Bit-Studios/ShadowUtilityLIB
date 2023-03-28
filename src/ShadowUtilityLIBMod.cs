using SpaceWarp.API.Mods;
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

namespace ShadowUtilityLIB;
public class CoroutineExecuter : MonoBehaviour { }

[BepInPlugin("com.shadowdev.utilitylib", "Shadow Utility LIB", "0.0.1")]
[BepInDependency(SpaceWarpPlugin.ModGuid, SpaceWarpPlugin.ModVer)]
public sealed class ShadowUtilityLIBMod : BaseSpaceWarpPlugin
{
    public const string ModId = "com.shadowdev.utilitylib";
    public const string ModName = "Shadow Utility Lib";
    public const string ModVersion = "0.0.1";
    public static bool IsDev = false;
    private static Logger logger = new Logger(ModName, ModVersion);
    private static CoroutineExecuter instance;
    public static bool Initilised = false;
    public static Texture2D MIcon { get; set; }
    public static bool runALlogo = false;
    public override void OnInitialized()
    {
        logger.Debug($"{DateTime.Now.Date.ToString()}");
        instance = new GameObject("CoroutineExecuter").AddComponent<CoroutineExecuter>();
        GameManager.Instance.Game.Messages.Subscribe<GameStateChangedMessage>(AppBar.StateChange);
        GameManager.Instance.Game.Messages.Subscribe<GameStateChangedMessage>(StateChange);
        MIcon = AssetManager.GetAsset<Texture2D>($"{SpaceWarpMetadata.ModID}/images/AprilFoolsLogo.png");
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
        if (File.Exists("./log.sl"))
        {
            try
            {
                if (Directory.Exists("./logs")){}
                else
            {
                Directory.CreateDirectory("./logs");
            }
            File.Move("./log.sl", $"./logs/log{DateTime.Now.ToFileTimeUtc().ToString()}.sl");
            }
            catch (Exception e)
            {
                logger.Error($"{e}\n{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}\n{e.GetBaseException()}");
        }
    }
        logger.Log($"Awake");
    }
    public static void StateChange(MessageCenterMessage messageCenterMessage)
    {
        GameStateChangedMessage gameStateChangedMessage = messageCenterMessage as GameStateChangedMessage;
        if(gameStateChangedMessage.CurrentState == GameState.MainMenu)
        {
            try
            {
                if(DateTime.Now.Date.ToString() == "01/04/2023 00:00:00")
                {
                    RunCr(ChangeLogo());
                }
            }
            catch (Exception e)
            {
                logger.Error($"{e}\n{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}\n{e.GetBaseException()}");
            }
        }
    }
    public static IEnumerator ChangeLogo()
    {
        logger.Debug("Set April fools logo");
        yield return new WaitForSeconds(1);
        try { 
        logger.Debug("Setting Logo");
        GameObject.Find("GameManager/Default Game Instance(Clone)/UI Manager(Clone)/Main Canvas/MainMenu(Clone)/Logo").GetComponent<Image>().sprite = Sprite.Create(MIcon, new Rect(0f, 0f, MIcon.width, MIcon.height), new Vector2(0.5f, 0.5f));
        }
        catch (Exception e)
        {
            logger.Error($"{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}");

        }
    }
}