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
    public class DemoApple
    {
        public UIElement UIElement { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private static DemoApple onlyAppleInstance;

        private DemoApple(int size)
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
            X = size;
            Y = size;
        }

        public static DemoApple getOnlyAppleInstance(int ElementSize)
        {
            if (onlyAppleInstance == null)
            {
                onlyAppleInstance = new DemoApple(ElementSize);
            }
            return onlyAppleInstance;
        }

        public override bool Equals(object obj)
        {
            if (obj is DemoApple onlyApple)
                return X == onlyApple.X && Y == onlyApple.Y;
            else
                return false;
        }

        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => base.ToString();
    }
}
