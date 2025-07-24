using System.Text.Json;
using TakeHomeAssessment.Models;
using TakeHomeAssessment.ViewModels;

namespace TakeHomeAssessment.Views;

public partial class QuotesPage : ContentPage
{
    public QuotesPage(QuotesPageViewModel quotesPageViewModel)
    {
        InitializeComponent();
        this.BindingContext = quotesPageViewModel;
    }
}