using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GestorDeDrones.Data;
using GestorDeDrones.Models;
using GestorDeDrones.Views;
using GestorDeDrones.ViewModels; // Se añade para poder referenciar a AddDroneViewModel

namespace GestorDeDrones.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Drone> Drones { get; set; }
        public ICommand AddDroneCommand { get; }

        public MainViewModel()
        {
            Drones = new ObservableCollection<Drone>();
            LoadDronesFromDatabase();
            AddDroneCommand = new RelayCommand(OpenAddDroneWindow);
        }

        private void LoadDronesFromDatabase()
        {
            using (var db = new DronesDbContext())
            {
                var dronesList = db.Drones.ToList();
                // Limpiamos y añadimos los drones de la base de datos a la colección
                Drones.Clear();
                foreach (var drone in dronesList)
                {
                    Drones.Add(drone);
                }
            }
        }

        private void OpenAddDroneWindow(object parameter)
        {
            var addWindowViewModel = new AddDroneViewModel();
            var addWindow = new AddDroneWindow
            {
                DataContext = addWindowViewModel
            };

            // Suscribimos al evento DroneAdded del AddDroneViewModel
            addWindowViewModel.DroneAdded += OnDroneAdded;

            // Mostramos la ventana como un diálogo para bloquear la principal
            addWindow.ShowDialog();

            // Desuscribimos el evento para evitar fugas de memoria
            addWindowViewModel.DroneAdded -= OnDroneAdded;
        }

        private void OnDroneAdded(Drone newDrone)
        {
            // Este método se ejecuta cuando un dron se guarda con éxito
            Drones.Add(newDrone);
        }
    }
}