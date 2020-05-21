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
    class GreenSkinSnake : SimpleSnake, IAnimal
    {
        public GreenSkinSnake(int elementSize)
        {
            base.Color = Brushes.Green;
            Elements = new List<SnakeElement>();
            _elementSize = elementSize;
        }

        public GreenSkinSnake()
        {

        }

        public override string GetColor()
        {
            string str = "Green snake has green color";
            return str;
        }

        public override string GetCharacteristicsOfKind()
        {
            string str = "Green snakes are popular in USA.";
            return str;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitGreenSnake(this);
        }
    }
}
