using System.IO;
using UnityEngine;

namespace IMIRT.SaveSystem
{
    public class FileSystemSaveFileHandler : ISaveFileHandler
    {
        public void SaveData(string key, string dataString)
        {
            string filePath = GetFilePath(key);

            FileInfo fileInfo = new FileInfo(filePath);

            StreamWriter writer = fileInfo.CreateText();

            writer.Write(dataString);
            writer.Close();
        }

        public string LoadData(string key)
        {
            string _data = string.Empty;

            if (Exists(key))
            {
                StreamReader streamReader = File.OpenText(GetFilePath(key));

                string _info = streamReader.ReadToEnd();

                streamReader.Close();

                _data = _info;
            }

            return _data;
        }

        public void DeleteData(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                FileInfo fileInfo = new FileInfo(GetFilePath(key));

                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
        }

        public bool Exists(string key)
        {
            return File.Exists(GetFilePath(key));
        }

        private string GetFilePath(string key)
        {
            string saveDirectory = Application.persistentDataPath;

            saveDirectory = saveDirectory.Replace('/', Path.DirectorySeparatorChar);

            return $"{saveDirectory}{Path.DirectorySeparatorChar}{key}";
        }
    }
}
