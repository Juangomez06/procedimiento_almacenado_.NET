using Microsoft.AspNetCore.Mvc;
using procedimientos_almacenados_API.Models;
using procedimientos_almacenados_API.Servicios;


namespace procedimientos_almacenados_API.Controllers
{
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase 
    {

        IEmpleadoServicios empleadoServicio;
        private readonly ILogger<EmpleadosController> logger;

        public EmpleadosController(IEmpleadoServicios servicio, ILogger<EmpleadosController> logger)
        {
            empleadoServicio = servicio;
            this.logger = logger;
        }

        //PROCEDIMIENTO ALMACENADO 
        [HttpGet("almacenado")]
        public ActionResult GetProAlmacenados()
        {
            try
            {
                var empleados = empleadoServicio.GetProAlmacenado();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ejecutando el procedimiento almacenado: {ex.Message}");
            }
        }
    }
}
