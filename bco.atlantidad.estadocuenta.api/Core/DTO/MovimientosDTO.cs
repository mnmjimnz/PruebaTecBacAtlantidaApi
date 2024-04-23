namespace bco.atlantidad.estadocuenta.api.Core.DTO
{
    public class MovimientosDTO
    {
        public int IdMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int TipoMovimiento { get; set; }
        public int IdTarjeta { get; set; }
    }
}
