﻿using System;
using System.Collections.Generic;
using System.Text;

using TheToolbox.DataProcessing.Base;

namespace TheToolbox.DataProcessing.Statistics.GeneralizedLinearModel
{
    public partial class LinerRegression
    {



        /// <summary>
        /// Lerning Liner_Regression .
        /// Return w ( Colmun Vector )
        /// </summary>
        /// <param name="design_matrix_without_constant"></param>
        /// <param name="column_vector_y"></param>
        /// <returns></returns>
        public static double[,] Learn(double[,] design_matrix_without_constant, double[,] column_vector_y)
        {


            if (design_matrix_without_constant.GetLength(0) - column_vector_y.GetLength(0) != 0)
            {
                throw new FormatException(nameof(design_matrix_without_constant) + "の行" + design_matrix_without_constant.GetLength(0) + "と、" + nameof(column_vector_y) + "の行" + column_vector_y.GetLength(0) + "が異なります。");
            }

            double[,] design_matrix_with_constant_1 = LinerRegression.Add_Constant_1(design_matrix_without_constant);



            double[,] X_T = Matrix.TransposeMatrix(design_matrix_with_constant_1);
            double[,] X_T_cross_X = Matrix.Multiplication(X_T, design_matrix_with_constant_1);

            double[,] X_T_cross_X_Inverse = Matrix.Inverse_of_a_Matrix(X_T_cross_X);

            double[,] w = Matrix.Multiplication(X_T_cross_X_Inverse, X_T);
            w = Matrix.Multiplication(w, column_vector_y);

            return w;
        }




    }
}
