using System;

namespace Biblioteca.Mensageiro
{
    public class Email
    {
        public void EnviarMensagem(Video video) => Console.Write($"Email enviado para o vídeo {video.Nome}");
    }
}
