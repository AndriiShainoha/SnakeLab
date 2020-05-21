using SnakeLab.Entities.Observer;
using SnakeLab.Entities.SnakeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeLab.Entities
{
    [Serializable]
    class YellowSkinSnake : SimpleSnake, IAnimal
    {
        public YellowSkinSnake(int elementSize)
        {
            base.Color = Brushes.Yellow;
            Elements = new List<SnakeElement>();
            _elementSize = elementSize;
        }

        public YellowSkinSnake()
        {
        }

        public override string GetColor()
        {
            string str = "Yellow snake has yellow color";
            return str;
        }

        public override string GetCharacteristicsOfKind()
        {
            string str = "Yellow snakes are popular in Australia.";
            return str;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitYellowSnake(this);
        }
    }
}
