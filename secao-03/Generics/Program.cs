using System;
using Biblioteca;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              permitir que classes e métodos possam receber outras classes
              - criada uma classe serializadora com métodos estáticos para
              facilitar o processo de serialização
              - sintaxe do Gererics: <T>
              - <T> representa um tipo genérico
            */
            Carro carro = new Carro() { Marca = "Fiat", Modelo = "UNO" };
            Casa casa = new Casa() { Cidade = "Brasilia", Endereco = "SQS 214" };
            Usuario usuario = new Usuario() { Nome = "Maria", Email = "maria@reis.com", Senha = "1234" };

            // serializando os objetos
            Serializador.Serializar(carro);
            Serializador.Serializar(casa);
            Serializador.Serializar(usuario);

            /*
              exemplos de instância de um método com generics abaixo
            */
            Carro carro2 = Serializador.Deserializar<Carro>();
            Casa casa2 = Serializador.Deserializar<Casa>();
            Usuario usuario2 = Serializador.Deserializar<Usuario>();

            Console.WriteLine($"Carro = Marca: {carro2.Marca}, Modelo: {carro2.Modelo}");
            Console.WriteLine($"Casa = Cidade: {casa2.Cidade}, Endereço: {casa2.Endereco}");
            Console.WriteLine($"Usuario = Nome: {usuario2.Nome}, Email: {usuario2.Email}");
        }
    }
}
