using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;
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
        public void AppendChanges(SessionEntity entity)
        {
            _context.sessions.Add(entity);
        }

        public async Task SaveAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(ct);
        }
        public List<SessionEntity> GetAll()
        {
            return _context.sessions.Include(x => x.Room).Include(x => x.Participants).ToList();
        }
        public SessionEntity? GetById(Guid id)
        {
            return _context.sessions.Include(x => x.Room).Include(x => x.Participants).FirstOrDefault(x => x.Id == id);
        }
        public List<SessionEntity?> GetAllFutureSessionsForRoom(Guid roomId)
        {
            DateTime now = DateTime.UtcNow;
            return _context.sessions.Include(x => x.Room).Where(x => (x.StartDateTime >= now) && (x.Room.Id == roomId)).ToList();
        }
    }
}
