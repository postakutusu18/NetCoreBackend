using Core.Entities.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Repository
{
   public interface IServiceRepository<TEntity> where TEntity:class,IEntity,new()
    {
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
        IDataResult<List<TEntity>> GetAll();
        IDataResult<TEntity> GetById(int id);
    }
}
