using SnakeLab.Entities.SnakeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.Visitor
{
    class Zoo
    {
        List<IAnimal> animals = new List<IAnimal>();
        public void Add(IAnimal animal)
        {
            animals.Add(animal);
        }
        public void Remove(IAnimal animal)
        {
            animals.Remove(animal);
        }
        public void Accept(IVisitor visitor)
        {
            foreach(IAnimal animal in animals)
            {
                animal.Accept(visitor);
            }
        }
    }
}
