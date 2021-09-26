namespace IMIRT.SaveSystem
{
    public interface ISaveFileHandler
    {
        void SaveData(string key, string data);

        string LoadData(string key);

        void DeleteData(string key);

        bool Exists(string key);
    }
}
