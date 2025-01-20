namespace JFExamenP3
{
    public partial class App : Application
    {
        public static JFClimaRepository ClimaRepo { get; private set; }

        public App(JFClimaRepository repo)
        {
            InitializeComponent();
            ClimaRepo = repo;

            // MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new AppShell());
        }
    }
}
