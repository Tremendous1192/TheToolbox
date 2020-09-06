using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public interface IScalarFunction
    {
        double Calculate_f_u(double[] input);

        decimal Calculate_f_u(decimal[] input);
    }
}
