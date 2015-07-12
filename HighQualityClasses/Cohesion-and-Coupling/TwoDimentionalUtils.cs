﻿namespace CohesionAndCoupling
{
    using System;

    internal static class TwoDimentionalUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDiagonal2D(double dimentionX, double dimentionY)
        {
            double distance = Math.Sqrt((dimentionX * dimentionX) + (dimentionY * dimentionY));
            return distance;
        }
    }
}
