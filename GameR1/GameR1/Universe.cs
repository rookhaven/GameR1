using System;
using System.Diagnostics;

using Game.Meta;

namespace Game
{
    class Universe
    {
        public Galaxy Galaxy;

        static void Main(string[] args)
        {
            Stopwatch StopWatch = new Stopwatch();
            StopWatch.Start();

            Universe Universe = new Universe
            {
                Galaxy = new Galaxy()
            };

            Console.WriteLine(Universe.Galaxy.ToString());

            Console.WriteLine("         Sectors: " + ControlData.Variables.Sectors);
            Console.WriteLine("  StarsPerSector: " + ControlData.Variables.StarsPerSector);
            Console.WriteLine("PlanetsPerSystem: " + ControlData.Variables.PlanetsPerSystem);
            Console.WriteLine("  ZonesPerPlanet: " + ControlData.Variables.ZonesPerPlanet);
            Console.WriteLine(" DepositsPerZone: " + ControlData.Variables.DepositsPerZone);

            Process proc = Process.GetCurrentProcess();
            Console.WriteLine();
            Console.WriteLine(" Physical Memory: {0:###,###} kb", proc.WorkingSet64 / 1024);
            Console.WriteLine("Peak Working Set: {0:###,###} kb", proc.PeakWorkingSet64 / 1024);
            Console.WriteLine("Page Memory Size: {0:###,###} kb", proc.PagedMemorySize64 / 1024);
            Console.WriteLine();

            StopWatch.Stop();
            TimeSpan ts = StopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            Console.WriteLine();
            Console.WriteLine("Total Runtime: " + elapsedTime);
            Console.WriteLine();

            Universe.Galaxy.SaveXML();
            //Universe.Galaxy.SaveBIN();
            //Universe.Galaxy.LoadBIN();

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
