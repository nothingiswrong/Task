using System;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using Task1;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private int StartValue = 0;
    private int NumValue = 0;
    private int StepValue = 0;
    
    private readonly TaskMaster _taskMaster;

    public MainWindowViewModel(TaskMaster taskMaster)
    {
        _taskMaster = taskMaster;
    }
    
    public ISeries[] Series { get; set; } =
    {
        new LineSeries<ObservablePoint>
        {
            Values = new ObservablePoint[]
            {
                new ObservablePoint(0, 4),
                new ObservablePoint(1, 3),
                new ObservablePoint(3, 8),
                new ObservablePoint(18, 6),
                new ObservablePoint(20, 12)
            }
        }
    };

    public int Start
    {
        get => StartValue;
        set
        {
            if (!int.TryParse(value.ToString(), out StartValue)) StartValue = 0;
        }
    }
    
    public int Num
    {
        get => StartValue;
        set
        {
            if (!int.TryParse(value.ToString(), out NumValue)) NumValue = 0;
        }
    }
    
    public int Step
    {
        get => StartValue;
        set
        {
            if (!int.TryParse(value.ToString(), out StepValue)) StepValue = 0;
        }
    }

    public void CalcButtonCommand()
    {
        var res = _taskMaster.PassTests(
            _taskMaster.GenerateTestsN7(NumValue, StartValue, StepValue)
        );
        
        throw new NotImplementedException();
    }
    
}