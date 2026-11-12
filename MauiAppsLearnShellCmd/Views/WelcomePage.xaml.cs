using ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Views;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.WelcomeViewModel();
    }
}
