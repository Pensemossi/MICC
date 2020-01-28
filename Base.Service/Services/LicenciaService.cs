﻿using Base.Data.Infrastructure;
using Base.Data.Repositories;
using Base.Model.Dtos;
using Base.Model.Models;
using Base.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Service.Services
{
   
    public class LicenciaService : EntityService<Licencia>, ILicenciaService
    {
        public LicenciaService(IUnitOfWork unitOfWork, ILicenciaRepository repository) : base(unitOfWork, repository)
        {

        }

      

    }

    public interface ILicenciaService : IEntityService<Licencia>
    {

       
    }
}
