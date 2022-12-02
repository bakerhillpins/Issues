using MauiBugz.ViewModels;

namespace MauiBugz.Views;

public partial class IssueXxxView : ContentView
{
	public IssueXxxView( IssueXxxViewModel vm )
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}