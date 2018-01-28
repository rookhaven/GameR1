using System.Collections.Generic;

using Game.Engine;

namespace Game.DAO
{
    public interface IDetailDataReader
    {
        int GetStardate();
        List<Star> GetSystems();
        List<Index> GetIndex();
        List<Event> GetEvents();
        List<Civilization> GetCivilizations();
    }
}
