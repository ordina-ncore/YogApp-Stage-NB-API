using YogApp.Domain.Sessions;
using YogApp.Domain.Users;

namespace YogApp.API.Schema.Types
{
    public class SessionType : ObjectType<SessionEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<SessionEntity> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Name("Session");
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Title);
            descriptor.Field(x => x.StartDateTime);
            descriptor.Field(x => x.EndDateTime);
            descriptor.Field(x => x.Capacity);
            descriptor.Field(x => x.Teacher);
            descriptor.Field(x => x.TimeStampAdded);
            descriptor.Field(x => x.IsCancelled);
            descriptor.Field(x => x.IsFull);
            descriptor.Field(x => x.Room);
            descriptor.Field(x => x.Participants);
        }
    }
}
