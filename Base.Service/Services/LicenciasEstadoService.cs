using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Data.Infrastructure;
using Base.Data.Repositories;
using Base.Model.Dtos;
using Base.Model.Models;
using Base.Service.Infrastructure;

namespace Base.Service.Services
{
    public class LicenciasEstadoService : EntityService<LicenciasEstado>, ILicenciasEstadoService
    {
        public LicenciasEstadoService(IUnitOfWork unitOfWork, ILicenciasEstadoRepository repository) : base(unitOfWork, repository)
        {

        }
    }
    public interface ILicenciasEstadoService : IEntityService<LicenciasEstado>
    {


    }
}
