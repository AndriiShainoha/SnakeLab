using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeLab.Entities
{
    class YellowSkinSnake : SimpleSnake
    {
        public YellowSkinSnake(int elementSize)
        {
            base.Color = Brushes.Yellow;
            Elements = new List<SnakeElement>();
            _elementSize = elementSize;
        }
    }
}
