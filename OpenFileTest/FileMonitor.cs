using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace OpenFileTest
{
    public class FileMonitor
    {
        Process proc;
        List<MetaFile> files;

        public FileMonitor()
        {
            this.proc = new Process();
            this.proc.StartInfo.FileName = "openfiles.exe";
            this.proc.StartInfo.Arguments = "/query /FO CSV /v";
            this.proc.StartInfo.UseShellExecute = false;
            this.proc.StartInfo.CreateNoWindow = true;
            this.proc.StartInfo.RedirectStandardOutput = true;

            this.files = new List<MetaFile>();
        }

        public void Run()
        {
            while (true)
            {
                this.RefreshData();

                Thread.Sleep(2000);
            }
        }

        public void RefreshData()
        {
            var tempList = new List<MetaFile>();

            try
            {
                proc.Start();
                if (proc.StandardOutput != null)
                {
                    var result = proc.StandardOutput.ReadToEnd().Trim().Replace("\"", "");
                    var lines = result.Split('\n');
                    var firstLineIndex = 1 + lines.Cast<string>().ToList().FindIndex(l => l.Contains("Hostname"));
                    for (int i = firstLineIndex; i < lines.Count() && firstLineIndex > 0; i++)
                    {
                        var fields = lines[i].Split(',');

                        if (!fields[6].EndsWith("\\"))
                        {
                            if (!fields[6].EndsWith("\\\r"))
                            {
                                tempList.Add(new MetaFile
                                {
                                    HostName = fields[0],
                                    Id = int.Parse(fields[1]),
                                    User = fields[2],
                                    Type = fields[3],
                                    Locks = fields[4],
                                    OpenMode = fields[5],
                                    FullPath = fields[6]
                                });
                            }
                        }
                    }
                }               
            }
            catch (Exception e)
            {
                Console.WriteLine(" Error: " + e.Message + " : " + DateTime.Now.ToShortTimeString());
            }
            finally
            {
                proc.Close();
            }

            var metaFileComparer = new MetaFileComparer();
            this.files.Except(tempList, metaFileComparer).ToList().ForEach(x => Console.WriteLine(x.FileName + " unlocked at " + DateTime.Now.ToShortTimeString())) ;
            tempList.Except(this.files, metaFileComparer).ToList().ForEach(x => Console.WriteLine(x.FileName + " locked at " + DateTime.Now.ToShortTimeString()));
            this.files = tempList;
        }

        
    }
}
