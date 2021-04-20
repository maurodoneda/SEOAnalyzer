using Data;
using Domain;
using HtmlAgilityPack;
using Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class SearchService : ISearchService
    {
        private readonly DataContext _context;

        public SearchService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> GetGoogleResultsAsync(string searchTerm, string url)
        {
            Search search = new Search
            {
                Query = searchTerm,
                Date = DateTime.Now
            };

            Result result = new Result()
            {
                UrlAnalyzed = url,
            };

            int maxResultPosition = 100;
            searchTerm = searchTerm.Replace(' ', '+');

            if (url.Contains("www"))
            {
                url = url.Replace("www.", "").Split('.')[0];

            }

            string searchUrl = $"http://www.google.co.uk/search?num={maxResultPosition}&q={searchTerm}";
            // need to process to get the real URL of the question.

            HtmlDocument response = new HtmlWeb().Load(searchUrl);

            //resultContent.DocumentNode.SelectNodes("//span[contains(@class, 'BNeawe')]")
            HtmlNodeCollection nodes = response.DocumentNode.SelectNodes("//div[contains(@class, 'BNeawe UPmit AP7Wnd')]");

            if (nodes != null)
            {
                string stringResult = "";
                IEnumerable<int> indexes = nodes.Select((x, i) => new { i, x.InnerHtml })
                                    .Where(x => x.InnerHtml.Contains(url))
                                    .Select(x => x.i + 1);

                foreach (int i in indexes)
                {
                    stringResult += $"{i},";
                }

                stringResult = stringResult.TrimEnd(',');


                result.Position = stringResult;
                search.Result = result;

                _context.Searches.Add(search);
                _context.SaveChanges();

                return stringResult;
            }

            return "";
        }
    }
}
