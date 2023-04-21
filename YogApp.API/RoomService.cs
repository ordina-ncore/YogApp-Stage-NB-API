using YogApp.Domain.Rooms;
using YogApp.Domain.Sessions;

namespace YogApp.API
{
    public class RoomService : IRoomService
    {
        public RoomEntity RemoveRoom(RoomEntity room)
        {
            room.IsDeleted = true;
            return room;
        }

    }
}
