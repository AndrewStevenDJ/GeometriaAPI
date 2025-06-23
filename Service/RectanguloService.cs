using GeometriaAPI.Data;
using GeometriaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace GeometriaAPI.Service
{
    public class RectanguloService
    {
        private readonly GeometriaContext _context;

        public RectanguloService(GeometriaContext context)
        {
            _context = context;
        }

        public IEnumerable<Rectangulo> GetAll() => _context.Rectangulos.ToList();

        public Rectangulo? GetById(int id) => _context.Rectangulos.Find(id);

        public Rectangulo Create(Rectangulo input)
        {
            input.Area = input.Largo * input.Ancho;
            input.Volumen = input.Area * 1; // Volumen = Área * altura (1)
            _context.Rectangulos.Add(input);
            _context.SaveChanges();
            return input;
        }

        public bool Update(int id, Rectangulo input)
        {
            var existente = _context.Rectangulos.Find(id);
            if (existente == null) return false;

            existente.Largo = input.Largo;
            existente.Ancho = input.Ancho;
            existente.Area = input.Largo * input.Ancho;
            existente.Volumen = existente.Area * 1; // Volumen = Área * altura (1)

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existente = _context.Rectangulos.Find(id);
            if (existente == null) return false;

            _context.Rectangulos.Remove(existente);
            _context.SaveChanges();
            return true;
        }
    }
}
