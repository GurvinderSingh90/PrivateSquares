using Microsoft.AspNetCore.Mvc;
using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Persistences;
using PrivateSquares.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSquares.Api.Infrastructure.Core
{
    public class ApiControllerBase : Controller
    {
        protected readonly IEntityRepository<Error> _errorsRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public ApiControllerBase(IEntityRepository<Error> errorsRepository, IUnitOfWork unitOfWork)
        {
            _errorsRepository = errorsRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
