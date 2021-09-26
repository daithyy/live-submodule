using UnityEngine;

namespace IMIRT.SaveSystem
{
    [RequireComponent(typeof(ISaveSystemFactory))]
    public class SaveSystem : MonoBehaviour, ISaveSystem
    {
        private ISerialiser m_Serialiser;
        
        private ISaveFileHandler m_SaveFileHandler;

        private ISaveSystemFactory m_SaveSystemFactory;

        private string SaveFileName => "SaveFile";

        public void Awake()
        {
            m_SaveSystemFactory = GetComponent<ISaveSystemFactory>();

            m_SaveFileHandler = m_SaveSystemFactory.SaveFileHandler();

            m_Serialiser = m_SaveSystemFactory.Serialiser();
        }

        public void Save<T>(T data)
        {
            /*  Take data and convert it to whatever format
             *  store the data
             */

            string serialisedString = m_Serialiser.SerialiseObject<T>(data);

            Debug.Log(serialisedString);

            m_SaveFileHandler.SaveData(SaveFileName, serialisedString);
        }

        public T Load<T>()
        {
            string serialisedString = m_SaveFileHandler.LoadData(SaveFileName);

            Debug.Log(serialisedString);

            if (string.IsNullOrEmpty(serialisedString))
            {
                return default;
            }

            T result = m_Serialiser.DeserialiseObject<T>(serialisedString);

            return result != null ? result : default;
        }
    }
}
