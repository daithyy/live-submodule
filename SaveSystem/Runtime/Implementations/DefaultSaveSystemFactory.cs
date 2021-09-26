using UnityEngine;

namespace IMIRT.SaveSystem
{
    public class DefaultSaveSystemFactory : MonoBehaviour, ISaveSystemFactory
    {
        public ISaveFileHandler SaveFileHandler()
        {
#if SAVE_TO_PREFS
            return new PlayerPrefsSaveFileHandler();
#else
            return new FileSystemSaveFileHandler();
#endif
        }

        public ISerialiser Serialiser()
        {
#if USE_BINARY_FORMATTER
            return new BinarySerialiser();
#else
            return new BinarySerialiser();
#endif
        }
    }
}
