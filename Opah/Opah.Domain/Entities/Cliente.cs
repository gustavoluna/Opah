using Opah.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Opah.Domain.Entities
{
    public class Cliente
    {

        


        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public String Cod_Empresa { get; set; }


        public virtual ICollection<ClienteEndereco> ClienteEnderecos { get; set; }

    }
}
