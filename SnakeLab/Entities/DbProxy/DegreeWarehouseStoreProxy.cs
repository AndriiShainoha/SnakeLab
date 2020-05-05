using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.Db
{
    public class DegreeWarehouseStoreProxy : IDegreeWarehouse
    {
        List<Degree> degrees;
        DegreeWarehouseStore degreeWarehouseStore;
        public DegreeWarehouseStoreProxy()
        {
            degrees = new List<Degree>();
        }
        public Degree GetDegree(int number)
        {
            Degree degree = degrees.FirstOrDefault(p => p.Id == number);
            if (degree == null)
            {
                if (degreeWarehouseStore == null)
                    degreeWarehouseStore = new DegreeWarehouseStore();
                degree = degreeWarehouseStore.GetDegree(number);
                degrees.Add(degree);
            }
            return degree;
        }

        public void Dispose()
        {
            if (degreeWarehouseStore != null)
                degreeWarehouseStore.Dispose();
        }
    }
}
