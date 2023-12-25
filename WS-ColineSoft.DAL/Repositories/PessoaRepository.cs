using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .Include(e => e.StatusGeral);
        }

        public override PessoaEntity? Get(Guid id) => GetAll().FirstOrDefault(e => e.Id == id);
    }
}
