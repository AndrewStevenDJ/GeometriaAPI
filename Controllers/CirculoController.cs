using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GeometriaAPI.Models;
using GeometriaAPI.Service;

namespace GeometriaAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CirculoController : ControllerBase
    {
        private readonly CirculoService _service;
        public CirculoController(CirculoService service) => _service = service;

        [HttpGet] public IActionResult Get() => Ok(_service.GetAll());
        [HttpGet("{id}")] public IActionResult Get(int id)
            => _service.GetById(id) is Circulo c ? Ok(c) : NotFound();
        [HttpPost] public IActionResult Post(Circulo c) => Ok(_service.Create(c));
        [HttpPut("{id}")] public IActionResult Put(int id, Circulo c)
            => _service.Update(id, c) ? Ok() : NotFound();
        [HttpDelete("{id}")] public IActionResult Delete(int id)
            => _service.Delete(id) ? Ok() : NotFound();
    }
}
