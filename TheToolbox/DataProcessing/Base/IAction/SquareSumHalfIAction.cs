﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public class SquareSumHalfIAction : IAction
    {

        public double Calculate_f_u(double[] input)
        {
            double result = 0.0;

            for (int j = 0; j < input.Length; j++)
            {
                result += input[j] * input[j];
            }

            return result / 2.0;
        }


        public decimal Calculate_f_u(decimal[] input)
        {
            decimal result = 0.0m;

            for (int j = 0; j < input.Length; j++)
            {
                result += input[j] * input[j];
            }

            return result / 2m;
        }

    }
}
