using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using api.dtos;
using Microsoft.EntityFrameworkCore;


namespace api.services
{  
    public class ServicoService(AppDbContext db)
    {
        // Referência privada para o contexto do banco de dados (EF Core)
        private readonly AppDbContext _db = db;

        public async Task<List<ServicoDto>> ListarTodos()
        {
            var servicos = await _db.Servicos.ToListAsync();

            return servicos.Select(s => s.ToDto()).ToList();
        }
        public async Task<ServicoDto> Adicionar(ServicoCreateDto dto)
        {
            var novoServico = new Servico  // aqui poderia ser feito um novoServico.Toentity()
            {
                Nome = dto.Nome,
                PrecoBase = dto.Preco,
                Descricao = dto.Descricao
            };  

            _db.Servicos.Add(novoServico);
            await _db.SaveChangesAsync();

            return novoServico.ToDto();
        }
    }
}