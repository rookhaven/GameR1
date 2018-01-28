using System.Xml.Serialization;

namespace Game.Meta
{
    /*******************************************************************
    * Resources 
    *******************************************************************/
    public class Resource
    {
        public enum ResourceType { Gas, Liquid, Solid };

        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Type")]
        public ResourceType Type { get; set; }
        [XmlAttribute("Credits")]
        public int Credits { get; set; }
        
        public Resource()
        {
            ID = 0;
            Name = "";
            Credits = 0;
            Type = ResourceType.Gas;
        }
    }
}


