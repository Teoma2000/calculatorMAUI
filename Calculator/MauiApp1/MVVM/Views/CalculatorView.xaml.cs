namespace MauiApp1.MVVM.Views;
using MauiApp1.MVVM.ViewModels;

using Microsoft.Maui.Controls;



public partial class CalculatorView : ContentPage


{

    double firstNum, secondNum;
    int currentState = 1;
    string operatorMath;

    private readonly CalculatorViewModel viewModel;

    public CalculatorView()
    {
        InitializeComponent();

        viewModel = new CalculatorViewModel();
        BindingContext = viewModel;
    }

    void OnClear(object sender, EventArgs e)
    {
        this.result.Text = viewModel.Clear();
    }

    void OnNumberSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;
        

        //viewModel.AppendNumber(btnPressed);

        this.result.Text = viewModel.AppendNumber(btnPressed);  
    }

    void OnOperatorSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;

         viewModel.PerformOperation(btnPressed);
    }

    void OnCalculate(object sender, EventArgs e)
    {
        this.result.Text = viewModel.CalculateResult();
    }

    void OnDelete(object sender, EventArgs e)
    {
        this.result.Text =  viewModel.DeleteDigit();
    }
}
