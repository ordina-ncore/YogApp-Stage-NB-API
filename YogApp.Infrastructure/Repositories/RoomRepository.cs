using Microsoft.EntityFrameworkCore;
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
    public class RoomRepository : IRoomRepository
    {
        private readonly YogAppDbContext _context;

        public RoomRepository(YogAppDbContext context)
        {
            _context = context;
        }

        public void AppendChanges(RoomEntity entity)
        {
             _context.rooms.Add(entity);
        }

        public async Task SaveAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(ct);
        }

        public List<RoomEntity> GetAll()
        {
            return _context.rooms.ToList();
        }

        public RoomEntity? GetById(Guid id)
        {
            return _context.rooms.FirstOrDefault(x => x.Id == id);
        }
        public bool CheckAvailability(RoomEntity? concernedRoom, DateTime startDate, DateTime endDate)
        {
            List<SessionEntity> betweenDateTimesSessions = _context.sessions.Where(x => (x.StartDateTime >= startDate && x.StartDateTime <= endDate) || (x.EndDateTime >= startDate && x.EndDateTime <= endDate) && !x.IsCancelled && !x.IsDeleted).Include(x => x.Room).ToList();
            foreach(SessionEntity session in betweenDateTimesSessions) {
                if(session.Room== concernedRoom)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
