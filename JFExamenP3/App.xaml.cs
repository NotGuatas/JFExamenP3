namespace JFExamenP3;

public partial class App : Application
{
    static JFClimaRepository _climaRepo;

    public static JFClimaRepository ClimaRepo
    {
        get
        {
            if (_climaRepo == null)
            {
                var dbPath = JFFileAccessHelper.GetLocalFilePath("clima.db3");
                _climaRepo = new JFClimaRepository(dbPath);
            }
            return _climaRepo;
        }
    }

    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
}
