using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosAPI.Models
{
    public class Livro
    {
        public int ID { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
    }
}
