using System;
using System.IO;

namespace EnderIce2.SDRSharpPlugin
{
    public static class LogWriter
    {
        public static void WriteToFile(string Message)
        {
            if (!SDRSharp.Radio.Utils.GetBooleanSetting("LogRPC", false))
            {
                return;
            }

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\RPCLogs\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\RPCLogs\\DiscordRPCLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".log";
            if (!File.Exists(filepath))
            {
                using StreamWriter sw = File.CreateText(filepath);
                sw.WriteLine($"[{DateTime.Now}] {Message}");
            }
            else
            {
                using StreamWriter sw = File.AppendText(filepath);
                sw.WriteLine($"[{DateTime.Now}] {Message}");
            }
        }
    }
}
