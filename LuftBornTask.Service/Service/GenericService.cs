using LuftBornTask.Domain;
using LuftBornTask.Domain.Helpers;
using LuftBornTask.Services.Dto;
using LuftBornTask.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LuftBornTask.Services.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<T> _dbset;
        public GenericService(ApplicationDBContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public PagingList<T> GetEntity(PagingDataDto data)
        {
            var entity = _dbset as IQueryable<T>;
            return PagingList<T>.Create(entity, data.PageNumber, data.PageSize);
        }
        public T GetEntityById(int Id)
        {
            return _dbset.Find(Id);
        }
        public void CreateEntity(T entity)
        {
            _dbset.Add(entity);
        }
        public void CreateRangeEntity(IEnumerable<T> entity)
        {
            _dbset.AddRange(entity);
        }
        public void UpdateEntity(T entity)
        {
            _dbset.Update(entity);
        }
        public void UpdateRangeEntity(IEnumerable<T> entity)
        {
            _dbset.UpdateRange(entity);
        }
        public void DeleteEntity(int Id)
        {
            var entity = GetEntityById(Id);
            if (entity != null)
                _dbset.Remove(entity);
        }
        public void DeleteRangeEntity(IEnumerable<int> listIds)
        {
            var entities = new List<T>();
            foreach (var Id in listIds)
            {
                var entity = GetEntityById(Id);
                if (entity != null)
                    entities.Add(entity);
            }
            _dbset.RemoveRange(entities);
        }
    }
}
