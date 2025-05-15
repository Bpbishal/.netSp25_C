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
            
        }
        public List<Category> Get() { 
            return new List<Category>();
        }
        public Category Get(int id) { 
            return new Category();
        }
        public void Delete(int id) { 
            
        }

        public void Update(Category c) { 
        
        }
    }
}
