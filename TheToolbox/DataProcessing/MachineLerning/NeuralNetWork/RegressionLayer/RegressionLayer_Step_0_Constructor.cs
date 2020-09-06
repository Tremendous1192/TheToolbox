using System;
using System.Collections.Generic;
using System.Text;
using TheToolbox.DataProcessing.Base;

namespace TheToolbox.DataProcessing.MachineLerning.NeuralNetWork
{
    public partial class RegressionLayer
    {

        public RegressionLayer(double[,] W, double[,] B,
            double Gamma, double L1, double L2, double Drop_out, 
            IVectorFunction Activation_Function)
        {
            ud = new UniformDistribution();

            w = W;
            b = B;

            gamma = Math.Max(Gamma, 1.0 / 1000 / 1000 / 1000);
            L_1 = Math.Max(L1, 0);
            L_2 = Math.Max(L2, 0);
            drop_out = Math.Min(Math.Max(Drop_out, 0), 1);

            activation_Function = Activation_Function;
        }

        public RegressionLayer(int input_dimension, int output_dimension, 
            double Gamma, double L1, double L2, double Drop_out, 
            IVectorFunction Activation_Function)
        {
            ud = new UniformDistribution();

            w = new double[output_dimension, input_dimension];
            for (int j = 0; j < w.GetLength(0); j++)
            {
                for (int k = 0; k < w.GetLength(1); k++)
                {
                    w[j, k] = (ud.NextDouble() - 0.5) * 2.0;
                }
            }

            b = new double[output_dimension, 1];
            for (int j = 0; j < b.GetLength(0); j++)
            {
                b[j, 0] = (ud.NextDouble() - 0.5) * 2.0;
            }

            gamma = Math.Max(Gamma, 1.0 / 1000 / 1000 / 1000);
            L_1 = Math.Max(L1, 0);
            L_2 = Math.Max(L2, 0);
            drop_out = Math.Min(Math.Max(Drop_out, 0), 1);

            activation_Function = Activation_Function;
        }


        public void Preset_1_3rd_Set_w_b(double[,] W, double[,] B)
        {
            w = W;
            b = B;
        }
        public void Preset_1_3rd_Set_w_b(int input_dimension, int output_dimension)
        {
            w = new double[output_dimension, input_dimension];
            for (int j = 0; j < w.GetLength(0); j++)
            {
                for (int k = 0; k < w.GetLength(1); k++)
                {
                    w[j, k] = (ud.NextDouble() - 0.5) * 2.0;
                }
            }

            b = new double[output_dimension, 1];
            for (int j = 0; j < b.GetLength(0); j++)
            {
                b[j, 0] = (ud.NextDouble() - 0.5) * 2.0;
            }
        }

        public void Preset_2_3rd_Set_Hyper_Parameter(double Gamma, double L1, double L2, double Drop_out)
        {
            gamma = Math.Max(Gamma, 1.0 / 1000 / 1000 / 1000);
            L_1 = Math.Max(L1, 0);
            L_2 = Math.Max(L2, 0);
            drop_out = Math.Min(Math.Max(Drop_out, 0), 1);
        }

        public void Preset_3_3rd_Set_activation_Function(IVectorFunction Activation_Function)
        {
            activation_Function = Activation_Function;
        }


    }
}
