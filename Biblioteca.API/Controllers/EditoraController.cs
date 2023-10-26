﻿using Biblioteca.Negocio.Atributos;
using Biblioteca.Negocio.Dtos.Editoras;
using Biblioteca.Servicos.Contratos.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/v1")]
    public class EditoraController : PrincipalController
    {
        private readonly IServicoEditora _servicoEditora;

        public EditoraController(ILogger<EditoraController> logger, IServicoEditora servicoEditora)
        {
            _logger = logger;
            _servicoEditora = servicoEditora;
        }

        [Authorize]
        [VersaoApi(VersaoDaApi = "V1.0")]
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(CadastroEditoraDto dto)
        {
             var retorno = _servicoEditora.Cadastrar(dto);
              return RespostaResponalizada(retorno);           
        }

        [Authorize]
        [VersaoApi(VersaoDaApi = "V1.0")]
        [HttpPut("Atualizar")]
        public IActionResult Atualizar(AlterarEditoraDto dto)
        {
            var retorno = _servicoEditora.Atualizar(dto);
            return RespostaResponalizada(retorno);
        }

        [Authorize]
        [VersaoApi(VersaoDaApi = "V1.0")]
        [HttpDelete("Deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            var retorno = _servicoEditora.Deletar(id);
            return RespostaResponalizada(retorno);
        }

        [Authorize]
        [VersaoApi(VersaoDaApi = "V1.0")]
        [HttpGet("ObterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var retorno = _servicoEditora.ObterPorId(id);
            return RespostaResponalizada(retorno);
        }

        [Authorize]
        [VersaoApi(VersaoDaApi = "V1.0")]
        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var retorno = _servicoEditora.ObterTodos();
            return RespostaResponalizada(retorno);
        }

    }
}
