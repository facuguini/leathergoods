using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Data
{
    public class CategoryData
    {
        public static List<Category> list = new List<Category>();
        public List<Category> GetList() {
            return list;
        }

        public Category GetById(int id) {
            return list.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Category category) {
            list.Add(category);
        }

        public void Update(Category category) {
            var c = list.FirstOrDefault(x => x.Id == category.Id);
            c = category;
        }

        public void Delete(int id) {
            list.Remove(
                list.FirstOrDefault(x => x.Id == id)
            );
        }
    }
}
