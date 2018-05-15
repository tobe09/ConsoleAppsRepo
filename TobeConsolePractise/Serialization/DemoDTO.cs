using System.Xml.Serialization;

namespace TobeConsolePractise.Serialization
{
    public class DemoDTO : BaseDTO
    {
        //[XmlElement(IsNullable = true)]  //not supremely important
        public string Id { get; set; }

        [XmlElement(IsNullable = true)]
        public string DemoName { get; set; }

        [XmlElement(IsNullable = true)]
        public string ProgrammerName { get; set; }
    }
}