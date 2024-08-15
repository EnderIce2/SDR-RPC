using System;
using System.Diagnostics;
using System.IO;

namespace EnderIce2.SDRSharpPlugin
{
    public static class LogWriter
    {
        public static void WriteToFile(string Message)
        {
            Debug.WriteLine(Message);
            if (SDRSharp.Radio.Utils.GetBooleanSetting("LogRPC", false))
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\RPCLogs\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "\\RPCLogs\\DiscordRPCLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".log");
                sw.WriteLine($"[{DateTime.Now}] {Message}");
            }
        }
    }
}