using YogApp.Domain.Rooms;
using YogApp.Domain.Sessions;

namespace YogApp.API
{
    public interface IRoomService
    {
        public RoomEntity RemoveRoom(RoomEntity room);
    }
}
