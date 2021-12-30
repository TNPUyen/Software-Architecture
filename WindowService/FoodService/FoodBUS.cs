using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShared;

namespace FoodService
{
    class FoodBUS : MarshalByRefObject, IFoodBUS
    {
        public List<Food> GetAll()
        {
            List<Food> foodList = new FoodDAO().SelectAll();
            return foodList;
        }

        public List<Food> Seacrh(String keyword)
        {
            List<Food> foodList = new FoodDAO().SelectByKeyword(keyword);
            return foodList;
        }

        public Food GetFoodDetails(int Id)
        {
            Food food = new FoodDAO().SelectByCode(Id);
            return food;
        }

        public bool AddNewFood(Food newfood)
        {
            bool result = new FoodDAO().Insert(newfood);
            return result;
        }

        public bool DeleteFood(int Id)
        {
            bool res = new FoodDAO().Delete(Id);
            return res;
        }
        public bool UpdateFood(Food food)
        {
            bool result = new FoodDAO().Update(food);
            return result;
        }

    }
}
