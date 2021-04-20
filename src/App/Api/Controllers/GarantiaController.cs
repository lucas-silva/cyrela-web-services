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
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Relational;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [ApiController,Route("garantia")]
    public class GarantiaController
    {
        private CultureInfo ptBR = CultureInfo.GetCultureInfo("pt-BR");

        private BancoDeDados Banco;
        #warning FIXME: eu acabei de pensar em uma solucao pra o que eu acho que esta quebrando essa request, mais eu eu vou tirar um cochilo de 1/2h antes, por causa de umas outras coisas hj eu to virado ha quase 26h
        [HttpGet, Route("itens")]
        public IEnumerable<GarantiaProduto> ListarItensDaCasa()
        {

            return Banco.Garantias.Select(garantia => new GarantiaProduto
            {
                Nome = garantia.nome_casa,
                DataFinal = garantia.dia_final
            }).ToList();
        }

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
            }

            return resultados;
        }
        #warning FIXME: honestamente eu nao lembro mais como retornar valor, se possivel acha uma solucao pra isso por favor 
        [HttpPost, Route("agenda")]
        public void criarOcorrencia(AgendarVistoria requisicao)
        {
           /* if (!DateTime.TryParseExact($"{requisicao.data} {requisicao.horario}", "dd/MM/yyyy HH:mm", ptBR,
                DateTimeStyles.None, out DateTime data))
                return ApiController.BadRequest(new Resposta {mensagem = "Data ou horário fora do formato esperado"});
*/         
           #warning  FIXME: isso aqui tambem
            var datas_disponiveis = this.VerificarDisponibilidade();
            var existe_data_disponivel = datas_disponiveis.Any(d => d.data == requisicao.data && d.horarios_disponiveis.Any(horario => horario == requisicao.horario));
            /*if (!existe_data_disponivel)
                throw new HttpResponseMessage( 400);*/
            Banco.Visitas.Add(new Visita
            {
                hora_visita = Convert.ToDateTime(requisicao.horario),
                dia_visita = Convert.ToDateTime(requisicao.data)
            });
        }
        #warning FIXME : acho que isso vai funcionar, mais graca a o banco que nao quer funcionar eu nao consigo testar, yay
        [HttpGet]
        public IEnumerable<Visita> GetOcorrencias()
        {
            return Banco.Visitas.SelectMany(visita => new List<Visita>());
        }
    }
}