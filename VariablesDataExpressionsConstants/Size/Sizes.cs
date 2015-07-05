using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Size
{
    class Sizes
    {
        public class Size
        {
            private double width;
            private double height;

            public Size(double width, double height)
            {
                this.Width = width;
                this.Height = height;
            }

            public double Width
            {
                get
                {
                    return this.width;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException();
                    }
                    this.width = value;
                }
            }

            public double Height 
            {
                get
                {
                    return this.height;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException();
                    }
                    this.height = value;
                }
            }

            public static Size GetRotatedSize(Size size, double figureRotationAngle)
            {
                var angleCos = Math.Abs(Math.Cos(figureRotationAngle));
                var angleSin = Math.Abs(Math.Sin(figureRotationAngle));
                var width = angleCos * size.Width + angleSin * size.Height;
                var height = angleSin * size.Width + angleCos * size.Height;
                var rotatedSize = new Size(width, height);

                return rotatedSize;
            }
        }

        static void Main()
        {
            Size newSize = new Size(2.4, 4.5);
            Console.WriteLine("width: {0:F5}; height: {1:F5}", newSize.Width, newSize.Height);
            newSize = Size.GetRotatedSize(newSize, 130);
            Console.WriteLine("width: {0:F5}; height: {1:F5}", newSize.Width, newSize.Height);
        }
    }
}
