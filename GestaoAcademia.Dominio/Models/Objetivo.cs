﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoAcademia.Dominio.Models
{
    public class Objetivo
    {
        public int ObjetivoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(100, ErrorMessage = "Use menos caracteres")]
        [Remote("OBjetivoExiste", "Objetivos", AdditionalFields ="ObjetivoId")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(500, ErrorMessage = "Use menos caracteres")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public ICollection<Aluno> Alunos { get; set; }

    }
}
