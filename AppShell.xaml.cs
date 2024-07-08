using TakeHomeAssessment.Views;

namespace TakeHomeAssessment;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(QuotesPage), typeof(QuotesPage));
	}
}
