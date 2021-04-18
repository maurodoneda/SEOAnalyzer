using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Logic
{
    public class SearchService
    {
        private readonly DataContext _context;

        public SearchService(DataContext context)
        {
            _context = context;
        }

        public List<Result> GetGoogleResults(string searchTerm, int numberOfResult)
        {
            var search = new Search
            {
                Query = searchTerm,
                Date = DateTime.Now
            };


            var results = new List<Result>();

            //land + registry + search
            string urlAddress = $"https://www.google.co.uk/search?num={numberOfResult}&q={searchTerm}";
            // need to process to get the real URL of the question.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();

                //foreach (var item in data)
                //{
                //    var result = new Result
                //    {
                //        //Url = item.Url,
                //        //Position = item.Postion
                //    };

                //    results.Add(result);

                //}

                search.Results = results;
                _context.Searches.Add(search);

                response.Close();
                readStream.Close();
            }

        
            _context.SaveChanges();

            return results;
        }
    }
}
