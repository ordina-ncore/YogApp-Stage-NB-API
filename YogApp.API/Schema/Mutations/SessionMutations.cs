using GraphQL;
using LanguageExt.Pretty;
using Realms.Sync.Exceptions;
using YogApp.API.Schema.Mutations.Inputs;
using YogApp.Domain.Exceptions;
using YogApp.Domain.Rooms;
using YogApp.Domain.Sessions;
using YogApp.Domain.Users;
using YogApp.Infrastructure.Repositories;

namespace YogApp.API.Schema.Mutations
{
    [MutationType]
    public class SessionMutations
    {
        [Error(typeof(RoomUnavailableException))]
        [Error(typeof(ParticipantsExceedRoomCapacityException))]
        [Error(typeof(SessionCanNotBeInThePastException))]
        [Error(typeof(SessionTooShortException))]
        [Error(typeof(NoRoomSelectedException))]
        public SessionEntity CreateSession([Service] ISessionRepository sessionRepo, [Service] IUserRepository userRepo, [Service] IRoomRepository roomRepo, CreateSessionInput input, CancellationToken ct)
        {
            RoomEntity? selectedRoom = roomRepo.GetById(input.RoomId);
            if(selectedRoom == null) { throw new NoRoomSelectedException(); }

            if (!roomRepo.CheckAvailability(selectedRoom, input.StartDateTime, input.EndDateTime))
            {
                throw new RoomUnavailableException();
            };

            // hier error throwen voor participants exceedroomcapacity
            SessionDomain session = SessionDomain.Create(input.Title, input.StartDateTime, input.EndDateTime, input.Capacity, userRepo.GetById(input.TeacherId), selectedRoom);
            sessionRepo.AppendChanges(session.entity);
            sessionRepo.SaveAsync(ct);
            return session.entity;
        }
    }

}
