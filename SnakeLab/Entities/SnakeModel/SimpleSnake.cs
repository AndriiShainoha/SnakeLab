using SnakeLab.Entities.SnakeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SnakeLab.Entities
{
    class SimpleSnake : Snake
    {
        public int _elementSize { get; set; }
        public Brush Color { get; set; }
        public SnakeElement TailBackup { get; set; }
        public List<SnakeElement> Elements { get; set; }
        public SnakeElement Head => Elements.Any() ? Elements[0] : null;
        private static int SnakeLives = 5;

        public ISimpleSnakeState simpleSnakeState { get; set; }

        public void SetState(ISimpleSnakeState sw)
        {
            simpleSnakeState = sw;
        }

        public void Eat()
        {
            simpleSnakeState.Eat(this);
        }

        public override void UpdateMovementDirection(MovementDirection up)
        {
            switch (up)
            {
                case MovementDirection.Up:
                    if (MovementDirection != MovementDirection.Down)
                        MovementDirection = MovementDirection.Up;
                    break;
                case MovementDirection.Left:
                    if (MovementDirection != MovementDirection.Right)
                        MovementDirection = MovementDirection.Left;
                    break;
                case MovementDirection.Down:
                    if (MovementDirection != MovementDirection.Up)
                        MovementDirection = MovementDirection.Down;
                    break;
                case MovementDirection.Right:
                    if (MovementDirection != MovementDirection.Left)
                        MovementDirection = MovementDirection.Right;
                    break;
            }
        }

        public override void PositionFirstElement(int cols, int rows, MovementDirection initialDirection)
        {
            Elements.Add(new SnakeElement(_elementSize, Color)
            {
                X = (cols / 2) * _elementSize,
                Y = (rows / 2) * _elementSize,
                IsHead = true
            });
            MovementDirection = initialDirection;
        }

        public override void MoveSnake()
        {
            SnakeElement head = Elements[0];
            SnakeElement tail = Elements[Elements.Count - 1];

            TailBackup = new SnakeElement(_elementSize, Color)
            {
                X = tail.X,
                Y = tail.Y
            };

            head.IsHead = false;
            tail.IsHead = true;
            tail.X = head.X;
            tail.Y = head.Y;
            switch (MovementDirection)
            {
                case MovementDirection.Right:
                    tail.X += _elementSize;
                    break;
                case MovementDirection.Left:
                    tail.X -= _elementSize;
                    break;
                case MovementDirection.Up:
                    tail.Y -= _elementSize;
                    break;
                case MovementDirection.Down:
                    tail.Y += _elementSize;
                    break;
                default:
                    break;
            }
            Elements.RemoveAt(Elements.Count - 1);
            Elements.Insert(0, tail);
        }

        public override void Grow()
        {
            Elements.Add(new SnakeElement(_elementSize, Color) { X = TailBackup.X, Y = TailBackup.Y });
        }

        public override bool CollisionWithSelf()
        {
            SnakeElement snakeHead = Head;
            if (snakeHead != null)
            {
                foreach (var snakeElement in Elements)
                {
                    if (!snakeElement.IsHead)
                    {
                        if (snakeElement.X == snakeHead.X && snakeElement.Y == snakeHead.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void FailedAttempt()
        {
            if(SnakeLives > 0)
            {
                SnakeLives--;
                MessageBox.Show($"You have {SnakeLives} lives", "Lives");
            }
            else
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        public SnakeMemento SaveState()
        {
            return new SnakeMemento(SnakeLives);
        }

        public void RestoreState(SnakeMemento snakeMemento)   //мож і не треба
        {
            //this.SnakeLives = snakeMemento.Lives;
            //вивести якийсь текст тіпа востановление игри
        }

        public void GetInfo()
        {
            MessageBox.Show(GetColor(), "Information about Snake");
            MessageBox.Show(GetCharacteristicsOfKind(), "Information about Snake");
        }

        public virtual string GetColor()
        {
            string str = "Simple Snake hasn't color.";
            return str;
        }
        public virtual string GetCharacteristicsOfKind()
        {
            string str = "Simple Snake hasn't characterstics.";
            return str;
        }
    }

    enum MovementDirection
    {
        Right,
        Left,
        Up,
        Down
    }
}
