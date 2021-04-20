using Data;
using Domain;
using HtmlAgilityPack;
using Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Logic.Services
{
    public class SearchService : ISearchService
    {
        private readonly DataContext _context;

        public SearchService(DataContext context)
        {
            _context = context;
        }

        //public static string GetPosition(string searchTerm, string url)
        //{
        //    string raw = "http://www.google.co.uk/search?num=100&q={0}&btnG=Search";

        //    string search = string.Format(raw, HttpUtility.UrlEncode(searchTerm));
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
        //    {
        //        string html = reader.ReadToEnd();

        //        return FindPosition(html, url);
        //    }
        //}

        //private static string FindPosition(string html, string url)
        //{
        //    string lookup = new Regex("<span class=\"BNeawe\\><a href =\"(\\w+[a-zA-Z0-9.-?=/]*)>").ToString();

        //    MatchCollection matches = Regex.Matches(html, lookup);
        //    string resultPositions = "";
        //    for (int i = 0; i < matches.Count; i++)
        //    {
        //        string match = matches[i].Groups[2].Value;
        //        if (match.Contains(url))
        //            resultPositions += $"{i + 1},";
        //    }
        //    return resultPositions.TrimEnd(',');
        //}

        public async Task<string> GetGoogleResultsAsync(string searchTerm, string url)
        {
            var search = new Search
            {
                Query = searchTerm,
                Date = DateTime.Now
            };

            //land + registry + search
            int maxResultPosition = 100;
            searchTerm = searchTerm.Replace(' ', '+');

            string searchUrl = $"http://www.google.co.uk/search?num={maxResultPosition}&q={searchTerm}";
            // need to process to get the real URL of the question.

            var response = new HtmlWeb().Load(searchUrl);

            //resultContent.DocumentNode.SelectNodes("//span[contains(@class, 'BNeawe')]")
            var nodes = response.DocumentNode.SelectNodes("//div[contains(@class, 'BNeawe UPmit AP7Wnd')]");


            if (nodes != null)
            {
                string stringResult = "";
                var indexes = nodes.Select((x, i) => new { i, x.InnerHtml })
                                    .Where(x => x.InnerHtml.Contains(url))
                                    .Select(x => x.i + 1);

                foreach (var i in indexes)
                {
                    stringResult += $"{i},";
                }

                stringResult = stringResult.TrimEnd(',');
                var result = new Result()
                {
                    UrlAnalyzed = url,
                    Position = stringResult,
                };

                search.Result = result;

                _context.Searches.Add(search);
                _context.SaveChanges();

                return stringResult;
            }

            return "";
        }
    }
}
