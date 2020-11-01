using System;
using System.Collections.Generic;
using System.Text;
using VosakOrgDataAccessLayer;

namespace VosakOrgRepositoryLayer
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        
        T Get(int id);

        void AddRange(List<T> elementes);
        
        void Add(T element);
    }
}
