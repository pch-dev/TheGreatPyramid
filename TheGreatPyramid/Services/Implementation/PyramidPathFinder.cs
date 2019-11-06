using System;
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

                if (!children.Any())
                {
                    throw new Exception("Pyramid path cannot be completed. No proper child elements found.");
                }

                var maxItem = children.GetItemByMaxNumber();

                PyramidPath.Add(maxItem);

                parent = maxItem;
            }

            DisposeEnumerator();
        }

        private void InitializeEnumerator()
        {
            Enumerator = Pyramid.Levels.GetEnumerator();
            Enumerator.MoveNext();
        }

        private void DisposeEnumerator()
        {
            Enumerator.Dispose();
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
