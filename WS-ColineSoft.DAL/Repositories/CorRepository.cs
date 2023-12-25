using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.DAL.Repositories
{
    public class CorRepository : BaseRepository<CorEntity>, ICorRepository
    {
        public CorRepository(ColineSoftContext context) : base(context)
        {
        }

        /*
        public override CorEntity? Get(Guid id)
        {
            return _context.Cores
                .Include(e => e.StatusGeral)
                .Include(e => e.UsuarioAlteracao).ThenInclude(e => e.GrupoUsuario)
                .Include(e => e.UsuarioAlteracao).ThenInclude(e => e.StatusGeral)
                .AsNoTracking()                
                .FirstOrDefault(e => e.Id == id);
        }
        public override IEnumerable<CorEntity> GetAll()
        {
            return _context.Cores
                .Include(e => e.StatusGeral)
                .Include(e => e.UsuarioAlteracao).ThenInclude(e => e.GrupoUsuario)
                .AsNoTracking();
        }
        */
    }
}
