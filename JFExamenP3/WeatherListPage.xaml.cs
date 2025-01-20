using JFExamenP3.Models;
namespace JFExamenP3
{
    public partial class WeatherListPage : ContentPage
    {
        public WeatherListPage()
        {
            InitializeComponent();
            LoadPeople();
        }

        private async void LoadPeople()
        {
            var people = await App.ClimaRepo.GetAllPeople();
            peopleList.ItemsSource = people;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPerson = e.SelectedItem as JFInfoClima;
            if (selectedPerson != null)
            {
                // Aquí puedes agregar más acciones, como editar, eliminar, etc.
            }
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Agregar una nueva entrada al repositorio.
            await App.ClimaRepo.AddNew("Nombre de la ciudad");
            await DisplayAlert("Guardado", "La ciudad ha sido guardada.", "OK");
        }
    }
}
