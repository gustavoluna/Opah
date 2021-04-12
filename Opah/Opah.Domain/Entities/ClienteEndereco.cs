using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Opah.Domain.Entities
{
    public class ClienteEndereco
    {
        [Key]
        public int IdClienteEndereco { get; set; }

        [ForeignKey("Clientes")]
        public int IdCliente { get; set; }

        [ForeignKey("Enderecos")]
        public int IdEndereco { get; set; }

        public Endereco Enderecos { get; set; }
        public Cliente Clientes { get; set; }

    }
}
