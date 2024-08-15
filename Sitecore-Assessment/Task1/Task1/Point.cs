using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Point : IFigure
    {
        public string Name { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public Point(string name, double xCoordinate, double yCoordinate)
        {
            Name = name;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public void Move(double dx, double dy)
        {
            double xBefore = XCoordinate;
            double yBefore = YCoordinate;
            XCoordinate += dx;
            YCoordinate += dy;
            Console.WriteLine($"Point {Name} is moved from ({xBefore},{yBefore}) to ({XCoordinate},{YCoordinate})");
        }

        public void Rotate(double angle)
        {
            Console.WriteLine($"Point {Name} rotation Has no effect on coordinates");
        }
    }
}
