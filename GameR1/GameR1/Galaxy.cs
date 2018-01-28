using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Game.DAO;
using Game.Meta;
using Game.Engine;

namespace Game
{
    /*******************************************************************
     * The Galaxy class represents the the container of
     * stars, actors, and related information.
     *******************************************************************/
    public class Galaxy
    {
        private XMLSerializer Serializer = new XMLSerializer();

        // These control data class is never saved in binary saves
        public ControlData ControlData { get; set; }

        // All fields below this line are detail data which implement
        // ISerializable if you want to save/load the game.  You would
        // need to use the DetailDataBIN class to serialize to binary.
        public int Stardate { get; set; }
        public List<Star> Systems { get; set; }
        public List<Civilization> Civilizations { get; set; }
        public List<Index> Index { get; set; }
        public List<Event> Events { get; set; }

        public Galaxy()
        {
            ControlData = new ControlData();
            Events = new List<Event>();
            Stardate = ControlData.Variables.StartDate;

            List<Star> stars = new List<Star>();
            for (int i = 0; i < ControlData.Variables.Sectors * ControlData.Variables.StarsPerSector; i++)
            {
                Star star = new Star();
                star.ID = i;
                stars.Add(star);
            }
            Systems = stars;
            // todo: SetSystemPositions();

            List<Civilization> civilizations = new List<Civilization>();
            for (int i = 0; i < ControlData.Factions.Count; i++)
            {
                Civilization c = new Civilization();
                c.ID = ControlData.Factions[i].ID;
                c.Name = ControlData.Factions[i].Name;
                c.Type = ControlData.Factions[i].Type;
                civilizations.Add(c);
            }
            civilizations[0].GeneratePlayer();
            Civilizations = civilizations;

            Index = new List<Index>();
            Events = new List<Event>();
        }

        public Galaxy(DetailDataBIN s)
        {
            ControlData = new ControlData();
            Stardate = s.Stardate;
            Systems = s.Systems;
            Civilizations = s.Civilizations;
            Index = s.Index;
            Events = s.Events;
        }

        public void SetSystemPositions()
        {

            int x = 0;
            int y = 0;
            int stars = ControlData.Variables.StarsPerSector;
            int x_offset = 0;
            int y_offset = 0;
            int offset = 100;          // Pixels per sector
            int i = 0;                 // systems index

            for (int grid_y = 0; grid_y < 8; grid_y++)
            {
                // Pass through each y row of sectors once x is finished
                for (int grid_x = 0; grid_x < 8; grid_x++)
                {
                    // Pass through each x sector row
                    for (int j = 0; j < stars; j++)
                    {
                        // Number of stars in each sector
                        int x_rand = ControlData.Random.Next(94) + 4;
                        int y_rand = ControlData.Random.Next(94) + 4;
                        x = x_rand + x_offset;
                        y = y_rand + y_offset;
                        Systems[i].XPos = x;
                        Systems[i].YPos = y;
                        i++;
                    }
                    x_offset = x_offset + offset;
                }
                x_offset = 0;
                y_offset = y_offset + offset;
            }
        }

        public void IncrementStardate()
        {
            this.Stardate++;
        }

        /*******************************************************************
         * Serialize binary version of galaxy detail data to disk
         *******************************************************************/
        public void SaveBIN()
        {
            DetailDataBIN dd = new DetailDataBIN();
            dd.Save(this, @"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\GameSave1.txt");
        }

        /*******************************************************************
         * Load binary version of galaxy detail data from disk
         *******************************************************************/
        public void LoadBIN()
        {
            DetailDataBIN dd = new DetailDataBIN();
            dd.Load(this, @"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\GameSave1.txt");
            #if DEBUG
                Console.WriteLine("Galaxy Loaded");
                Console.WriteLine(this.ToString());
                Console.WriteLine();
            #endif
        }

        /*******************************************************************
         * Serialize XML version of galaxy detail data to disk
         *******************************************************************/
        public void SaveXML()
        {
            System.IO.File.WriteAllText(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\gControlData.xml", Serializer.Serialize(this.ControlData));
            System.IO.File.WriteAllText(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\gSystems.xml", Serializer.Serialize(this.Systems));
            System.IO.File.WriteAllText(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\gCivilizations.xml", Serializer.Serialize(this.Civilizations));
        }

        /*******************************************************************
         * Returns formatted string with Stardate
         *******************************************************************/
        public string GetFormattedStardate()
        {
            string s = Stardate.ToString().Substring(0, 4) + "." +
                       Stardate.ToString().Substring(4, 2) + "." +
                       Stardate.ToString().Substring(6, 2);
            return s;
        }

        /*******************************************************************
         * Displays Galaxy statistics
         *******************************************************************/
        public override string ToString()
        {
            int total_possible_planets = ControlData.Variables.Sectors *
                                         ControlData.Variables.StarsPerSector *
                                         ControlData.Variables.PlanetsPerSystem;

            int planet_count = 0;

            foreach (Star star in Systems)
            {
                planet_count = planet_count + star.Planets.Count;
            }

            String s = "\n  GALAXY STATISTICS\n";
            s = s + "\n  Stardate:         " + Stardate + "\n";
            s = s + "\n  Open Systems:     " + Systems.Count;
            s = s + "\n  Planet Max:       " + total_possible_planets;
            s = s + "\n  Open Planets:     " + planet_count;
            s = s + DisplayPlanetTypes();
            s = s + "\n";

            return s;
        }

        /*******************************************************************
         * Displays the number of non-faction planet types
         *******************************************************************/
        public string DisplayPlanetTypes()
        {
            string s = "\n";
            int v_Planets = 0;
            int b_Planets = 0;
            int g_Planets = 0;
            int i_Planets = 0;
            int o_Planets = 0;
            int t_Planets = 0;

            for (int i = 0; i < Systems.Count; i++)
            {
                for (int j = 0; j < Systems[i].Planets.Count; j++)
                {
                    switch (Systems[i].Planets[j].Type)
                    {
                        case Planet.PlanetType.Volcanic:
                            v_Planets++;
                            break;
                        case Planet.PlanetType.Barren:
                            b_Planets++;
                            break;
                        case Planet.PlanetType.Gas:
                            g_Planets++;
                            break;
                        case Planet.PlanetType.Ice:
                            i_Planets++;
                            break;
                        case Planet.PlanetType.Oceanic:
                            o_Planets++;
                            break;
                        default:
                            t_Planets++;
                            break;
                    }
                }
            }

            s = s + "\n    Volcanic Planets:  " + v_Planets;
            s = s + "\n    Barren Planets:    " + b_Planets;
            s = s + "\n    Gas Planets:       " + g_Planets;
            s = s + "\n    Ice Planets:       " + i_Planets;
            s = s + "\n    Oceanic Planets:   " + o_Planets;
            s = s + "\n    Temperate Planets: " + t_Planets;

            return s;
        }
    }

    [Serializable()]
    public class Star
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("XPos")]
        public int XPos { get; set; }
        [XmlAttribute("YPos")]
        public int YPos { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        public List<Planet> Planets { get; set; }

        public Star()
        {
            List<Planet> planets = new List<Planet>();
            for (int i = 0; i < ControlData.Variables.PlanetsPerSystem; i++)
            {
                Planet planet = new Planet();
                planet.ID = i;
                int r = ControlData.Random.Next(100) + 1;
                SetPlanetType(planet, i, r);
                planets.Add(planet);
            }
            Planets = planets;
        }

        private void SetPlanetType(Planet p, int planetNumber, int chance)
        {
            switch (planetNumber)
            {
                case 0:
                    if (chance < 90)
                        p.Type = Planet.PlanetType.Volcanic;
                    else
                        p.Type = Planet.PlanetType.Barren;
                    break;
                case 1:
                    if (chance < 50)
                        p.Type = Planet.PlanetType.Volcanic;
                    else
                        p.Type = Planet.PlanetType.Barren;
                    break;
                case 2:
                    if (chance < 60)
                        p.Type = Planet.PlanetType.Gas;
                    else if (chance < 98)
                        p.Type = Planet.PlanetType.Barren;
                    else if (chance < 99)
                        p.Type = Planet.PlanetType.Oceanic;
                    else
                        p.Type = Planet.PlanetType.Temperate;
                    break;
                case 3:
                    if (chance < 50)
                        p.Type = Planet.PlanetType.Gas;
                    else if (chance < 96)
                        p.Type = Planet.PlanetType.Barren;
                    else if (chance < 98)
                        p.Type = Planet.PlanetType.Oceanic;
                    else
                        p.Type = Planet.PlanetType.Temperate;
                    break;
                case 4:
                    if (chance < 25)
                        p.Type = Planet.PlanetType.Barren;
                    else if (chance < 50)
                        p.Type = Planet.PlanetType.Gas;
                    else if (chance < 87)
                        p.Type = Planet.PlanetType.Ice;
                    else if (chance < 99)
                        p.Type = Planet.PlanetType.Oceanic;
                    else
                        p.Type = Planet.PlanetType.Temperate;
                    break;
                case 5:
                    if (chance < 25)
                        p.Type = Planet.PlanetType.Barren;
                    else if (chance < 50)
                        p.Type = Planet.PlanetType.Gas;
                    else if (chance < 98)
                        p.Type = Planet.PlanetType.Ice;
                    else if (chance < 99)
                        p.Type = Planet.PlanetType.Oceanic;
                    else
                        p.Type = Planet.PlanetType.Temperate;
                    break;
                case 6:
                    if (chance < 30)
                        p.Type = Planet.PlanetType.Barren;
                    else if (chance < 85)
                        p.Type = Planet.PlanetType.Ice;
                    else
                        p.Type = Planet.PlanetType.Gas;
                    break;
                default:
                    // catch the rest with a generic setting
                    if (chance < 90)
                        p.Type = Planet.PlanetType.Ice;
                    else if (chance < 95)
                        p.Type = Planet.PlanetType.Barren;
                    else
                        p.Type = Planet.PlanetType.Gas;
                    break;
            }
        }
    }

    [Serializable()]
    public class Planet
    {
        public enum PlanetType
        {
            [XmlEnum(Name = "Volcanic")] Volcanic,
            [XmlEnum(Name = "Barren")] Barren,
            [XmlEnum(Name = "Gas")] Gas,
            [XmlEnum(Name = "Ice")] Ice,
            [XmlEnum(Name = "Oceanic")] Oceanic,
            [XmlEnum(Name = "Temperate")] Temperate,
            [XmlEnum(Name = "Megalopolis")] Megalopolis
        }

        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("XPos")]
        public int XPos { get; set; }
        [XmlAttribute("YPos")]
        public int YPos { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Type")]
        public PlanetType Type { get; set; }
        public List<Zone> Zones { get; set; }

        public Planet()
        {
            ID = 0;
            XPos = 0;
            YPos = 0;
            Name = "";
            Type = PlanetType.Volcanic;
            List<Zone> zones = new List<Zone>();
            for (int i = 0; i < ControlData.Variables.ZonesPerPlanet; i++)
            {
                Zone zone = new Zone();
                zone.ID = i;
                zones.Add(zone);
            }
            Zones = zones;
        }
    }

    [Serializable()]
    public class Zone
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("XPos")]
        public int XPos { get; set; }
        [XmlAttribute("YPos")]
        public int YPos { get; set; }
        public List<Deposit> Deposits { get; set; }

        public Zone()
        {
            ID = 0;
            XPos = 0;
            YPos = 0;
            List<Deposit> deposits = new List<Deposit>();
            for (int i = 0; i < ControlData.Variables.DepositsPerZone; i++)
            {
                Deposit deposit = new Deposit();
                deposit.ID = i;
                deposits.Add(deposit);
            }
            Deposits = deposits;
        }
    }

    [Serializable()]
    public class Deposit
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }
        [XmlAttribute("XPos")]
        public int XPos { get; set; }
        [XmlAttribute("YPos")]
        public int YPos { get; set; }
        [XmlAttribute("ResourceID")]
        public int ResourceID { get; set; }
        [XmlAttribute("Volume")]
        public int Volume { get; set; }
        [XmlAttribute("Amount")]
        public int Amount { get; set; }

        public Deposit()
        {
            ID = 0;
            XPos = 0;
            YPos = 0;
            Volume = 0;
            Amount = 0;
            int r = ControlData.Random.Next(100) + 1;
            SetDepositResource(this, r);
        }

        private void SetDepositResource(Deposit d, int chance)
        {
            if (chance > 90)
            {
                d.ResourceID = 0;
                d.Volume = chance * ControlData.Random.Next(1000);
                d.Amount = d.Volume * 1000;
            }
            else if (chance > 80)
            {
                d.ResourceID = 1;
                d.Volume = chance * ControlData.Random.Next(1000);
                d.Amount = d.Volume * 1000;
            }
            else if (chance > 70)
            {
                d.ResourceID = 2;
                d.Volume = chance * ControlData.Random.Next(1000);
                d.Amount = d.Volume * 1000;
            }
            else
            {
                d.ResourceID = 3;
                d.Volume = chance * ControlData.Random.Next(1000);
                d.Amount = d.Volume * 1000;
            }
        }
    }
}
