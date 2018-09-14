using System;
using Biblioteca;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              serve para que você possa aumentar o poder de uma classe que, por exemplo,
              não seja de sua autoria
              - é uma forma também de se trabalhar com classes seladas
              - é um método que é escrito fora da classe, mas é visto como sendo de dentro
              da classe
              - para utilizar o Extension Methods é necessário que a Classe seja estática!
              - neste exemplo estamos utilizando o objeto passado (que é uma string) e
              criando um novo método para trabalhar com o mesmo.
            */
            Console.WriteLine(StringExtension.FirstToUpper("yuri"));
        }
    }
}
