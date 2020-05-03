using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities
{
    abstract class SnakeCreator
    {
        public abstract SimpleSnake Create(int elementSize);
    }
}
