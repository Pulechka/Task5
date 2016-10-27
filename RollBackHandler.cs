using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem
{
    public class RollBackHandler
    {
        private static ChangesStorage Changes = ChangesStorage.GetInstance();
        
        public static void RollBackOnTime(DateTime time)
        {
            Changes.LoadFromFile(@"D:\changes.xml", @"D:\backup-files.xml");
            var changes = Changes.GetAll();

            for (int i = 0; i < changes.Count; i++)
            {
                if (time < changes[i].Time)
                {
                    switch (changes[i].Type)
                    {
                        case WatcherChangeTypes.Created:
                            File.Delete(changes[i].FullPath);
                            Changes.Delete(changes[i]);
                            break;
                        case WatcherChangeTypes.Renamed:
                            File.Move(changes[i].FullPath, changes[i].OldFullPath);
                            Changes.Delete(changes[i]);
                            break;
                        case WatcherChangeTypes.Deleted:
                            File.Create(changes[i].FullPath);
                            //copy data
                            Changes.Delete(changes[i]);
                            break;
                        case WatcherChangeTypes.Changed:
                            BackupFileInfo fileInfo = Changes.FindFileLastState(changes[i].Name, time);
                            string backupFilePath = FilesHandler.CopyDirectory + fileInfo.Time.ToString("[HH-mm-ss dd-MM-yyyy] ") + fileInfo.Name;
                            File.Copy(backupFilePath, changes[i].FullPath, overwrite: true);
                            Changes.Delete(changes[i]);
                            break;
                    }
                }
                else return;
            }
        }
    }
}
