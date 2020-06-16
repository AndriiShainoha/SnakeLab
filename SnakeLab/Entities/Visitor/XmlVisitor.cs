using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeLab.Entities.SnakeModel
{
    class XmlVisitor : IVisitor
    {
        private string path = @"D:\SnakeLab3\SnakeLab\HtmlAndXML.txt";
        public void VisitBlueSnake(BlueSkinSnake blueSkinSnake)
        {
            string result = "<BlueSkinSnake><Color>" + blueSkinSnake.Color + "</Color>";
        }

        public void VisitGreenSnake(GreenSkinSnake greenSkinSnake)
        {
            string result = "<GreenSkinSnake><Color>" + greenSkinSnake.Color + "</Color>";
        }

        public void VisitYellowSnake(YellowSkinSnake yellowSkinSnake)
        {
            string result = "<YellowSkinSnake><Color>" + yellowSkinSnake.Color + "</Color>";
        }
    }
}
