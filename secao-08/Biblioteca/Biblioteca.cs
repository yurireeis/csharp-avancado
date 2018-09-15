using System;

namespace Biblioteca
{
    [
        AttributeUsage(
            AttributeTargets.Class |
            AttributeTargets.Field |
            AttributeTargets.Property
        )
    ]
    public class MeuAtributo : Attribute
    {
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public MeuAtributo(string nome) => Nome = nome;
    }
}
