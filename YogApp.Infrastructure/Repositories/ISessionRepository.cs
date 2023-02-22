using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;
using YogApp.Domain.Sessions;

namespace YogApp.Infrastructure.Repositories
{
    public interface ISessionRepository
    {
        public Task SaveAsync(CancellationToken ct);
        public void AppendChanges(SessionEntity entity);
        public List<SessionEntity> GetAll();
        public SessionEntity? GetById(Guid id);
    }
}
