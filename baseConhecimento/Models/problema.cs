using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baseConhecimento.Models
{
    public class problema
    {
        [HiddenInput(DisplayValue = true)]
        public int id_itens { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public int ranking { get; set; }
        public string imagem { get; set; }
        public int id_ic { get; set; }
    }
}