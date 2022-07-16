namespace DrinkDrink.View;

public partial class MainPage : ContentPage
{

	public MainPage(TodayDrinkViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		viewModel.GetAllHistoryCommand.Execute(null);
	}

	//private void Button_Clicked(object sender, EventArgs e)
	//{
	//	var viewmodel= (TodayDrinkViewModel)BindingContext;
	//	if(viewmodel.cupOnHand == 0)
	//	{
	//		viewmodel.StartDrinkCommand.Execute(null);
	//		this.ToggleButton.Source = "fullbottle.png";
 //       }
	//	else
	//	{
	//		viewmodel.FinishDrinkCommand.Execute(null);
	//		this.ToggleButton.Source = "emptybottle.png";
	//	}
	//}
}

