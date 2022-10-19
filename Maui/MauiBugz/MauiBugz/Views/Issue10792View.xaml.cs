using MauiBugz.ViewModels;

namespace MauiBugz.Views;

public partial class Issue10792View : ContentPage
{
	public Issue10792View( Issue10792ViewModel vm )
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}