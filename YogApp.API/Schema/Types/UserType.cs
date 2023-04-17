using Microsoft.Graph;
using YogApp.Domain.Users;

namespace YogApp.API.Schema.Types
{
    public class UserType : ObjectType<User>
    {

        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Name("User");
            descriptor.Field(x => x.AzureId);
            descriptor.Field(x => x.FirstName);
            descriptor.Field(x => x.LastName);
            descriptor.Field(x => x.ProfilePicture);
        }

    }
}

