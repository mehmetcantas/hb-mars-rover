using System;

namespace HbMarsRover
{
    public class Plateau
    {
        public int Width { get; private set; }
        public int Height { get; private set; }


        public void SetWidth(int width)
        {
            if (width <= 0)
                throw new ArgumentException("Insufficient width");

            Width = width;
        }

        public void SetHeight(int height)
        {
            if (height <= 0)
                throw new ArgumentException("Insufficient height");

            Height = height;
        }
    }
}