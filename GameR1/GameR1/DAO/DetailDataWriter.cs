using System.Collections.Generic;

using Game.Engine;

namespace Game.DAO
{
    public interface IDetailDataWriter
    {
        void SetStardate(int x);
        void SetSystems(List<Star> x);
        void SetIndex(List<Index> x);
        void SetEvents(List<Event> x);
        void SetCivilizations(List<Civilization> x);
    }
}
