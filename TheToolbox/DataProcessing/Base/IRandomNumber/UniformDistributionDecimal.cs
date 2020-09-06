﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
   public partial class UniformDistribution :IRandomNumber
    {

        //乱数の種はdoubleと共通
        //計算回数もdoubleと共通


        /// <summary>
        /// 計算結果
        /// </summary>
        decimal result_decimal;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public decimal ResultDecimal()
        { return result_decimal; }



        const decimal denominator_decimal = uint.MaxValue;

        /// <summary>
        /// 乱数を生成する
        /// 値域  :[ 0 , 1 ]
        /// </summary>
        /// <returns></returns>
        public decimal NextDecimal()
        {
            T = (X ^ (X << 11));
            X = Y;
            Y = Z;
            Z = W;
            W = (W = (W ^ (W >> 19)) ^ (T ^ (T >> 8)));

            decimal numerator = W;

            result_decimal = numerator / denominator_decimal;
            //result /= uint.MaxValue;

            CountUp();

            return result_decimal;
        }

        /// <summary>
        /// 乱数を生成する
        /// 値域  :[ min , max ]
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public decimal NextDecimal(decimal max, decimal min)
        {
            result_decimal = min + (max - min) * NextDecimal();
            return result_decimal;
        }



    }
}
