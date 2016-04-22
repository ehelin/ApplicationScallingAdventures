using System;
using Shared.abstractClasses;
using System.Threading.Tasks;
using Implementation.builders;

namespace Implementation.scaling
{
    public class VerticalScaling
    {
        public bool Complete { get; set; }

        private static int numberOfEnginesBuilt = 0;

        private int numberOfBuilderResources = 0;
        private bool printToConsole = true;
        private bool clearClassTotalVariable = true;
        private bool setHorizontalScalingCompleteCount = false;

        public VerticalScaling(int numberOfBuilderResources, bool clearClassTotalVariable, bool printToConsole, bool setHorizontalScalingCompleteCount)
        {
            this.numberOfBuilderResources = numberOfBuilderResources;
            this.clearClassTotalVariable = clearClassTotalVariable;
            this.printToConsole = printToConsole;
            this.setHorizontalScalingCompleteCount = setHorizontalScalingCompleteCount;
        }

        public async Task<bool> RunVerticalScaling()
        {
            if (printToConsole)
                Console.WriteLine("Starting Vertical Scaling with " + numberOfBuilderResources.ToString() + " builder resource(s) - " + DateTime.Now.ToString());

            if (this.clearClassTotalVariable)
                numberOfEnginesBuilt = 0;

            await RunScaling();

            if (printToConsole)
            {
                Console.WriteLine("Number of engines built - " + numberOfEnginesBuilt.ToString());
                Console.WriteLine("Vertical Scaling is Done! - " + DateTime.Now.ToString());
            }

            if (setHorizontalScalingCompleteCount)
            {
                HorizontalScaling.UpdateCompletedBuilders();
            }

            return true;
        }

        #region private methods

        private async Task<bool> RunScaling()
        {
            bool done = false;

            Builder engineBuilder = new BuildEngine(numberOfBuilderResources);
            done = await engineBuilder.RunBuilders();

            return done;
        }

        #endregion

        #region static methods

        static object SpinLock = new object();
        public static void SetNumberOfEnginesBuilt(int pNumberOfEnginesBuilt)
        {
            lock(SpinLock)
            {
                numberOfEnginesBuilt += pNumberOfEnginesBuilt;
            }
        }

        public static int GetNumberOfEnginesBuilt()
        {
            return numberOfEnginesBuilt;
        }

        #endregion
    }
}
