using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Result
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int  Position { get; set; }
        public Search Search { get; set; }
    }
}
