namespace bco.atlantidad.estadocuenta.api.Core.DTO
{
    public class TarjetaDTO
    {
        public int IdTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int CodigoSeguridad { get; set; }
        public decimal Limite { get; set; }
        public int IdCliente { get; set; }
        public decimal TotalMasIntereses { get; set; }
    }
}
