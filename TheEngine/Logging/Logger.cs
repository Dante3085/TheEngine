using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEngine.Logging
{
    public static class Logger
    {
        public static void Log(string text)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine("[" + DateTime.Now.ToString());
                writer.WriteLine(new StackTrace().ToString() + "]: " + text);
            }
        }
    }
}
