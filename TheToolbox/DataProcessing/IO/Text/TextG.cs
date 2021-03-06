﻿using System;
using System.Collections.Generic;
using System.Text;

using System.IO;


namespace TheToolbox.DataProcessing.IO
{
    public partial class Text
    {


        /// <summary>
        /// 現在のDirectoryにあるtxtデータのファイル名を全て取得する
        /// </summary>
        /// <returns></returns>
        public string[] Get_File_Name_txt_type()
        {
            string[] files = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory());
            if (files.Length < 1) { Console.WriteLine("No file is here ."); return new string[1]; }

            List<string> temp_List = new List<string>();
            for (int i = 0; i < files.GetLength(0); i++)
            {
                if (Path.GetExtension(files[i]) == ".txt")
                {
                    temp_List.Add(Path.GetFileNameWithoutExtension(files[i]) + Path.GetExtension(files[i]));
                }
            }

            if (temp_List.Count < 1) { Console.WriteLine("No .txt file is here ."); return new string[1]; }

            return temp_List.ToArray();
        }

    }
}
