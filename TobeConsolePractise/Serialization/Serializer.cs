using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Xml.Serialization;

namespace TobeConsolePractise.Serialization
{
    public class Serializer
    {
        public static string SerializeXml<T>(T dto)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            StringWriter sWriter = new StringWriter();
            // Serialize the dto to xml.
            xmlSer.Serialize(sWriter, dto);
            // Return the string of xml.

            return sWriter.ToString();
        }

        public static T DeserializeXml<T>(string xml)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            // Read the XML.
            StringReader sReader = new StringReader(xml);
            // Cast the deserialized xml to the type of dto.
            T dto = (T)xmlSer.Deserialize(sReader);
            // Return the data transfer object.

            return dto;
        }

        public static string SerializeJson<T>(T dto)
        {
            JsonSerializer jsonSer = new JsonSerializer();
            StringWriter sWriter = new StringWriter();
            // Serialize the dto to xml.
            jsonSer.Serialize(sWriter, dto);
            // Return the string of xml.

            return sWriter.ToString();
        }

        public static T DeserializeJson<T>(string xml)
        {
            JsonSerializer jsonSer = new JsonSerializer();
            // Read the XML.
            StringReader sReader = new StringReader(xml);
            JsonReader jReader = new JsonTextReader(sReader);
            // Cast the deserialized xml to the type of dto.
            JObject jObj = (JObject)jsonSer.Deserialize(jReader);

            T dto = jObj.ToObject<T>();

            // Return the data transfer object.
            return dto;
        }
    }
}
