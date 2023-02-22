using YogApp.API.Schema.Mutations.Inputs;
using YogApp.Domain.Rooms;
using YogApp.Infrastructure.Repositories;

namespace YogApp.API.Schema.Mutations;

[MutationType]
public class RoomMutations
{
    public RoomEntity CreateRoom([Service] IRoomRepository repo, CreateRoomInput input, CancellationToken ct)
    {
        RoomDomain room = RoomDomain.Create(input.Name, input.Address, input.Capacity);
        repo.AppendChanges(room.entity);
        repo.SaveAsync(ct);
        return room.entity;
    }
}