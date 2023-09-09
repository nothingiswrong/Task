using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ObservableObject, INotifyPropertyChanged
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

    //Not implemented yet
    public void CalcButtonOnClick()
    {
        Console.WriteLine("It works!");
    }

    //Plot
    
    public ISeries[] Series { get; set; } 
        = new ISeries[]
        {
            new LineSeries<double>
            {
                Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                Fill = null
            }
        };

    

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}