using Opah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opah.WebApi.Models
{
    public class Cliente
    {
        //informações do cliente
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public String Cod_Empresa { get; set; }

        //informações do endereço        


        
    }
}
