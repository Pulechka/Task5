using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem
{
    public class Watcher
    {
        private static FileSystemWatcher watcher;

        public static void Start()
        {
            watcher = new FileSystemWatcher(@"D:\New");
            watcher.IncludeSubdirectories = true;
            watcher.Created += OnCreated;
        }

        public static void Stop()
        {

        }

        private static void OnCreated(object obj, EventArgs e)
        {
            
        }
    }
}
