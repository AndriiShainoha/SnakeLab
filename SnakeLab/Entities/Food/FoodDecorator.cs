using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.Food
{
    public abstract class FoodDecorator : Apple
    {
        protected Apple apple;
        public FoodDecorator(Apple apple)
        {
            this.apple = apple;
        }
    }
}
