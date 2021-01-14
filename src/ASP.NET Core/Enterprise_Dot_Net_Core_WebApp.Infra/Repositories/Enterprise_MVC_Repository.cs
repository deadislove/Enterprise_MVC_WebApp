﻿using System.Collections.Generic;
using System.Linq;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Infra.DBContext;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories
{
    public class Enterprise_MVC_Repository : IEnterprise_MVC_CoreRepository
    {
        private readonly DemoDbContext db;

        public Enterprise_MVC_Repository(DemoDbContext _db)
        {
            this.db = _db;
        }

        public void Add(Enterprise_MVC_Core o)
        {
            db.Add<Enterprise_MVC_Core>(o);
            db.SaveChanges();
        }

        public void Edit(Enterprise_MVC_Core o)
        {
            db.Entry(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();            
        }

        public Enterprise_MVC_Core FindById(int ID) => db.Set<Enterprise_MVC_Core>().Find(ID);


        public IEnumerable<Enterprise_MVC_Core> GetData() => db.Set<Enterprise_MVC_Core>().ToList();


        public void Remove(int ID)
        {
            var _o = db.Set<Enterprise_MVC_Core>().Find(ID);
            if (_o != null)
            {
                db.Set<Enterprise_MVC_Core>().Remove(_o);
                db.SaveChanges();
            }
        }
    }
}
