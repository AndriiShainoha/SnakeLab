using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    class XmlVisitor : IVisitor
    {
        public void VisitBlueSnake(BlueSkinSnake blueSkinSnake)
        {
            string result = "<BlueSkinSnake><Color>" + blueSkinSnake.Color + "</Color>";
            //Console.WriteLine(result);    напевно вивисти у якийсь другий файл
        }

        public void VisitGreenSnake(GreenSkinSnake greenSkinSnake)
        {
            string result = "<BlueSkinSnake><Color>" + greenSkinSnake.Color + "</Color>";
            //Console.WriteLine(result);    напевно вивисти у якийсь другий файл
        }

        public void VisitYellowSnake(YellowSkinSnake yellowSkinSnake)
        {
            string result = "<BlueSkinSnake><Color>" + yellowSkinSnake.Color + "</Color>";
            //Console.WriteLine(result);    напевно вивисти у якийсь другий файл
        }
    }
}
