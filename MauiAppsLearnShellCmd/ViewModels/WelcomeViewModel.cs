using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModels
{
    public class WelcomeViewModel: BaseViewModel
    {
        public ICommand GoToAgeCommand { get; }
        public ICommand GoToCalculatorCommand { get; }
        public WelcomeViewModel()
        {
            Title = "Welcome";

            GoToAgeCommand = new Command(async () =>
                await Shell.Current.GoToAsync("//CalcAge"));

            GoToCalculatorCommand = new Command(async () =>
                await Shell.Current.GoToAsync("//CalculatorPage"));
        }

    }
}
