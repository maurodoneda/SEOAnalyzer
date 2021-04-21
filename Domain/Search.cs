using System;
using System.Collections.Generic;

namespace Domain
{
    public class Search
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public DateTime Date { get; set; }
        public int ResultId { get; set; }
        public Result Result { get; set; }
    }
}
