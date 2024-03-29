﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
        public interface IRepository<TEntity> : IDisposable where TEntity : class
        {
            Task Add(TEntity entity);
            Task<TEntity> GetById(Guid id);
            Task<List<TEntity>> GetAll();
            Task Update(TEntity entity);
            Task Delete(Guid id);        
            Task<int> SaveChanges();
        }    
}
