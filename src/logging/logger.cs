
namespace ShadowUtilityLIB.logging
{
    public class Logger
    {
        public string ModName { get; set; }
        public string ModVersion { get; set; }
        public string FileLocation = "./log.sl";
        public Logger(string ModName,string ModVersion) { 
            this.ModName = ModName;
            this.ModVersion = ModVersion;
        }
        public void Log(string logmessage)
        {
            Console.WriteLine($"[Info] [{DateTime.UtcNow}] [{ModName}] [{ModVersion}] {logmessage}\n");
            File.AppendAllText(FileLocation, $"[Info] [{DateTime.UtcNow}] [{ModName}] [{ModVersion}] {logmessage}\n");
        }
        public void Error(string logmessage)
        {
            Console.WriteLine($"[Error] [{DateTime.UtcNow}] [{ModName}] [{ModVersion}] {logmessage}\n");
            File.AppendAllText(FileLocation, $"[Error] [{DateTime.UtcNow}] [{ModName}] [{ModVersion}] {logmessage}\n");
        }
        public void Debug(string logmessage)
        {
            if (ShadowUtilityLIBMod.IsDev)
            {
                Console.WriteLine($"[Debug] [{DateTime.UtcNow}] [{ModName}] [{ModVersion}] {logmessage}\n");
                File.AppendAllText(FileLocation, $"[Debug] [{DateTime.UtcNow}] [{ModName}] [{ModVersion}] {logmessage}\n");
            }
        }
    }
}
