using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Business.DomainModels
{
    public class UserRoleView
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual RoleView Role { get; set; }
    }
}
