using Newtonsoft.Json.Linq;
using System;

namespace TobeConsolePractise.Serialization
{
    class DtoSerialize
    {
        public static void Run()
        {
            DemoDTO dto = CreateDemoDto();
            XmlSerialize(dto);
            Console.WriteLine("\r\n");
            JsonSerialize(dto);
        }

        private static void XmlSerialize(DemoDTO dto)
        {
            // Serialize the dto to xml.
            string strXml = Serializer.SerializeXml(dto);

            // Write the serialized dto as xml.
            Console.WriteLine("Serialized DTO (XML)");
            Console.WriteLine("=======================");
            Console.WriteLine("\r");
            Console.WriteLine(strXml);
            Console.WriteLine("\r");

            // Deserialize the xml to the data transfer object.
            DemoDTO desDto = (DemoDTO)Serializer.DeserializeXml<DemoDTO>(strXml);

            // Write the deserialized dto values.
            Console.WriteLine("Deseralized DTO (XML)");
            Console.WriteLine("=======================");
            Console.WriteLine("\r");
            Console.WriteLine("DemoId         : " + desDto.Id);
            Console.WriteLine("Demo Name      : " + desDto.DemoName);
            Console.WriteLine("Demo Programmer: " + desDto.ProgrammerName);
            Console.WriteLine("\r");
        }

        private static void JsonSerialize(DemoDTO dto)
        {
            // Serialize the dto to xml.
            string strXml = Serializer.SerializeJson(dto);

            // Write the serialized dto as xml.
            Console.WriteLine("Serialized DTO (JSON)");
            Console.WriteLine("=======================");
            Console.WriteLine("\r");
            Console.WriteLine(strXml);
            Console.WriteLine("\r");

            // Deserialize the xml to the data transfer object.
            DemoDTO desDto = Serializer.DeserializeJson<DemoDTO>(strXml);
            
            // Write the deserialized dto values.
            Console.WriteLine("Deseralized DTO (JSON)");
            Console.WriteLine("=======================");
            Console.WriteLine("\r");
            Console.WriteLine("DemoId         : " + desDto.Id);
            Console.WriteLine("Demo Name      : " + desDto.DemoName);
            Console.WriteLine("Demo Programmer: " + desDto.ProgrammerName);
            Console.WriteLine("\r");
        }

        private static DemoDTO CreateDemoDto()
        {
            DemoDTO dto = new DemoDTO();

            dto.Id = "1";
            dto.DemoName = "Data Transfer Object Demonstration Program";
            dto.ProgrammerName = "Tobenna Chineke";

            return dto;
        }
    }
}
