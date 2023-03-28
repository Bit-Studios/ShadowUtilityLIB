
namespace ShadowUtilityLIB.logging
{
    public class Logger
    {
        public string ModName { get; set; }
        public string ModVersion { get; set; }
        public Logger(string ModName,string ModVersion) { 
            this.ModName = ModName;
            this.ModVersion = ModVersion;
        }
        public void Log(string logmessage)
        {
            File.AppendAllText("./log.sl",$"[Info] [{DateTime.UtcNow}] [{ModName}] [{ModVersion}] {logmessage}\n");
        }
        public void Error(string logmessage)
        {
            File.AppendAllText("./log.sl", $"[Error] [{DateTime.UtcNow}] [{ModName}] [{ModVersion}] {logmessage}\n");
        }
        public void Debug(string logmessage)
        {
            if (ShadowUtilityLIBMod.IsDev)
            {
                File.AppendAllText("./log.sl", $"[Debug] [{DateTime.UtcNow}] [{ModName}] [{ModVersion}] {logmessage}\n");
            }
        }
    }
}
