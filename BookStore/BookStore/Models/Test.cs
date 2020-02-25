using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Test
    {
        public Test(int id, string name, int old)
        {
            this.id = id;
            this.name = name;
            this.old = old;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int old { get; set; }
        public string phone { get; set; }
    }
}
