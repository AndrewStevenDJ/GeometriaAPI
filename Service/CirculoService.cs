using GeometriaAPI.Data;
using GeometriaAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GeometriaAPI.Service
{
    public class CirculoService
    {
        private readonly GeometriaContext _context;

        public CirculoService(GeometriaContext context)
        {
            _context = context;
        }

        public IEnumerable<Circulo> GetAll() => _context.Circulos.ToList();

        public Circulo? GetById(int id) => _context.Circulos.Find(id);

        public Circulo Create(Circulo input)
        {
            input.Area = Math.PI * Math.Pow(input.Radio, 2);
            input.Volumen = (4.0 / 3.0) * Math.PI * Math.Pow(input.Radio, 3);
            _context.Circulos.Add(input);
            _context.SaveChanges();
            return input;
        }

        public bool Update(int id, Circulo input)
        {
            var existente = _context.Circulos.Find(id);
            if (existente == null) return false;

            existente.Radio = input.Radio;
            existente.Area = Math.PI * Math.Pow(input.Radio, 2);
            existente.Volumen = (4.0 / 3.0) * Math.PI * Math.Pow(input.Radio, 3);

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existente = _context.Circulos.Find(id);
            if (existente == null) return false;

            _context.Circulos.Remove(existente);
            _context.SaveChanges();
            return true;
        }
    }
}
