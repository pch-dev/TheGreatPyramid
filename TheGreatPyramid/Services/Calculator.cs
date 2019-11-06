using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGreatPyramid.Models;

namespace TheGreatPyramid.Services
{
    public class Calculator
    {
        public Pyramid Pyramid { get; set; }
        public IList<PyramidItem> PyramidPath { get; set; }
        public int MaxSum { get; set; }

        public Calculator()
        {
            Pyramid = new Pyramid();
            PyramidPath = new List<PyramidItem>();
            MaxSum = 0;
        }

        public void Initialize(string[] lines)
        {
            for(int depth = 0; depth < lines.Length; depth++)
            {
                var pyramidLevel = new PyramidLevel();

                pyramidLevel.Depth = depth;

                var line = lines[depth];
                var items = line.Split(' ');

                for (var index = 0; index < items.Length; index++)
                {
                    var item = items[index];
                    var isParsed = int.TryParse(item, out int number);

                    if (!isParsed)
                    {
                        throw new ArgumentException("Pyramid input contains incorrect value.", item);
                    }

                    pyramidLevel.AddItem(number, index);
                }

                Pyramid.AddLevel(pyramidLevel);
            }
        }

        public void CalculatePyramidPath()
        {
            int depth = 0;
            var currentLevel = Pyramid.Levels.Single(l => l.Depth == depth);
            var currentMaxItem = currentLevel.GetMaxItem();

            PyramidPath.Add(currentMaxItem);

            for (depth = 0; depth < Pyramid.Levels.Count; depth++)
            {
                var nextLevel = Pyramid.Levels.SingleOrDefault(l => l.Depth == depth + 1);

                if (nextLevel == null)
                {
                    break; // or something..
                }

                var children = GetChildren(currentMaxItem.Index, nextLevel.Items).Where(c => c.IsEven() != currentMaxItem.IsEven()).ToList();

                var maxItem = GetMaxItem(children);

                PyramidPath.Add(maxItem);

                currentMaxItem = maxItem;
            }
        }

        public void CalculateMaxSum()
        {
            MaxSum = PyramidPath.Select(i => i.Number).Sum();
        }

        private IList<PyramidItem> GetChildren(int parentIndex, IList<PyramidItem> items)
        {
            var children = items.Skip(parentIndex).Take(2).ToList();

            return children;
        }

        public PyramidItem GetMaxItem(IList<PyramidItem> items)
        {
            var item = items.MaxBy(i => i.Number).Single();

            return item;
        }
    }
}
