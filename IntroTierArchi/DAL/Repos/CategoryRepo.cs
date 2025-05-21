using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CategoryRepo : Repo
    {
        public void Create(Category c) {
            db.Categories.Add(c);
            db.SaveChanges();
        }
        public List<Category> Get() { 
            return db.Categories.ToList();
        }
        public Category Get(int id) { 
            return db.Categories.Find(id);  
        }
        public void Delete(int id) {
            var exobj = Get(id);
            db.Categories.Remove(exobj);
            db.SaveChanges();
        }

        public void Update(Category c) {
            var exobj = Get(c.Id);
            db.Entry(exobj).CurrentValues.SetValues(c);
            db.SaveChanges();

        }
    }
}
