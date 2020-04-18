using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeLab.Entities
{
    abstract class Snake
    {
        public MovementDirection MovementDirection { get; set; }
        public abstract void UpdateMovementDirection(MovementDirection up);
        public abstract void Grow();
        public abstract bool CollisionWithSelf();
        public abstract void PositionFirstElement(int cols, int rows, MovementDirection initialDirection);
        public abstract void MoveSnake();
    }
}
