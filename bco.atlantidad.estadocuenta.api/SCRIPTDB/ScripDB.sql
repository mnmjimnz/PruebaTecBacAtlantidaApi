use master
go
create database EstadoCuentas
go

use EstadoCuentas
go

create table Cliente(
IdCliente int not null identity(1,1) primary key,
NombresCliente nvarchar(100) not null,
ApellidosCliente nvarchar(150) not null
)
go

create table Tarjeta(
IdTarjeta int not null identity(1,1) primary key,
NumeroTarjeta nvarchar(16) not null, --generar un numero de 16 digitos de manera aleatoria(siempre verificar que no sea repetido en la BD)
FechaExpiracion date not null,
CodigoSeguridad int not null,
Limite decimal(12,2) not null,
IdCliente int not null foreign key references Cliente(IdCliente)
)
create table EstadoCuenta(
IdEstadoCuenta int not null identity(1,1) primary key,
SaldoActual decimal(12,2),
SaldoDisponible decimal(12,2),
TotalMasIntereses decimal(12,2),
IdTarjeta int not null foreign key references Tarjeta(IdTarjeta)
)

create table Movimientos(
IdMovimiento int not null identity(1,1) primary key,
FechaMovimiento date,
Descripcion nvarchar(500),
Monto decimal(12,2) not null,
TipoMovimiento int not null, --1 Compra, 2 Pago
IdTarjeta int not null foreign key references Tarjeta(IdTarjeta)
)

create table Configuraciones(
IdConfiguracion int not null identity(1,1) primary key,
PorcentajeSaldoMin int not null,
PorcentajeInteres int not null,
IdTarjeta int not null foreign key references Tarjeta(IdTarjeta)
)

