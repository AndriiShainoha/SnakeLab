using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    interface ISimpleSnakeState
    {
        void Eat(SimpleSnake simpleSnake);
    }
}
