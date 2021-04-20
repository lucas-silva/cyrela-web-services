using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using App.WebApi.Models;
using App.WebApi.Models.Vistoria.Requisicoes;
using App.WebApi.Models.Vistoria.Respostas;
using App.Dominio;
using App.Dominio.Entidades;
using System.Globalization;

namespace App.WebApi.Controllers
{
  [ApiController]
  [Route("vistoria")]
  public class VistoriaController : ControllerBase
  {
    private CultureInfo ptBR = CultureInfo.GetCultureInfo("pt-BR");

    private BancoDeDados Banco;

    public VistoriaController(BancoDeDados dados)
    {
      Banco = dados;
    }

    /// <summary>
    /// Retorna as datas disponíveis para vistoria
    /// </summary>
    [HttpGet]
    [Route("agenda/disponibilidade")]
    public IEnumerable<DisponibilidadeNaAgenda> BuscarDisponibilidadeNaAgenda()
    {
      var horario_inicio = 8;
      var horario_fim = 20;
      var data_final = DateTime.Now.AddDays(30);
      var resultados = new List<DisponibilidadeNaAgenda>();

      for (var i = 0; i <= 30; i++)
      {
        var dia = DateTime.Now.AddDays(i);
        var disponibilidade = new DisponibilidadeNaAgenda();

        disponibilidade.data = dia.ToString("dd/MM/yyyy");

        for (var hora = horario_inicio; hora <= horario_fim; hora++)
        {
          var horarioFormatado = DateTime.Today.AddHours(hora).ToString("HH:mm");
          disponibilidade.horarios_disponiveis.Add(horarioFormatado);
        }

        resultados.Add(disponibilidade);
      }

      return resultados;
    }

    /// <summary>
    /// Realiza o agendamento para realizar a vistoria
    /// </summary>
    [HttpPost]
    [Route("agenda")]
    public ActionResult<Resposta> AgendarVistoria(AgendarVistoria requisicao)
    {
      if (!DateTime.TryParseExact($"{requisicao.data} {requisicao.horario}", "dd/MM/yyyy HH:mm", ptBR, DateTimeStyles.None, out DateTime data))
        return BadRequest(new Resposta { mensagem = "Data ou horário fora do formato esperado" });

      if (data < DateTime.Now)
        return BadRequest(new Resposta { mensagem = "A data de agendamento deve estar no futuro" });

      var datas_disponiveis = this.BuscarDisponibilidadeNaAgenda();
      var existe_data_disponivel = datas_disponiveis.Any(d => d.data == requisicao.data && d.horarios_disponiveis.Any(horario => horario == requisicao.horario));
      if (!existe_data_disponivel)
        return BadRequest(new Resposta { mensagem = "Data e horário informado indisponível" });

      Banco.Vistorias.Add(new Vistoria
      {
        data_agendamento = data,
        status = "pendente"
      });

      Banco.SaveChanges();

      return Ok(new Resposta { mensagem = "Vistoria agendada com sucesso" });
    }

    /// <summary>
    /// Retorna as vistorias agendadas
    /// </summary>
    [HttpGet]
    [Route("agenda")]
    public IEnumerable<VistoriaAgendada> BuscarVistoriasAgendadas()
    {
      return Banco.Vistorias.Select(vistoria => new VistoriaAgendada
      {
        vistoria_id = vistoria.id,
        data = vistoria.data_agendamento.ToString("dd/MM/yyyy"),
        horario = vistoria.data_agendamento.ToString("HH:mm"),
        status = vistoria.status
      });
    }

    /// <summary>
    /// Aprova uma vistoria e libera a entrega de chaves
    /// </summary>
    [HttpPost]
    [Route("/vistoria/{vistoria_id:int}/aprovar")]
    public ActionResult<Resposta> AprovarVistoria(int vistoria_id)
    {
      var vistoria = Banco.Vistorias.SingleOrDefault(vistoria => vistoria.id == vistoria_id);

      if (vistoria == null)
        return BadRequest(new Resposta { mensagem = "A vistoria informada não existe" });

      if (!vistoria.esta_pendente)
        return BadRequest(new Resposta { mensagem = "O status dessa vistoria já foi definido" });

      vistoria.data_aprovacao = DateTime.Now;
      vistoria.status = "aprovada";

      Banco.SaveChanges();

      return new Resposta { mensagem = "Vistoria aprovada e chaves entregues!" };
    }

    /// <summary>
    /// Reprova uma vistoria
    /// </summary>
    [HttpPost]
    [Route("/vistoria/{vistoria_id:int}/reprovar")]
    public ActionResult<Resposta> ReprovarVistoria(int vistoria_id, ReprovarVistoria requisicao)
    {
      var vistoria = Banco.Vistorias.SingleOrDefault(vistoria => vistoria.id == vistoria_id);

      if (vistoria == null)
        return BadRequest(new Resposta { mensagem = "Vistoria não existe" });

      if (!vistoria.esta_pendente)
        return BadRequest(new Resposta { mensagem = "O status dessa vistoria já foi definido" });

      vistoria.data_reprovacao = DateTime.Now;
      vistoria.status = "reprovada";
      vistoria.problemas_encontrados = requisicao.problemas_encontrados;

      Banco.SaveChanges();

      return new Resposta { mensagem = "Vistoria reprovada" };
    }

    /// <summary>
    /// Cancela uma vistoria
    /// </summary>
    [HttpDelete]
    [Route("/vistoria/{vistoria_id:int}")]
    public ActionResult<Resposta> CancelarVistoria(int vistoria_id)
    {
      var vistoria = Banco.Vistorias.SingleOrDefault(vistoria => vistoria.id == vistoria_id);

      if (vistoria == null)
        return BadRequest(new Resposta { mensagem = "Vistoria não existe" });

      if (!vistoria.esta_pendente)
        return BadRequest(new Resposta { mensagem = "O status dessa vistoria já foi definido" });

      vistoria.data_cancelamento = DateTime.Now;
      vistoria.status = "cancelada";

      Banco.SaveChanges();

      return new Resposta { mensagem = "Vistoria cancelada" };
    }
  }
}
