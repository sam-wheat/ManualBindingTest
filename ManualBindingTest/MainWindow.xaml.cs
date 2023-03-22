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
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ManualBindingTest;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window, INotifyPropertyChanged
{
    public ICommand Command { get; set; }

    private string _Message;
    public string Message
    {
        get => _Message;
        set => SetProp(ref _Message, value);
    }
  

    public MainWindow()
    {
        this.InitializeComponent();

        // Wire up a command handler for the existing instance of ContainerControl
        Command = new RelayCommand<object>(x =>
        {
            Message = DateTime.Now.TimeOfDay.ToString();
            
        });

        
        // Add a new instance of ControlContainer and bind its Command to the Command on this control
        ContainerControl cc = new();
        Binding b = new() { Mode = BindingMode.OneWay };
        b.Source = Command;
        cc.SetBinding(ContainerControl.CommandProperty, b);
        layoutRoot.Children.Add(cc);
    }


    #region INotifyPropertyChanged implementation
    public event PropertyChangedEventHandler? PropertyChanged;
    public void RaisePropertyChanged([CallerMemberNameAttribute] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void SetProp<T>(ref T prop, T value, [CallerMemberNameAttribute] string propertyName = "")
    {
        if (!Object.Equals(prop, value))
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }
    }
    #endregion    
}
