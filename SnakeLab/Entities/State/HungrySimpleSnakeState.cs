using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    [Serializable]
    class HungrySimpleSnakeState : ISimpleSnakeState
    {
        private MainWindow mainWindow;

        public HungrySimpleSnakeState(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Eat(SimpleSnake simpleSnake)
        {
            mainWindow.AppetiteLbl.Content = $"Hungry";
            simpleSnake.simpleSnakeState = new FamishedSimpleSnakeState(this.mainWindow);
        }
    }
}
