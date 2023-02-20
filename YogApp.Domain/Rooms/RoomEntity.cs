using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Shared;

namespace YogApp.Domain.Rooms
{
    public class RoomEntity: EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
    }
}
