using YogApp.Domain.Users;

namespace YogApp.API.Schema.Mutations.Inputs
{
    public class CreateSessionParticipantInput
    {

        public int MatNumber { get; set; }
        public Guid SessionId { get; set; }
        public string UserAzureId { get; set; }
    }
}
