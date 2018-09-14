using System;

namespace Biblioteca
{
    public class Filtro
    {
        public void Colorir(Foto foto) => Console.WriteLine($"Filtro > Colorir > {foto.Nome}");
        public void GerarThumb(Foto foto) => Console.WriteLine($"Filtro > GerarThumb > {foto.Nome}");
        public void PretoEBranco(Foto foto) => Console.WriteLine($"Filtro > PretoEBranco > {foto.Nome}");
        public void Redimensionar(Foto foto) => Console.WriteLine($"Filtro > Redimensionar > {foto.Nome}");
    }
}
