using System.Xml.Serialization;

namespace Game.Meta
{
    /*******************************************************************
    * Game Factions
    *******************************************************************/
    public class Faction
    {
        public enum FactionType { Republic, Dictatorship, Empire, Independent };

        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Type")]
        public FactionType Type { get; set; }

        public Faction()
        {
            ID = 0;
            Name = "";
            Type = FactionType.Independent;
        }
    }
}
