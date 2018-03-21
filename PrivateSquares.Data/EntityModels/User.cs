using System;

namespace PrivateSquares.Data.EntityModels
{
    public class User : IEntityBase
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string Title { get; set; }
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string Photo { get; set; }
        public Guid  EmailVerification { get; set; }
        public Guid ApprovedBy { get; set; }
        public bool IsActived { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifyOn { get; set; }
    }
}
