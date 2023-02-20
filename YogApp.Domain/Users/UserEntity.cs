using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogApp.Domain.Shared;

namespace YogApp.Domain.Users
{
    public class UserEntity: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public DateOnly BirthDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
