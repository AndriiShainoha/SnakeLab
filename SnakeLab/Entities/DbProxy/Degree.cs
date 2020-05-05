using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.Db
{
    public class Degree
    {
        public int Id { get; set; }
        public string DegreeName { get; set; }
        public int MinLevel { get; set; }
        public int MaxLevel { get; set; }
    }
}
