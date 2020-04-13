using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities
{
    class GreenSkinSnakeCreator : SnakeCreator
    {
        public override Snake Create(int elementSize)
        {
            return new GreenSkinSnake(elementSize);
        }
    }
}
