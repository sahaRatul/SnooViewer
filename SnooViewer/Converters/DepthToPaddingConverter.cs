﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SnooViewer.Converters
{
    public class DepthToPaddingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string _)
        {
            if (value is UInt32)
            {
                return new Thickness(10 + (uint)value * 20, 0, 0, 0);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string _)
        {
            throw new NotImplementedException();
        }
    }
}
