﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities
{
    class BlueSkinSnakeCreator : SnakeCreator
    {
        public override SimpleSnake Create(int elementSize)
        {
            return new BlueSkinSnake(elementSize);
        }
    }
}
