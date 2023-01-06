using MauiBugz.ViewModels;

namespace MauiBugz.Views;

public partial class Issue12469View : ContentPage
{
	public Issue12469View( Issue12469ViewModel vm )
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}