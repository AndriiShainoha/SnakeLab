using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeLab.Entities
{
    class GreenSkinSnake : SimpleSnake
    {
        public GreenSkinSnake(int elementSize)
        {
            base.Color = Brushes.Green;
            Elements = new List<SnakeElement>();
            _elementSize = elementSize;
        }

    }
}
