﻿using Rest.MicroServicioParqueo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Dominio.Repository
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> ConsutarVehiculos();
        Task<Vehiculo> ConsutarVehiculo(int IdVehiculo);
        Task<Vehiculo> CrearVehiculo(Vehiculo vehiculo);
        Task<Vehiculo> ActualizarVehiculo(Vehiculo vehiculo);
        Task<bool> EliminarVehiculo(int IdVehiculo);
    }
}
