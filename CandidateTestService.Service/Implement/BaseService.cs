using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using CandidateTestService.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTestService.Service.Implement
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected ServiceResult _serviceResult;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }

        public ServiceResult Add(TEntity entity)
        {
            try
            {
                int rowAffect = _baseRepository.Add(entity);
                _serviceResult.Response = new ResponseModel(2001, "OK", rowAffect);
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public ServiceResult Delete(Guid id)
        {
            try
            {
                int rowAffect = _baseRepository.Delete(id);
                _serviceResult.Response = new ResponseModel(2001, "OK", rowAffect);
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public ServiceResult GetAll()
        {
            try
            {
                var entitys = _baseRepository.GetAll();
                if (entitys.Count > 0)
                {
                    _serviceResult.Response = new ResponseModel(2000, "OK", entitys);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(2004, "No data or end of list data");
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public ServiceResult GetById(Guid id)
        {
            try
            {
                var entity = _baseRepository.GetById(id);
                if (entity !=  null)
                {
                    _serviceResult.Response = new ResponseModel(2000, "OK", entity);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(2004, "No data or end of list data");
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public ServiceResult Update(TEntity entity, Guid id)
        {
            try
            {
                int rowAffect = _baseRepository.Update(entity, id);
                _serviceResult.Response = new ResponseModel(2001, "OK", rowAffect);
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }
    }
}
