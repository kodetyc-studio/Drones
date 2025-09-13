using System;
using System.Windows.Input;
using GestorDeDrones.Data;
using GestorDeDrones.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestorDeDrones.ViewModels
{
    public class AddDroneViewModel : INotifyPropertyChanged
    {
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
                }
                // Opcional: Notificar al usuario o cerrar la ventana
                Console.WriteLine("Dron guardado con éxito.");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al guardar el dron: {ex.Message}");
            }
        }

        // Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Una implementación simple de ICommand para el ejemplo
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
    }
}