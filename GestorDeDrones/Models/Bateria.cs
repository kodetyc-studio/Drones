namespace GestorDeDrones.Models
{
    public class Bateria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NumeroSerie { get; set; }
        public int CiclosDeCarga { get; set; }
        public int AnioCompra { get; set; }
    }
}