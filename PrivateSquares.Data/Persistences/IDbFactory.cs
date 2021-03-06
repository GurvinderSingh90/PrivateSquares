﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Data.Persistences
{
    public interface IDbFactory : IDisposable
    {
        PrivateSquaresDbContext Init();
    }
}
