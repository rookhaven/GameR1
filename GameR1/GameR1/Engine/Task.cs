using System;

namespace Game.Engine
{
	/*************************************************************************
     * The Events class handles all events that have duration,
     * both system and Actor driven.
     *************************************************************************/
	public class Task
	{
		private Galaxy Galaxy;

        public enum TaskType { AI, Resource, Population, Economy };

        public Task (Galaxy Galaxy)
		{
			this.Galaxy = Galaxy;
		}

		/*******************************************************************
        * SysTaskAI will maintain all AI activities not covered by the other tasks.
        * It will only start once the Actor has been created.
        *******************************************************************/
		public void SysTaskAI ()
		{
			#if DEBUG
			Console.WriteLine ("SysTaskAI Started:  {0:HH:mm:ss.fff}", DateTime.Now);
			#endif
			
			#if DEBUG
			Console.WriteLine ("SysTaskAI Finished:  {0:HH:mm:ss.fff}", DateTime.Now);
			#endif
		}

		/*******************************************************************
        * The SysTaskCities will maintain
        * the population levels of each Actor city in the game.  
        * It will also generate Actor tax based on population levels.
        *******************************************************************/
		public void SysTaskCities ()
		{
			#if DEBUG
			Console.WriteLine ("SysTaskCities Started:  {0:HH:mm:ss.fff}", DateTime.Now);
			#endif
			
			#if DEBUG
			Console.WriteLine ("SysTaskCities Finished:  {0:HH:mm:ss.fff}", DateTime.Now);
			#endif
		}

		/*******************************************************************
        * SysTaskIndustry will maintain industrial resource generation.
        *******************************************************************/
		public void SysTaskIndustry ()
		{
			#if DEBUG
			Console.WriteLine ("SysTaskIndustry Started:  {0:HH:mm:ss.fff}", DateTime.Now);
			#endif
			
			// Select and process all stations
			#if DEBUG
			Console.WriteLine ("SysTaskIndustry Finished:  {0:HH:mm:ss.fff}", DateTime.Now);
			#endif
		}
    }
}

