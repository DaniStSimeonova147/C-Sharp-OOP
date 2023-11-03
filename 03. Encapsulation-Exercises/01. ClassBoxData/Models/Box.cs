using E01.ClassBoxData.Exeptions;

using System;
using System.Text;

namespace E01.ClassBoxData.Models
{
   public class Box
    {
        //length, width and height

        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExeptionMessege.lengthExeption);
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
           private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExeptionMessege.widthExeption);
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
           private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExeptionMessege.heightExeption);
                }
                this.height = value;
            }
        }


        public double SurfaceArea()
        {
            double surfaceArea = 2 * this.Length * this.Width + LateralSurfaceArea();

            return surfaceArea;
        }
        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;

            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = this.Length * this.Width * this.Height;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Surface Area - {SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {Volume():f2}");
           

            return result.ToString().TrimEnd();
        }
    }
}
