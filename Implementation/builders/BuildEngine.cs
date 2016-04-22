using System.Collections.Generic;
using System.Threading.Tasks;
using Implementation.scaling;
using Shared.abstractClasses;
using Shared.dto;
using Shared;

namespace Implementation.builders
{
    public class BuildEngine : Builder
    {
        public BuildEngine(int numberOfBuilderResources)
        {
            this.Name = BuilderConstants.ENGINE;
            this.builderResources = new List<Task>();

            Init(numberOfBuilderResources);
        }

        private void Init(int numberOfBuilderResources)
        {
            int counter = 0;

            while (counter < numberOfBuilderResources)
            {
                this.builderResources.Add(Task.Run(() => this.BuildPart()));

                counter++;
            }
        }

        public async override Task<bool> RunBuilders()
        {
            await Task.WhenAll(builderResources);

            return true;
        }

        public async override Task<Part> BuildPart()
        {
            Engine part = new Engine();

            int counter = 0;

            while (counter < BuilderConstants.ENGINE_BUILDER_METHOD_INTERATION_COUNT)
            {
                //Console.WriteLine("Building " + PartConstants.ENGINE + "...count is " + counter.ToString());
                System.Threading.Thread.Sleep(BuilderConstants.ENGINE_BUILDER_WAIT_TIME);

                counter++;
            }

            VerticalScaling.SetNumberOfEnginesBuilt(1);

            return part;
        }
    }
}
