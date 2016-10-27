using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace BackupSystem
{
    /*public class FilesBackupper
    {
        private List<FileInfo> files;
        private static FilesBackupper filesBackupper;

        private FilesBackupper()
        {
            files = new List<FileInfo>();
        }

        public static FilesBackupper GetInstance()
        {
            if (filesBackupper == null)
                filesBackupper = new FilesBackupper();
            return filesBackupper;
        }

        public void Add(FileInfo file)
        {
            files.Add(file);
        }

        public FileInfo FindFileLastState(DateTime time)
        {
            return files.Where(f => f.CreationTime < time).Max();
        }

        public void SaveToFile(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Change>));
            using (Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fileStream, files);
            }
        }
        public void LoadFromFile(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Change>));
            using (Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                XmlReader reader = XmlReader.Create(fileStream);
                files = (List<FileInfo>)serializer.Deserialize(reader);
            }
        }
    }*/
}
