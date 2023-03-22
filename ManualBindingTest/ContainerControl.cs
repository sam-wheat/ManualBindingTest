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
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ManualBindingTest;
public sealed class ContainerControl : Control
{
    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(ContainerControl), new PropertyMetadata(null));

    public ContainerControl()
    {
        this.DefaultStyleKey = typeof(ContainerControl);

        //Command = new RelayCommand<object>(x =>
        //{
        //    int arg = Convert.ToInt32(x) + 1;

        //});


        
    }
    protected override void OnApplyTemplate()
    {
        //return;

        
        // Add a new instance of ButtonControl and bind its Command to the Command on this control
        ButtonControl bc = new();
        Binding b = new() { Mode = BindingMode.OneWay };
        b.Source = Command;
        bc.SetBinding(ButtonControl.CommandProperty, b);
        StackPanel layoutRoot = GetTemplateChild("layoutRoot") as StackPanel;
        layoutRoot.Children.Add(bc);
        base.OnApplyTemplate();
    }
}
