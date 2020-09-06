using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public partial class HalfNormalDistributionPolar : IRandomNumber
    {

        /// <summary>
        /// 計算結果
        /// </summary>
        decimal result_decimal;

        /// <summary>
        /// 計算結果をもう一度取得する
        /// </summary>
        /// <returns></returns>
        public decimal ResultDecimal()
        {
            UpdateSeed();
            return result_decimal;
        }


        /// <summary>
        /// 乱数を生成する
        /// 標準偏差 1
        /// </summary>
        /// <returns></returns>
        public decimal NextDecimal()
        {
        retry_point:

            decimal u1 = ud1.NextDecimal();
            decimal u2 = ud2.NextDecimal();

            decimal v = u1 * u1 + u2 * u2;

            if (v <= 0 || 1 <= v)
            {
                goto retry_point;
            }

            decimal w = TaylorSeriesDecimal.SquareRoot(-2 * TaylorSeriesDecimal.NaturalLogarithm(v) / v);

            decimal y1 = u1 * w;
            decimal y2 = u2 * w;

            if (even)
            {
                result_decimal = y1;
                even = false;
            }
            else
            {
                result_decimal = y2;
                even = true;
            }

            return result_decimal;
        }



        /// <summary>
        /// 乱数を生成する
        /// 標準偏差 std
        /// </summary>
        /// <param name="std"></param>
        /// <returns></returns>
        public decimal NextDecimal(decimal std)
        {
            return NextDecimal() * Math.Abs(std);
        }




    }
}
