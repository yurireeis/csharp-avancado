using System;
// using System.ComponentModel.DataAnnotation;

namespace Biblioteca
{
    public class Pessoa
    {
        [Required]
        public string Nome { get; set; }
        [Required, EmailAdress]
        public string Email { get; set; }
        [Required, StringLength]
        public string Senha { get; set; }
    }
}
