/*
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TheToolbox.Tester.DataProcessing.IO
{
    /// <summary>
    /// class libraryでWPFを試すクラス。
    /// 細工の手順をクラス内のコメントに記した。
    /// </summary>
    public partial class Study_WPF
    {
        //csprojファイルに下記の細工を行う。

        //Step 1
        //<Project Sdk="Microsoft.NET.Sdk">を、
        //<Project Sdk="Microsoft.NET.Sdk.WindowsDesktop">に変更。

        //Step 2 : 下記の2行を追加する
        //<UseWPF>true</UseWPF>
        //<ProjectTypeGuids>{60dc8134-eba5-43b8-bcc9-bb4bc16c2548};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>

        //参考
        //https://stackoverflow.com/questions/58836149/how-can-i-add-wpf-items-into-a-c-sharp-class-library-project-in-vs2019

        //下記URLのwpfを呼び出すメソッドを学習する
        //https://shirakamisauto.hatenablog.com/entry/2016/02/20/120313
        [STAThread]
        public void Study_001()
        {
            var img = new Image()
            {
                Source =
    new BitmapImage(
        new Uri(@"C:\Users\treme\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\Test.png"))
            };

            var window = new Window()
            {
                Title = "サンプル",
                Width = 300,
                Height = 300,
                Content = new Grid
                {
                    Children = {
                        new StackPanel { Children= {img,}
                                 }
                        }
                }
            };

            var app = new Application();
            app.Run(window);

        }



    }
}

*/