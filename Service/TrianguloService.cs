using GeometriaAPI.Data;
using GeometriaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace GeometriaAPI.Service
{
    public class TrianguloService
    {
        private readonly GeometriaContext _context;

        public TrianguloService(GeometriaContext context)
        {
            _context = context;
        }

        public IEnumerable<Triangulo> GetAll() => _context.Triangulos.ToList();

        public Triangulo? GetById(int id) => _context.Triangulos.Find(id);

        public Triangulo Create(Triangulo input)
        {
            input.Area = (input.Base * input.Altura) / 2;
            input.Volumen = input.Area * 1; // Volumen = Área * profundidad (1)
            _context.Triangulos.Add(input);
            _context.SaveChanges();
            return input;
        }

        public bool Update(int id, Triangulo input)
        {
            var existente = _context.Triangulos.Find(id);
            if (existente == null) return false;

            existente.Base = input.Base;
            existente.Altura = input.Altura;
            existente.Area = (input.Base * input.Altura) / 2;
            existente.Volumen = existente.Area * 1; // Volumen = Área * profundidad (1)

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existente = _context.Triangulos.Find(id);
            if (existente == null) return false;

            _context.Triangulos.Remove(existente);
            _context.SaveChanges();
            return true;
        }
    }
}
