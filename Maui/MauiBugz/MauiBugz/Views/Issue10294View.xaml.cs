using MauiBugz.ViewModels;

namespace MauiBugz.Views;

public partial class Issue10294View : ContentPage
{
	public Issue10294View( Issue10294ViewModel vm )
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}