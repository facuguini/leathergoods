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
            return db.Select();
        }

        public Category GetById(int id) {
            return db.SelectById(id);
        }

        public void Create(Category category) {
            db.Create(category);
        }

        public void Update(Category category) {
            db.UpdateById(category);
        }

        public void Delete(int id) {
            db.DeleteById(id);
        }
    }
}
