using System;

namespace Biblioteca
{
    public class VideoEncode
    {
        // essa vai ser a classe responsável por gerenciar o Delegate
        public delegate void VideoEncodedHandler(Video video);
        public event VideoEncodedHandler Encoded;
        public void Encode(Video video) {
          Console.Write("Covertendo o vídeo...");
          Console.Write("Vídeo convertido!");
          Encoded(video);
        }
    }
}
