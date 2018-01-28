using System.Xml.Serialization;

namespace Game.Meta
{
    /*******************************************************************
    * Products are special goods only produced by Corporations
    *******************************************************************/
    public class Product
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Credits")]
        public int Credits { get; set; }
        
        public Product()
        {
            ID = 0;
            Name = "";
            Credits = 0;
        }
    }
}


