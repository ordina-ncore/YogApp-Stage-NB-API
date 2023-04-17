
using HotChocolate.Authorization;
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
    [Authorize]
    public static class SessionMutations
    {
        [Error(typeof(RoomUnavailableException))]
        [Error(typeof(ParticipantsExceedRoomCapacityException))]
        [Error(typeof(SessionCanNotBeInThePastException))]
        [Error(typeof(SessionTooShortException))]
        [Error(typeof(NoRoomSelectedException))]
        [Authorize(Roles = new[] {"Teacher"})]
        public static async Task<SessionEntity> CreateSession([Service] ISessionRepository sessionRepo, [Service] IRoomRepository roomRepo, CreateSessionInput input, CancellationToken ct)
        {
            RoomEntity? selectedRoom = roomRepo.GetById(input.RoomId);
            if(selectedRoom == null) { throw new NoRoomSelectedException(); }

            if (!roomRepo.CheckAvailability(selectedRoom, input.StartDateTime, input.EndDateTime))
            {
                throw new RoomUnavailableException();
            };

            // hier error throwen voor participants exceedroomcapacity
            SessionDomain session = SessionDomain.Create(input.Title, input.StartDateTime, input.EndDateTime, input.Capacity, input.TeacherId, selectedRoom, null);
            sessionRepo.AppendChanges(session.entity);
            await sessionRepo.SaveAsync(ct);
            return session.entity;
        }

        [Authorize(Roles = new[] { "Teacher" })]
        public static async Task<SessionEntity> CancelSession([Service] ISessionRepository sessionRepo, Guid sessionId, CancellationToken ct, [Service] ISessionService sessionService)
        {
            SessionEntity? session = sessionRepo.GetById(sessionId);
            session = sessionService.CancelSession(session);
            await sessionRepo.SaveAsync(ct);
            return session;
        }

        [Authorize(Roles = new[] { "Teacher" })]
        public static async Task<SessionEntity> EditSession([Service] ISessionRepository sessionRepo, [Service] IRoomRepository roomRepo, EditSessionInput input, CancellationToken ct)
            {
            RoomEntity? selectedRoom = roomRepo.GetById(input.RoomId);
            if (selectedRoom == null) throw new NoRoomSelectedException();
            if (!roomRepo.CheckAvailabilityEditSession(selectedRoom, input.StartDateTime, input.EndDateTime, input.Id)) throw new RoomUnavailableException();

            SessionEntity? existingSession = sessionRepo.GetById(input.Id);
            SessionDomain session = SessionDomain.Create(existingSession);
            existingSession = session.Edit(input.Title, input.StartDateTime, input.EndDateTime, input.Capacity, input.TeacherId, selectedRoom, existingSession.Participants.Count); //added this line so that there would be a check on domain level
            
            await sessionRepo.SaveAsync(ct);
            return existingSession;
        }
    }
}
