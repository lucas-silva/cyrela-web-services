using System.Collections.Generic;

namespace App.WebApi.Models.Vistoria.Respostas
{
  public class DisponibilidadeNaAgenda
  {
    public DisponibilidadeNaAgenda()
    {
      horarios_disponiveis = new List<string>();
    }

    public string data { get; set; }

    public List<string> horarios_disponiveis { get; set; }
  }
}