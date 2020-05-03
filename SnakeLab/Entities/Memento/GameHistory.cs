using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    class GameHistory
    {
        public Stack<SnakeMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<SnakeMemento>();
        }
    }
}
