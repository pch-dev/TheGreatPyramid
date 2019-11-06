using TheGreatPyramid.Models;

namespace TheGreatPyramid.Services.Interface
{
    public interface IPyramidValueCalculator
    {
        CalculationResult CalculationResult { get; }
        void Execute();
    }
}
