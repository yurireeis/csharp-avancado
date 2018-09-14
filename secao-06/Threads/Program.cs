using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static int Rede = 0;
        static object VariavelDeControle = 0;
        static ManualResetEvent Manual01;
        static AutoResetEvent Manual02;
        static void Main(string[] args)
        {
            /*
              a classe Threading é a responsável por criar o fluxo que
              será executado em paralelo 
            */

            // toda thread instanciada deve receber uma função/método quando instanciado
            Thread t1 = new Thread(ThreadRepeticao);
            t1.Start();

            // vou executar na Thread principal um outro laço for
            ThreadRepeticao("Main");

            // criando novas Threads em um loop
            // aqui será utilizado 4 threads
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(ThreadRepeticao);
                thread.Start();
            }

            // Threads em Background
            // essa thread irá executar até que o programa seja encerrado
            // interessante para atividades de CRON (caso o app fique aberto)
            Thread t2 = new Thread(ThreadRepeticao);
            t2.IsBackground = true;
            t2.Start();

            // utilizando Threads com Recursos Compartilhados (Thread Safe)
            // para tal, utilizamos a palavra reservada lock
            // lock é uma variável de controle (similar ao famigerado "i"),
            // porém seu objetivo é verificar se um recurso dentro de um 
            // contexto está sendo utilizado
            // a variável de controle é do tipo object e NÃO pode ser nula
            // Thread t3 = new Thread(ThreadRepeticaoComLock);
            // t3.Start();

            // identificando uma Thread
            // setar um parâmetro do tipo object para a função repassada
            // no start da Thread, passar este parâmetro
            for (int i = 0; i < 5; i++)
            {
                Thread threadComID = new Thread(ThreadRepeticaoComID);
                threadComID.Start(i);
            }

            // outro exemplo passando o ID interno da Thread
            for (int i = 0; i < 5; i++)
            {
                Thread threadComID = new Thread(ThreadRepeticaoComIDInterno);
                threadComID.Start();
            }

            // Thread.Sleep já conhecemos
            // Thread.Join (importantíssimo!)
            /*
              o join faz com que, para darmos segmento com a execução da aplicação
              seja necessária a finalização das Threads determinadas!
            */
            Console.WriteLine("Inicio da execucação das Threads com Join");
            for (int i = 0; i < 5; i++)
            {
                Thread threadComJoin = new Thread(ThreadRepeticaoComJoin);
                threadComJoin.Start();
                threadComJoin.Join();
            }
            Console.Write("Fim da execucação das Threads com Join. Pressione qualquer tecla pra continuar: ");
            // Console.ReadKey();

            /*
              O manual reset e o auto reset são semáforos
              - propriedades ManualResetEvent e AutoResetEvent devem ser inicializadas
              - se for setado false significa que está vermelho
              - esse recurso é utilizado para informar que uma Thread pode ser dependente de outra
              - a diferença entre o ManualResetEvent e o AutoReset event é que, para reiniciar o status
              do Manual é necessário chamar o método Reset(). No Auto, a partir do momento que ele recebe o Set()
              ele já irá permitir com que você possa setar o WaitOne sem a necessidade de Reset.
            */

            // falso representa o sinal vermelho (está pausado)
            Manual01 = new ManualResetEvent(false);

            // AutoResetEvent
            Thread autoResetEventThread = new Thread(Executa01);
            autoResetEventThread.Start();

            // ManualResetEvent
            Thread manualResetEventThread = new Thread(Executa02);
            autoResetEventThread.Start();
        }

        private static void ThreadRepeticao()
        {
            for (int i = 0; i < 100; i++) { Console.WriteLine($"Thread: {i}"); }
        }

        private static void ThreadRepeticao(string tipo)
        {
            for (int i = 0; i < 100; i++) { Console.WriteLine($"{tipo}: {i}"); }
        }

        private static void ThreadRepeticaoComLock()
        {
            for (int i = 0; i < 100; i++) { lock (VariavelDeControle) { Console.WriteLine($"Thread com Lock: {i}"); } }
        }

        private static void ThreadRepeticaoComID(object id)
        {
            for (int i = 0; i < 100; i++) { Console.WriteLine($"Thread ID {id}: {i}"); }
        }

        private static void ThreadRepeticaoComIDInterno()
        {
            // essa irá apresentar o ID interno
            for (int i = 0; i < 100; i++) { Console.WriteLine($"Thread ID Interno {Thread.CurrentThread.ManagedThreadId}: {i}"); }
        }

        private static void ThreadRepeticaoComJoin()
        {
            // essa irá apresentar o ID interno
            for (int i = 0; i < 100; i++) { Console.WriteLine($"Thread ID Interno {Thread.CurrentThread.ManagedThreadId} com Join: {i}"); }
        }

        private static void Executa01()
        {
            Console.WriteLine("01 - Iniciado Executa 01.");
            Manual01.WaitOne(); // esperando que ele esteja liberado
            Console.WriteLine("02 - Em execução 01 Executa 01.");
            Console.WriteLine("03 - Em execução 02 Executa 01.");
            Console.WriteLine("04 - Finalizado Executa 01.");
        }

        private static void Executa02()
        {
            Console.WriteLine("01 - Iniciado Executa 02.");
            Console.WriteLine("02 - Em execução 01 Executa 02.");
            Console.WriteLine("03 - Em execução 02 Executa 02.");
            Console.WriteLine("04 - Finalizado Executa 02.");
            Manual01.Set(); // liberando a Thread 01
            Manual01.Reset(); // reseta o status permitindo que ele receba um novo WaitOne por exemplo
        }
    }
}
