using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public class ConstantIScalar : IScalarFunction
    {
        public double Calculate_f_u(double[] input)
        {
            return 1.0;
        }


        public decimal Calculate_f_u(decimal[] input)
        {
            return 1m;
        }
    }
}
