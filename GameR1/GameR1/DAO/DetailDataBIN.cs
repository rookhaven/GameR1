using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using Game.Engine;

namespace Game.DAO
{
    /*******************************************************************
    * DetailDataBIN holds all the Galaxy detail data for game saves
    *******************************************************************/
    [Serializable()]
    public class DetailDataBIN
    {
        public int Stardate { get; set; }
        public List<Star> Systems { get; set; }
        public List<Index> Index { get; set; }
        public List<Event> Events { get; set; }
        public List<Civilization> Civilizations { get; set; }

        public DetailDataBIN() { }

        public DetailDataBIN(SerializationInfo info, StreamingContext ctxt)
        {
            Stardate = (int)info.GetValue("Stardate", typeof(int));
            Systems = (List<Star>)info.GetValue("Systems", typeof(List<Star>));
            Civilizations = (List<Civilization>)info.GetValue("Civilizations", typeof(List<Civilization>));
            Index = (List<Index>)info.GetValue("Index", typeof(List<Index>));
            Events = (List<Event>)info.GetValue("Events", typeof(List<Event>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Stardate", Stardate);
            info.AddValue("Systems", Systems);
            info.AddValue("Civilizations", Civilizations);
            info.AddValue("Index", Index);
            info.AddValue("Events", Events);
        }

        public void Load(Galaxy g, string fileName)
        {
            DetailDataBIN detail = new DetailDataBIN();
            using (Stream stream = File.Open(fileName, FileMode.Open))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                detail = (DetailDataBIN)bFormatter.Deserialize(stream);
            }
            g = new Galaxy(detail);
        }

        public void Save(Galaxy g, string fileName)
        {
            Stardate = g.Stardate;
            Systems = g.Systems;
            Civilizations = g.Civilizations;
            Index = g.Index;
            Events = g.Events;

            using (Stream stream = File.Open(fileName, FileMode.Create))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, this);
            }
        }
    }
}