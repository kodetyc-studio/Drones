#nullable enable

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GestorDeDrones.Data;
using GestorDeDrones.Models;
using GestorDeDrones.Utilities;
using GestorDeDrones.Views;
using Microsoft.EntityFrameworkCore;

namespace GestorDeDrones.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Drone> Drones { get; set; }
        public ICommand AddDroneCommand { get; }
        public ICommand OpenDetailsCommand { get; }

        private Drone? _selectedDrone;
        public Drone? SelectedDrone
        {
            get => _selectedDrone;
            set => _selectedDrone = value;
        }

        public MainViewModel()
        {
            Drones = new ObservableCollection<Drone>();
            LoadDronesFromDatabase();
            AddDroneCommand = new RelayCommand(OpenAddDroneWindow);
            OpenDetailsCommand = new RelayCommand(OpenDetailsWindow);
        }

        private void LoadDronesFromDatabase()
        {
            using (var db = new DronesDbContext())
            {
                var dronesList = db.Drones
                                   .Include(d => d.Baterias)
                                   .Include(d => d.Mandos)
                                   .Include(d => d.Accesorios)
                                   .ToList();
                Drones.Clear();
                foreach (var drone in dronesList)
                {
                    Drones.Add(drone);
                }
            }
        }

        private void OpenAddDroneWindow(object? parameter)
        {
            var addWindowViewModel = new AddDroneViewModel();
            var addWindow = new AddDroneWindow
            {
                DataContext = addWindowViewModel
            };

            addWindowViewModel.DroneAdded += OnDroneAdded;
            addWindow.ShowDialog();
            addWindowViewModel.DroneAdded -= OnDroneAdded;
        }

        private void OnDroneAdded(Drone newDrone)
        {
            Drones.Add(newDrone);
        }

        private void OpenDetailsWindow(object? parameter)
        {
            if (parameter is Drone selectedDrone)
            {
                var viewModel = new DroneDetailsViewModel(selectedDrone);
                var detailsWindow = new DroneDetailsWindow(viewModel);
                detailsWindow.ShowDialog();
                LoadDronesFromDatabase();
            }
        }
    }
}