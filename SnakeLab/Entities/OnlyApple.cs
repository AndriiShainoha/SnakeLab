using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeLab.Entities
{
    public class OnlyApple
    {
        public UIElement UIElement { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private static Random _randoTron = new Random(DateTime.Now.Millisecond / DateTime.Now.Second);

        private static OnlyApple onlyAppleInstance;
        public OnlyApple(int size)
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
            X = _randoTron.Next(4, 5) * size;
            Y = _randoTron.Next(4, 5) * size;
        }

        public static OnlyApple getOnlyAppleInstance(int ElementSize)
        {
            if (onlyAppleInstance == null)
            {
                onlyAppleInstance = new OnlyApple(ElementSize);
            }
            return onlyAppleInstance;
        }

        public override bool Equals(object obj)
        {
            if (obj is OnlyApple onlyApple)
                return X == onlyApple.X && Y == onlyApple.Y;
            else
                return false;
        }

        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => base.ToString();
    }
}
