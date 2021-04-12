using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opah.WebApi.Models
{
    public class Endereco
    {
        public Endereco()
        {
            this.Clientes = new HashSet<Cliente>();
        }

        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Tipo_Endereco { get; set; }
        //public Cidade Cidade { get; set; }


        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
