﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wings.Examples.UseCase.Server.Models;

namespace Wings.Examples.UseCase.Server.Services.Repositorys
{
    public class BaseRepository<T> where T:class
    {
        protected AppDbContext appDbContext;

        public BaseRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;

        }
        public async ValueTask<EntityEntry<T>> Insert(T entity)
        {
            return await appDbContext.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            appDbContext.Set<T>().Update(entity);
        }
        public async Task<int> Delete(Expression<Func<T, bool>> whereLambda)
        {
            var removeEntity= await appDbContext.Set<T>().Where(whereLambda).ToListAsync();
              appDbContext.Set<T>().RemoveRange(removeEntity);
            return removeEntity.Count;
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> whereLambda)
        {
            return await appDbContext.Set<T>().AnyAsync(whereLambda);
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> whereLambda)
        {
            return await appDbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(whereLambda);
        }

        public async Task<List<T>> Select()
        {
            return await appDbContext.Set<T>().ToListAsync();
        }
        public  IQueryable<T> AsQueryable()
        {
            return  appDbContext.Set<T>();
        }

        public async Task<List<T>> Select(Expression<Func<T, bool>> whereLambda)
        {
            return await appDbContext.Set<T>().Where(whereLambda).ToListAsync();
        }

        public async Task<Tuple<List<T>, int>> Select<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            var total = await appDbContext.Set<T>().Where(whereLambda).CountAsync();

            if (isAsc)
            {
                var entities = await appDbContext.Set<T>().Where(whereLambda)
                                      .OrderBy<T, S>(orderByLambda)
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).ToListAsync();

                return new Tuple<List<T>, int>(entities, total);
            }
            else
            {
                var entities = await appDbContext.Set<T>().Where(whereLambda)
                                      .OrderByDescending<T, S>(orderByLambda)
                                      .Skip(pageSize * (pageIndex - 1))
                                      .Take(pageSize).ToListAsync();

                return new Tuple<List<T>, int>(entities, total);
            }
        }
    }
}
