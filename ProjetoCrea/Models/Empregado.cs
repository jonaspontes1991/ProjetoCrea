using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoCrea.Models
{
    public class Empregado
    {
        [Key]
        public int empregadoId { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime dataEntrada { get; set; }
    }
}