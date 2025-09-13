using System.Collections.ObjectModel;
using System.Windows.Input;
using GestorDeDrones.Models;
using GestorDeDrones.Views; // Asegúrate de añadir esta referencia

namespace GestorDeDrones.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Drone> Drones { get; set; }
        public ICommand AddDroneCommand { get; }

        public MainViewModel()
        {
            Drones = new ObservableCollection<Drone>();
            LoadSampleData();
            AddDroneCommand = new RelayCommand(OpenAddDroneWindow);
        }

        private void OpenAddDroneWindow(object parameter)
        {
            AddDroneWindow addWindow = new AddDroneWindow();
            addWindow.ShowDialog();
        }

        private void LoadSampleData()
        {
            // Datos de ejemplo para probar la interfaz
            Drones.Add(new Drone 
            { 
                Marca = "DJI", 
                Modelo = "Mavic Air 2", 
                NumeroSerie = "1A2B3C4D", 
                Peso = 570, 
                Clase = "C1", 
                Anio = 2020 
            });

            Drones.Add(new Drone
            {
                Marca = "Autel Robotics",
                Modelo = "EVO Nano+",
                NumeroSerie = "9X8Y7Z6W",
                Peso = 249,
                Clase = "C0",
                Anio = 2021
            });
        }
    }
}