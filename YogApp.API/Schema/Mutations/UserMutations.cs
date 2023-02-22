using YogApp.API.Schema.Mutations.Inputs;
using YogApp.Domain.Users;
using YogApp.Infrastructure.Repositories;

namespace YogApp.API.Schema.Mutations;

[MutationType]
public class UserMutations
{
    public UserEntity? CreateUser([Service] IUserRepository repo, CreatUserInput input, CancellationToken ct)
    {
        UserDomain user = UserDomain.Create(input.FirstName, input.LastName, input.ProfilePicture, input.BirthDate);
        repo.AppendChanges(user.entity);
        repo.SaveAsync(ct);
        return user.entity;
    }
}