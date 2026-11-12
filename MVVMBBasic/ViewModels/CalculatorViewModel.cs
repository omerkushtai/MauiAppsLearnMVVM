
using System.Windows.Input;

namespace ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        private string _number1 = "";
        private string _number2 = "";
        private string _result = "0";

        public string Number1
        {
            get => _number1;
            set
            {
                _number1 = value;
                OnPropertyChanged();
            }
        }

        public string Number2
        {
            get => _number2;
            set
            {
                _number2 = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

        public CalculatorViewModel()
        {
            Title = "מחשבון";

            AddCommand = new Command(() => Calculate("+"));
            SubtractCommand = new Command(() => Calculate("-"));
            MultiplyCommand = new Command(() => Calculate("*"));
            DivideCommand = new Command(() => Calculate("/"));
        }

        private async void Calculate(string operation)
        {
            if (!double.TryParse(Number1, out double num1) ||
                !double.TryParse(Number2, out double num2))
            {
                await ShowAlertAsync(
                    "קלט לא תקין",
                    "אנא הכנס מספרים תקינים בשתי התיבות",
                    "אישור");

                return;
            }

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;

                case "-":
                    result = num1 - num2;
                    break;

                case "*":
                    result = num1 * num2;
                    break;

                case "/":
                    if (num2 == 0)
                    {
                        Result = "שגיאה";

                        await ShowAlertAsync(
                            "שגיאה",
                            "לא ניתן לחלק באפס!",
                            "אישור");

                        return;
                    }

                    result = num1 / num2;
                    break;
            }

            Result = result.ToString();
        }
    }
}
