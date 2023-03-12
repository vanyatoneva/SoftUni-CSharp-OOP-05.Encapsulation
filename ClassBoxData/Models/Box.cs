using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData.Models
{
    public class Box
    {
		private double length;
		private double width;
		private double height;
		private string exceptionMessage(string type) =>  $"{type} cannot be zero or negative.";

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(exceptionMessage(nameof(Length)));
                }
                length = value;
            }
        }
        public double Width
        {
			get => width;
			private set
			{
				if(value < 0)
				{
					throw new ArgumentException(exceptionMessage(nameof(Width)));
				}
				width = value;
			}
		}

		public double Height
        {
            get => height;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(exceptionMessage(nameof(Height)));
                }
                height = value;
            }
        }


        public double SurfaceArea()
        {
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }

        public double Volume()
        {

            return length * width * height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * length * height + 2 * width * height;
        }
    }
}
