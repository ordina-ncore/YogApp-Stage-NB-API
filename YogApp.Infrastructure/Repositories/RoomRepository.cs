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
        public List<RoomEntity> GetAll()
        {
            return _context.rooms.ToList();
        }
        public RoomEntity? GetById(Guid id)
        {
            return _context.rooms.FirstOrDefault(x => x.Id == id);
        }
    }
}
