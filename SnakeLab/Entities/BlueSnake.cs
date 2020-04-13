using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeLab.Entities
{
    class BlueSnake : Snake
    {
        public BlueSnake(int elementSize)
        {
            base.Color = Brushes.Blue;
            Elements = new List<SnakeElement>();
            _elementSize = elementSize;
        }
    }
}
