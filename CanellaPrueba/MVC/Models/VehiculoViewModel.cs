namespace MVC.Models
{
    public class VehiculoViewModel
    {
        public int IdVehiculo { get; set; }
        public string Matricula { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Color { get; set; } = null!;
        public decimal Alquiler { get; set; }
    }
}
