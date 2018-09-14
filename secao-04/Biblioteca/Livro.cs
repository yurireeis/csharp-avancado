using System;

namespace Biblioteca
{
    public class Livro
    {
        public uint Id { get; set; }
        public uint AutorId { get; set; }
        public string Titulo { get; set; }
        public DateTime DataDePublicacao { get; set; }
    }
}
