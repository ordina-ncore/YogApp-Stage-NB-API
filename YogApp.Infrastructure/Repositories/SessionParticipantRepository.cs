using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;
using YogApp.Domain.SessionParticipants;
using YogApp.Infrastructure.Data;

namespace YogApp.Infrastructure.Repositories
{
    public class SessionParticipantRepository : ISessionParticipantRepository
    {
        private readonly YogAppDbContext _context;

        public SessionParticipantRepository(YogAppDbContext context)
        {
            _context = context;
        }

        public void AppendChanges(SessionParticipantEntity entity)
        {
            _context.sessionParticipants.Add(entity);
        }

        public async Task SaveAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(ct);
        }

        public List<SessionParticipantEntity> GetAll()
        {
            return _context.sessionParticipants.Include(x => x.User).ToList();
        }

        public SessionParticipantEntity? GetById(Guid id)
        {
            return _context.sessionParticipants.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }
    }
}
