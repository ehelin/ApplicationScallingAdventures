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

        //TODO - write a version of your scaling app to implement crdt's
        //first write to a static list from multiple threads and have the results come out as expected
        //http://www.se-radio.net/2016/03/se-radio-episode-252-christopher-meiklejohn-on-crdts/
        private static void Run()
        {
            Scaling scaling = new Scaling();
            scaling.RunScaling();

            Console.Read();    //wait for developer to close application :)
        }
    }
}
