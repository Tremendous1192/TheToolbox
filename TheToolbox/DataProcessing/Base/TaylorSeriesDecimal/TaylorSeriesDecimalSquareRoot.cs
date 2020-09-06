using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public partial class TaylorSeriesDecimal
    {

        public static decimal Sqrt2() { return 1.41421356237m; }

        /// <summary>
        /// 平方根のテーラー展開。
        /// √input = √2^count2 * (1+x) = √2^count2 * ( 1 + x/2 - x^2/8 + x^3/16 - x^4/128 + ・・・)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static decimal SquareRoot(decimal input)
        {

            if (input == 0m) { return decimal.Zero; }
            else if (input < 0)
            {
                throw new FormatException("Input " + nameof(input) + ";" + input.ToString("G6") + "must be equal to or more than zero .");
            }


            //input = 2^count2 * (1+x)
            //の形に変形する。
            decimal onePlusX = input;
            if (input < 1)
            {
                onePlusX = 1m / input;
            }

            uint count2 = 0;
            while (onePlusX > 2m)
            {
                count2++;
                onePlusX /= 2m;
            }
            decimal x = onePlusX - 1m;

            //テーラー展開
            decimal numerator = x;
            decimal result = 1m + x / 2m;
            numerator *= x;
            result -= numerator / 8m;
            numerator *= x;
            result += numerator / 16m;
            numerator *= x;
            result -= numerator / 128m;

            //√2^count2 をかける
            for (uint j = 0; j < count2 / 2; j++) { result *= 2m; }
            for (uint j = 0; j < count2 / 2 - 1; j++) { result *= TaylorSeriesDecimal.Sqrt2(); }

            return result;
        }




    }
}
