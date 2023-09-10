using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using Task1;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ObservableObject, INotifyPropertyChanged
{
    private int _num = 0;
    private int _start = 0;
    private int _step = 0;
    private readonly TaskMaster _taskMaster;

    public MainWindowViewModel(TaskMaster taskMaster)
    {
        _taskMaster = taskMaster;
        var wmTests = _taskMaster.GenerateTestsN7(100, 10000, 10000);
        Util.WarmUp(1000, _taskMaster.N7, wmTests[0][0], wmTests[0][1]);
    }

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
        var res = _taskMaster.PassTests(
            _taskMaster.GenerateTestsN7(_num, _start, _step)
        );
        
        var val = new List<ObservablePoint>(res.Count);
        foreach (var r in res)  val.Add(new ObservablePoint(r.Key, r.Value));
        
        
        Series = new ISeries[]
        {
            new LineSeries<ObservablePoint>()
            {
                Values = val,
                Fill = null
            }
        };
        OnPropertyChanged(nameof(Series));
    }



    //Plot
    
    public LabelVisual Title { get; set; } =
        new LabelVisual
        {
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

    public ISeries[] Series { get; set; } =
    {
        new LineSeries<ObservablePoint>
        {
            Values = new ObservablePoint[]
            {
                new ObservablePoint()
            }
        }
    };


    

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}