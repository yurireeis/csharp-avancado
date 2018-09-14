namespace Biblioteca
{
    public class Processador
    {
        public delegate void FiltroHandler(Foto foto);

        public static FiltroHandler Filtros;
        public static void Processar(Foto foto)
        {
            /*
              da mesma forma que utilizamos a propriedade filtro para
              atribuir um método, podemos utilizá-la para executar um
              método
            */
            Filtros(foto);
        }
    }
}
