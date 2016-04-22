using Implementation;
using System;

namespace ApplicationScallingAdventures
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            Scaling scaling = new Scaling();
            scaling.RunScaling();

            Console.Read();    //wait for developer to close application :)
        }
    }
}
