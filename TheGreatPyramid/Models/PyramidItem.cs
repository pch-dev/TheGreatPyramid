namespace TheGreatPyramid.Models
{
    public class PyramidItem
    {
        public int Number { get; set; }
        public int Index { get; set; }

        public bool IsNumberEven()
        {
            return Number % 2 == 0;
        }
    }
}
