using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    
    class HtmlVisitor : IVisitor
    {
        private string path = @"D:\SnakeLab3\SnakeLab\HtmlAndXML.txt";
        public void VisitBlueSnake(BlueSkinSnake blueSkinSnake)
        {
            string result = "<table><tr><td>Властивість<td><td>Значення</td></tr>";
            result += "<tr><td>Color<td><td>" + blueSkinSnake.Color + "</td></tr>";
        }

        public void VisitGreenSnake(GreenSkinSnake greenSkinSnake)
        {
            string result = "<table><tr><td>Властивість<td><td>Значення</td></tr>";
            result += "<tr><td>Color<td><td>" + greenSkinSnake.Color + "</td></tr>";
        }

        public void VisitYellowSnake(YellowSkinSnake yellowSkinSnake)
        {
            string result = "<table><tr><td>Властивість<td><td>Значення</td></tr>";
            result += "<tr><td>Color<td><td>" + yellowSkinSnake.Color + "</td></tr>";
        }
    }
}
