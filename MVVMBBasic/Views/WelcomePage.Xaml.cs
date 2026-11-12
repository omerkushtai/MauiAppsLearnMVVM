
namespace Views;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.WelcomeViewModel();
    }
}
