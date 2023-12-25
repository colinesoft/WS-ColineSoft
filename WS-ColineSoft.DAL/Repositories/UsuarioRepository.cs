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
            return _context.Usuarios
                .Include(e => e.GrupoUsuario).ThenInclude(e => e.StatusGeral)
                .Include(e => e.StatusGeral)
                .AsNoTracking();
        }

        public override UsuarioEntity? Get(Guid id) => GetAll().FirstOrDefault(e => e.Id == id);
    }
}
