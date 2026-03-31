namespace api.models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public string CodigoRastreio { get; set; } = string.Empty; 
        public string? NomeCliente { get; set; } = string.Empty;
        public string? Whatsapp { get; set; } = string.Empty;
        public string? Aparelho { get; set; } = string.Empty;
        public string? Status { get; set; } = "Recebido"; // Recebido, Analise, Pronto, Entregue
        public decimal ValorOrcado { get; set; }
        public DateTime DataEntrada { get; set; } = DateTime.Now;
    }
}
