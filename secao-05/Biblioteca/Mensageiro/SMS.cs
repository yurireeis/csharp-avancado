using System;

namespace Biblioteca.Mensageiro
{
    public class SMS
    {
        public void EnviarMensagem(Video video) => Console.Write($"SMS enviado para o vídeo {video.Nome}");
    }
}
