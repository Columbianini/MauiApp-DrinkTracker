namespace DrinkDrink.View;

public partial class HistoryPage : ContentPage
{
	public HistoryPage(TodayDrinkViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}