﻿using System;
using System.Collections.Generic;
using System.Text;

using TheToolbox.DataProcessing.Base;


namespace TheToolbox.DataProcessing.Statistics.GeneralizedLinearModel
{
    public partial class LinerRegression
    {
        /// <summary>
        /// 線形回帰 X_T × w ( w : Colmun_Vector )
        /// </summary>
        /// <param name="row_Vector_or_Design_Matrix_without_Constant"></param>
        /// <param name="columnVector_w"></param>
        /// <returns></returns>
        public static double[,] Regression(double[,] row_Vector_or_Design_Matrix_without_Constant, double[,] columnVector_w)
        {
            double[,] row_vector_or_design_matrix_with_constant_1 = LinerRegression.Add_Constant_1(row_Vector_or_Design_Matrix_without_Constant);
            return Matrix.Multiplication(row_vector_or_design_matrix_with_constant_1, columnVector_w);
        }




        /// <summary>
        /// Ridge回帰のパラメータ学習
        /// </summary>
        /// <param name="design_matrix_without_constant"></param>
        /// <param name="target_y"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static double[,] Ridge_Learn(double[,] design_matrix_without_constant, double[,] target_y, double alpha)
        {
            if (design_matrix_without_constant.GetLength(0) - target_y.GetLength(0) != 0)
            {
                throw new FormatException(nameof(design_matrix_without_constant) + "の行" + design_matrix_without_constant.GetLength(0) + "と、" + nameof(target_y) + "の行" + target_y.GetLength(0) + "が異なります。");
            }

            double[,] design_matrix_with_constant_1 = LinerRegression.Add_Constant_1(design_matrix_without_constant);


            double[,] X_T = Matrix.TransposeMatrix(design_matrix_with_constant_1);
            double[,] X_T_cross_X = Matrix.Multiplication(X_T, design_matrix_with_constant_1);

            double hyper_parameter = Math.Abs(alpha);

            double[,] I = new double[X_T_cross_X.GetLength(0), X_T_cross_X.GetLength(0)];
            for (int j = 0; j < X_T_cross_X.GetLength(0); j++) { I[j, j] = hyper_parameter; }
            double[,] X_T_cross_X_add_I = Matrix.Addition(X_T_cross_X, I);

            double[,] X_T_cross_X_Inverse = Matrix.Inverse_of_a_Matrix(X_T_cross_X_add_I);

            double[,] w = Matrix.Multiplication(X_T_cross_X_Inverse, X_T);
            w = Matrix.Multiplication(w, target_y);

            return w;
        }



    }
}
