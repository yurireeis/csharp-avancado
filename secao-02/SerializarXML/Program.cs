using System;
using System.IO;
using System.Xml.Serialization;
using Biblioteca;

namespace SerializarXML
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              serializar: processo de pegar uma string e transformar em um objeto trabalhável
              deserializar: pegar um objeto e transformar em uma string
            */
            Usuario usuario = new Usuario() {
                Nome = "Yuri",
                CPF = "000.000.000-00",
                Email = "yuri@reis.com"
            };

            /*
              abaixo o objeto responsável por serializar um objeto para texto xml
              - existem duas formas de passar o tipo do objeto ao qual se vai trabalhar:
                1) com a palavra reservada typeof
                2) chamando o GetType do próprio objeto (método da classe object)
            */
            // XmlSerializer serializador = new XmlSerializer(typeof(usuario));
            XmlSerializer serializador = new XmlSerializer(usuario.GetType());

            using(StreamWriter writer = new StreamWriter("serializar.xml")) {
                serializador.Serialize(writer, usuario);
                writer.Close();
                writer.Dispose();
            }

            /*
              para deserializar não é necessário ter a classe que recebe a deserialização. Porém,
              é importante ter um objeto conciso para receber a deserialização.
              - na deserialização geralmente se utiliza o typeof pois não há um objeto instanciado.
            */
            serializador = new XmlSerializer(typeof(Usuario));

            Usuario usuarioDeserializado = new Usuario();
            
            using(StreamReader reader = new StreamReader("serializar.xml")) {
                usuarioDeserializado = (Usuario)serializador.Deserialize(reader);
                reader.Close();
                reader.Dispose();
            }

            Console.WriteLine($"Nome: {usuarioDeserializado.Nome}, CPF: {usuarioDeserializado.CPF}");
        }
    }
}
