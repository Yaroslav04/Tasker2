using Tasker2.Core.ViewModel;

namespace Tasker2.Core.View;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();
        BindingContext = new TestViewModel();
    }
}