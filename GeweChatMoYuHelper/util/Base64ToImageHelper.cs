﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZXing;
using ZXing.QrCode;
using SixLabors.ImageSharp.PixelFormats;


namespace GeweChatMoYuHelper.util
{
    public class Base64ToImageHelper
    {
        public static void Output(string text)
        {
            const int threshold = 180;
            //生成二维码
            var writer = new ZXing.ImageSharp.BarcodeWriter<Rgba32>
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Width = 33,
                    Height = 33,
                    Margin = 1

                }
            };
            var image = writer.WriteAsImageSharp<Rgba32>(text);

            int[,] points = new int[image.Width, image.Height];

            for (var i = 0; i < image.Width; i++)
            {
                for (var j = 0; j < image.Height; j++)
                {
                    //获取该像素点的RGB的颜色
                    var color = image[i, j];
                    if (color.B <= threshold)
                    {
                        points[i, j] = 1;
                    }
                    else
                    {
                        points[i, j] = 0;
                    }
                }
            }


            for (var i = 0; i < image.Width; i++)
            {
                for (var j = 0; j < image.Height; j++)
                {
                    //根据像素点颜色的不同来设置 Console Color
                    if (points[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                }
                Console.Write("\n");
            }
        }

    }
}
