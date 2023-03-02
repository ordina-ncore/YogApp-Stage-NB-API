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
        public Task SaveAsync(CancellationToken ct);
        public void AppendChanges(RoomEntity entity);
        public List<RoomEntity> GetAll();
        public RoomEntity? GetById(Guid id);
        public bool CheckAvailability(RoomEntity? room, DateTime startDate, DateTime endDate);
    }
}
