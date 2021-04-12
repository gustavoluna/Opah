using System;
using System.Collections.Generic;
using System.Text;

namespace Opah.Application.DTOs
{
    public class ClienteRequest
    {        
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cod_Empresa { get; set; }
        public EnderecoRequest Endereco { get; set; }

        
    }
}
