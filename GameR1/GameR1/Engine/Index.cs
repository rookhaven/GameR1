using System;
using System.Collections.Generic;

namespace Game.Engine
{
    /*************************************************************************
     * The Index class references all objects used when processing tasks.
     * Avoids scanning a largely unpopulated Galaxy unnecessarily.
     *************************************************************************/
    [Serializable()]
    public class Index
	{
		private Galaxy Galaxy;

        public List<Structure> PopulationStructures { get; set; }
        public List<Structure> ResourceStructures { get; set; }
        public List<Structure> EconomicStructures { get; set; }
        public List<Corporation> Corporations { get; set; }

        public Index()
        {
        }

        public Index (Galaxy Galaxy)
		{
			this.Galaxy = Galaxy;
		}
    }
}

