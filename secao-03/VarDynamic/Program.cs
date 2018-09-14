using System;
using Biblioteca;

namespace VarDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              var tem um contexto diferente do object
              - o var realiza o casting ao receber um determinado valor
              - o object é um tipo mais primitivo do que o var
              - quando instancia o var, é obrigatório setar o valor da mesma
            */
            object o1 = "";
            o1 = 213;

            /*
              - o object é mais flexível pois pode receber qualquer valor,
              ao contrário do var que se, por exemplo, receber um Int32
              em um primeiro momento, caso você tente passar uma string
              para a variável, simplesmente não conseguirá
            */

            var v1 = "";
            // v1 = 23123; não será possível realizar esta operação

            /*
              o tipo dynamic trabalha no tempo de execução
              caso este não esteja coeso com o tipo esperado, irá gerar
              uma runtime exception
            */
            dynamic d1 = 1;

            dynamic teste = new Carro();
            teste.Marca = "FIAT";

            // normalmente o código abaixo geraria uma exception em build
            // por não tem uma string no modelo
            Console.WriteLine($"Modelo: {teste.Modelo.ToUpper()}");
        }
    }
}
