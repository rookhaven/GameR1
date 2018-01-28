using System.Xml.Serialization;

namespace Game.Meta
{
    [XmlRootAttribute("Variables")]
    public class Variables
    {
        [XmlElement("StartDate")]
        public int StartDate { get; set; }
        [XmlElement("Sectors")]
        public int Sectors { get; set; }
        [XmlElement("StarsPerSector")]
        public int StarsPerSector { get; set; }
        [XmlElement("PlanetsPerSystem")]
        public int PlanetsPerSystem { get; set; }
        [XmlElement("ZonesPerPlanet")]
        public int ZonesPerPlanet { get; set; }
        [XmlElement("DepositsPerZone")]
        public int DepositsPerZone { get; set; }
    }
}
