using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.Food
{
    abstract class FoodDecorator : GameEntity
    {
        protected GameEntity gameEntity;
        public FoodDecorator(GameEntity gameEntity)
        {
            this.gameEntity = gameEntity;
        }
    }
}
