using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public partial class LogNormalDistributionPolar : IRandomNumber
    {

        /// <summary>
        /// 計算結果
        /// </summary>
        decimal resultDecimal;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public decimal ResultDecimal()
        {
            UpdateSeed();
            return resultDecimal;
        }


        /// <summary>
        /// 乱数を生成する
        /// 平均値 0
        /// 標準偏差 1
        /// </summary>
        /// <returns></returns>
        public decimal NextDecimal()
        {
        retry_point:

            decimal u1 = ud1.NextDecimal();
            decimal u2 = ud2.NextDecimal();

            decimal v1 = 2 * u1 - 1;
            decimal v2 = 2 * u2 - 1;
            decimal v = v1 * v1 + v2 * v2;

            if (v <= 0 || 1 <= v)
            {
                goto retry_point;
            }

            decimal w = TaylorSeriesDecimal.SquareRoot(-2 * TaylorSeriesDecimal.NaturalLogarithm(v) / v);

            decimal y1 = v1 * w;
            decimal y2 = v2 * w;


            if (even)
            {
                resultDecimal = y1;
                even = false;
            }
            else
            {
                resultDecimal = y2;
                even = true;
            }

            resultDecimal = TaylorSeriesDecimal.Exponential(resultDecimal);
            return resultDecimal;
        }



        /// <summary>
        /// 乱数を生成する
        /// 平均値 average
        /// 標準偏差 std
        /// </summary>
        /// <param name="average"></param>
        /// <param name="std"></param>
        /// <returns></returns>
        public decimal NextDecimal(decimal average, decimal std)
        {
        retry_point:

            decimal u1 = ud1.NextDecimal();
            decimal u2 = ud2.NextDecimal();

            decimal v1 = 2 * u1 - 1;
            decimal v2 = 2 * u2 - 1;
            decimal v = v1 * v1 + v2 * v2;

            if (v <= 0 || 1 <= v)
            {
                goto retry_point;
            }

            decimal w = TaylorSeriesDecimal.SquareRoot(-2 * TaylorSeriesDecimal.NaturalLogarithm(v) / v);

            decimal y1 = v1 * w;
            decimal y2 = v2 * w;


            if (even)
            {
                resultDecimal = y1;
                even = false;
            }
            else
            {
                resultDecimal = y2;
                even = true;
            }

            resultDecimal = TaylorSeriesDecimal.Exponential(resultDecimal * Math.Abs(std) + average);
            return resultDecimal;
        }





    }
}
