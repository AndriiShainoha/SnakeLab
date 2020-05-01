using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities
{
    class YellowSkinSnakeCreator : SnakeCreator
    {
        public override SimpleSnake Create(int elementSize)
        {
            return new YellowSkinSnake(elementSize, this.mainWindow);
        }
    }
}
