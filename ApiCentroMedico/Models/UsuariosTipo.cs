﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCentroMedico.Models
{
    [Table("TIPOUSUARIOS")]
    public class UsuariosTipo
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TIPO")]
        public string Tipo { get; set; }
    }
}
