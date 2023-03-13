using YogApp.Domain.Users;

namespace YogApp.API.Schema.Types
{
    public class UserType : ObjectType<UserEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<UserEntity> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Name("User");
            descriptor.Field(x => x.AzureId);
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.FirstName);
            descriptor.Field(x => x.LastName);
            descriptor.Field(x => x.ProfilePicture);
            descriptor.Field(x => x.BirthDate);
            descriptor.Field(x => x.IsAdmin);
        }
    }

}
