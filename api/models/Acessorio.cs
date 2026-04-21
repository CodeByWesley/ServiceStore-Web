namespace api.models
{
    public class Acessorio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal PrecoBase { get; set; }
        public string? Icone { get; set; }

        // não permitir serviço com preço negativo (opcional)
        public bool IsValido() => !string.IsNullOrWhiteSpace(Nome) && PrecoBase >= 0;
        
    }
}
