using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.dtos
{
    public class ServicoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public string? Descricao { get; set; } 
        public decimal PrecoBase { get; set; }
        public string? Icone { get; set; } 
    }
    public class ServicoCreateDto
    {
        public string Nome {get; set;}
        public decimal Preco {get; set;}
        public string? Descricao {get; set;}
    }
        // Mapper: converte o model em dto 

        // exemplo sem mapper:
        //  return Servicos.Select(s => new ServicoDto( s.id, s.nome ....

        // exemplo com mapper (como está no service):
        //  return Servicos.Todto() (ou select pra caso de listas)
        public static class ServicoMapper
        {
            public static ServicoDto ToDto(this Servico entity) =>
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