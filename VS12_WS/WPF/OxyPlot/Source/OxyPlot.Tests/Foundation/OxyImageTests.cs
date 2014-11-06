﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OxyImageTests.cs" company="OxyPlot">
//   The MIT License (MIT)
//
//   Copyright (c) 2012 Oystein Bjorke
//
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace OxyPlot.Tests
{
    using System.IO;
    using System.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class OxyImageTests
    {
        [Test]
        public void FromArgb()
        {
            var data = new OxyColor[2, 4];
            data[1, 0] = OxyColors.Blue;
            data[1, 1] = OxyColors.Green;
            data[1, 2] = OxyColors.Red;
            data[1, 3] = OxyColors.White;
            data[0, 0] = OxyColors.Yellow.ChangeAlpha(127);
            data[0, 1] = OxyColors.Orange.ChangeAlpha(127);
            data[0, 2] = OxyColors.Pink.ChangeAlpha(127);
            data[0, 3] = OxyColors.Transparent;
            var img = OxyImage.FromArgb(data);
            var bytes = img.GetData();
            File.WriteAllBytes("FromArgb.bmp", bytes);
        }

        [Test]
        public void PngFromArgb()
        {
            var data = new OxyColor[2, 4];
            data[1, 0] = OxyColors.Blue;
            data[1, 1] = OxyColors.Green;
            data[1, 2] = OxyColors.Red;
            data[1, 3] = OxyColors.White;
            data[0, 0] = OxyColors.Yellow.ChangeAlpha(127);
            data[0, 1] = OxyColors.Orange.ChangeAlpha(127);
            data[0, 2] = OxyColors.Pink.ChangeAlpha(127);
            data[0, 3] = OxyColors.Transparent;
            var img = OxyImage.PngFromArgb(data);
            var bytes = img.GetData();
            File.WriteAllBytes("PngFromArgb.png", bytes);
        }

        [Test]
        public void PngFromArgb2()
        {
            int w = 266;
            int h = 40;
            var data = new OxyColor[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    data[i, j] = OxyColor.FromHsv((double)j / w, 1, 1);
                }
            }

            var img = OxyImage.PngFromArgb(data);
            var bytes = img.GetData();
            File.WriteAllBytes("PngFromArgb2.png", bytes);
        }

        [Test]
        public void FromArgbX()
        {
            var data = new OxyColor[2, 4];
            data[1, 0] = OxyColors.Blue;
            data[1, 1] = OxyColors.Green;
            data[1, 2] = OxyColors.Red;
            data[1, 3] = OxyColors.White;
            data[0, 0] = OxyColors.Yellow.ChangeAlpha(127);
            data[0, 1] = OxyColors.Orange.ChangeAlpha(127);
            data[0, 2] = OxyColors.Pink.ChangeAlpha(127);
            data[0, 3] = OxyColors.Transparent;
            var img = OxyImage.FromArgbX(data);
            var bytes = img.GetData();
            File.WriteAllBytes("FromArgbX.bmp", bytes);
        }

        [Test]
        public void FromIndexed8()
        {
            var data = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            var data2 = new byte[,] { { 0, 1, 2, 3 }, { 4, 5, 6, 7 } };

            var palette = new OxyColor[8];
            palette[4] = OxyColors.Blue;
            palette[5] = OxyColors.Green;
            palette[6] = OxyColors.Red;
            palette[7] = OxyColors.White;
            palette[0] = OxyColors.Yellow.ChangeAlpha(127);
            palette[1] = OxyColors.Orange.ChangeAlpha(127);
            palette[2] = OxyColors.Pink.ChangeAlpha(127);
            palette[3] = OxyColors.Transparent;
            var img = OxyImage.FromIndexed8(4, 2, data, palette);
            var bytes = img.GetData();
            File.WriteAllBytes("FromIndexed8.bmp", bytes);

            var img2 = OxyImage.FromIndexed8(data2, palette);
            var bytes2 = img2.GetData();
            File.WriteAllBytes("FromIndexed8_2.bmp", bytes2);
        }

        [Test]
        public void Discussion453825_100()
        {
            var data = new byte[100 * 100];
            int k = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    data[i + (j * 100)] = (byte)(k++ % 256);
                }
            }

            var palette = OxyPalettes.Gray(256).Colors.ToArray();
            var im = OxyImage.FromIndexed8(100, 100, data, palette);
            File.WriteAllBytes("Discussion453825.bmp", im.GetData());
        }

        [Test]
        public void Discussion453825_199()
        {
            int w = 199;
            int h = 256;
            var data = new byte[h, w];
            var data2 = new byte[h * w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    data[i, j] = (byte)(i % 256);
                    data2[(i * w) + j] = (byte)(i % 256);
                }
            }

            var palette1 = OxyPalettes.Gray(256).Colors.ToArray();
            var im1 = OxyImage.FromIndexed8(data, palette1);
            var im2 = OxyImage.FromIndexed8(w, h, data2, palette1);
            var bytes1 = im1.GetData();
            var bytes2 = im2.GetData();

            // The images should show a gradient image 199x256 - black at the bottom, white at the top
            File.WriteAllBytes("Discussion453825_199a.bmp", bytes1);
            File.WriteAllBytes("Discussion453825_199b.bmp", bytes2);

            // The two files should be identical
            Assert.IsTrue(bytes1.Length == bytes2.Length);
            for (int i = 0; i < bytes1.Length; i++)
            {
                Assert.IsTrue(bytes1[i] == bytes2[i], "Position: " + i);
            }
        }
    }
}