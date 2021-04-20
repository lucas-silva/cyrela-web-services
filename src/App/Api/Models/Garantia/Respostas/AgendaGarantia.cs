using System.Collections.Generic;

namespace App.WebApi.Models.Garantia.Respostas
{
    public class AgendaGarantia
    {

        public AgendaGarantia()
        {
            horarios_disponiveis = new List<string>();
        }

        public string data { get; set; }

        public List<string> horarios_disponiveis { get; set; }
    
    }
}