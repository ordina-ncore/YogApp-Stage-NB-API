using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Sessions;
using YogApp.Domain.Users;
using YogApp.Infrastructure.Data;

namespace YogApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly YogAppDbContext _context;

        public UserRepository(YogAppDbContext context)
        {
            _context = context;
        }
        public List<UserEntity> GetAll()
        {
            return _context.users.ToList();
        }
    }
}
