using System;

namespace App.Dominio.Entidades
{
  public class Vistoria
  {


    public int id { get; set; }

    public DateTime data_agendamento { get; set; }

    public string status { get; set; }

    public DateTime? data_aprovacao { get; set; }

    public DateTime? data_reprovacao { get; set; }

    public DateTime? data_cancelamento { get; set; }

    public string problemas_encontrados { get; set; }

    public bool esta_pendente { get { return this.status == "pendente"; } }
  }
}
