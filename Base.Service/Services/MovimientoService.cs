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
   
    public class MovimientoService : EntityService<Movimiento>, IMovimientoService
    {
        public MovimientoService(IUnitOfWork unitOfWork, IMovimientoRepository repository) : base(unitOfWork, repository)
        {

        }

      

    }

    public interface IMovimientoService : IEntityService<Movimiento>
    {

       
    }
}
