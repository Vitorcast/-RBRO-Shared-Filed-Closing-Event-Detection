using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFileTest
{
    public class MetaFile
    {
        public string HostName { get; set; }
        public int Id { get; set; }
        public string User { get; set; }
        public string Type { get; set; }
        public string Locks { get; set; }
        public string OpenMode { get; set; }
        public string FullPath { get; set; }

        public string FileName
        {
            get
            {
                return Path.GetFileName(FullPath);
            }
        }

        public bool isLocked
        {
            get
            {
                if (this.OpenMode.ToUpper().Contains("WRITE"))
                    return true;
                else return false;
            }
        }

        //public DateTime LastestLock { get; set; }
        //public DateTime LatestRelease { get; set; }
    }

    class MetaFileComparer : IEqualityComparer<MetaFile>
    {
        public bool Equals(MetaFile x, MetaFile y)
        {
            return x.FullPath == y.FullPath;
        }

        public int GetHashCode(MetaFile obj)
        {
            unchecked
            {
                if (obj == null)
                    return 0;

                return obj.FullPath.GetHashCode();
            }
        }
    }
}

