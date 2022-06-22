using Microsoft.EntityFrameworkCore;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using Rest.MicroServicioParqueo.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Infraestructure.Data
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly BDParqueoContext _contexto;
        public VehiculoRepository(BDParqueoContext contexto)
        {
            _contexto= contexto;
        }
        public async Task<Vehiculo> ActualizarVehiculo(Vehiculo vehiculo)
        {
            _contexto.Entry(vehiculo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return vehiculo;
        }

        public async Task<Vehiculo> ConsutarVehiculo(int IdVehiculo)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo = await _contexto.Vehiculos.FindAsync(IdVehiculo);
            return vehiculo;
        }

        public async Task<IEnumerable<Vehiculo>> ConsutarVehiculos()
        {
            IEnumerable<Vehiculo> vehiculos = null;
            vehiculos = await _contexto.Vehiculos.ToListAsync();
            return vehiculos;
        }

        public async Task<Vehiculo> CrearVehiculo(Vehiculo vehiculo)
        {
            _contexto.Vehiculos.Add(vehiculo);
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return vehiculo;
        }

        public async Task<bool> EliminarVehiculo(int IdVehiculo)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo = await _contexto.Vehiculos.FindAsync(IdVehiculo);
            _contexto.Vehiculos.Remove(vehiculo);
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return true;
        }
    }
}
