namespace IMIRT.SaveSystem
{
    public interface ISerialiser
    {
        string SerialiseObject<T>(T dataObject);

        T DeserialiseObject<T>(string dataString);
    }
}
