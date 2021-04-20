namespace Cyrela.WebApi.Models
{
  public class Resposta
  {
    public string mensagem { get; set; }
  }

  public class Resposta<TDetalhes> : Resposta
  {
    public TDetalhes detalhes { get; set; }
  }
}