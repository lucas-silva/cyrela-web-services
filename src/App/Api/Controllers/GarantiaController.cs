using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Channels;
using App.Dominio;
using App.Dominio.Entidades;
using App.WebApi.Models;
using App.WebApi.Models.Garantia.Respostas;
using App.WebApi.Models.Vistoria.Requisicoes;
using MySqlX.XDevAPI.Relational;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualBasic;

namespace App.WebApi.Controllers
{
    [ApiController, Route("ocorrencia")]
    public class GarantiaController : ControllerBase
    {
        private CultureInfo ptBR = CultureInfo.GetCultureInfo("pt-BR");

        private BancoDeDados Banco;

        public GarantiaController(BancoDeDados banco)
        {
            Banco = banco;
        }
        /// <summary>
        /// Retorna o nome dos apartamentos, os itens cobertos por garantia nela, e quanto tempo falta na garantia
        /// </summary>
        [HttpGet, Route("garantia/itens")]
        public IEnumerable<GarantiaProduto> ListarItensDaCasa()
        {

            return Banco.Garantias.Select(garantia => new GarantiaProduto
            {
                Nome = garantia.nome_casa,
                Item = garantia.tipo_de_produto,
                DataFinal = garantia.dia_final
            }).ToList();
        }
        /// <summary>
        /// retorna todas as datas disponiveis para agendar uma ocorrencia
        /// </summary>
        [HttpGet, Route("agenda/disponibilidade")]
        public IEnumerable<AgendaGarantia> VerificarDisponibilidade()
        {
            var horario_inicio = 8;
            var horario_fim = 20;
            var data_final = DateTime.Now.AddDays(30);
            var resultados = new List<AgendaGarantia>();

            for (var i = 0; i <= 30; i++)
            {
                var dia = DateTime.Now.AddDays(i);
                var disponibilidade = new AgendaGarantia();

                disponibilidade.data = dia.ToString("dd/MM/yyyy");

                for (var hora = horario_inicio; hora <= horario_fim; hora++)
                {
                    var horarioFormatado = DateTime.Today.AddHours(hora).ToString("HH:mm");
                    disponibilidade.horarios_disponiveis.Add(horarioFormatado);
                }

                resultados.Add(disponibilidade);
                Banco.SaveChanges();
            }

            return resultados;
        }
        /// <summary>
        /// cria uma ocorrencia e define o horario de visita
        /// </summary>
        [HttpPost, Route("agenda")]
        public ActionResult<Resposta>  criarOcorrencia(AgendarVistoria requisicao)
        {
            
            if (!DateTime.TryParseExact($"{requisicao.data} {requisicao.horario}", "dd/MM/yyyy HH:mm", ptBR, DateTimeStyles.None, out DateTime data))
                return BadRequest(new Resposta { mensagem = "Data ou horário fora do formato esperado" });

            if (data < DateTime.Now)
                return BadRequest(new Resposta { mensagem = "A data de agendamento deve estar no futuro" });

            Banco.Visitas.Add(new Visita
            {
                hora_visita = requisicao.horario,
                dia_visita = data
            });
            Banco.SaveChanges();

            return Ok(new Resposta { mensagem = "Visita agendada com sucesso" });
        }
        /// <summary>
        /// visualiza o status de todas as ocorrencias
        /// </summary>
        [HttpGet]
        public IEnumerable<Visita> GetOcorrencias()
        {
            return Banco.Visitas.Select(visita => new Visita());
        }

        /// <summary>
        /// cria um cadastro com todas as opcoes possiveis
        /// </summary>
        [HttpPostAttribute, Route("cadastro/garantia")]
        public ActionResult<Resposta> CriarCadastroCompleto(Garantia g)
        {
            Banco.Garantias.Add(g);
            Banco.SaveChanges();
            return Ok(new Resposta {mensagem = "cadastro de resposta completo"});
        }
        
        /// <summary>
        /// cria uma visita com todas as opcoes possiveis
        /// </summary>
        [HttpPostAttribute, Route("visita/garantia")]
        public ActionResult<Visita> CriarVisitaCompleta(Visita v)
        {
            Banco.Visitas.Add(v);
            Banco.SaveChanges();
            return Ok(new Resposta
            {
                mensagem = "cadastro com sucesso"
            });

        }
    }
}