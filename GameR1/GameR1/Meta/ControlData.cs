using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Game.Meta
{
    /*******************************************************************
    * The ControlData class includes all non-transactional defintions
    * mostly from corresponding XML files.  These values are not saved 
    * and should therefore be moddable and 'save game safe' as players 
    * modify various values.
    *******************************************************************/
    public class ControlData
    {
        public static Random Random = new Random();
        public enum Status { Idle, Active, Fighting, Incapacitated }

        // XML file lists
        public static Variables Variables { get; set; }
        public static List<Resource> Resources { get; set; }
        public static List<Product> Products { get; set; }
        public static List<Schematic> Schematics { get; set; }
        public static List<Faction> Factions { get; set; }
        public static List<PlayerAttribute> PlayerAttributes { get; set; }
        public static List<Skill> Skills { get; set; }
        public static List<Research> Research { get; set; }
        public static List<string> NpcNames { get; set; }
        public static List<string> SystemNames { get; set; }

        // Defined so I can spit it back out in XML and look at it
        // This will eventually go away once everything is settled.
        public Variables VariablesXML { get; set; }
        [XmlArray("Resources")]
        public List<Resource> ResourcesXML { get; set; }
        [XmlArray("Products")]
        public List<Product> ProductsXML { get; set; }
        [XmlArray("Schematics")]
        public List<Schematic> SchematicsXML { get; set; }
        [XmlArray("Factions")]
        public List<Faction> FactionsXML { get; set; }
        [XmlArray("PlayerAttributes")]
        public List<PlayerAttribute> PlayerAttributesXML { get; set; }
        [XmlArray("Skills")]
        public List<Skill> SkillsXML { get; set; }
        [XmlArray("Research")]
        public List<Research> ResearchXML { get; set; }
        /*
        [XmlArray("NpcNames")]
        [XmlArrayItem("Name")]
        public List<string> NpcNamesXML { get; set; }
        [XmlArray("SystemNames")]
        [XmlArrayItem("Name")]
        public List<string> SystemNamesXML { get; set; }
        */

        private XMLSerializer Serializer = new XMLSerializer();

        public ControlData()
        {
            Variables = Serializer.Deserialize<Variables>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Variables.xml");
            Resources = Serializer.Deserialize<List<Resource>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Resource.xml");
            Products = Serializer.Deserialize<List<Product>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Product.xml");
            Schematics = Serializer.Deserialize<List<Schematic>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Schematic.xml");
            Factions = Serializer.Deserialize<List<Faction>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Faction.xml");
            PlayerAttributes = Serializer.Deserialize<List<PlayerAttribute>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\PlayerAttribute.xml");
            Skills = Serializer.Deserialize<List<Skill>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Skill.xml");
            Research = Serializer.Deserialize<List<Research>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Research.xml");

            VariablesXML = Serializer.Deserialize<Variables>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Variables.xml");
            ResourcesXML = Serializer.Deserialize<List<Resource>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Resource.xml");
            ProductsXML = Serializer.Deserialize<List<Product>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Product.xml");
            SchematicsXML = Serializer.Deserialize<List<Schematic>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Schematic.xml");
            FactionsXML = Serializer.Deserialize<List<Faction>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Faction.xml");
            PlayerAttributesXML = Serializer.Deserialize<List<PlayerAttribute>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\PlayerAttribute.xml");
            SkillsXML = Serializer.Deserialize<List<Skill>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Skill.xml");
            ResearchXML = Serializer.Deserialize<List<Research>>(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\Research.xml");

            NpcNames = GetNames("NpcNames.txt");
            SystemNames = GetNames("SystemNames.txt");
        }

        public List<string> GetNames(string FileName)
        {
            int i = 0;
            string line = "";
            List<string> list = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Owner\Documents\Visual Studio 2017\GameR1\GameR1\Meta\" + FileName))
                {
                    #if DEBUG
                        Console.WriteLine("File " + FileName + " being read");
                    #endif
                    while ((line = sr.ReadLine()) != null)
                    {
                        list.Add(line.Trim());
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                #if DEBUG
                    Console.WriteLine(e.Message);
                #endif
            }
            return list;
        }
    }
}
