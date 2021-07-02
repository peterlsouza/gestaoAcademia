using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoAcademia.ViewModels
{
    public class AdministradorViewModel
    {
        [Required(ErrorMessage ="Campo Obrigatório!")]
        [EmailAddress(ErrorMessage ="Email Inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


    }
}
