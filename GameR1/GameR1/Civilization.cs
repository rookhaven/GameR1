using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Game.Meta;

namespace Game
{
    [Serializable()]
    public class Civilization : Faction
    {
        public Score Score { get; set; }
        public Government Government { get; set; }
        public Military Military { get; set; }
        public List<Institution> Institutions { get; set; }
        public List<Corporation> Corporations { get; set; }
        public List<Player> Players { get; set; }

        public Civilization()
        {
            List<Measure> Measures = new List<Measure>();
            Measure Measure1 = new Measure();
            Measure1.Type = Measure.MeasureType.Justice;
            Measure1.Rating = 85;
            Measures.Add(Measure1);
            Measure Measure2 = new Measure();
            Measure2.Type = Measure.MeasureType.Liberty;
            Measure2.Rating = 95;
            Measures.Add(Measure2);
            Measure Measure3 = new Measure();
            Measure3.Type = Measure.MeasureType.Prosperity;
            Measure3.Rating = 60;
            Measures.Add(Measure3);
            Measure Measure4 = new Measure();
            Measure4.Type = Measure.MeasureType.Security;
            Measure4.Rating = 75;
            Measures.Add(Measure4);

            Score score = new Score();
            score.Measures = Measures;
            score.Overall = (Measure1.Rating + Measure2.Rating + Measure3.Rating + Measure4.Rating) / 4;

            Score = score;
        }

        public void GeneratePlayer()
        {
            List<Player> players = new List<Player>();

            Player player = new Player();
            player.Name = "Player 1";
            player.Hitpoints = 1000;
            player.Health = 1000;
            player.Credits = 10000;
            players.Add(player);

            Players = players;
        }
    }

    public class Score
    {
        public int Overall { get; set; }
        public List<Measure> Measures { get; set; }
    }

    public class Measure
    {
        public enum MeasureType { Justice, Prosperity, Liberty, Security }

        [XmlAttribute("Type")]
        public MeasureType Type { get; set; }
        [XmlAttribute("Rating")]
        public int Rating { get; set; }
    }

    /*******************************************************************
     * Entity class represents a defined organization in a civilization.
     *******************************************************************/
    [Serializable()]
    public class Entity
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Renown")]
        public int Renown { get; set; }
        [XmlAttribute("Budget")]
        public int Budget { get; set; }
        [XmlAttribute("Expense")]
        public int Expense { get; set; }
        [XmlAttribute("Balance")]
        public int Balance { get; set; }
        [XmlAttribute("Jobs")]
        public int Jobs { get; set; }
        [XmlAttribute("Employees")]
        public int Employees { get; set; }

        public Entity()
        {
            ID = 0;
            Name = "";
            Renown = 0;
            Balance = 0;
        }

        public List<NPC> GenerateNPCs()
        {
            List<NPC> npcs = new List<NPC>();

            NPC npc = new NPC();
            npc.Name = ControlData.NpcNames[ControlData.Random.Next(ControlData.NpcNames.Count)];
            npc.Hitpoints = 1000;
            npc.Health = 1000;
            npc.Credits = 1000;
            npcs.Add(npc);

            npc = new NPC();
            npc.Name = ControlData.NpcNames[ControlData.Random.Next(ControlData.NpcNames.Count)];
            npc.Hitpoints = 1000;
            npc.Health = 1000;
            npc.Credits = 1000;
            npcs.Add(npc);

            return npcs;
        }
    }

    /*******************************************************************
     * Government entities assigned to civilizations.
     *******************************************************************/
    [Serializable()]
    public class Government : Entity
    {
        public enum Titles { Senator, Chancellor, Delegate, Page, King, Queen, Duke, Duchess, Lord, Lade, Darth }

        public List<NPC> NPCS { get; set; }

        public Government()
        {
        }
    }

    /*******************************************************************
     * Military entities assigned to civilizations.
     *******************************************************************/
    [Serializable()]
    public class Military : Entity
    {
        public enum Titles { Pilot, Ensign, Captain, Commander, Admiral, GrandAdmiral, Trooper, Sergeant, Lieutenant, General }

        public List<NPC> NPCS { get; set; }

        public Military()
        {
        }
    }

    /*******************************************************************
     * Institutions provide services to civilizations.
     *******************************************************************/
    [Serializable()]
    public class Institution : Entity
    {
        public enum Titles { Administrator, Master, Knight, Padawan, Apprentice }

        public List<NPC> NPCS { get; set; }

        public Institution()
        {
        }
    }

    /*******************************************************************
     * Corporations produce specialty products not producable by players.
     *******************************************************************/
    [Serializable()]
    public class Corporation : Entity
    {
        public enum Titles { CEO, CIO, COO, Assistant, Specialist }
        public enum Grade { Low, High, Premium };

        [XmlAttribute("ProductID")]
        public int ProductID { get; set; }
        public List<NPC> NPCS { get; set; }

        public Corporation()
        {
            ProductID = 0;
        }
    }
}