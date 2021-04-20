using System;

namespace App.Dominio.Entidades
{
    public class Garantia
    {
        public int id { get; set; }
        
        public string? nome_casa { get; set; } 
        
        public string tipo_de_produto  { get; set; }
        
        public DateTime? dia_inicial { get; set; }
        
        public DateTime? dia_final { get; set; }

        public string? casos_cobertos { get; set; }
        
        public string? casos_nao_cobertos { get; set; }
        
        public string? descricao { get; set; }
    }
}