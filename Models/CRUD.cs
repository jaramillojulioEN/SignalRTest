using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using signal_test.Models.dbContext;
namespace signal_test.Models
{
    public class CRUD
    {
        public bool Crear<T>(T model) where T : class
        {
            try
            {
                using (var db = new signaltestEntities())
                {
                    var dbSet = db.Set<T>();
                    dbSet.Add(model);

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> Todos<T>() where T : class
        {
            try
            {
                using (var db = new signaltestEntities())
                {
                    var dbSet = db.Set<T>();
                    return dbSet.ToList();
                }
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }
    }
}