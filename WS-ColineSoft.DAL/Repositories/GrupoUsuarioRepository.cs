using Microsoft.EntityFrameworkCore;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.DAL.Repositories
{
    public class GrupoUsuarioRepository : BaseRepository<GrupoUsuarioEntity>, IGrupoUsuarioRepository
    {
        public GrupoUsuarioRepository(ColineSoftContext context) : base(context)
        {
        }

        public override IEnumerable<GrupoUsuarioEntity> GetAll()
        {
            return _context.GruposUsuarios
                .Include(e => e.StatusGeral)
                .AsNoTracking();
        }

        public override GrupoUsuarioEntity? Get(Guid id) => GetAll().FirstOrDefault(e => e.Id == id);
    }
}
