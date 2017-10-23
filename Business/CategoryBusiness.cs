using System;
using System.Collections.Generic;
using Data;
using Entities;

namespace Business
{
    public class CategoryBusiness
    {
        CategoryData db = new CategoryData();

        public List<Category> GetList() {
            return db.GetList();
        }

        public Category GetById(int id) {
            return db.GetById(id);
        }

        public void Create(Category category) {
            db.Create(category);
        }

        public void Update(Category category) {
            db.Update(category);
        }

        public void Delete(int id) {
            db.Delete(id);
        }
    }
}
