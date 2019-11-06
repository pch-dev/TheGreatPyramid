using System;
using System.Linq;
using TheGreatPyramid.Models;
using TheGreatPyramid.Services.Interface;

namespace TheGreatPyramid.Services.Implementation
{
    public class PyramidValueCalculator : IPyramidValueCalculator
    {
        private readonly IPyramidCreator pyramidCreator;
        private readonly IPyramidPathFinder pyramidPathFinder;

        public PyramidValueCalculator(
            IPyramidCreator pyramidCreator, 
            IPyramidPathFinder pyramidPathFinder)
        {
            this.pyramidCreator = pyramidCreator ?? throw new ArgumentNullException(nameof(pyramidCreator));
            this.pyramidPathFinder = pyramidPathFinder ?? throw new ArgumentNullException(nameof(pyramidPathFinder));

            CalculationResult = new CalculationResult();
        }

        public int CalculatedValue { get; set; }
        public CalculationResult CalculationResult { get; set; }

        public void Execute()
        {
            Initialize();
            FindPath();
            CalculateValue();
            SetResult();
        }

        public void Initialize()
        {
            var pyramid = pyramidCreator.CreatePyramid();

            pyramidPathFinder.Pyramid = pyramid;
        }

        public void FindPath()
        {
            pyramidPathFinder.FindPyramidPath();
        }

        public void CalculateValue()
        {
            CalculatedValue = pyramidPathFinder.PyramidPath.Select(i => i.Number).Sum();
        }

        public void SetResult()
        {
            CalculationResult.PyramidPath = pyramidPathFinder.PyramidPath;
            CalculationResult.CalculatedValue = CalculatedValue;
        }
    }
}
