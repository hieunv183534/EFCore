using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Repository.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        TEntity GetById(Guid id);

        List<TEntity> GetAll();

        int Add(TEntity entity);

        int Update(TEntity entity, Guid id);

        int Delete(Guid id);
    }
}
