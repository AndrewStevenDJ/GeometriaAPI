using Microsoft.AspNetCore.Mvc;
using System; // Necesario para Math.PI y Math.Pow

namespace Geometria.Controllers // <<<<< ¡IMPORTANTE! Asegúrate de que este namespace coincida con el de tu proyecto Geometria >>>>>
{
    [ApiController] // Indica que esta clase es un controlador de API
    [Route("api/[controller]")] // Define la ruta base para este controlador (ej. /api/Areas)
    public class AreasController : ControllerBase
    {
        /// <summary>
        /// Calcula el área de un círculo.
        /// Ejemplo de uso: GET /api/Areas/circulo?radio=5
        /// </summary>
        /// <param name="radio">El radio del círculo.</param>
        /// <returns>El área del círculo.</returns>
        [HttpGet("circulo")] // Define un endpoint HTTP GET específico para "circulo"
        public IActionResult GetAreaCirculo([FromQuery] double radio)
        {
            if (radio < 0)
            {
                return BadRequest("El radio no puede ser negativo.");
            }

            double area = Math.PI * Math.Pow(radio, 2); // Fórmula: Pi * radio^2
            return Ok(new { Figura = "Circulo", Radio = radio, Area = area });
        }

        /// <summary>
        /// Calcula el área de un rectángulo.
        /// Ejemplo de uso: GET /api/Areas/rectangulo?baseRect=10&alturaRect=4
        /// </summary>
        /// <param name="baseRect">La base del rectángulo.</param>
        /// <param name="alturaRect">La altura del rectángulo.</param>
        /// <returns>El área del rectángulo.</returns>
        [HttpGet("rectangulo")] // Define un endpoint HTTP GET específico para "rectangulo"
        public IActionResult GetAreaRectangulo([FromQuery] double baseRect, [FromQuery] double alturaRect)
        {
            if (baseRect < 0 || alturaRect < 0)
            {
                return BadRequest("La base y la altura no pueden ser negativas.");
            }

            double area = baseRect * alturaRect; // Fórmula: base * altura
            return Ok(new { Figura = "Rectangulo", Base = baseRect, Altura = alturaRect, Area = area });
        }

        /// <summary>
        /// Calcula el área de un triángulo.
        /// Ejemplo de uso: GET /api/Areas/triangulo?baseTriangulo=8&alturaTriangulo=6
        /// </summary>
        /// <param name="baseTriangulo">La base del triángulo.</param>
        /// <param name="alturaTriangulo">La altura del triángulo.</param>
        /// <returns>El área del triángulo.</returns>
        [HttpGet("triangulo")] // Define un endpoint HTTP GET específico para "triangulo"
        public IActionResult GetAreaTriangulo([FromQuery] double baseTriangulo, [FromQuery] double alturaTriangulo)
        {
            if (baseTriangulo < 0 || alturaTriangulo < 0)
            {
                return BadRequest("La base y la altura no pueden ser negativas.");
            }

            double area = (baseTriangulo * alturaTriangulo) / 2; // Fórmula: (base * altura) / 2
            return Ok(new { Figura = "Triangulo", Base = baseTriangulo, Altura = alturaTriangulo, Area = area });
        }

        /// <summary>
        /// Calcula el área de un cuadrado.
        /// Ejemplo de uso: GET /api/Areas/cuadrado?lado=9
        /// </summary>
        /// <param name="lado">El lado del cuadrado.</param>
        /// <returns>El área del cuadrado.</returns>
        [HttpGet("cuadrado")] // Define un endpoint HTTP GET específico para "cuadrado"
        public IActionResult GetAreaCuadrado([FromQuery] double lado)
        {
            if (lado < 0)
            {
                return BadRequest("El lado no puede ser negativo.");
            }

            double area = lado * lado; // Fórmula: lado * lado
            return Ok(new { Figura = "Cuadrado", Lado = lado, Area = area });
        }
    }
}