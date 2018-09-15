using System;

namespace Reflection.Modelo
{
    public class Carro : ICloneable
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public object Clone() => new Carro() { Marca = this.Marca, Modelo = this.Modelo };
    }
}
