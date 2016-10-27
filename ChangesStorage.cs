using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BackupSystem
{
    public class ChangesStorage
    {
        private static ChangesStorage changesStorage;
        private List<Change> changes;
        private List<BackupFileInfo> backupFilesInfo;


        private ChangesStorage()
        {
            changes = new List<Change>();
            backupFilesInfo = new List<BackupFileInfo>();
        }

        public static ChangesStorage GetInstance()
        {
            if (changesStorage == null)
                changesStorage = new ChangesStorage();
            return changesStorage;
        }

        public void Add(Change newChange)
        {
            changes.Add(newChange);
        }

        public void Delete(Change change)
        {
            changes.Remove(change);
        }

        public bool Contains(Change change)
        {
            if (changes.Contains(change))
                return true;
            return false;
        }

        public List<Change> GetAll()
        {
            changes.Reverse();
            return changes;
        }

        public void AddBackupFileInfo(BackupFileInfo info)
        {
            backupFilesInfo.Add(info);
        }

        public BackupFileInfo FindFileLastState(string name, DateTime time)
        {
            return backupFilesInfo.Where(f => f.Name == name && f.Time < time).Max();
        }

        public void SaveToFile(string changesFileName, string backupFilesInfoFileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Change>));
            using (Stream fileStream = new FileStream(changesFileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fileStream, changes);
            }
            serializer = new XmlSerializer(typeof(List<BackupFileInfo>));
            using (Stream fileStream = new FileStream(backupFilesInfoFileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fileStream, backupFilesInfo);
            }
        }
        public void LoadFromFile(string changesFileName, string backupFilesInfoFileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Change>));
            using (Stream fileStream = new FileStream(changesFileName, FileMode.Open, FileAccess.Read))
            {
                XmlReader reader = XmlReader.Create(fileStream);
                changes = (List<Change>)serializer.Deserialize(reader);
            }
            serializer = new XmlSerializer(typeof(List<BackupFileInfo>));
            using (Stream fileStream = new FileStream(backupFilesInfoFileName, FileMode.Open, FileAccess.Read))
            {
                XmlReader reader = XmlReader.Create(fileStream);
                backupFilesInfo = (List<BackupFileInfo>)serializer.Deserialize(reader);
            }
        }
    }
}
