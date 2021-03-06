﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Statistics
{
    public partial class InferentialStatistics
    {

        /// <summary>
        /// 計画行列を昇順に並べ替える。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Sorted_in_Ascending_Order(double[,] designMatrix)
        {
            //並べ替え用の配列。
            //design_matrixを計算に用いると参照渡しになるバグがある。
            double[,] sorted = new double[designMatrix.GetLength(0), designMatrix.GetLength(1)];
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < designMatrix.GetLength(1); j++)
                {
                    sorted[i, j] = designMatrix[i, j];
                }
            }

            //昇順に並び替える
            double buffer = 0.0;
            for (int j = 0; j < sorted.GetLength(1); j++)
            {
                for (int i = 0; i < sorted.GetLength(0); i++)
                {
                    for (int i2 = i + 1; i2 < sorted.GetLength(0); i2++)
                    {
                        if (sorted[i, j] > sorted[i2, j])
                        {
                            buffer = sorted[i, j];
                            sorted[i, j] = sorted[i2, j];
                            sorted[i2, j] = buffer;
                        }
                    }
                }
            }

            return sorted;
        }


        /// <summary>
        /// 標準偏差を計算する。
        /// </summary>
        /// <param name="designMatrix"></param>
        /// <returns></returns>
        public static double[,] Nonbias_Standard_Deviation(double[,] designMatrix)
        {

            double[] sum = new double[designMatrix.GetLength(1)];
            double[,] standardDeviation
                     = new double[1, designMatrix.GetLength(1)];

            //標準偏差のk次元目を計算する。
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {

                //j次元目とk次元目の積の総和を計算する。 Σxy
                for (int i = 0; i < designMatrix.GetLength(0); i++)
                {
                    sum[j] += designMatrix[i, j];
                    standardDeviation[0, j] += designMatrix[i, j] * designMatrix[i, j];
                }

                //偏差平方和の計算
                standardDeviation[0, j] -= sum[j] * sum[j];

                //不偏分散の計算
                standardDeviation[0, j] /= designMatrix.GetLength(0) - 1;

                //不偏標準偏差を計算する
                standardDeviation[0, j] = Math.Sqrt(standardDeviation[0, j]);
            }

            return standardDeviation;
        }


        /// <summary>
        /// [0,*] 最小値
        /// [1,*] 第一四分位数
        /// [2,*] 中央値
        /// [3,*] 平均値
        /// [4,*] 第三四分位数
        /// [5,*] 最大値
        /// [6,*] 偏差平方和
        /// [7,*] 不偏分散
        /// [8,*] 不偏標準偏差
        /// </summary>
        /// <param name="design_Matrix"></param>
        /// <returns></returns>
        public static double[,] Summary(double[,] designMatrix)
        {

            //配列を昇順に並べ替える。
            double[,] sorted = InferentialStatistics.Sorted_in_Ascending_Order(designMatrix);


            double[,] summary = new double[9, sorted.GetLength(1)];


            //[0,*] 最小値 and [5,*] 最大値
            for (int j = 0; j < summary.GetLength(1); j++)
            {
                summary[0, j] = sorted[0, j];
                summary[5, j] = sorted[sorted.GetLength(0) - 1, j];
            }

            //[3,*] 平均値
            for (int j = 0; j < sorted.GetLength(1); j++)
            {
                for (int i = 0; i < sorted.GetLength(0); i++)
                {
                    summary[3, j] += sorted[i, j];
                }
                summary[3, j] /= sorted.GetLength(0);
            }

            //[2,*] 中央値
            int median_point = sorted.GetLength(0) / 2;
            if (sorted.GetLength(0) % 2 == 0)
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    summary[2, j] = (sorted[median_point, j] + sorted[Math.Max(median_point - 1, 0), j]) / 2;
                }
            }
            else
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    summary[2, j] = sorted[median_point, j];
                }
            }

            //[1,*] 第一四分位数
            //[4,*] 第三四分位数
            int lower_quartile_point = sorted.GetLength(0) / 4;
            int upper_quartile_point = Math.Max(sorted.GetLength(0) - sorted.GetLength(0) / 4, 0);
            if (sorted.GetLength(0) % 4 < 2)
            {
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    summary[1, j] = (sorted[lower_quartile_point, j] + sorted[Math.Max(lower_quartile_point - 1, 0), j]) / 2;
                    summary[4, j] = (sorted[upper_quartile_point, j] + sorted[Math.Max(upper_quartile_point - 1, 0), j]) / 2;
                }
            }
            else
            {
                upper_quartile_point = Math.Max(upper_quartile_point - 1, 0);
                for (int j = 0; j < sorted.GetLength(1); j++)
                {
                    summary[1, j] = sorted[lower_quartile_point, j];
                    summary[4, j] = sorted[upper_quartile_point, j];
                }
            }

            //[6,*] 偏差平方和
            for (int i = 0; i < designMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < designMatrix.GetLength(1); j++)
                {
                    summary[6, j] += (designMatrix[i, j] - summary[3, j]) * (designMatrix[i, j] - summary[3, j]);
                }
            }

            //[7,*] 不偏分散
            //[8,*] 不偏標準偏差
            for (int j = 0; j < designMatrix.GetLength(1); j++)
            {
                summary[7, j] = summary[6, j] / (designMatrix.GetLength(0) - 1);
                summary[8, j] = Math.Sqrt(summary[7, j]);
            }


            return summary;
        }





    }
}
