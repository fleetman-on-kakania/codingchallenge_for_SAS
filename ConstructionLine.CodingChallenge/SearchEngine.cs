using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
        }
        public SearchResults Search(SearchOptions options)
        {
            var searchResults = new SearchResults();


            searchResults.Shirts
                .AddRange(_shirts.Where(x => options.Colors.Contains(x.Color) && options.Sizes.Contains(x.Size)));

            foreach (var color in Color.All)
            {
                searchResults.ColorCounts.Single(x => x.Color == color).Count = searchResults.Shirts.Count(x => x.Color == color);
            }

            foreach (var size in Size.All)
            {
                searchResults.SizeCounts.Single(x => x.Size == size).Count = searchResults.Shirts.Count(x => x.Size == size);
            }

            return searchResults;
        }
        
    }
}