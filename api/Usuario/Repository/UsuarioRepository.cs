﻿using api.Controllers;
using api.Usuario.Dtos;
using api.Usuario.Helper;
using api.Usuario.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Usuario.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly ApplicationDBContext _dbContext;
        public UsuarioRepository(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        
        public async Task<UsuarioModel> CreateAsync(UsuarioModel userModel)
        {
            userModel.senha = HashSenhaController.GerarHash(userModel.senha);
            await _dbContext.USERS.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        
        public async Task<UsuarioModel?> DeleteIdAsync(int id)
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
        

        public async Task<List<UsuarioModel>> ObterTodosAsync(UsuarioQueryObject query)
        {
            var user = _dbContext.USERS.AsQueryable();
            // AsQueyable -> execução adiada: a consulta só será enviada ao banco quando chamar o ToListAsync();

            if (!string.IsNullOrEmpty(query.usuario))
            {
                user = user.Where(u => u.usuario.Contains(query.usuario));
            }

            if (!string.IsNullOrEmpty(query.nome))
            {
                user = user.Where(u => u.nome.Contains(query.nome));
            }

            if (query.nivel_acesso.HasValue) 
            {
                user = user.Where(u => u.nivel_acesso == query.nivel_acesso.Value);
            }

            if (!string.IsNullOrWhiteSpace(query.ordenar))
            {
                if (query.ordenar.Equals("nome"))
                {
                    if (query.DESC)
                    {
                        user = user.OrderByDescending(u => u.nome);
                    }
                    else
                    {
                        user = user.OrderBy(u => u.nome);
                    }
                }

                if (query.ordenar.Equals("usuario"))
                {
                    if (query.DESC)
                    {
                        user = user.OrderByDescending(u => u.usuario);
                    }
                    else
                    {
                        user = user.OrderBy(u => u.usuario);
                    }
                }

                if (query.ordenar.Equals("nivel_acesso"))
                {
                    if (query.DESC)
                    {
                        user = user.OrderByDescending(u => u.nivel_acesso);
                    }
                    else
                    {
                        user = user.OrderBy(u => u.nivel_acesso);
                    }
                }
            }

            // calcula quantos itens devem ser pulados antes de começar a listar os resultados
            //var skipNumber = (query.num_pag -1) * query.tam_pag;
            // itens a pular = (pagina atual - 1) * tamanho da pag
            //return await user.Skip(skipNumber).Take(query.tam_pag).ToListAsync();

            return await user.ToListAsync();
        }


        public async Task<UsuarioModel?> ObterPorIdAsync(int id)
        {
            return await _dbContext.USERS.FindAsync(id);
        }


        public async Task<UsuarioModel?> UpdateAsync(int id, AtualizarUsuarioDto updateDto)
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
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        public async Task<UsuarioModel?> UpdateSenha(int id, AtualizarSenhaDto updateDto)
        {
            var userModel = await _dbContext.USERS.FirstOrDefaultAsync(x => x.id_usuario == id);
            if (userModel == null)
            {
                return null;
            }
            // pega oq temos no BD e atualiza com os valores fornecidos pelo cliente do sistema
            userModel.senha = updateDto.senha;
            userModel.senha = HashSenhaController.GerarHash(userModel.senha);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        public async Task<UsuarioModel?> UpdateFotoDePerfil(int id, AtualizarFotoDto updateDto)
        {
            var userModel = await _dbContext.USERS.FirstOrDefaultAsync(x => x.id_usuario == id);
            if (userModel == null)
            {
                return null;
            }
            userModel.foto = updateDto.foto;
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

    }
}
