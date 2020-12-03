using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_MVC_WebApplication.Core;
using Enterprise_MVC_WebApplication.Core.Interface;

namespace Enterprise_MVC_WebApplication.Infra
{
    public class Enterprise_MVC_Repository :IEnterprise_MVC_CoreRepository
    {
        TestEntities context = new TestEntities();

        public void Add(Core.Enterprise_MVC_Core o)
        {
            Infra.Enterprise_MVC_Core _o = new Enterprise_MVC_Core()
            {
                ID = o.ID,
                Name = o.Name,
                Age = o.Age
            };

            context.Enterprise_MVC_Core.Add(_o);
            context.SaveChanges();
        }

        public void Edit(Core.Enterprise_MVC_Core _o)
        {
            Enterprise_MVC_Core o = new Enterprise_MVC_Core()
            {
                ID = _o.ID,
                Name = _o.Name,
                Age = _o.Age
            };
            context.Entry(o).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Core.Enterprise_MVC_Core FindById(int ID)
        {
            var _o = context.Enterprise_MVC_Core.Find(ID);
            Core.Enterprise_MVC_Core o = new Core.Enterprise_MVC_Core()
            {
                ID = _o.ID,
                Name = _o.Name,
                Age = _o.Age.Value
            };
            return o; 
        }

        public IEnumerable<Core.Enterprise_MVC_Core> GetData()
        {
            //var testDB = context.Database.Connection.State;
            var _o = context.Enterprise_MVC_Core.ToList();
                        
            IEnumerable<Core.Enterprise_MVC_Core> o =
                from t in _o select new Core.Enterprise_MVC_Core() {
                    ID = t.ID,
                    Name = t.Name,
                    Age = t.Age.Value };
            return o;
        }

        public void Remove(int ID)
        {
            var _o = context.Enterprise_MVC_Core.Find(ID);
            Enterprise_MVC_Core o = new Enterprise_MVC_Core() {
                ID = _o.ID,
                Name = _o.Name,
                Age = _o.Age
            };
            context.Enterprise_MVC_Core.Remove(o);
        }
    }
}
