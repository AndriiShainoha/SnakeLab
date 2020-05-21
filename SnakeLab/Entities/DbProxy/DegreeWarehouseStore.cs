using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.Db
{
    public class DegreeWarehouseStore : IDegreeWarehouse
    {
        DegreeContext db;
        public DegreeWarehouseStore()
        {
            db = new DegreeContext();
        }

        public Degree GetDegree(int number)
        {
            return db.Degrees.FirstOrDefault(p => p.Id == number);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
