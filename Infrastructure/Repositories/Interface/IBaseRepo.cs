﻿using Infrastructure.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interface
{
    public interface IBaseRepo<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);

        Task<T> GetDefault(Expression<Func<T, bool>> expression = null);
        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression=null);
        Task<T> GetDefaultIncluding(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<bool> Any(Expression<Func<T, bool>> expression);

        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select,
                                                         Expression<Func<T, bool>> where,
                                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select,
                                                         Expression<Func<T, bool>> where,
                                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    }
}
