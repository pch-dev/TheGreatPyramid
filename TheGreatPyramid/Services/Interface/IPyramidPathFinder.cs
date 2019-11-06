using System.Collections.Generic;
using TheGreatPyramid.Models;

namespace TheGreatPyramid.Services.Interface
{
    public interface IPyramidPathFinder
    {
        Pyramid Pyramid { get; set; }
        IList<PyramidItem> PyramidPath { get; }
        void FindPyramidPath();
    }
}
