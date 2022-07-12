namespace DrinkDrink.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DrinkDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}