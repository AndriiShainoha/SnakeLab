using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    interface IVisitor
    {
        void VisitBlueSnake(BlueSkinSnake blueSkinSnake);
        void VisitGreenSnake(GreenSkinSnake blueSkinSnake);
        void VisitYellowSnake(YellowSkinSnake blueSkinSnake);

    }
}
