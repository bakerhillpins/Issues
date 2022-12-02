using MauiBugz.ViewModels;

namespace MauiBugz.Views;

public partial class IssueXxxView : ContentPage
{
	public IssueXxxView( IssueXxxViewModel vm )
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}