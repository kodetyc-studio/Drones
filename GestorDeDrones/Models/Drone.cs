using System.Collections.ObjectModel;

namespace GestorDeDrones.Models
{
    public class Drone
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroSerie { get; set; }
        public double Peso { get; set; }
        public string Clase { get; set; }
        public int Anio { get; set; }
        public ObservableCollection<Bateria> Baterias { get; set; } = new ObservableCollection<Bateria>();
        public ObservableCollection<Mando> Mandos { get; set; } = new ObservableCollection<Mando>();
        public ObservableCollection<Accesorio> Accesorios { get; set; } = new ObservableCollection<Accesorio>();
    }
}