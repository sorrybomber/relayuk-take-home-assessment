using TakeHomeAssessment.ViewModels;

namespace TakeHomeAssessment.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}
