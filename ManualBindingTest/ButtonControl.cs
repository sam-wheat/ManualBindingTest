// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ManualBindingTest;
public sealed class ButtonControl : Control
{


    public ICommand InternalCommand
    {
        get { return (ICommand)GetValue(InternalCommandProperty); }
        set { SetValue(InternalCommandProperty, value); }
    }

    public static readonly DependencyProperty InternalCommandProperty =
        DependencyProperty.Register("InternalCommand", typeof(ICommand), typeof(ButtonControl), new PropertyMetadata(null));


    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(ButtonControl), new PropertyMetadata(null));




    public ButtonControl()
    {
        this.DefaultStyleKey = typeof(ButtonControl);

        InternalCommand = new RelayCommand<object>(x =>
        {
            int arg = Convert.ToInt32(x) + 1;
            Command?.Execute(arg);
        });
    }
}
