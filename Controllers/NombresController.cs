using Microsoft.AspNet.SignalR;
using signal_test.Models.dbContext;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace signal_test.Controllers
{
    public class BaseController : ApiController
    {
        // Instancia del servicio o repositorio que contiene el método Crear
        private readonly Models.CRUD _servicio;
        private readonly IHubContext _hubContext;
        // Constructor que recibe una instancia del servicio
        public BaseController()
        {
            _servicio = new Models.CRUD();
            _hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub1>();
        }

        // Método POST para crear un nuevo registro
        [HttpPost]
        [Route("api/Nombres/crear")]
        public IHttpActionResult Crea(test model)
        {
            if (model == null)
            {
                return BadRequest("El modelo no puede ser nulo.");
            }

            bool exito = _servicio.Crear(model);

            if (exito)
            {
                var nombres = _servicio.Todos<test>();
                _hubContext.Clients.All.NuevosNombres(nombres);
                return Ok("Registro creado exitosamente.");
            }
            else
            {
                return InternalServerError(new Exception("Error al crear el registro."));
            }
        }


        [HttpGet]
        [Route("api/Nombres/Todos")]
        public List<test> Todos()
        {
            return  _servicio.Todos<test>();
        }
    }
}
