﻿using System;
using System.Collections.Generic;
using System.Text;

using TheToolbox.DataProcessing.Base;

using TheToolbox.DataProcessing.Statistics;

namespace TheToolbox.DataProcessing.MachineLerning.SupportVector
{
    public partial class SupportVectorMachine
    {

        /// <summary>
        /// 行ベクトルの識別を行う .
        /// Perform row vector identification .
        /// </summary>
        /// <param name="labelY"></param>
        /// <param name="design_Matrix_without_Constant"></param>
        /// <param name="iKernel"></param>
        /// <param name="variance_Covariance_Matrix"></param>
        /// <param name="CoefficientA"></param>
        /// <param name="rowVector"></param>
        /// <returns></returns>
        public static double Classify(double[,] labelY, double[,] design_Matrix_without_Constant, IKernel iKernel, double[,] CoefficientA, double[,] rowVector)
        {

            if (rowVector.GetLength(0) > 1)
            {
                throw new FormatException(nameof(rowVector) + "(" + rowVector.GetLength(0) + ")" + " must be 1 .");
            }

            //カーネルのセット
            iKernel.Set_Variance_Covariance_Matrix(DesignMatrix.Variance_Covariance_Matrix(design_Matrix_without_Constant));


            //カーネル用の行列
            double[,] kernelMatrix = new double[design_Matrix_without_Constant.GetLength(0), 1];

            //カーネルを計算する
            double[,] r_j = new double[1, 1];
            for (int j = 0; j < design_Matrix_without_Constant.GetLength(0); j++)
            {
                r_j = Matrix.Pick_Up_Row_Vector(design_Matrix_without_Constant, j);
                kernelMatrix[j, 0] = iKernel.Calculate(rowVector, r_j);
            }

            //予測値の計算
            //予測値の符号 = Σ( for j ) 教師ラベル[Y]j * 係数[A]j * カーネル K( x , [X]j )
            double[,] hadamard = Matrix.Hadamard_product(labelY, CoefficientA);
            hadamard = Matrix.Hadamard_product(hadamard, kernelMatrix);


            //Σ( for j )
            double sum = 0;
            foreach (double h in hadamard)
            {
                sum += h;
            }

            return sum;
        }



    }
}
