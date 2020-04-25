using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeLab.Entities.Food
{
    public class ClassicApple : Apple
    {
        public ClassicApple(int size)
        {
            Rectangle rect = new Rectangle
            {
                Width = size - 4,
                Height = size - 4,
                Fill = Brushes.Red,
                RadiusX = 10,
                RadiusY = 10
            };
            UIElement = rect;
        }

        public override bool Equals(object obj)
        {
            if (obj is Apple apple)
                return X == apple.X && Y == apple.Y;
            else
                return false;
        }

        public override int GetHashCode() => GetHashCode();
        public override string ToString() => ToString();
    }
}
