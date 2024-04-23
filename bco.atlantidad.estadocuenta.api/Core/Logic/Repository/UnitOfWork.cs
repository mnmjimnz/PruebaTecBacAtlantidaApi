using bco.atlantidad.estadocuenta.api.Core.Logic.Interface;

namespace bco.atlantidad.estadocuenta.api.Core.Logic.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICliente _Cliente { get; set; }
        public ITarjeta _Tarjeta { get; set; }
        public IEstadoCuenta _EstadoCuenta { get; set; }
        public IMovimientos _Movimientos { get; set; }
        public IConfiguraciones _Configuraciones { get; set; }

        public UnitOfWork(ICliente Cliente, ITarjeta tarjeta, IEstadoCuenta estadoCuenta, IMovimientos movimientos, IConfiguraciones configuraciones)
        {
            this._Cliente = Cliente;
            _Tarjeta = tarjeta;
            _EstadoCuenta = estadoCuenta;
            _Movimientos = movimientos;
            _Configuraciones = configuraciones;
        }
    }
}
