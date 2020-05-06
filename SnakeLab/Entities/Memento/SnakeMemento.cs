using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    [Serializable]
    class SnakeMemento
    {
        public int Lives { get; set; }
        public SnakeMemento(int Lives)
        {
            this.Lives = Lives;
        }
    }
}
