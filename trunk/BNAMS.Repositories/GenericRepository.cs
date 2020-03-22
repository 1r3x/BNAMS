using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SR.Repositories
{
    public   class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Entities.SmartRecordEntities _db;
        private readonly DbSet<T> _aTable;

        public GenericRepository(SR.Entities.SmartRecordEntities db)
        {
            _db = db;
            _aTable = _db.Set<T>();
        }

        public GenericRepository()
        {
            _db = new SR.Entities.SmartRecordEntities();
            _aTable = _db.Set<T>();
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<T> SelectAll()
         {
            return _aTable.ToList();
        }


        public T SelectedById(object id)
        {
            return _aTable.Find(id);
        }

        public void Insert(T obj)
        {
            _aTable.Add(obj);
        }

        public void Update(T obj)
        {
            _aTable.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var find = _aTable.Find(id);
            if (find != null) _aTable.Remove(find);
            _db.SaveChanges();
        }

        public void Save()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
