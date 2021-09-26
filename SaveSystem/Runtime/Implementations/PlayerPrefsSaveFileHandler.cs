using UnityEngine;

namespace IMIRT.SaveSystem
{
    public class PlayerPrefsSaveFileHandler : ISaveFileHandler
    {
        public void SaveData(string key, string dataString)
        {
            PlayerPrefs.SetString(key, dataString);
        }

        public string LoadData(string key)
        {
            Debug.Log(key);
            return PlayerPrefs.GetString(key);
        }

        public void DeleteData(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public bool Exists(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
    }
}
