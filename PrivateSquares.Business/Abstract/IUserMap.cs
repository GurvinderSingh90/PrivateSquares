using PrivateSquares.Business.DomainModels;
using PrivateSquares.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Business.Abstract
{
    public interface IUserMap
    {
        User AddUserMapping(UserView T);
    }
}
