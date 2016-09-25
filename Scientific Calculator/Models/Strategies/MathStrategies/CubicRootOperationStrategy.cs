﻿namespace Scientific_Calculator.Models.Strategies.MathStrategies
{
    using System;

    using Scientific_Calculator.Attributes;

    [Component]
    public class CubicRootOperationStrategy
    {
        public double Calculate(double first)
        {
            return Math.Pow(first, 1d / 3);
        }
    }
}
