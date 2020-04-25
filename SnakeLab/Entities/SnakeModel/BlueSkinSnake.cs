﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeLab.Entities
{
    class BlueSkinSnake : SimpleSnake
    {
        public BlueSkinSnake(int elementSize)
        {
            base.Color = Brushes.Blue;
            Elements = new List<SnakeElement>();
            _elementSize = elementSize;
        }

        public override string GetColor()
        {
            string str = "Blue snake has blue color";
            return str;
        }
        public override string GetCharacteristicsOfKind()
        {
            string str = "Blue snakes are popular in Africa.";
            return str;
        }
    }
}
