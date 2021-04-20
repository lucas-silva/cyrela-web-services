using System;
using Microsoft.AspNetCore.Http;

namespace App.Dominio.Entidades
{
    public class Visita
    {
        public int id { get; set; }

        public string ocorrencia { get; set; }
        
        public string status { get; set; }
        
        public string tecnico { get; set; }
        
        public DateTime dia_pedido { get; set; }
            
        public DateTime dia_visita { get; set; }
        
        public DateTime hora_visita { get; set; }
    }
}