using UnityEngine.UIElements;
using ShadowUtilityLIB.logging;
using UnityEngine;
using Logger = ShadowUtilityLIB.logging.Logger;
using BepInEx;
using System.Drawing.Printing;
using KSP.Game.Flow;
using Newtonsoft.Json;
using UitkForKsp2;

namespace ShadowUtilityLIB.UI
{
    public class Manager
    {
        private static Logger logger = new Logger(ShadowUtilityLIBMod.ModName, ShadowUtilityLIBMod.ModVersion);
        public Dictionary<string, UIDocument> Windows { get; set; }
        public int arbitrary_Limitation_because_of_an_update_to_uitk_that_limits_screen_size_due_to_space_warp_being_shit___Width = 1920;
        public int arbitrary_Limitation_because_of_an_update_to_uitk_that_limits_screen_size_due_to_space_warp_being_shit___height = 1080;
        public Manager()
        { 
            try
            {
                Windows = new Dictionary<string, UIDocument>();
            }
            catch (Exception e)
            {
                logger.Error($"{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}");
            }
        }
        public void Add(string name, UIDocument document)
        {
            try
            {
                Windows.Add(name, document);
            }
            catch (Exception e)
            {
                logger.Error($"{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}");
            }
        }
        public void Remove(string name)
        {
            try
            {
                Windows.Remove(name);
            }
            catch (Exception e)
            {
                logger.Error($"{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}");
            }
        }
        public UIDocument Get(string name)
        {
            return Windows[name];
        }
        public void Toggle(string name)
        {
            try
            {
                Windows[name].rootVisualElement.visible = !Windows[name].rootVisualElement.visible;
            }
            catch (Exception e)
            {
                logger.Error($"{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}");
            }
        }
        public void Set(string name,bool state)
        {
            try
            {
                Windows[name].rootVisualElement.visible = state;
            }
            catch (Exception e)
            {
                logger.Error($"{e.Message}\n{e.InnerException}\n{e.Source}\n{e.Data}\n{e.HelpLink}\n{e.HResult}\n{e.StackTrace}\n{e.TargetSite}");
            }
        }
    }
}
