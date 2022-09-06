using DataAccess.Context;
using Entities.Abstract;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConcreteRepository
{
    
    public class BaseRepository<T> where T : class,IBaseEntity
    {
        private readonly CodeFirstDBContext _codeFirstDBContext;
        private DbSet<T> _table;
        public BaseRepository(CodeFirstDBContext codeFirstDBContext)
        {
            _codeFirstDBContext = codeFirstDBContext;
            _table = _codeFirstDBContext.Set<T>();
        }
        public bool Add(T entity)
        {
            _table.Add(entity);
            return Save() > 0;
        }
        public bool AddRange(List<T> entities)
        {
            _table.AddRange(entities);
            return Save() > 0;
        }
        public bool Delete(T entity)
        {
            entity.status = Entities.Enums.Status.Deleted;
            return Update(entity);
            //_table.Remove(entity);
            //return Save() > 0;
        }
        public bool Update(T entity)
        {
            _codeFirstDBContext.Entry<T>(entity).State = EntityState.Modified;
            return Save() > 0;
        }
        public List<T> GetAll()
        {
            return _table.Where(x => x.status == Status.Active || x.status == Status.Modified).ToList();
        }
        public T GetById(int id)
        {
            return _table.Find(id);
        }
        public int Save()
        {
            return _codeFirstDBContext.SaveChanges();
        }
    }
}
