using LuftBornTask.Domain.Helpers;
using LuftBornTask.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LuftBornTask.Services.IServices
{
    public interface IGenericService<T> where T : class
    {
        PagingList<T> GetEntity(PagingDataDto data);
        T GetEntityById(int Id);
        void CreateEntity(T entity);
        void CreateRangeEntity(IEnumerable<T> entity);
        void UpdateEntity(T entity);
        void UpdateRangeEntity(IEnumerable<T> entity);
        void DeleteEntity(int Id);
        void DeleteRangeEntity(IEnumerable<int> listIds);
    }
}
