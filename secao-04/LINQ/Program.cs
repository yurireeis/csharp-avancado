using System;
using System.Linq;
using System.Collections.Generic;
using Biblioteca;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              LINQ: dá um poder maior ao C# para manipular listas de dados
              - MS criou essa forma de manipular os dados para trabalhar
              com bancos SQL
              - estrutura do lambda: (entrada) => (expressao)
            */
            uint[] lista = { 3, 9, 14, 6, 60 ,20 };

            // realizando filtro, ordenação e seleção dos dados a serem apresentados
            Console.WriteLine("- Trabalhar os dados com o LINQ:");
            var listaFiltrada = lista.Where(a => a > 10).OrderBy(a => a).Select(a => a);
            foreach (uint item in listaFiltrada) { Console.WriteLine(item); }

            // outra forma de referenciar o LINQ (mais semelhante ao python por exemplo)
            Console.WriteLine("- Outra forma de trabalhar os dados com o LINQ:");
            var listaFiltrada2 = from item in lista where item > 10 orderby item select item;
            foreach (uint item in listaFiltrada2) { Console.WriteLine(item); }

            // LINQ com objetos
            Console.WriteLine("LINQ com objetos");
            Usuario[] usuarios = {
                new Usuario("yuri", "yuri@msn.com"),
                new Usuario("reis", "reis@msn.com"),
                new Usuario("silva", "silva@gmail.com")
            };

            Console.WriteLine($"Nome: {usuarios[0].Nome}");

            string servidorDeEmail = "msn.com".ToUpper();

            var listaUsuarioFiltrada = usuarios.Where(usuario => usuario.Email.EndsWith(servidorDeEmail)).OrderBy(usuario => usuario.Nome).Select(usuario => usuario);
            foreach (Usuario usuario in listaUsuarioFiltrada) { Console.WriteLine($"Nome: {usuario.Nome}, Email: {usuario.Email}"); }

            var listaUsuarioFiltrada2 = from usuario in usuarios where usuario.Email.EndsWith(servidorDeEmail) orderby usuario.Nome select usuario;
            // listaUsuarioFiltrada2.ForEach(usuario => Console.WriteLine($"Nome: {usuario.Nome}, Email: {usuario.Email}"));
            foreach (Usuario usuario in listaUsuarioFiltrada2) { Console.WriteLine($"Nome: {usuario.Nome}, Email: {usuario.Email}"); }

            // realizando join com o LINQ
            List<Autor> autores = new List<Autor>();
            autores.Add(new Autor() { Nome = "Russell Crowe", Id = 1 });
            autores.Add(new Autor() { Nome = "Daniel Craig", Id = 2 });
            autores.Add(new Autor() { Nome = "Roberto Bolãnos", Id = 3 });

            List<Livro> livros = new List<Livro>();
            livros.Add(new Livro() { Id = 1, AutorId = 2, Titulo = "Amor Amado" });
            livros.Add(new Livro() { Id = 2, AutorId = 2, Titulo = "Aguenta Coração" });
            livros.Add(new Livro() { Id = 3, AutorId = 3, Titulo = "Senhor do Tempo" });
            livros.Add(new Livro() { Id = 4, AutorId = 1, Titulo = "Fera Ferida" });

            // criando uma classe anônima com livro e autor
            var listaJoin = from livro in livros join autor in autores on livro.AutorId equals autor.Id orderby autor.Nome select new { livro, autor };

            foreach (var livroAutor in listaJoin)
            {
                Console.WriteLine($"Livro: {livroAutor.livro.Titulo} - Autor: {livroAutor.autor.Nome}");
            }

            // realizando o agrupamento (GROUP)
            // - pode-se utilizar o GROUP e o DISTINCT para essa atividade
            int[] listaDeNumeros = { 1, 1, 1, 1, 4, 4, 2, 3, 5, 6, 6, 10, 9, 8 };

            // o distinct já irá fazer a distinção dos valores que se repetem
            var listaFiltrada = listaDeNumeros.OrderBy(numero => numero).Distinct().Select(numero => numero);

            var listaFiltrada2 = listaDeNumeros.OrderBy(numero => numero).GroupBy(numero => numero).Select(numero => numero);
        }
    }
}
