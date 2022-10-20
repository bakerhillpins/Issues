using MauiBugz.ViewModels;

namespace MauiBugz.Views;

public partial class Issue10806View : ContentPage
{
	public Issue10806View( Issue10806ViewModel vm )
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}