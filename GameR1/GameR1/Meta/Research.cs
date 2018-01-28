using System.Xml.Serialization;
using System.Collections.Generic;

namespace Game.Meta
{
   /*******************************************************************
    * Research detail
    *******************************************************************/
    public class Research
    {
        public enum ResearchType { Engineering, Civics, Military, Force }

        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Tier")]
        public int Tier { get; set; }
        [XmlAttribute("Type")]
        public ResearchType Type { get; set; }
        [XmlAttribute("Cost")]
        public int Cost { get; set; }
        public Requirements Requirements { get; set; }

        public Research()
        {
            ID = 0;
            Name = "";
            Tier = 1;
            Type = ResearchType.Engineering;
            Cost = 0;
            Requirements = new Requirements();
        }
    }

    public class Requirements
    {
        public enum ResearchRole { Primary, Secondary, Ancillary }

        public List<Predecessor> Predecessors { get; set; }
        public List<ResourcePerCost> Materials { get; set; }
        public List<Researcher> Researchers { get; set; }

        public class Predecessor
        {
            [XmlAttribute("ResearchID")]
            public int ResearchID;
        }

        public class ResourcePerCost
        {
            [XmlAttribute("ResourceID")]
            public int ResourceID;
            [XmlAttribute("Amount")]
            public int Amount;
        }

        public class Researcher
        {
            [XmlAttribute("Title")]
            public string Title;
            [XmlAttribute("Role")]
            public ResearchRole Role;
        }

        public Requirements()
        {
        }
    }
}
