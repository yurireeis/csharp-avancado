using System;

namespace Atributos
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                metadados: trabalham em relação a outra informação
                - dados voltados para explicar outros dados (?)
                - a classe mãe de todos os atributos de C# é a classe Attribute
                - funciona como uma espécie de Decorator
                - válido para classes, métodos...
                - para setar os atributos basta utilizar abrir e fechar colchetes
                dentro de uma classe (ver classe MeuAtributo), Chamar a classe 
                AttributeUsage e passar por parâmetros quais são os atributos 
                daquela classe
                - para setar os atributos, deve se chamar no parâmetro a classe
                AttributeTargets
                - para definir mais de um atributo nos parâmetros basta utilizar
                o pipe
            */

            // utilizando para Data Annotation
        }
    }
}
