using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; } // nullable pois nem todos servicos tem uma descrição
        public decimal PrecoBase { get; set; }
        public string? Icone { get; set; } // Emoji/Url ou classe de ícone

        // não permitir serviço com preço negativo (opcional)
        public bool IsValido() => !string.IsNullOrWhiteSpace(Nome) && PrecoBase >= 0;
    }
}