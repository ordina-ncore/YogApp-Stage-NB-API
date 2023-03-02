using GraphQL;
using LanguageExt.Pretty;
using Realms.Sync.Exceptions;
using YogApp.API.Schema.Mutations.Inputs;
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

            if (input.Capacity > selectedRoom.Capacity)
            {
                throw new ParticipantsExceedRoomCapacityException();
            };

            if (input.StartDateTime < DateTime.UtcNow)
            {
                throw new SessionCanNotBeInThePastException();
            };

            if (input.StartDateTime > input.EndDateTime)
            {
                throw new SessionStartTimeBeforeSessionEndtimeException();
            }

            TimeSpan minimumDuration = new TimeSpan(0, 15, 0); // 15 minutes
            TimeSpan sessionDuration = input.EndDateTime - input.StartDateTime;
            if (sessionDuration < minimumDuration)
            {
                
                throw new SessionTooShortException();
            }

            // hier error throwen voor participants exceedroomcapacity
            SessionDomain session = SessionDomain.Create(input.Title, input.StartDateTime, input.EndDateTime, input.Capacity, userRepo.GetById(input.TeacherId), selectedRoom);
            sessionRepo.AppendChanges(session.entity);
            sessionRepo.SaveAsync(ct);
            return session.entity;
        }
    }

    public class RoomUnavailableException : Exception
    {
        public RoomUnavailableException() : base("The selected room is unavailable during the chosen timeslot")
        {
        }
    }
    public class ParticipantsExceedRoomCapacityException : Exception
    {
        public ParticipantsExceedRoomCapacityException() : base("The maximum number of participants exceeds the capacity of the selected room")
        {
        }
    }
    public class SessionCanNotBeInThePastException : Exception
    {
        public SessionCanNotBeInThePastException() : base("You can not create a session in the past")
        {
        }
    }
    public class SessionTooShortException : Exception
    {
        public SessionTooShortException() : base("A session must at least be 15 minutes long")
        {
        }
    }
    public class SessionStartTimeBeforeSessionEndtimeException : Exception
    {
        public SessionStartTimeBeforeSessionEndtimeException() : base("The session must end after it has started")
        {
        }
    }
    public class NoRoomSelectedException : Exception
    {
        public NoRoomSelectedException() : base("Please select a room")
        {
        }
    }
}
