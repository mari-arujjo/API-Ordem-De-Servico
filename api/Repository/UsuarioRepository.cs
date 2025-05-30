using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly ApplicationDBContext _dbContext;
        public UsuarioRepository(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        
        public async Task<Usuario> CreateAsync(Usuario userModel)
        {
            await _dbContext.USERS.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        
        public async Task<Usuario?> DeleteIdAsync(int id)
        {
            var userModel = await _dbContext.USERS.FirstOrDefaultAsync(x => x.id_usuario == id);
            // para cada usuario x da tabela, verifique se o x.id_usuario é igual ao id informado

            if (userModel == null)
            {
                return null;
            }
            _dbContext.USERS.Remove(userModel);
            _dbContext.SaveChanges();
            return userModel;
        }
        

        public async Task<List<Usuario>> GetAllAsync()
        {
            // ToList -> executa a consulta no banco de dados e transforma o resultado em uma lista na memória, como uma List<User>.
            return await _dbContext.USERS.ToListAsync(); // carrega os usuarios do banco para uma lista
        }


        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _dbContext.USERS.FindAsync(id);
        }


        public async Task<Usuario?> UpdateAsync(int id, AtualizarUsuarioDto updateDto)
        {
            var userModel = await _dbContext.USERS.FirstOrDefaultAsync(x => x.id_usuario == id);
            if (userModel == null)
            {
                return null;
            }
            // pega oq temos no BD e atualiza com os valores fornecidos pelo cliente do sistema
            userModel.usuario = updateDto.usuario;
            userModel.nome = updateDto.nome;
            userModel.nivel_acesso = updateDto.nivel_acesso;
            userModel.senha = updateDto.senha;
            await _dbContext.SaveChangesAsync();
            return userModel;
        }
    }
}
