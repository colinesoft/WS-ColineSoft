using Microsoft.EntityFrameworkCore;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.DAL.Repositories
{
    public class PessoaEnderecoRepository: BaseRepository<PessoaEnderecoEntity>, IPessoaEnderecoRepository
    {
        public PessoaEnderecoRepository(ColineSoftContext context): base(context) 
        {
            
        }
        public override IEnumerable<PessoaEnderecoEntity> GetAll()
        {
            return _context.PessoasEnderecos.AsNoTracking()
                .Include(e => e.StatusGeral)
                .Include(e => e.Pessoa);
        }
    }
}
