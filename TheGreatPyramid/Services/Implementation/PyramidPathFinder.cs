using System.Collections.Generic;
using System.Linq;
using TheGreatPyramid.Helpers;
using TheGreatPyramid.Models;
using TheGreatPyramid.Services.Interface;

namespace TheGreatPyramid.Services.Implementation
{
    public class PyramidPathFinder : IPyramidPathFinder
    {
        public Pyramid Pyramid { get; set; }
        public IList<PyramidItem> PyramidPath { get; set; }
        public IEnumerator<PyramidLevel> Enumerator { get; set; }

        public PyramidPathFinder()
        {
            Pyramid = new Pyramid();
            PyramidPath = new List<PyramidItem>();
        }

        public void FindPyramidPath()
        {
            InitializeEnumerator();

            var parent = InitializeParent();

            PyramidPath.Add(parent);

            while (Enumerator.MoveNext())
            {
                var children = GetChildrenItems(parent);

                var maxItem = children.GetItemByMaxNumber();

                PyramidPath.Add(maxItem);

                parent = maxItem;
            }
        }

        private void InitializeEnumerator()
        {
            Enumerator = Pyramid.Levels.GetEnumerator();
            Enumerator.MoveNext();
        }

        private PyramidItem InitializeParent()
        {
            var topPyramidLevel = Enumerator.Current;
            var parent = topPyramidLevel.Items.GetItemByMaxNumber();

            return parent;
        }

        private IList<PyramidItem> GetChildrenItems(PyramidItem parent)
        {
            var children = Enumerator.Current
                .GetItemsByParentIndex(parent.Index)
                .Where(child => child.IsNumberEven() != parent.IsNumberEven())
                .ToList();

            return children;
        }
    }
}
