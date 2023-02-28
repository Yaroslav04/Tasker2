namespace Tasker2;

public partial class App : Application
{
    static DataBase dataBase;
    public static DataBase DataBase
    {
        get
        {
            if (dataBase == null)
            {
                dataBase = new DataBase(FileManager.Path(), new List<string> {
                    "TaskDataBase.db3", "PeriodDataBase.db3", "ObjectDataBase.db3", "TypeDataBase.db3",
                    "SubTypeDataBase.db3", "NotificationDataBase.db3"
                });
            }
            return dataBase;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
