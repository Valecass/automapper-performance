using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAutomapper.Models
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Property { get; set; }

        public List<int> Numbers { get; set; }
    }
}
