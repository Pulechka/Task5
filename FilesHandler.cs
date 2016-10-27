using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BackupSystem
{
    public class FilesHandler
    {
        public static string CopyDirectory { get; set; } = @"D:\Backup\";

        public static void SaveCopyFile(string fullPath, string name, DateTime time)
        {
            string nameWithDate = time.ToString("[HH-mm-ss dd-MM-yyyy] ") + name;
            File.Copy(fullPath, CopyDirectory + nameWithDate);

            ChangesStorage Changes = ChangesStorage.GetInstance();
            Changes.AddBackupFileInfo(new BackupFileInfo(name, time));
        }
    }
}
