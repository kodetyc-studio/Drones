using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GestorDeDrones.Models
{
    public class Drone : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public double Peso { get; set; }
        public string Clase { get; set; }
        public int Anio { get; set; }
        public ObservableCollection<Bateria> Baterias { get; set; }
        public ObservableCollection<Mando> Mandos { get; set; }
        public ObservableCollection<Accesorio> Accesorios { get; set; }

        public Drone()
        {
            Baterias = new ObservableCollection<Bateria>();
            Mandos = new ObservableCollection<Mando>();
            Accesorios = new ObservableCollection<Accesorio>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}