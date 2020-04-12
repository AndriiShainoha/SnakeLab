﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeLab.Entities
{
    class YellowSnake : Snake
    {
        public YellowSnake(int elementSize) : base(elementSize)
        {
            base.Color = Brushes.Yellow;
        }
    }
}
