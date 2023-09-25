using System.Data.SqlTypes;

namespace InfoTrackWebScrape
{
    public static class HelperClass
    {
        public static string ExtractPositionsFromResponse(string response, string urlString)
        {
            var anchorTagsSplit = response.Split("><a href=\"/url?q").ToList<string>();
            var indexValues = anchorTagsSplit.Select((x, i) => new { Value = x, Index = i })
                                                    .Where(b => b.Value.Contains(urlString))
                                                        .Select(c => c.Index).ToList();
            string indexValuesString = string.Join(",", indexValues);
            return (indexValuesString);
        }
    }
}
