// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ManualBindingTest;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public ICommand Command { get; set; }
  

    public MainWindow()
    {
        this.InitializeComponent();

        // Wire up a command handler for the existing instance of ContainerControl
        Command = new RelayCommand<object>(x =>
        {
            int arg = Convert.ToInt32(x) + 1;
            
        });

        
        // Add a new instance of ControlContainer and bind its Command to the Command on this control
        ContainerControl cc = new();
        Binding b = new() { Mode = BindingMode.OneWay };
        b.Source = Command;
        cc.SetBinding(ContainerControl.CommandProperty, b);
        layoutRoot.Children.Add(cc);
    }

    
}
