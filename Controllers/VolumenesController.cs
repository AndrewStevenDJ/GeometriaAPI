
{
    [ApiController]
    [Route("api/[controller]")] // Esto mapeará el controlador a la ruta /api/Volumenes
    public class VolumenesController : ControllerBase
    {
        /// <summary>
        /// Calcula el volumen de una esfera.
        /// Ejemplo de uso: GET /api/Volumenes/esfera?radio=3
        /// </summary>
        /// <param name="radio">El radio de la esfera.</param>
        /// <returns>El volumen de la esfera.</returns>
        [HttpGet("esfera")]
        public IActionResult GetVolumenEsfera(double radio)
        {
            if (radio < 0)
            {
                return BadRequest("El radio no puede ser negativo.");
            }

            double volumen = (4.0 / 3.0) * Math.PI * Math.Pow(radio, 3); // Fórmula: (4/3) * Pi * radio^3
            return Ok(new { Figura = "Esfera", Radio = radio, Volumen = volumen });
        }

        /// <summary>
        /// Calcula el volumen de un cubo.
        /// Ejemplo de uso: GET /api/Volumenes/cubo?lado=5
        /// </summary>
        /// <param name="lado">El lado del cubo.</param>
        /// <returns>El volumen del cubo.</returns>
        [HttpGet("cubo")]
        public IActionResult GetVolumenCubo(double lado)
        {
            if (lado < 0)
            {
                return BadRequest("El lado no puede ser negativo.");
            }

            double volumen = Math.Pow(lado, 3); // Fórmula: lado^3
            return Ok(new { Figura = "Cubo", Lado = lado, Volumen = volumen });
        }
    }
}