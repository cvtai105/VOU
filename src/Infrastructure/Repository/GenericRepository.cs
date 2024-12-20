using Domain.Entities;
using Domain.Repository;
using Domain.Specifications;
using Infrastructure.Data;
using Infrastructure.SpecificationEvaluator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _db;

        #region ctor
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion

        public async Task<T> GetByIdAsync(Guid id)
        {
            T? matchingItem = await _db.Set<T>().FirstOrDefaultAsync(temp => temp.Id == id);

            if (matchingItem == null)
            {
                throw new ArgumentException(nameof(matchingItem));
            }

            return matchingItem;
        }

        public async Task<List<T>> ListAllAsync()
        {
            List<T> matchingItems = await _db.Set<T>().ToListAsync();

            return matchingItems;
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_db.Set<T>().AsQueryable(), spec);
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _db.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.Set<T>().RemoveRange(entities);
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
