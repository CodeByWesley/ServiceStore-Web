using api.dtos;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.services
{
    public class AcessorioService(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task<List<AcessorioDto>> ListarTodos()
        {
            var servicos = await _db.Acessorios.ToListAsync();

            return servicos.Select(s => s.ToDto()).ToList();
        }
        public async Task<AcessorioDto> Adicionar(AcessorioCreateDto dto)
        {
            var acessorio = new Acessorio  // aqui poderia ser feito um novoServico.Toentity()
            {
                Nome = dto.Nome,
                PrecoBase = dto.Preco,
                Descricao = dto.Descricao
            };

            _db.Acessorios.Add(acessorio);
            await _db.SaveChangesAsync();

            return acessorio.ToDto();
        }
    }
}
