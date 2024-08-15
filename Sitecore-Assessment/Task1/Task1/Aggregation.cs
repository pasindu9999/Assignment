using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Aggregation
    {
        public IFigure[] FiguresArray { get; set; }

        public Aggregation(IFigure[] figures)
        {
            FiguresArray = figures;
        }

        public void Move(double dx, double dy, params IFigure[] figures) 
        {
            foreach (IFigure figure in FiguresArray) 
            {
                figure.Move(dx, dy);
            }
        }

        public void Rotate(double angle, params IFigure[] figures)
        {
            foreach (IFigure figure in FiguresArray)
            {
                figure.Rotate(angle);
            }
        }
    }
}
