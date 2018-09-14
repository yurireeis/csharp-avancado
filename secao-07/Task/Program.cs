using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              Tasks: uma espécie de evolução das Threads
              - classes acrescentadas ao .NET (System.Threading.Tasks)
              - melhoras em pontos específicos como : download de arquivos na internet,
              salvamento de arquivos no HD, etc.
              - usada a palavra chave async
              - todos os métodos que utilizam Tasks devem possuir na declaração a palavra
              async
            */

            Task.Run(() => Contador());
            // Task.Run(() => Contador());
            // Task.Run(() => BaixarHtml("https://www.google.com.br"));
            // Task.Factory.StartNew(Contador);

            // múltiplas tasks
            // criando uma lista de tarefas
            List<Task> tarefas = new List<Task>();
            tarefas.Add(Task.Factory.StartNew(Contador));
            tarefas.Add(Task.Factory.StartNew(Contador));
            tarefas.Add(Task.Factory.StartNew(Contador));

            // all: espera todas, any: prossegue quando a primeira das tarefas finalizar
            Task.WaitAll(tarefas.ToArray());

            // baixando várias páginas da internet
            WebClient web = new WebClient();
            string[] enderecos = new string[] {
                "https://www.google.com",
                "https://www.microsoft.com"
            };

            // criando uma lista de conteúdo html
            var htmldasPaginas = from endereco in enderecos select DownloadPagina(endereco);

            Task.WaitAll(htmldasPaginas.ToArray());

        }

        private async static void BaixarHtml(string endereco)
        {
            WebClient web = new WebClient(); // instancia de um browser

            /*
              só será possíve utilizar um método com o parâmetro await caso ele esteja em
              uma função async
            */ 
            string html = await web.DownloadStringTaskAsync(new Uri(endereco));
            Console.WriteLine(html);
        }

        private static void Contador()
        {
            for (int i = 0; i < 1000; i++) { Console.WriteLine($"Valor: {i}, Task: {Task.CurrentId}"); }
        }

        private static async Task DownloadPagina(string endereco)
        {
            WebClient web = new WebClient();
            string html = await web.DownloadStringTaskAsync(endereco);
            Console.WriteLine($"Download realizado para a página: {html}");
        }
    }
}
