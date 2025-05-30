using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class UsuarioDto
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; } = string.Empty; 
        public string nome { get; set; } = string.Empty;
        public int nivel_acesso { get; set; }

        //public string senha { get; set; } = string.Empty;

    } 
}
