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
            var v1 = _context.GruposUsuarios;
            var v2 = _context.StatusGeral;
            var v3 = _context.Usuarios;

            return _context.GruposUsuarios
                .Include(e => e.StatusGeral)
                //.Include(e => e.Usuarios)
                .AsNoTracking();
        }

        public override GrupoUsuarioEntity? Get(Guid id) => GetAll().FirstOrDefault(e => e.Id == id);
    }
}
