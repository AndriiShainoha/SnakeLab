using SnakeLab.Entities.SnakeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.GameMode
{
    class MediumGameMode : IGameMode
    {
        public int GetModeForGame()
        {
            return 5;
        }
    }
}
