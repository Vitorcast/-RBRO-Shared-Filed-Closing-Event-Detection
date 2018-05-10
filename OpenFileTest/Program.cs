using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenFileTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var process = new Process();
            //process.StartInfo.FileName = "openfiles.exe";
            //process.StartInfo.Arguments = "/query /FO CSV /v";
            //process.StartInfo.UseShellExecute = false;
            //process.StartInfo.CreateNoWindow = true;
            //process.StartInfo.RedirectStandardOutput = true;

            FileMonitor monitor = new FileMonitor();
            monitor.Run();

            #region Old
            //while (true)
            //{

            //    try
            //    {
            //        process.Start();
            //        if (process.StandardOutput != null)
            //        {
            //            var result = process.StandardOutput.ReadToEnd().Trim().Replace("\"", "");
            //            var lines = result.Split('\n');
            //            var firstLineIndex = 1 + lines.Cast<string>().ToList().FindIndex(l => l.Contains("Hostname"));
            //            for (int i = firstLineIndex; i < lines.Count() && firstLineIndex > 0; i++)
            //            {
            //                var fields = lines[i].Split(',');
            //                foreach (var row in fields)
            //                {
            //                    Console.WriteLine(row);
            //                }
            //            }
            //        }
            //        process.WaitForExit();
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(" Error: " + e.Message + " : " + DateTime.Now.ToShortTimeString());
            //    }
            //    finally
            //    {
            //        process.Close();
            //    }

            //    monitor.Run();

            //    Thread.Sleep(2000);
            //}
            #endregion
        }
    }
}
