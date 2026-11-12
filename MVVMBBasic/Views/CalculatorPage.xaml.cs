
namespace Views
{
    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.CalculatorViewModel();
        }
    }
}




