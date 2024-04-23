namespace bco.atlantidad.estadocuenta.api.Core.Logic.Interface
{
    public interface IUnitOfWork
    {
        ICliente _Cliente { get; }
        ITarjeta _Tarjeta { get; }
        IEstadoCuenta _EstadoCuenta { get; }
        IMovimientos _Movimientos { get; }
        IConfiguraciones _Configuraciones { get; }
    }
}
