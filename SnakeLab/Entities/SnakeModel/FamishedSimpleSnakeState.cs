using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    class FamishedSimpleSnakeState : ISimpleSnakeState
    {
        private MainWindow mainWindow;
        public FamishedSimpleSnakeState(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        public void Eat(SimpleSnake simpleSnake)
        {
            mainWindow.AppetiteLbl.Content = $"Very hungry";
            simpleSnake.simpleSnakeState = new HungrySimpleSnakeState(this.mainWindow);
        }
    }
}
