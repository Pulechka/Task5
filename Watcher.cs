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
        private static ChangesStorage Changes = ChangesStorage.GetInstance();

        public static void Start()
        {
            watcher = new FileSystemWatcher(@"D:\WatchDirectory");
            watcher.IncludeSubdirectories = true;
            watcher.Filter = "*.txt";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                                   NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;
        }

        public static void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }


        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            DateTime changeTime = DateTime.Now;
            var newChange = new Change(e.ChangeType, e.FullPath, e.Name, "", changeTime);
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                bool r = !Changes.Contains(newChange);
                if (r)
                {
                    Changes.Add(newChange);
                    Console.WriteLine(newChange);
                    FilesHandler.SaveCopyFile(e.FullPath, e.Name, changeTime);
                }
            }
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            var newChange = new Change(e.ChangeType, e.FullPath, e.Name, e.OldFullPath, DateTime.Now);
            Changes.Add(newChange);
            Console.WriteLine(newChange);
        }
    }
}
