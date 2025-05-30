using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> CreateAsync(Usuario usuarioModel);
        Task<Usuario?> UpdateAsync(int id, AtualizarUsuarioDto updateDto);
        Task<Usuario?> DeleteIdAsync(int id);
    }
}
