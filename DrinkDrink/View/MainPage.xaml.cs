namespace DrinkDrink.View;

public partial class MainPage : ContentPage
{

	public MainPage(TodayDrinkViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		viewModel.GetAllHistoryCommand.Execute(null);
	}

}

