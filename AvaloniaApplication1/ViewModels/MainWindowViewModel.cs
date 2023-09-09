namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    private int StartValue = 0;
    private int NumValue = 0;
    private int StepValue = 0;
    

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
    
    
    
}