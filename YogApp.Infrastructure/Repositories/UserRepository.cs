using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;
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
        public void AppendChanges(UserEntity entity)
        {
            _context.users.Add(entity);
        }

        public async Task SaveAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(ct);
        }

        public List<UserEntity> GetAll()
        {
            return _context.users.ToList();
        }

        public UserEntity? GetById(Guid id)
        {
            return _context.users.FirstOrDefault(x => x.Id == id);
        }
        public UserEntity? GetByAzureId(string id)
        {
            return _context.users.FirstOrDefault(x => x.AzureId == id);
        }
    }
}
