using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeLab.Entities
{
    public abstract class Apple : GameEntity
    {
        public abstract bool Equals(object obj);
        public abstract int GetHashCode();
        public abstract string ToString();
    }
}
