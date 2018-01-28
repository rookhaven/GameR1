using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Game.Meta;

namespace Game
{
    /*******************************************************************
    * The research technology available to an actor.
    *******************************************************************/
    [Serializable()]
    public class Technology : Research
    {
        [XmlAttribute("Progress")]
        public int Progress { get; set; }
        [XmlAttribute("Complete")]
        public bool Complete { get; set; }
        public List<int> Assigned { get; set; }
        public List<Schematic> Schematics { get; set; }

        public Technology()
        {
        }
    }

    /*******************************************************************
    * A set of connected structures and related data
    *******************************************************************/
    [Serializable()]
    public class Installation
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("XPos")]
        public int XPos { get; set; }
        [XmlAttribute("YPos")]
        public int YPos { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        public List<Structure> Structures { get; set; }
        public List<Corporation> Corporations { get; set; }

        public Installation()
        {
            ID = 0;
            XPos = 0;
            YPos = 0;
            Name = "";
            Structures = new List<Structure>();
            Corporations = new List<Corporation>();
        }
    }

    /*******************************************************************
     * Structure detail
     *******************************************************************/
    [Serializable()]
    public class Structure
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("XPos")]
        public int XPos { get; set; }
        [XmlAttribute("YPos")]
        public int YPos { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Hitpoints")]
        public int Hitpoints { get; set; }
        [XmlAttribute("Health")]
        public int Health { get; set; }
        public List<Component> Components { get; set; }

        public Structure()
        {
            ID = 0;
            XPos = 0;
            YPos = 0;
            Name = "";
            Hitpoints = 0;
            Health = 0;
            Components = new List<Component>();
        }

        public Structure(int ID
                       , int XPos
                       , int YPos
                       , string Name
                       , int Hitpoints
                       , int Health
                        , List<Component> Components)
        {
            this.ID = ID;
            this.XPos = XPos;
            this.YPos = YPos;
            this.Name = Name;
            this.Hitpoints = Hitpoints;
            this.Health = Health;
            this.Components = Components;
        }
    }

    /*******************************************************************
     * Component detail
     *******************************************************************/
    [Serializable()]
    public class Component
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("XPos")]
        public int XPos { get; set; }
        [XmlAttribute("YPos")]
        public int YPos { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Hitpoints")]
        public int Hitpoints { get; set; }
        [XmlAttribute("Health")]
        public int Health { get; set; }
        [XmlAttribute("Energy")]
        public int Energy { get; set; }

        public Component()
        {
            ID = 0;
            XPos = 0;
            YPos = 0;
            Name = "";
            Hitpoints = 0;
            Health = 0;
            Energy = 0;
        }
    }
}

