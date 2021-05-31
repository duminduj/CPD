using RACGP_AutomationFramework.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RACGP_AutomationFramework.Helpers
{
    public class LogHelpers
    {
        //log filr
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        //create a file to store log info

        public static void CreateLogFile()
        {
            //string dir=Settings.LogPath;
            //if(Directory.Exists(dir))
            //{
            //    _streamw = File.AppendText(dir + _logFileName + ".log");
            //}
            //else
            //{
            //    Directory.CreateDirectory(dir);
            //    _streamw = File.AppendText(dir + _logFileName + ".log");
            //}
        }
        
        //write log

        public static void Write(string logMessage)
        {
            //_streamw.Write("{0} {1}", DateTime.Now.ToShortTimeString(), DateTime.Now.ToLongDateString());
            //_streamw.WriteLine("   {0}", logMessage);
            //_streamw.Flush();
        }

    }
}
