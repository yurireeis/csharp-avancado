namespace Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              alguns tipos não aceitam receber o famigerado null
              - é utilizado a classe Nullable
              - através de Generics é passado o tipo esperado da
              classe
              - isso ocorre por exemplo para trabalhar com valores
              opcionais que podem ser persistidos no banco
            */

            Nullable<uint> primeiroNumero = null;

            // também é possível setar um Nullable com uma interrogação
            uint? segundoNumero = null;

            // o código abaixo não funciona
            // int primeiroNumero = null;
        }
    }
}
