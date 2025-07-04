﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api.Dtos
{
    public class CriarUsuarioDto
    {
        //public int id_usuario { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O username deve ter no mínimo 5 carcateres")]
        [MaxLength(15, ErrorMessage = "Limite de carcateres: 15")] 
        public string usuario { get; set; } = string.Empty;

        [Required]
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo 10 carcater es")]
        [MaxLength(50, ErrorMessage = "Limite de carcateres: 50")]
        public string nome { get; set; } = string.Empty;
        public int nivel_acesso { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "A senha deve ter no mínimo 8 carcateres")]
        [MaxLength(20, ErrorMessage = "Limite de carcateres: 20")]
        public string senha { get; set; } = string.Empty;

        [DefaultValue("https://fldoyzuifdwwxrtzinsb.supabase.co/storage/v1/object/sign/fotos-de-perfil/sem-foto.png?token=eyJraWQiOiJzdG9yYWdlLXVybC1zaWduaW5nLWtleV82MDEyZDE1Mi1lMDAwLTQ3NDUtYmQ3Zi1iOTI5OTZkMTlkMWYiLCJhbGciOiJIUzI1NiJ9.eyJ1cmwiOiJmb3Rvcy1kZS1wZXJmaWwvc2VtLWZvdG8ucG5nIiwiaWF0IjoxNzUxNjM2NjQyLCJleHAiOjE3ODMxNzI2NDJ9.7TuEkC9FKlqyJBGwrYKYZMobIDV-fm042xpb0JtLv8k")]
        [JsonPropertyName("foto_url")]
        public string? foto_url { get; set; }
    }
}
