namespace App.WebApi.Models.Vistoria.Respostas
{
  public class VistoriaAgendada
  {
    public int vistoria_id { get; set; }

    public string data { get; set; }

    public string horario { get; set; }

    public string status { get; set; }
  }
}
