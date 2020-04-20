using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.Db
{
    public interface IDegreeWarehouse : IDisposable
    {
        Degree GetDegree(int number);
    }
}
