using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;
using Web_Api.Repositories;
using Web_Api.ViewsModels;

namespace Web_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       UsuarioRepository repository = new UsuarioRepository();


        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            // Busca o usuário pelo e-mail e senha
            Usuario usuarioBuscado = repository.BuscarEmalSenha(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }
            return StatusCode(202, usuarioBuscado);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(repository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPorId(int id)
        {
            var buscar = repository.BuscarPorId(id);

            if (buscar == null)
            {
                return StatusCode(404, "usuario não encontrado");
            }
            else
            {
                return StatusCode(202, buscar);
            }
        }
 
        [HttpPost]       
        public IActionResult Adiciona(Usuario NovoUsuario)
        {
            if (NovoUsuario == null)
            {
                return StatusCode(404, "algun campo não foi preenchido");
            }
            else
            {
                repository.AdicionarUsuario(NovoUsuario);
                return StatusCode(201, "seu usuario foi criado com sucesso");
            }
        }

       
        [HttpPut]
        public IActionResult atualizar(Usuario usuarioAtualizado)
        {
            repository.AtualizarIdCorpo(usuarioAtualizado);
            return StatusCode(202, "seu TipoUsuario foi atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult deletar(int id)
        {
            repository.Deletar(id);
            return StatusCode(202, "seu TipoUsuario foi deletado com sucesso");
        }
    }
}