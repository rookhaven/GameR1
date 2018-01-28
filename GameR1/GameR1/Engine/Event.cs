using System;
using System.Xml.Serialization;

namespace Game.Engine
{
    /*************************************************************************
     * The Events class handles all events that have duration,
     * both system and Actor driven.
     *************************************************************************/
    [Serializable()]
    public class Event
	{
		private Galaxy Galaxy;

        public enum EventType { Colonization, Invasion, Raid, Encounter, Visit, Request };

        [XmlAttribute("FactionID")]
        public int FactionID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Credits")]
        public int Credits { get; set; }

        public Event()
        {
        }

        public Event (Galaxy Galaxy)
		{
			this.Galaxy = Galaxy;
		}
    }
}

