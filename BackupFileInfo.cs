using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem
{
    [Serializable]
    public class BackupFileInfo
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }

        public BackupFileInfo() { }

        public BackupFileInfo(string name, DateTime time)
        {
            Name = name;
            Time = time;
        }
    }
}
