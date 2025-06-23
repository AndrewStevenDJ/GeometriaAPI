using GeometriaAPI.Data;
using GeometriaAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace GeometriaAPI.Service
{
    public class CuadradoService
    {
        private readonly GeometriaContext _context;

        public CuadradoService(GeometriaContext context)
        {
            _context = context;
        }

        public IEnumerable<Cuadrado> GetAll() => _context.Cuadrados.ToList();

        public Cuadrado? GetById(int id) => _context.Cuadrados.Find(id);

        public Cuadrado Create(Cuadrado input)
        {
            input.Area = input.Lado * input.Lado;
            input.Volumen = input.Lado * input.Lado * input.Lado; // Volumen = lado³
            _context.Cuadrados.Add(input);
            _context.SaveChanges();
            return input;
        }

        public bool Update(int id, Cuadrado input)
        {
            var existente = _context.Cuadrados.Find(id);
            if (existente == null) return false;

            existente.Lado = input.Lado;
            existente.Area = input.Lado * input.Lado;
            existente.Volumen = input.Lado * input.Lado * input.Lado; // Volumen = lado³

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existente = _context.Cuadrados.Find(id);
            if (existente == null) return false;

            _context.Cuadrados.Remove(existente);
            _context.SaveChanges();
            return true;
        }
    }
}
