﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCentroMedico.Models
{
    [Table("ESTADOUSUARIO")]
    public class Estados
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ESTADO")]
        public string Estado { get; set;}
    }
}
