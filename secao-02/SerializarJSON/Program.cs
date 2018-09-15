using System;
using Biblioteca;
using System.IO;
using System.Web.Extensions;

namespace SerializarJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario() {
                Nome = "Maria Angelica",
                CPF = "111.111.111-11",
                Email = "maria.angelica@reis.com"
            };

            /*
              serializando um objeto para string com o formato json
            */
            // JavaScriptSerializer (só para windows?)
            JavaScriptSerializer serializador = new JavaScriptSerializer();
            string usuarioSerializado = serializador.Serialize(usuario);

            using (StreamWriter writer = new StreamWriter("serialize.json"))
            {
                writer.WriteLine(usuarioSerializado);
                writer.Close();
                writer.Dispose();
            }

            /*
              deserializando um json string para um objeto
            */
            Usuario novoUsuario = new Usuario();

            using (StreamReader reader = new StreamReader("serialize.json"))
            {
                string linhasDoArquivo = reader.ReadToEnd();
                novoUsuario = (Usuario)serializador.Deserialize(linhasDoArquivo, typeof(Usuario));
            }

            Console.WriteLine($"Nome: {novoUsuario.Nome}, CPF: {novoUsuario.CPF}, Email: {novoUsuario.Email}");
        }
    }
}
