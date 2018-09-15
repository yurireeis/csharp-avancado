using Reflection.Modelo;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Reflection.Logs
{
    public class Log
    {
        public static List<Usuario> Usuarios = new List<Usuario>();
        public static List<Carro> Carros = new List<Carro>();
        public static List<object>Objetos = new List<object>(); 
        public static void GravarUsuario(Usuario usuario) => Usuarios.Add((Usuario)usuario.Clone());
        public static void GravarCarro(Carro carro) => Carros.Add((Carro)carro.Clone());
        public static void ApresentarLog() {
            Usuarios.ForEach(usuario => 
                Console.WriteLine($"Nome: {usuario.Nome}, E-mai: {usuario.Email}"
            ));
            Carros.ForEach(carro => 
                Console.WriteLine($"Marca: {carro.Marca}, Modelo: {carro.Modelo}"
            ));
        }

        // esse método irá utilizar os benefícios de uma Reflection
        public static void Gravar(object obj) => Objetos.Add(obj);
        public static void ApresentarLogComReflection() {
            Objetos.ForEach(obj => {
                Console.WriteLine($"Nome da Classe: {obj.GetType().Name}");
                // iterando nas propriedades do objeto
                foreach (var prop in obj.GetType().GetProperties())
                {
                    Console.WriteLine($"{prop.Name}: {prop.GetValue(obj)}");
                }
            });
        }
    }
}
