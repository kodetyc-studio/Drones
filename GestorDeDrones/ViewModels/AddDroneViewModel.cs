using System;
using System.Windows.Input;
using GestorDeDrones.Data;
using GestorDeDrones.Models;
using GestorDeDrones.Utilities; // Importamos el nuevo namespace
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestorDeDrones.ViewModels
{
    public class AddDroneViewModel : INotifyPropertyChanged
    {
        public event Action<Drone> DroneAdded;

        private Drone _newDrone;
        public Drone NewDrone
        {
            get => _newDrone;
            set
            {
                _newDrone = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public AddDroneViewModel()
        {
            NewDrone = new Drone();
            SaveCommand = new RelayCommand(SaveDrone);
        }

        private void SaveDrone(object parameter)
        {
            try
            {
                using (var db = new DronesDbContext())
                {
                    db.Drones.Add(NewDrone);
                    db.SaveChanges();
                    DroneAdded?.Invoke(NewDrone);
                }
                Console.WriteLine("Dron guardado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el dron: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}