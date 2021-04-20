using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Cyrela.WebApi.Models;
using Cyrela.WebApi.Models.Vistoria.Requisicoes;
using Cyrela.WebApi.Models.Vistoria.Respostas;

namespace Cyrela.WebApi.Controllers
{
  [ApiController]
  [Route("vistoria")]
  public class VistoriaController : ControllerBase
  {

    /// <summary>
    /// Retorna as datas disponíveis para vistoria
    /// </summary>
    [HttpGet]
    [Route("agenda/disponibilidade")]
    public IEnumerable<DisponibilidadeNaAgenda> BuscarDisponibilidadeNaAgenda()
    {
      return new[] {
        new DisponibilidadeNaAgenda
        {
          data = "20/04/2020",
          horarios_disponiveis = new [] { "09:00", "10:00", "16:30" }
        }
      };
    }

    /// <summary>
    /// Realiza o agendamento para realizar a vistoria
    /// </summary>
    [HttpPost]
    [Route("agenda")]
    public Resposta AgendarVistoria(AgendarVistoria requisicao)
    {
      return new Resposta { mensagem = "Vistoria agendada com sucesso" };
    }

    /// <summary>
    /// Retorna as vistorias agendadas
    /// </summary>
    [HttpGet]
    [Route("agenda")]
    public IEnumerable<VistoriaAgendada> BuscarVistoriasAgendadas()
    {
      return new[] {
        new VistoriaAgendada
        {
          vistoria_id = 1,
          data = "20/04/2021",
          horario = "09:30",
          status = "cancelado",
        }
      };
    }

    /// <summary>
    /// Aprova uma vistoria e libera a entrega de chaves
    /// </summary>
    [HttpPost]
    [Route("/vistoria/{vistoria_id:int}/aprovar")]
    public Resposta AprovarVistoria(int vitoria_id)
    {
      return new Resposta { mensagem = "Vistoria aprovada e chaves entregues!" };
    }

    /// <summary>
    /// Reprova uma vistoria
    /// </summary>
    [HttpPost]
    [Route("/vistoria/{vistoria_id:int}/reprovar")]
    public Resposta ReprovarVistoria(int vistoria_id, ReprovarVistoria requisicao)
    {
      return new Resposta { mensagem = "Vistoria reprovada" };
    }

    /// <summary>
    /// Cancela uma vistoria
    /// </summary>
    [HttpDelete]
    [Route("/vistoria/{vistoria_id:int}")]
    public Resposta CancelarVistoria(int vistoria_id)
    {
      return new Resposta { mensagem = "Vistoria cancelada" };
    }
  }
}
