﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TheToolbox.DataProcessing.Base
{
    public partial class TypeChange
    {


        /// <summary>
        /// Change string[] to int[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] String_to_Int(string[] input)
        {
            int[] result = new int[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                try
                {
                    result[i] = int.Parse(input[i]);
                }
                catch
                {
                    result[i] = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Change string[] to double[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[] String_to_Double(string[] input)
        {
            double[] result = new double[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                try
                {
                    result[i] = Double.Parse(input[i]);
                }
                catch
                {
                    result[i] = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Change string[] to byte[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static byte[] String_to_Byte(string[] input)
        {
            byte[] result = new byte[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                try
                {
                    result[i] = Byte.Parse(input[i]);
                }
                catch
                {
                    result[i] = 0;
                }
            }
            return result;
        }

        /// <summary>
        /// Change int[] to string[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] Number_to_String(int[] input)
        {
            string[] result = new string[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                result[i] = input[i].ToString();
            }
            return result;
        }

        /// <summary>
        /// Change double[] to string[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] Number_to_String(double[] input)
        {

            string[] result = new string[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                result[i] = Change_String(input[i]);
            }
            return result;
        }

        /// <summary>
        /// Change byte[] to string[]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] Number_to_String(byte[] input)
        {
            string[] result = new string[input.GetLength(0)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                result[i] = input[i].ToString();
            }
            return result;
        }




    }
}
