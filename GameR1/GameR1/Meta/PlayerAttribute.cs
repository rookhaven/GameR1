using System.Xml.Serialization;

namespace Game.Meta
{
    /*******************************************************************
    * An attribute for an actor
    *******************************************************************/
    public class PlayerAttribute
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("BaseXP")]
        public int BaseXP { get; set; }
        [XmlAttribute("Levels")]
        public int Levels { get; set; }

        public PlayerAttribute()
        {
            ID = 0;
            Name = "";
            BaseXP = 0;
            Levels = 0;
        }
    }
}
