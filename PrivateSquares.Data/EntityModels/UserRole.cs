using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Data.EntityModels
{
    public class UserRole : IEntityBase
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
