using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MauiMarkupExtension.OnScreenSizeExtension;

namespace MauiMarkupExtension;

public class MyControl
{
    public static readonly BindableProperty PageWidthProperty =
     BindableProperty.CreateAttached("PageWidth", typeof(double), typeof(MyControl), default(double), propertyChanged: OnPageWidthChanged);

    public static double GetPageWidth(BindableObject view)
    {
        return (double) view.GetValue(PageWidthProperty);
    }

    public static void SetPageWidth(BindableObject view, double value)
    {
        view.SetValue(PageWidthProperty, value);
    }

    private static void OnPageWidthChanged(BindableObject bindable, object oldValue, object newValue)
    {
        Debug.WriteLine(newValue);
        WeakReferenceMessenger.Default.Send(new ScreenSizeChangedMessage((double)newValue));
    }
}
