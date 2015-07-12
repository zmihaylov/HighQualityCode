using System;

namespace Abstraction
{
    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentNullException("Circle radius cannot be null or empty!");
                }
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("circle radius cannot be negative!");
                }
                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = Math.PI * 2 * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return area;
        }
    }
}
