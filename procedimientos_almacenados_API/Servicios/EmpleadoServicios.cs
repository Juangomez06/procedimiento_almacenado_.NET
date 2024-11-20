using procedimientos_almacenados_API.Models;
using Microsoft.EntityFrameworkCore;

namespace procedimientos_almacenados_API.Servicios
{
    public class EmpleadoServicios : IEmpleadoServicios
    {
        PruebaContext context;

        public EmpleadoServicios(PruebaContext dbcontext)
        {
            context = dbcontext;
        }

        //PROCEDIMIENTO ALMACENADO 
        public IEnumerable<UsuarioEmpleadoDto> GetProAlmacenado()
        {
            var resultado = context.Set<UsuarioEmpleadoDto>()
                .FromSqlRaw("EXEC ObtenerUsuariosEmpleados")
                .ToList();
            return resultado;
        }

    }
    public interface IEmpleadoServicios
    {
        IEnumerable<UsuarioEmpleadoDto> GetProAlmacenado();

    }
}
