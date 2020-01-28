using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Data.Extensions;
using Base.Data.Infrastructure;
using Base.Data.Xml;
using Base.Model.Dtos;
using Base.Model.Models;

namespace Base.Data.Repositories
{
    public class LicenciasEstadoRepository : AdoNetRepository<LicenciasEstado>, ILicenciasEstadoRepository
    {
        public LicenciasEstadoRepository(IAdoNetDbFactory dbFactory, IUnitOfWork uow) : base(dbFactory, uow)
        {

        }

    }

    public interface ILicenciasEstadoRepository : IRepository<LicenciasEstado>
    {

    }
}
