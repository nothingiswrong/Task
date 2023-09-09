using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private int _num = 0;
    private int _start = 0;
    private int _step = 0;

    public string Num
    {
        get => _num == 0 ? "" : _num.ToString();
        set => _num = int.TryParse(value, out var x) ? x : 0;
    }

    public string Start
    {
        get => _start == 0 ? "" : _start.ToString();
        set => _start = int.TryParse(value, out var x) ? x : 0;
    }

    public string Step
    {
        get => _step == 0 ? "" : _step.ToString();
        set => _step = int.TryParse(value, out var x) ? x : 0;
    }


    public void CalcButtonOnClick()
    {
        Console.WriteLine("It works!");
    }






    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}