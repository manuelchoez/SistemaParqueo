use BDParqueo
go 

if  exists(select top 1 1 from sys.objects where name = 'vehiculo')
begin 
	drop table vehiculo
end 


if  exists(select top 1 1 from sys.objects where name = 'vehiculo')
begin 
	drop table vehiculo
end 


create table Vehiculo
(
IdVehiculo int identity(1,1),
Placa varchar(20),
Marca varchar(200),
Modelo varchar(100),
primary key (IdVehiculo)
)

