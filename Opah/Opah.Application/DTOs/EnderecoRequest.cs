using System;
using System.Collections.Generic;
using System.Text;

namespace Opah.Application.DTOs
{
    public class EnderecoRequest
    {        
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Tipo_Endereco { get; set; }
        public int IdCidade { get; set; }
    }
}
