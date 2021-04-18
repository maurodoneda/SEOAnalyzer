using System;
using System.Collections.Generic;

namespace Domain
{
    public class Search
    {
        public int Id { get; set; }
        public string Query { get; set; }
        public DateTime Date { get; set; }
        public virtual IEnumerable<Result> Results { get; set; }
    }
}
