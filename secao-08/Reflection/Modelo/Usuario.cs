using System;

namespace Reflection.Modelo
{
    public class Usuario : ICloneable
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public object Clone() => new Usuario() {
            Nome = this.Nome,
            Email = this.Email,
            Senha = this.Senha
        };
    }
}
