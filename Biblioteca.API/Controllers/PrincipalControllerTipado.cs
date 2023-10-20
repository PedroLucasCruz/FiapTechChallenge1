﻿using Biblioteca.Negocio.Validacoes.FabricaDeValidacoes;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    public class PrincipalControllerTipado<T> : ControladorAbstratoComContexto<PrincipalControllerTipado<T>>
    {
        protected ICollection<string> Erros = new List<string>();

        protected IActionResult RespostaResponalizada(InconsistenciaDeValidacaoTipado<T> inconsistenciaDeValidacao)
        {
            AdicionarErroProcessamento(inconsistenciaDeValidacao);

            if (inconsistenciaDeValidacao.EhValido()) return Ok(new { Mensagem = inconsistenciaDeValidacao.Mensagem, Data = inconsistenciaDeValidacao.ObtenhaRetornoServico() });

            return StatusCode(200, new { Erros });
        }

        protected IActionResult RespostaResponalizada(object objeto = null)
        {
            if (OperacaoValida()) return Ok(objeto);

            return StatusCode(200, new { Erros });
        }

        protected void AdicionarErroProcessamento(InconsistenciaDeValidacaoTipado<T> inconsistenciaDeValidacao)
        {
            foreach (var error in inconsistenciaDeValidacao.listaDeInconsistencias)
            {
                Erros.Add(error.Mensagem.ToString());
            }
        }

        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }
    }
}
