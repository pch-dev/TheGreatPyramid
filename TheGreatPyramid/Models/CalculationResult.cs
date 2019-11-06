using System.Collections.Generic;

namespace TheGreatPyramid.Models
{
    public class CalculationResult
    {
        public int CalculatedValue { get; set; }
        public IList<PyramidItem> PyramidPath { get; set; }
    }
}
