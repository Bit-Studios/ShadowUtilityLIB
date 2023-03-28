﻿using UnityEngine.UIElements;
using ShadowUtilityLIB.logging;

namespace ShadowUtilityLIB.UI
{
    public class Manager
    {
        private static Logger logger = new Logger(ShadowUtilityLIBMod.ModName, ShadowUtilityLIBMod.ModVersion);
        public Dictionary<string, UIDocument> Windows { get; set; }
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
