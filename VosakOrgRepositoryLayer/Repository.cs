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
        private readonly VosakRepoDBContext _dbContext;
        private readonly DbSet<T> _entities;

        public Repository(VosakRepoDBContext dbContext)
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
    }
}
