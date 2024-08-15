using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Circle : IFigure
    {
        public string Name { get; set; }
        public double XCoordinate { get; set; } // center of the circle
        public double YCoordinate { get; set; } // center of the circle
        public double Radius { get; set; }

        public Circle(string name, double xCoordinate, double yCoordinate, double radius) 
        {
            Name = name;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Radius = radius;
        }
        public void Move(double dx, double dy)
        {
            double xBefore = XCoordinate;
            double yBefore = YCoordinate;
            XCoordinate += dx;
            YCoordinate += dy;
            Console.WriteLine($"center of circle {Name} is moved from ({xBefore},{yBefore}) to ({XCoordinate},{YCoordinate})");
        }

        public void Rotate(double angle)
        {
            Console.WriteLine($"Circle {Name} rotation Has no effect on coordinates");
        }
    }
}
