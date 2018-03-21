using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Data.EntityModels
{
    public class Error : IEntityBase
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
