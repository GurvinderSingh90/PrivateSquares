using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Data.EntityModels
{
    public class Experience : IEntityBase
    {
        public Experience()
        {
            UserID = new User().UserID;
        }
        public int ID { get; set; }
        public virtual Guid UserID { get; set; }
        public string OrgName { get; set; }
        public string Designation { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
