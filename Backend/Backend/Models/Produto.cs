using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
