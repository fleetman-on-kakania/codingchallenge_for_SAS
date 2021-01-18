using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class SearchResults
    {
        public SearchResults()
        {
            Shirts = new List<Shirt>();
            SizeCounts = new List<SizeCount> {
                new SizeCount { Size = Size.Small, Count = 0},
                new SizeCount { Size = Size.Medium, Count = 0},
                new SizeCount { Size = Size.Large, Count = 0}

            };
            ColorCounts = new List<ColorCount>
            {
                new ColorCount {Color = Color.Black, Count = 0},
                new ColorCount {Color = Color.Blue, Count = 0},
                new ColorCount {Color = Color.Red, Count = 0},
                new ColorCount {Color = Color.White, Count = 0},
                new ColorCount {Color = Color.Yellow, Count = 0}
            };

        }
        public List<Shirt> Shirts { get; set; }


        public List<SizeCount> SizeCounts { get; set; }


        public List<ColorCount> ColorCounts { get; set; }
    }


    public class SizeCount
    {
        public Size Size { get; set; }

        public int Count { get; set; }
    }


    public class ColorCount
    {
        public Color Color { get; set; }

        public int Count { get; set; }
    }
}