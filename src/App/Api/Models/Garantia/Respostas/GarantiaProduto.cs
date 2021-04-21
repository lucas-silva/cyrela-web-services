using System;

namespace App.WebApi.Models.Garantia.Respostas
{
    public class GarantiaProduto
    {
        public string? Nome { get; set; }
        
        public string Item { get; set; }
        
        public DateTime? DataFinal { get; set; }
        
    }
}