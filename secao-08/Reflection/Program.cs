using System;
using Reflection.Modelo;
using Reflection.Logs;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Reflection é utilizada por exemplo na classe JavaScriptSerializer, pois
                ela faz a leitura dos campos do objeto para transformá-lo em Json
                - 
            */



            // criando uma forma de "log" com Reflections
            // consistirá em guardar o dado antigo em caso de alteração
            Usuario usuario = new Usuario() {
                Nome = "Jose",
                Email = "jose@jose.com",
                Senha = "1234"
            };
            Carro carro = new Carro() {
                Marca = "FIAT",
                Modelo = "Uno"
            };
            Log.GravarUsuario(usuario);
            usuario.Nome = "Costa";
            Log.GravarUsuario(usuario);
            Log.ApresentarLog();
            Console.WriteLine("Log gravado!");

            // o reflection irá permitir com que armazenemos um objeto e que
            // e que possamos identificar os seus atributos sem maiores problemas!
            Log.Gravar(usuario);
            Log.Gravar(carro);
            Log.ApresentarLogComReflection();
        }
    }
}
