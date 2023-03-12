
using System.Security;

namespace Tasker2;

public partial class AppShell : Shell
{
	public AppShell()
	{
        Run();
	}

    async Task Run()
    {
        InitializeComponent();
    }

}
