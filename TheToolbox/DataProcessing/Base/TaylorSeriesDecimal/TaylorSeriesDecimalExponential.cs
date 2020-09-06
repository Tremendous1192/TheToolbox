using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public partial class TaylorSeriesDecimal
    {

        public static decimal Napier { get { return 2.718281828459045235360287471352m; } }

        /// <summary>
        /// 指数関数のテーラー展開。
        /// e^input = e^(integer + x ) ≒ e^integer *(1 + x + x^2/2 + x^3/3! + ・・・)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static decimal Exponential(decimal input)
        {
            if (input == 0m) { return 1m; }
            else if (input == decimal.MinValue) { return 0m; }

            decimal integer = Math.Round(input);
            decimal e_integer = 1m;
            if (integer == 0m) { }
            else
            {
                for (uint j = 0; j < Math.Abs(integer); j++)
                {
                    e_integer *= TaylorSeriesDecimal.Napier;
                }
            }


            decimal x = input - integer;

            decimal numerator = x;
            decimal denominator = 1m;

            decimal result = 1m + x;

            for (uint j = 2; j <= 6; j++)
            {
                numerator *= x;
                denominator *= j;
                result += numerator / denominator;
            }


            if (integer > 0) { return e_integer * result; }
            else { return result / e_integer; }

        }



    }
}
