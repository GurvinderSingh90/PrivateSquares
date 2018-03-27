using System;
using System.Collections.Generic;

namespace PrivateSquares.Data.EntityModels
{
    public class User : IEntityBase
    {
        public User()
        {
            UserRoles = new List<UserRole>();
        }
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string Title { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        public string Photo { get; set; }
        public bool VerifiedPhone { get; set; }
        public bool VerifiedEmail { get; set; }
        public Guid ApprovedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
