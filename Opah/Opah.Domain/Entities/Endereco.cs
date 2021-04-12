using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Opah.Domain.Entities
{
    public class Endereco
    {

        
        [Key]
        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Tipo_Endereco { get; set; }
        
        [ForeignKey("Cidades")]
        public int IdCidade { get; set; }

        
        

        public virtual ICollection<ClienteEndereco> ClienteEnderecos { get; set; }

    }
}
