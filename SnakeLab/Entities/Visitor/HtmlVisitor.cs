using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    class HtmlVisitor : IVisitor
    {
        public void VisitBlueSnake(BlueSkinSnake blueSkinSnake)
        {
            string result = "<table><tr><td>Властивість<td><td>Значення</td></tr>";
            result += "<tr><td>Color<td><td>" + blueSkinSnake.Color + "</td></tr>";
            //Console.WriteLine(result);    напевно вивисти у якийсь другий файл
        }

        public void VisitGreenSnake(GreenSkinSnake greenSkinSnake)
        {
            string result = "<table><tr><td>Властивість<td><td>Значення</td></tr>";
            result += "<tr><td>Color<td><td>" + greenSkinSnake.Color + "</td></tr>";
            //Console.WriteLine(result);    напевно вивисти у якийсь другий файл
        }

        public void VisitYellowSnake(YellowSkinSnake yellowSkinSnake)
        {
            string result = "<table><tr><td>Властивість<td><td>Значення</td></tr>";
            result += "<tr><td>Color<td><td>" + yellowSkinSnake.Color + "</td></tr>";
            //Console.WriteLine(result);    напевно вивисти у якийсь другий файл
        }
    }
}
