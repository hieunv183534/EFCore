﻿using CandidateTestService.Core.Entities;
using CandidateTestService.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CandidateTestService.Repository.Implement
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DatabaseContext _databaseContext;
        protected readonly string _tableName;
        DbSet<TEntity> _entities;

        public BaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _tableName = typeof(TEntity).Name;
            _entities = (DbSet<TEntity>)typeof(DatabaseContext).GetProperty($"{_tableName}s").GetValue(_databaseContext);
        }

        public int Add(TEntity entity)
        {
            _entities.Add(entity);
            _databaseContext.SaveChanges();
            return _entities.Count();
        }

        public int Delete(Guid id)
        {
            _entities.Remove(GetById(id));
            _databaseContext.SaveChanges();
            return 1;
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> listEntity = _entities.ToList();

            foreach (var entity in listEntity)
            {
                Console.WriteLine(entity.ToString());
            }
            return listEntity;
        }

        public TEntity GetById(Guid id)
        {
            var myEntity = (from entity in _entities where entity.Id == id select entity).FirstOrDefault();
            return myEntity;
        }

        public int Update(TEntity entity, Guid id)
        {
            TEntity myEntity = GetById(id);
            var props = myEntity.GetType().GetProperties();

            foreach (var prop in props)
            {
                var propValue = prop.GetValue(entity);
                if (prop.Name == "Id")
                    continue;
                prop.SetValue(myEntity, propValue);
            }

            _databaseContext.SaveChanges();
            return 1;
        }
    }
}
