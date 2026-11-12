using ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Views;

    public partial class CalculatorPage : ContentPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.CalculatorViewModel();
        }
    }

