using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Text.Json;
namespace ViewModels;

public class CurrencyCalculatorViewModel
{
    
        private string amount = "";
        private string result = "";
        private string fromCurrency = "USD";
        private string toCurrency = "ILS";

        private static readonly HttpClient client = new HttpClient();

        public List<string> Currencies { get; } =
            new List<string> { "ILS", "USD", "EUR", "GBP" };

        public string Amount
        {
            get => amount;
            set
            {
                amount = value;
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

        public string FromCurrency
        {
            get => fromCurrency;
            set
            {
                fromCurrency = value;
                OnPropertyChanged();
            }
        }

        public string ToCurrency
        {
            get => toCurrency;
            set
            {
                toCurrency = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConvertCommand { get; }
        public ICommand WelcomeCommand { get; }

        public CurrencyCalculatorViewModel()
        {
            ConvertCommand = new Command(async () =>
                await ConvertCurrency());

            WelcomeCommand = new Command(async () =>
                await Shell.Current.GoToAsync("//Welcome"));
        }

        private async Task ConvertCurrency()
        {
            if (!double.TryParse(Amount, out double value)
                || value < 0)
            {
                Result = "Please enter a valid amount";
                return;
            }

            if (FromCurrency == ToCurrency)
            {
                Result = $"{value:F2} {ToCurrency}";
                return;
            }

            try
            {
                string url =
                    $"https://open.er-api.com/v6/latest/{FromCurrency}";

                string response =
                    await client.GetStringAsync(url);

                using JsonDocument document =
                    JsonDocument.Parse(response);

                string status = document.RootElement
                    .GetProperty("result").GetString();

                if (status != "success")
                {
                    Result = "Could not get exchange rates";
                    return;
                }

                JsonElement rates = document.RootElement
                    .GetProperty("rates");

                double rate = rates.GetProperty(ToCurrency)
                    .GetDouble();

                double converted = value * rate;

                Result = $"{converted:F2} {ToCurrency}";
            }
            catch
            {
                Result = "Error connecting to exchange rates";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
