using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Sessions;

namespace YogApp.Infrastructure.Repositories
{
    public interface ISessionRepository
    {
        public List<SessionEntity> GetAll();
    }
}
