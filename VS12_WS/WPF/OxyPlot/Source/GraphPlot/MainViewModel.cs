﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="OxyPlot">
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
using OxyPlot;
using System;

namespace GraphPlot
{
    using OxyPlot.Series;

    public class MainViewModel: Observable
    {
        private PlotModel model;

        public MainViewModel()
        {
            var tmp = new PlotModel("GA Example", "with OxyPlot");

            var series1 = new LineSeries("Series 1") { MarkerType = MarkerType.Circle};

            for (double x = 0; x < 512; x = x+0.5)
            {
                series1.Points.Add(new DataPoint(x,-System.Math.Abs(x*(System.Math.Sin(System.Math.Sqrt(System.Math.Abs(x)))))));
            }

            tmp.Series.Add(series1);

            Model = tmp;
        }

        public PlotModel Model
        {
            get { return model; }
            set
            {
                if (model != value)
                {
                    model = value;
                    RaisePropertyChanged(() => Model);
                }
            }
        }
    }
}