using MoreLinq;
using System.Collections.Generic;
using System.Linq;

namespace TheGreatPyramid.Models
{
    public class PyramidLevel
    {
        public PyramidLevel()
        {
            Items = new List<PyramidItem>();
        }

        public IList<PyramidItem> Items { get; set; }
        public int Depth { get; set; }

        public void AddItem(int number, int index)
        {
            Items.Add(
                new PyramidItem
                {
                    Number = number,
                    Index = index
                });
        }

        public PyramidItem GetMaxItem()
        {
            var item = Items.MaxBy(i => i.Number).Single();

            return item;
        }
    }
}
