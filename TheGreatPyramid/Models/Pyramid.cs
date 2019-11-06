using System;
using System.Collections.Generic;

namespace TheGreatPyramid.Models
{
    public class Pyramid
    {
        public Pyramid()
        {
            Levels = new List<PyramidLevel>();
        }

        public IList<PyramidLevel> Levels { get; set; }

        public void AddLevel(PyramidLevel pyramidLevel)
        {
            if (pyramidLevel == null)
            {
                throw new ArgumentNullException(nameof(pyramidLevel));
            }

            Levels.Add(pyramidLevel);
        }
    }
}
