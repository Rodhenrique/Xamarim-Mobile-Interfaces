﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;
using Web_Api.Repositories;

namespace Web_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class FormaPagamentoController : ControllerBase
    {
        FormaPagamentoRepository repository = new FormaPagamentoRepository();

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
                return StatusCode(404, "forma de pagamaneto não encontrado");
            }
            else
            {
                return StatusCode(202, buscar);
            }
        }

        [HttpPost]
        public IActionResult Adiciona(FormaDePagamento NovoUsuario)
        {
            if (NovoUsuario == null)
            {
                return StatusCode(404, "algun campo não foi preenchido");
            }
            else
            {
                repository.AdicionarForma(NovoUsuario);
                return StatusCode(201, "seu forma de pagamento foi criado com sucesso");
            }
        }


        [HttpPut]
        public IActionResult atualizar(FormaDePagamento pagamento)
        {
            repository.atuazliarId(pagamento);
            return StatusCode(202, "seu TipoUsuario foi atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult deletar(int id)
        {
            repository.Deletar(id);
            return StatusCode(202, "seu forma de pagamento foi deletado com sucesso");
        }
    }
}