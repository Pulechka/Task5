using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem
{
    [Serializable]
    public class Change : IEquatable<Change>
    {
        public WatcherChangeTypes Type { get; set; }
        public string FullPath { get; set; }
        public string OldFullPath { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }

        public Change() { }

        public Change (WatcherChangeTypes type, string fullPath, string name, string oldFullPath, DateTime time)
        {
            Type = type;
            FullPath = fullPath;
            Name = name;
            OldFullPath = oldFullPath;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Type} | {FullPath} | {Name} | {OldFullPath} | {Time}";
        }

        public bool Equals(Change other)
        {
            return (Type == other.Type && Name == other.Name && OldFullPath == other.OldFullPath && 
                Time.Hour == other.Time.Hour && Time.Minute == other.Time.Minute && Time.Second == other.Time.Second);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Change change = obj as Change;
            return Equals(change);
        }

        public override int GetHashCode()
        {
            return Type.ToString().Length * Name.Length * OldFullPath.Length + Time.Millisecond;
        }
    }
}
