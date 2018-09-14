using System;
using Biblioteca;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              Delegate - espécie de ponteiro
              - uma maneira de chamar um método de uma maneira mais simples
              - permite uma abstração de código
              - a principal vantagem do Delegate é executar os médotos sem a
              necessidade de conhecê-los
            */

            // calc na verdade é um ponteiro para a função de Somar
            Calcula calc = new Calcula(Somar);

            // aplicação prática do Delegate
            Foto foto = new Foto() { Nome = "perfil.jpg", TamanhoX = 1920, TamanhoY = 1080 };
            Foto foto2 = new Foto() { Nome = "image.jpg", TamanhoX = 1920, TamanhoY = 1080 };

            /*
              Exemplo: Thumb
              nesta linha eu estou definindo qual é o método que estará vinculado
              ao meu delegate
              - como podemos ver, mesmo GerarThumb sendo um método não-estático, 
              ele poderá ser invocado para popular o FiltroHandler, pois o FiltroHandler
              é uma propriedade do tipo delegate
            */
            Processador.Filtros = new Filtro().GerarThumb;
            Processador.Processar(foto);

            /*
              Exemplo: Colorir + Médio
              caso seja dado um novo new, irá substituir o ponteiro com o método populado
              na propriedade do tipo Delegate
              - para popular a propriedade com dois métodos, basta concatenar
            */
            Processador.Filtros = new Filtro().Colorir;
            Processador.Filtros += new Filtro().Redimensionar;
            Processador.Processar(foto2);

            // também é possível utilizar o delegate com funções anônimas
            Processador.Filtros = delegate { Console.WriteLine($"Fitro > Sepia > {foto.Nome}"); };
            Processador.Processar(foto);
        }

        // criando uma função delegate
        // delegate precisa ter o mesmo número de parâmetros da função original
        delegate int Calcula(int a, int b);

        static int Somar(int a, int b) => a + b;
        static int Subtrair(int a, int b) => a - b;
    }
}
