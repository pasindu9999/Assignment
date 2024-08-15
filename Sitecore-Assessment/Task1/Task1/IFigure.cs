using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IFigure
    {
        string Name { get; set; }

        double XCoordinate { get; set; }

        double YCoordinate { get; set; }

        void Move(double x, double y);

        void Rotate(double angle);
    }
}
