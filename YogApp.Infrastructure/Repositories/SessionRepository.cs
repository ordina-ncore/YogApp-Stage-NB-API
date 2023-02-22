using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Sessions;
using YogApp.Infrastructure.Data;

namespace YogApp.Infrastructure.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly YogAppDbContext _context;

        public SessionRepository(YogAppDbContext context)
        {
            _context = context;
        }
        public List<SessionEntity> GetAll()
        {
            return _context.sessions.Include(x => x.Teacher).Include(x => x.Room).Include(x => x.Participants).ThenInclude(x => x.User).ToList();
        }
        public SessionEntity? GetById(Guid id)
        {
            return _context.sessions.Include(x => x.Teacher).Include(x => x.Room).Include(x => x.Participants).ThenInclude(x => x.User).FirstOrDefault(x => x.Id == id);
        }
    }
}
