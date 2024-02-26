using System.Xml.Serialization;

namespace Services.Implemantations
{
    public class XmlReaderService
    {
        public T? GetDataFromFile<T>(string fileName) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                return (T?)serializer.Deserialize(stream);
            }
        }
    }
}
