namespace GestorDeDrones.Models
{
    public class Accesorio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public int CiclosDeCarga { get; set; }
        public int AnioCompra { get; set; }
    }
}