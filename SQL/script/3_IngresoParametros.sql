use BDParqueo
go 

delete from Parametro
insert into Parametro (TipoVehiculo,Tarifa,UnidadTiempo) values ('Moto', 0.25, 'Hora')
insert into Parametro (TipoVehiculo,Tarifa,UnidadTiempo) values ('Auto', 0.50, 'Hora')

select * from Parametro