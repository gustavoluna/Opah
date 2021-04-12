using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Opah.Domain.Entities
{
    public class Cidade
    {
        [Key]
        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public String Estado { get; set; }
    }
}
