using System;
using System.Collections.Generic;
using System.Linq;
using ConstructionLine.CodingChallenge.Tests.SampleData;
using NUnit.Framework;

namespace ConstructionLine.CodingChallenge.Tests
{
    [TestFixture]
    public class SearchEngineTests : SearchEngineTestsBase
    {
        [Test]
        public void Test()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red },
                Sizes = new List<Size> { Size.Small }
            };

            var results = searchEngine.Search(searchOptions);
           
            SelfExplanatoryAssert(total: 1, 
                reds: 1, blues: 0, yellows: 0, whites: 0, blacks: 0, 
                smalls: 1, mediums: 0, larges: 0, 
                results);
            
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void ShouldReturnMoreThanOneShirtCase()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Red - Medium", Size.Medium, Color.Red),
                new Shirt(Guid.NewGuid(), "Blue - Small", Size.Small, Color.Blue),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red },
                Sizes = new List<Size> { Size.Small }
            };

            var results = searchEngine.Search(searchOptions);

            SelfExplanatoryAssert(total: 3,
                reds: 3, blues: 0, yellows: 0, whites: 0, blacks: 0,
                smalls: 3, mediums: 0, larges: 0,
                results);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void ShouldReturnZeroResultsWhenNoSizesInOptions()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red }
            };

            var results = searchEngine.Search(searchOptions);
            
            SelfExplanatoryAssert(total: 0,
                reds: 0, blues: 0, yellows: 0, whites: 0, blacks: 0,
                smalls: 0, mediums: 0, larges: 0,
                results);
            
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
        }
        [Test]
        public void ShouldReturnZeroResultsWhenNoColorsInOptions()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Sizes = new List<Size> { Size.Small }
            };

            var results = searchEngine.Search(searchOptions);

            SelfExplanatoryAssert(total: 0,
                reds: 0, blues: 0, yellows: 0, whites: 0, blacks: 0,
                smalls: 0, mediums: 0, larges: 0,
                results);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void ShouldReturnZeroResultsWhenEmptyOptions()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions { };

            var results = searchEngine.Search(searchOptions);

            SelfExplanatoryAssert(total: 0,
                reds: 0, blues: 0, yellows: 0, whites: 0, blacks: 0,
                smalls: 0, mediums: 0, larges: 0,
                results);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void ShouldReturnRightResultWhenMultipleOptions()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red, Color.Black },
                Sizes = new List<Size> { Size.Small, Size.Large }
            };

            var results = searchEngine.Search(searchOptions);

            SelfExplanatoryAssert(total: 1,
                reds: 1, blues: 0, yellows: 0, whites: 0, blacks: 0,
                smalls: 1, mediums: 0, larges: 0,
                results);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
        }
        [Test]
        public void ShouldReturnRightResultWhenMultipleRepeatedOptions()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red, Color.Black, Color.Red, Color.Red },
                Sizes = new List<Size> { Size.Small, Size.Large, Size.Small }
            };

            var results = searchEngine.Search(searchOptions);

            SelfExplanatoryAssert(total: 1,
                reds: 1, blues: 0, yellows: 0, whites: 0, blacks: 0,
                smalls: 1, mediums: 0, larges: 0,
                results);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void ShouldReturnRightResultWhenMultipleRepeatedOptionsAndAMoreComplicatedListToBeSearched()
        {
            var shirts = new List<Shirt>
            {
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Medium", Size.Medium, Color.Black),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Red - Small", Size.Small, Color.Red),
                new Shirt(Guid.NewGuid(), "Red - Medium", Size.Medium, Color.Red),
                new Shirt(Guid.NewGuid(), "Blue - Small", Size.Small, Color.Blue),
                new Shirt(Guid.NewGuid(), "Blue - Large", Size.Large, Color.Blue),
                new Shirt(Guid.NewGuid(), "Red - Large", Size.Large, Color.Red),
                new Shirt(Guid.NewGuid(), "Black - Small", Size.Small, Color.Black),
                new Shirt(Guid.NewGuid(), "Black - Large", Size.Large, Color.Black),
            };

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red, Color.Black, Color.Red, Color.Red },
                Sizes = new List<Size> { Size.Small, Size.Large, Size.Small }
            };

            var results = searchEngine.Search(searchOptions);

            SelfExplanatoryAssert(total: 6,
                reds: 4, blues: 0, yellows: 0, whites: 0, blacks: 2,
                smalls: 4, mediums: 0, larges: 2,
                results);
            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
        }

        [Test]
        public void ShouldReturnRightResultWhenMultipleRepeatedOptionsAndARandomListOfShirtsIsPassed()
        {
            var dataBuilder = new SampleDataBuilder(10000);

            var shirts = dataBuilder.CreateShirts();

            var searchEngine = new SearchEngine(shirts);

            var searchOptions = new SearchOptions
            {
                Colors = new List<Color> { Color.Red, Color.Black, Color.Red, Color.Red },
                Sizes = new List<Size> { Size.Small, Size.Large, Size.Small }
            };

            var results = searchEngine.Search(searchOptions);

            AssertResults(results.Shirts, searchOptions);
            AssertSizeCounts(results.Shirts, searchOptions, results.SizeCounts);
            AssertColorCounts(results.Shirts, searchOptions, results.ColorCounts);
        }

        private void SelfExplanatoryAssert(int total, int reds, int blues, int yellows, int whites, int blacks, int smalls, int mediums, int larges, SearchResults results)
        {
            Assert.AreEqual(total, results.Shirts.Count, $"Total count is wrong");
            Assert.AreEqual(reds, results.ColorCounts.Single(x => x.Color == Color.Red).Count, $"Reds count is wrong");
            Assert.AreEqual(blues, results.ColorCounts.Single(x => x.Color == Color.Blue).Count, $"Blues count is wrong");
            Assert.AreEqual(yellows, results.ColorCounts.Single(x => x.Color == Color.Yellow).Count, $"Yellows count is wrong");
            Assert.AreEqual(whites, results.ColorCounts.Single(x => x.Color == Color.White).Count, $"Whites count is wrong");
            Assert.AreEqual(blacks, results.ColorCounts.Single(x => x.Color == Color.Black).Count, $"Blacks count is wrong");
            Assert.AreEqual(smalls, results.SizeCounts.Single(x => x.Size == Size.Small).Count, $"Smalls count is wrong");
            Assert.AreEqual(mediums, results.SizeCounts.Single(x => x.Size == Size.Medium).Count, $"Mediums count is wrong");
            Assert.AreEqual(larges, results.SizeCounts.Single(x => x.Size == Size.Large).Count, $"Larges count is wrong");
        }

    }
}
