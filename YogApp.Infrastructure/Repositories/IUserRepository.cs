using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Users;

namespace YogApp.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public List<UserEntity> GetAll();
    }
}
