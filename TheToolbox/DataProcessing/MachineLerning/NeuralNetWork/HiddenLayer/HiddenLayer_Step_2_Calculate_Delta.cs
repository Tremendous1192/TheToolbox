using System;
using System.Collections.Generic;
using System.Text;
using TheToolbox.DataProcessing.Base;

namespace TheToolbox.DataProcessing.MachineLerning.NeuralNetWork
{
    public partial class HiddenLayer
    {


        /// <summary>
        /// パラメータ更新のためのdeltaを計算する。
        /// </summary>
        /// <param name="w_next"></param>
        /// <param name="delta_next"></param>
        public void Step_2_3rd_Calculate_Delta(double[,] w_next, double[,] delta_next)
        {
            double[,] w_T = Matrix.TransposeMatrix(w_next);
            double[,] w_T_x_delta = Matrix.Multiplication(w_T, delta_next);

            delta = Matrix.Hadamard_product(w_T_x_delta, f_dash_wx_plus_b);
            change_w = Matrix.Multiplication(delta, Get_input_Transpose());
        }


    }
}
