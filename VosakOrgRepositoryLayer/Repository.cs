using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VosakOrgDataAccessLayer;

namespace VosakOrgRepositoryLayer
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly VosakOrgDBContext _dbContext;
        private readonly DbSet<T> _entities;

        public Repository(VosakOrgDBContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T Get(int id)
        {
            return _entities.SingleOrDefault(p => p.Id == id);
        }

        public void AddRange(List<T> elementes)
        {
            _entities.AddRange(elementes);
        }

        public void Add(T element)
        {
            _entities.Add(element);
        }
    }
}
