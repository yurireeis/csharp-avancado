using System;

namespace Biblioteca
{
    public class Usuario
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
        
        private string _Nome;
        private string _Email;
        public string Nome { get => _Nome; set => _Nome = value.ToUpper(); }
        public string Email { get => _Email; set => _Email = value.ToUpper(); }
    }
}
