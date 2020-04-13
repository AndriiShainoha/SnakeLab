﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities
{
    class BlueSnakeCreator : SnakeCreator
    {
        public override Snake Create(int elementSize)
        {
            return new BlueSnake(elementSize);
        }
    }
}