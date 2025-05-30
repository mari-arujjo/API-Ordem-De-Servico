using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{

    [ApiController]
    [Route("api/testeConexao")]

    public class TesteConexaoController : ControllerBase
    {
        
        private readonly ApplicationDBContext _dbContext;

        public TesteConexaoController(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult TestarConexao()
        {
            try
            {
                if (_dbContext.Database.CanConnect())
                {
                    return Ok("Concetado ao banco com sucesso");
                }
                else
                {
                    return StatusCode(500, "Não foi possível conectar ao banco de dados");
                }

            } catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível conectar ao banco de dados: {ex.Message}");
                // 500 - Internal Server Error, houve um erro interno no servidor 
            }
        }

    }
}
