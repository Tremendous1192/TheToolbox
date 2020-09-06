﻿using System;
using System.Collections.Generic;
using System.Text;
using TheToolbox.DataProcessing.Base;


namespace TheToolbox.DataProcessing.MachineLerning
{
    public partial class MonteCarlo
    {


        /// <summary>
        /// モンテカルロ積分を行う。
        /// </summary>
        /// <param name="result"></param>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <param name="calculation_count"></param>
        /// <param name="iscalar"></param>
        /// <param name="range_max"></param>
        /// <param name="range_min"></param>
        /// <param name="seeds"></param>
        public static void Monte_Carlo_Integration
             (ref decimal result, ref decimal numerator, ref decimal denominator
              , uint calculation_count
              , IScalarFunction iscalar, decimal[] range_max, decimal[] range_min
              , uint[] seeds)
        {
            //積分区間の最大値と最小値の次元をそろえる
            if (range_max.Length != range_min.Length)
            {
                throw new FormatException("length of " + nameof(range_max) + "(" + range_max.Length + ")"
                    + " with that of " + nameof(range_min) + "(" + range_min.Length + ")");
            }
            //乱数の種の次元もそろえる
            if (range_max.Length != seeds.Length)
            {
                throw new FormatException("length of " + nameof(range_max) + "(" + range_max.Length + ")"
                    + " with that of " + nameof(seeds) + "(" + seeds.Length + ")");
            }

            //一様乱数のclassを生成する
            List<UniformDistribution> list_ud = new List<UniformDistribution>();
            for (int j = 0; j < range_min.Length; j++)
            {
                list_ud.Add(new UniformDistribution(seeds[j]));
            }


            //積分を行う
            decimal[] xs = new decimal[range_min.Length];
            for (uint j = 0; j < calculation_count; j++)
            {
                //乱数を生成する
                for (int k = 0; k < list_ud.Count; k++)
                {
                    xs[k] = list_ud[k].NextDecimal(range_max[k], range_min[k]);
                }
                numerator += iscalar.Calculate_f_u(xs);
                denominator++;
            }

            result = numerator / denominator;

        }


    }
}
