using System;
using System.IO;
using System.Xml.Serialization;

namespace Biblioteca
{
    public class Serializador
    {

        public static void Serializar(object obj) {
          using(StreamWriter writer = new StreamWriter($"{obj.GetType()}.xml"))
          {
              XmlSerializer serializador = new XmlSerializer(obj.GetType());
              serializador.Serialize(writer, obj);
              writer.Close();
              writer.Dispose();
          }
        }

        /*
          criando um método com Generics
          - quando um método é assinado como Generics, ele deverá receber 
          na mesma sintaxe do Generics a classe ao qual o método está
          utilizando (ver no program.cs os exemplos)
        */
        public static T Deserializar<T>() {
          using(StreamReader reader = new StreamReader($"{typeof(T)}.xml"))
          {
              XmlSerializer serializador = new XmlSerializer(typeof(T));
              T obj = (T)serializador.Deserialize(reader);
              reader.Close();
              reader.Dispose();
              return obj;
          }
        }
    }
}
