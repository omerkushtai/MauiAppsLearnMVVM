
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace ViewModels
{

    public class TemperatureCalculatorViewModel
    {
            private string temperature = "";
            private string result = "";

            public string Temperature
            {
                get => temperature;
                set
                {
                    temperature = value;
                    OnPropertyChanged();
                }
            }

            public string Result
            {
                get => result;
                set
                {
                    result = value;
                    OnPropertyChanged();
                }
            }

            public ICommand ToCelsiusCommand { get; }
            public ICommand ToFahrenheitCommand { get; }
            public ICommand WelcomeCommand { get; }

            public TemperatureCalculatorViewModel()
            {
                ToCelsiusCommand = new Command(ConvertToCelsius);
                ToFahrenheitCommand = new Command(ConvertToFahrenheit);
                WelcomeCommand = new Command(GoToWelcome);
            }

            private void ConvertToCelsius()
            {
                if (double.TryParse(Temperature, out double fahrenheit))
                {
                    double celsius = (fahrenheit - 32) * 5 / 9;
                    Result = $"{celsius:F2} °C";
                }
                else
                {
                    Result = "Please enter a valid number";
                }
            }

            private void ConvertToFahrenheit()
            {
                if (double.TryParse(Temperature, out double celsius))
                {
                    double fahrenheit = (celsius * 9 / 5) + 32;
                    Result = $"{fahrenheit:F2} °F";
                }
                else
                {
                    Result = "Please enter a valid number";
                }
            }

            private async void GoToWelcome()
            {
                await Shell.Current.GoToAsync("//Welcome");
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(
                [CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }




