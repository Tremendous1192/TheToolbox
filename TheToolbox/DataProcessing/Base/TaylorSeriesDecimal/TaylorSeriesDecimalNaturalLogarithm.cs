using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public partial class TaylorSeriesDecimal
    {

        public static decimal Ln2() { return 0.6931471805599453094172321m; }

        /// <summary>
        /// 自然対数のテーラー展開。
        /// ln(input) = ln 2^count2 (1+x) ≒ count2 * ln2 + (x - x^2/2 + x^3/3 - x^4/4 + ・・・)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static decimal NaturalLogarithm(decimal input)
        {
            //引数が0以下が定義できないので、例外を返す
            if (input <= 0)
            {
                throw new FormatException("Input " + nameof(input) + ";" + input.ToString("G6") + "must be equal to or more than zero");
            }


            //引数が1より小さい場合、絶対値の大きな負の数が返される。
            //近似の制度が下がるので、ln(input) = -ln(1/input)=-ln(1+x)
            //とおいて計算する。
            decimal onePlusX = input;
            decimal sign = 1m;
            if (input < 1)
            {
                onePlusX = 1m / input;
                sign = -1;
            }

            //input = 2^count2 * (1+x)
            //の形に変形する。
            uint count2 = 0;
            while (onePlusX > 2m)
            {
                count2++;
                onePlusX /= 2m;
            }
            decimal x = onePlusX - 1m;


            decimal numerator = x;

            decimal result = count2 * TaylorSeriesDecimal.Ln2();

            //テーラー展開
            result += x;
            for (int j = 2; j <= (int)Math.Ceiling(10m * x); j++)
            {
                numerator *= x;
                if (j % 2 == 0)
                {
                    result -= numerator / j;
                }
                else
                {
                    result += numerator / j;
                }
            }

            //符号を反映する.
            result *= sign;

            return result;

        }



    }
}
