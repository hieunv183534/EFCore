using CandidateTestService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Interfaces
{
    public interface IBaseService<TEntity>
    {
        ServiceResult GetById(Guid id);

        ServiceResult GetAll();

        ServiceResult Add(TEntity entity);

        ServiceResult Update(TEntity entity, Guid id);

        ServiceResult Delete(Guid id);
    }
}
