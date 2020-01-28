using Base.Data.Infrastructure;
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

    public class VisitaAnexoService : EntityService<VisitaAnexo>, IVisitaAnexoService
    {
        public VisitaAnexoService(IUnitOfWork unitOfWork, IVisitaAnexoRepository repository) : base(unitOfWork, repository)
        {

        }


    }

    public interface IVisitaAnexoService : IEntityService<VisitaAnexo>
    {


    }
}

