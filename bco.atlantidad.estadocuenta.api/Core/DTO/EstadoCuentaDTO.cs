namespace bco.atlantidad.estadocuenta.api.Core.DTO
{
    public class EstadoCuentaDTO
    {
        public int IdEstadoCuenta { get; set; }
        public decimal SaldoActual { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal TotalMasIntereses { get; set; }
        public int IdTarjeta { get; set; }
    }
}
