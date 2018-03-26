using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Data.EntityModels
{
    public class Role : IEntityBase
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
