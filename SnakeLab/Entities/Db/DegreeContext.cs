using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.Db
{
    public class DegreeContext : DbContext
    {
        public DbSet<Degree> Degrees { get; set; }
    }
}
