using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public interface IKernel
    {
        void Set_Variance_Covariance_Matrix(double[,] variance_Covariance_Matrix);


        double Calculate(double[,] row_Vector_1, double[,] row_Vector_2);
    }

}
