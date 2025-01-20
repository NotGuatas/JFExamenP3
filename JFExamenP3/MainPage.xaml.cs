using JFExamenP3.Models;

namespace JFExamenP3
{
    public partial class MainPage : ContentPage
    {
        private readonly JFInfoClima _weatherService;

        public MainPage()
        {
            InitializeComponent();
            _weatherService = new JFInfoClima();

        }

        private async void ObtenerClima(object sender, EventArgs e)
        {
          
        }
    }

}
