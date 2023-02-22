using YogApp.Domain.Rooms;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Users;

namespace YogApp.API.Schema.Mutations.Inputs
{
    public class CreateSessionInput
    {
        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int Capacity { get; set; }

        public UserEntity Teacher { get; set; }

        public RoomEntity Room { get; set; }
    }
}
