using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace api.Data

{
    //classe gigante que permite a pesquisa sua tabelas individuais
    //especifica qual tabela vai virar objeto com EntinyFramework
    public class ApplicationDBContext : DbContext //classe principal do Entity Framework Core para gerenciar acesso ao banco de dados
    {

        // CONSTRUTOR
        // DbContextOptions é um pacote de configurações — ele guarda coisas como qual banco usar string de conexão, log, cache, etc.
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions) //repassando dbContextOptions para a mãe
        {
            
        }


        //DbSet<T> representa uma tabela do banco de dados
        public DbSet<Usuario> USERS { get; set; } //“Pesquisa no banco a tabela USERS que guarde objetos da entidade Usuario.”

    }
}
