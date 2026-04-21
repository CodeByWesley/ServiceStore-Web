using api.models;

namespace api.dtos
{
    public class AcessorioDto
    {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string? Descricao { get; set; }
            public decimal PrecoBase { get; set; }
            public string? Icone { get; set; }
    }
    public class AcessorioCreateDto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string? Descricao { get; set; }
    }
    public static class AcessorioMapper
    {
        public static AcessorioDto ToDto(this Acessorio entity) =>
        new()
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Descricao = entity.Descricao,
            PrecoBase = entity.PrecoBase,
            Icone = entity.Icone
        };
    }

}
