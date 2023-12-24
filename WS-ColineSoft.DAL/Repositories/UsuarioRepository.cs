using Microsoft.EntityFrameworkCore;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.DAL.Repositories
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(ColineSoftContext context) : base(context)
        {

        }

        public override IEnumerable<UsuarioEntity> GetAll()
        {
            var v1 = _context.Usuarios
                .Include(e => e.GrupoUsuario)
                .Include(e => e.UsuarioAlteracao)
                .Include(e => e.StatusGeral)
                .AsNoTracking();
            return v1;
        }
    }
}
