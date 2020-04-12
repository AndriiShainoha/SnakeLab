using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeLab.Entities
{
    public class SnakeElement : GameEntity
    {
        public SnakeElement(int size, Brush color)
        {
            UIElement = new Rectangle
            {
                Width = size - 4,
                Height = size - 4,
                Fill = color
                //Fill = Brushes.Green
            };
        }

        public bool IsHead { get; set; }
    }
}
