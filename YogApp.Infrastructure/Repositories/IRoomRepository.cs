using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;

namespace YogApp.Infrastructure.Repositories
{
    public interface IRoomRepository
    {
        public List<RoomEntity> GetAll();
        public RoomEntity? GetById(Guid id);
    }
}
