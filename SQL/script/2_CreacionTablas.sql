use BDParqueo
go 

if  exists(select top 1 1 from sys.objects where name = 'Pago' and type = 'U')
begin 
	drop table Pago
end 

if  exists(select top 1 1 from sys.objects where name = 'Ticket' and type = 'U')
begin 
	drop table Ticket
end 

if  exists(select top 1 1 from sys.objects where name = 'Vehiculo' and type = 'U')
begin 
	drop table Vehiculo
end 

if  exists(select top 1 1 from sys.objects where name = 'Parametro' and type = 'U')
begin 
	drop table Parametro
end 

if  exists(select top 1 1 from sys.objects where name = 'Persona' and type = 'U')
begin 
	drop table Persona
end 


create table Persona
(
IdPersona int identity(1,1),
Identificacion varchar(200),
Nombres varchar(100),
Apellidos varchar(100),
primary key (IdPersona)
)

create table Vehiculo
(
IdVehiculo int identity(1,1),
IdPersona int, 
Placa varchar(20),
Marca varchar(200),
Modelo varchar(100),
TipoVehiculo varchar(20)
primary key (IdVehiculo),
foreign key (IdPersona) references Persona(IdPersona)
)


create table Ticket
(
IdTicket int identity(1,1),
Secuencial uniqueidentifier,
FechaIngreso datetime, 
FechaSalida datetime,
Estado varchar(10)
primary key (IdTicket)
)

create table Pago
(
IdPago int identity(1,1),
IdTicket int,
IdPersona int, 
Valor decimal(19,2),
FechaPago datetime,
primary key (IdPago),
foreign key (IdTicket) references Ticket(IdTicket),
foreign key (IdPersona) references Persona(IdPersona)
)

create table Parametro 
(
IdParametro int identity(1,1),
TipoVehiculo varchar(20),
Tarifa decimal(19,2),
UnidadTiempo varchar(20),
primary key (IdParametro),
)