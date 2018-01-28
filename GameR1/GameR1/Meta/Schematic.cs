using System.Xml.Serialization;
using System.Collections.Generic;

namespace Game.Meta
{
   /*******************************************************************
    * Schematic detail
    *******************************************************************/
    public class Schematic
    {
        public enum SchematicType { Exploration, Manufacturing, Research, Computing, Energy };

        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("ResearchID")]
        public int ResearchID { get; set; }
        [XmlAttribute("Type")]
        public SchematicType Type { get; set; }
        [XmlAttribute("ComponentID")]
        public int ComponentID { get; set; }
        public List<Ingredient> Factory { get; set; }

        public Schematic()
        {
            ID = 0;
            Name = "";
            ResearchID = 1;
            Type = SchematicType.Energy;
            ComponentID = 0;
            Factory = new List<Ingredient>();
        }
    }

    public class Ingredient
    {
        public enum FlowType { IN, OUT };

        [XmlAttribute("ResourceID")]
        public int ResourceID;
        [XmlAttribute("Amount")]
        public int Amount;
        [XmlAttribute("Flow")]
        public FlowType Flow;

        public Ingredient()
        {
            ResourceID = 0;
            Amount = 0;
            Flow = FlowType.IN;
        }
    }
}
