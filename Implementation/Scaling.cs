using System.Threading.Tasks;
using Implementation.scaling;

namespace Implementation
{
    public class Scaling
    {
        public Scaling() { }

        public void RunScaling()
        {
            Run();
        }

        #region private methods 

        private async void Run()
        {
            await RunVerticalScaling();
            await RunHorizatalScaling();
        }

        private async Task<bool> RunHorizatalScaling()
        {
            HorizontalScaling horizontalScaling = new HorizontalScaling(5, 5);
            bool done = await horizontalScaling.RunHorizontalScaling();

            return done;
        }

        private async Task<bool> RunVerticalScaling()
        {
            VerticalScaling verticalScaling = new VerticalScaling(5, true, true, false);
            bool done = await verticalScaling.RunVerticalScaling();

            return done;
        }

        #endregion
    }
}
