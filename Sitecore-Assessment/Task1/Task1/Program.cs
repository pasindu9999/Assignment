using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFigure line1 = new Line("1", 5, 7, 4, 0);
            IFigure line2 = new Line("2", 19, 8, 8, 45);

            IFigure circle1 = new Circle("1", 5, 8, 8);
            IFigure circle2 = new Circle("2", 20, 30, 5);
            IFigure circle3 = new Circle("3", 10, 40, 4);

            IFigure point1 = new Point("1", 7, 8);
            IFigure point2 = new Point("2", 19, -11);

            IFigure[] figures = { line1, line2, circle1, circle2, circle3, point1, point2, };

            var aggregate = new Aggregation(figures);

            Console.WriteLine("Moves");
            aggregate.Move(5, 5);

            Console.WriteLine();
            Console.WriteLine("Rotations");
            aggregate.Rotate(90); 

            Console.ReadLine();
        }
    }
}
