using MoreLinq;
using System;
using System.Collections.Generic;
using TheGreatPyramid.Models;

namespace TheGreatPyramid.Helpers
{
    public static class ExtensionMethods
    {
        public static PyramidItem GetItemByMaxNumber(this IList<PyramidItem> items)
        {
            var item = items.MaxBy(i => i.Number).Single();

            return item;
        }

        public static int ToInteger(this string value)
        {
            var isParsed = int.TryParse(value, out int number);

            if (!isParsed)
            {
                throw new FormatException($"Pyramid input contains incorrect value: {value}");
            }

            return number;
        }
    }
}
