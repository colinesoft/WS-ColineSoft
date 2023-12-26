using Microsoft.EntityFrameworkCore;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.DAL.Repositories
{
    public class PessoaRepository : BaseRepository<PessoaEntity>, IPessoaRepository
    {
        public PessoaRepository(ColineSoftContext context) : base(context)
        {
        }
        public override IEnumerable<PessoaEntity> GetAll()
        {
            return _context.Pessoas.AsNoTracking()
                .Include(e => e.StatusGeral)
                .Include(e => e.Enderecos);
        }

        public override PessoaEntity? Get(Guid id) => GetAll().FirstOrDefault(e => e.Id == id);
    }
}
