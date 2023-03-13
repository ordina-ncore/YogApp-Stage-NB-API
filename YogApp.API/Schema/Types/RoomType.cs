using YogApp.Domain.Rooms;
using YogApp.Domain.Users;

namespace YogApp.API.Schema.Types
{
    public class RoomType : ObjectType<RoomEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<RoomEntity> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Name("Room");
            descriptor.Field(x => x.Id);
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Address);
            descriptor.Field(x => x.Capacity);
        }
    }
}
