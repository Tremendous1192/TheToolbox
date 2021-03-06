﻿using System;
using System.Collections.Generic;
using System.Text;

using TheToolbox.DataProcessing.Base;

namespace TheToolbox.DataProcessing.Statistics
{
    public partial class DesignMatrix
    {

        /// <summary>
        /// 共分散行列の逆行列
        /// Calculate Inverse of the covariance matrix.
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Inverse_Variance_Covariance_Matrix(double[,] designMatrix)
        {
            return Matrix.Inverse_of_a_Matrix(DesignMatrix.Variance_Covariance_Matrix(designMatrix));
        }


    }
}
