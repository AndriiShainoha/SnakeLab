using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities
{
    class YellowSnakeCreator : SnakeCreator
    {
        public override Snake Create(int elementSize)
        {
            return new YellowSnake(elementSize);
        }
    }
}
