namespace Views;

public partial class CurrencyCalculatorPage : ContentPage
{
    public CurrencyCalculatorPage()
    {
        InitializeComponent();
    }

    private async void OpenRatesWebsite(
        object sender, TappedEventArgs e)
    {
        await Browser.Default.OpenAsync(
            "https://www.exchangerate-api.com");
    }
}