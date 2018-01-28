using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Game.Meta;

namespace Game
{
    [Serializable()]
    public class Actor
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Hitpoints")]
        public int Hitpoints { get; set; }
        [XmlAttribute("Health")]
        public int Health { get; set; }
        [XmlAttribute("Midichlorians")]
        public int Midichlorians { get; set; }
        [XmlAttribute("Credits")]
        public int Credits { get; set; }
        public List<Attr> Attributes { get; set; }
        public List<Skillset> Skills { get; set; }
        public List<Technology> Technology { get; set; }
        public Cartography Cartography { get; set; }
        public List<Installation> Installations { get; set; }
        public List<Structure> Ships { get; set; }

        public Actor()
        {
            List<Skillset> skills = new List<Skillset>();
            for (int i = 0; i < ControlData.Skills.Count; i++)
            {
                Skillset s = new Skillset();
                s.ID = ControlData.Skills[i].ID;
                s.Name = ControlData.Skills[i].Name;
                s.XP = 0;
                s.Rank = 0;
                skills.Add(s);
            }
            Skills = skills;

            Cartography = new Cartography();
            Installations = new List<Installation>();
            Ships = new List<Structure>();
        }

        public void UpdateCredits(int Credits)
        {
            this.Credits = this.Credits + Credits;
        }

        public void UpdateEnvironment()
        {
        }
    }

    [Serializable()]
    public class NPC : Actor
    {
        public int Loyalty;

        public NPC()
        {
        }

        // todo: Add AI
    }

    [Serializable()]
    public class Player : Actor
    {
        public List<int> Reputation { get; set; }

        public Player()
        {
            Reputation = new List<int>();
        }

        public void UpdateReputation(int i, int amount)
        {
            int a = this.Reputation[i];
            a += amount;
            this.Reputation[i] = a;
        }

        public void ActorEncounter()
        {
        }

        public void ActorCreateOrg()
        {
        }

        public void ActorDismissOrg()
        {
        }
    }

    /*******************************************************************
    * An attribute for an actor records progress against a given attribute.
    *******************************************************************/
    [Serializable()]
    public class Attr : PlayerAttribute
    {
        [XmlAttribute("XP")]
        public int XP { get; set; }
        [XmlAttribute("Rank")]
        public int Rank { get; set; }

        public Attr()
        {
        }
    }

    /*******************************************************************
    * A Skillset for an actor records progress against a given skill.
    *******************************************************************/
    [Serializable()]
    public class Skillset : Skill
    {
        [XmlAttribute("XP")]
        public int XP { get; set; }
        [XmlAttribute("Rank")]
        public int Rank { get; set; }

        public Skillset()
        {
        }
    }
}

