﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Usuario.Model
{
    public class UsuarioModel
    {
        [Key]
        public int id_usuario { get; set; }
        public string usuario { get; set; } = string.Empty; //a string é vazia, e não nula
        public string nome { get; set; } = string.Empty;
        public int nivel_acesso { get; set; }
        public string senha { get; set; } = string.Empty;
        public byte[]? foto { get; set; } = Array.Empty<byte>();


    }
}
