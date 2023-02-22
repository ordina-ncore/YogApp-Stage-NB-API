using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Rooms;
using YogApp.Domain.SessionParticipants;
using YogApp.Domain.Sessions;

namespace YogApp.Infrastructure.Repositories
{
    public interface ISessionParticipantRepository
    {
        public Task SaveAsync(CancellationToken ct);
        public void AppendChanges(SessionParticipantEntity entity);
        public List<SessionParticipantEntity> GetAll();
        public SessionParticipantEntity? GetById(Guid id);
    }
}
