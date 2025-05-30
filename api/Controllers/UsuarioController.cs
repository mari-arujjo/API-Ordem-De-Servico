using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    
    [ApiController] // marca a  classe como uma api controller
    [Route("api/usuario")]


    // herda funcionalidades básicas de um controlador da ASP.NET
    public class UsuarioController : ControllerBase 
    {
        private readonly IUsuarioRepository _usuarioRep;
        public UsuarioController(IUsuarioRepository usuarioRep)
        {
            _usuarioRep = usuarioRep;
        }


        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var users = await _usuarioRep.GetAllAsync(); 
            var usersDto = users.Select(u => u.ConverterParaUsuarioDto());

            return Ok(usersDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorID([FromRoute] int id)
        {
            var user = await _usuarioRep.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ConverterParaUsuarioDto());
        }


        [HttpPost]
        public async Task<IActionResult> NovoUsuario([FromBody] CriarUsuarioDto dto)
        {
            var userModel = dto.CriarNovoUsuarioDto();
            await _usuarioRep.CreateAsync(userModel);

            return CreatedAtAction(nameof(ObterPorID), new { id = userModel.id_usuario }, userModel.ConverterParaUsuarioDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> AtualizarUsuario([FromRoute] int id, [FromBody] AtualizarUsuarioDto updateDto)
        {
            var userModel = await _usuarioRep.UpdateAsync(id, updateDto);
            if (userModel == null) 
            {
                return NotFound();
            }

            return Ok(userModel.ConverterParaUsuarioDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletarUsuario([FromRoute] int id)
        {
            var userModel = await _usuarioRep.DeleteIdAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
