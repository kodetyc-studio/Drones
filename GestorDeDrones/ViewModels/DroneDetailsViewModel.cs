using GestorDeDrones.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestorDeDrones.ViewModels
{
    public class DroneDetailsViewModel : INotifyPropertyChanged
    {
        private Drone _drone;
        public Drone Drone
        {
            get => _drone;
            set
            {
                _drone = value;
                OnPropertyChanged();
            }
        }

        public DroneDetailsViewModel(Drone selectedDrone)
        {
            // Copia el dron seleccionado para trabajar con él
            this.Drone = selectedDrone;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}