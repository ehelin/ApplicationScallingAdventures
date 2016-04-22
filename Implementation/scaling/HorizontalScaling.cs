using System;
using Shared.abstractClasses;
using System.Threading.Tasks;
using Implementation.builders;
using System.Collections.Generic;

namespace Implementation.scaling
{
    public class HorizontalScaling
    {
        private List<VerticalScaling> builders = null;
        private int numberOfBuilders = 0;
        private int numberOfResourcesPerBuilder = 0;

        private static int completedBuilders = 0;
        public static void UpdateCompletedBuilders()
        {
            completedBuilders++;
        }

        public HorizontalScaling(int numberOfBuilders, int numberOfResourcesPerBuilder)
        {
            builders = new List<VerticalScaling>();

            this.numberOfBuilders = numberOfBuilders;
            this.numberOfResourcesPerBuilder = numberOfResourcesPerBuilder;

            Init(numberOfBuilders, numberOfResourcesPerBuilder);
        }

        public async Task<bool> RunHorizontalScaling()
        {
            int numberOfEnginesBuilt = 0;
            Console.WriteLine("Starting Horizonal Scaling with " + this.numberOfBuilders.ToString() + " builders with "
                                + this.numberOfResourcesPerBuilder.ToString() + " resources per builder - " + DateTime.Now.ToString());

            foreach (VerticalScaling builder in builders)
            {
                builder.RunVerticalScaling();
            }

            while (HorizontalScaling.completedBuilders < this.numberOfBuilders)
            {
                System.Threading.Thread.Sleep(1000);
            }

            numberOfEnginesBuilt = VerticalScaling.GetNumberOfEnginesBuilt();

            Console.WriteLine("Number of engines built - " + numberOfEnginesBuilt.ToString());
            Console.WriteLine("Horizontal Scaling is Done! - " + DateTime.Now.ToString());

            return true;
        }

        #region private methods

        private void Init(int numberOfBuilders, int numberOfResourcesPerBuilder)
        {
            int counter = 0;

            while (counter < numberOfBuilders)
            {
                this.builders.Add(new VerticalScaling(numberOfResourcesPerBuilder, true, true, true));             
                counter++;
            }
        }

        #endregion

    }
}
