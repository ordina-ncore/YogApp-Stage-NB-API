using HotChocolate.Authorization;
using YogApp.API.Schema.Mutations.Inputs;
using YogApp.Domain.Exceptions;
using YogApp.Domain.Rooms;
using YogApp.Domain.Sessions;
using YogApp.Infrastructure.Repositories;

namespace YogApp.API.Schema.Mutations;

[MutationType]
public static class RoomMutations
{
    [Authorize]
    [Authorize(Roles = new[] {"Teacher"})]
    public static async Task<RoomEntity> CreateRoom([Service] IRoomRepository repo, CreateRoomInput input, CancellationToken ct)
    {
        RoomDomain room = RoomDomain.Create(input.Name, input.Address, input.Capacity, input.Description);
        repo.AppendChanges(room.entity);
        await repo.SaveAsync(ct);
        return room.entity;
    }
    [Authorize(Roles = new[] { "Teacher" })]
    public static async Task<RoomEntity> RemoveRoom([Service] IRoomRepository roomRepo, [Service] ISessionRepository sessionRepository, Guid roomId, CancellationToken ct, [Service] IRoomService roomService)
    {
        RoomEntity? room = roomRepo.GetById(roomId);

        List<SessionEntity> sessionEntities = sessionRepository.GetAllFutureSessionsForRoom(room.Id);
        if (sessionEntities.Count > 0)
        {
            throw new CanNotDeleteRoomIfRoomIsPlannedForUpcomingSessionException();
        }
        room = roomService.RemoveRoom(room);
        await roomRepo.SaveAsync(ct);
        return room;
    } 

    [Authorize(Roles = new[] { "Teacher" })]
    public static async Task<RoomEntity> EditRoom([Service] IRoomRepository roomRepository, [Service] ISessionRepository sessionRepository, EditRoomInput input, CancellationToken ct)
    {
        RoomEntity? selectedRoom = roomRepository.GetById(input.Id);

        if(input.Capacity < selectedRoom.Capacity)
        {
            List<SessionEntity> sessionEntities = sessionRepository.GetAllFutureSessionsForRoom(selectedRoom.Id);
            if(sessionEntities.Count > 0) {
                throw new CanNotReduceCapacityIfRoomIsPlannedForUpcomingSessionException();
            }
        }
        RoomDomain room = RoomDomain.Create(selectedRoom);
        selectedRoom = room.Edit(input.Name, input.Address, input.Capacity, input.Description); //added this line so that there would be a check on domain level

        await roomRepository.SaveAsync(ct);
        return selectedRoom;
    }
}