using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Line : IFigure
    {
        public string Name { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public double Length { get; set; }
        public double Angle { get; set; }

        public Line(string name, double xCoordinate, double yCoordinate, double length, double angle)
        {
            Name = name;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Length = length;
            Angle = angle;
        }

        public void Move(double dx, double dy)
        {
            double xBefore = XCoordinate;
            double yBefore = YCoordinate;
            XCoordinate += dx;
            YCoordinate += dy;
          
            Console.WriteLine($"The line {Name} is moved from ({xBefore},{yBefore}) to ({XCoordinate},{YCoordinate})");
        }

        public void Rotate(double rotateAngle)
        {
         
        double radians = rotateAngle * Math.PI / 180;

        double halfLength = Length / 2;

        // Calculation of original start and end points
        double startX = XCoordinate - halfLength * Math.Cos(Angle * Math.PI / 180);
        double startY = YCoordinate - halfLength * Math.Sin(Angle * Math.PI / 180);
        double endX = XCoordinate + halfLength * Math.Cos(Angle * Math.PI / 180);
        double endY = YCoordinate + halfLength * Math.Sin(Angle * Math.PI / 180);

        double newStartX = XCoordinate + (startX - XCoordinate) * Math.Cos(radians) - (startY - YCoordinate) * Math.Sin(radians);
        double newStartY = YCoordinate + (startX - XCoordinate) * Math.Sin(radians) + (startY - YCoordinate) * Math.Cos(radians);

        double newEndX = XCoordinate + (endX - XCoordinate) * Math.Cos(radians) - (endY - YCoordinate) * Math.Sin(radians);
        double newEndY = YCoordinate + (endX - XCoordinate) * Math.Sin(radians) + (endY - YCoordinate) * Math.Cos(radians);

        Angle += rotateAngle;

        Console.WriteLine($"Line {Name} is rotated {rotateAngle} degrees from [({startX}, {startY}), ({endX}, {endY})] to [({newStartX}, {newStartY}), ({newEndX}, {newEndY})]");

        }
    }
}
