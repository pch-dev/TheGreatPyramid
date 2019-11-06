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

        public void AddItem(int number, int index)
        {
            Items.Add(
                new PyramidItem
                {
                    Number = number,
                    Index = index
                });
        }

        public IList<PyramidItem> GetItemsByParentIndex(int parentIndex)
        {
            var children = Items.Skip(parentIndex).Take(2).ToList();

            return children;
        }
    }
}
