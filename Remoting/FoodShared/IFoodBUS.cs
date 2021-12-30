using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShared
{
    public interface IFoodBUS
    {
        List<Food> GetAll();
        List<Food> Seacrh(String keyword);
        Food GetFoodDetails(int Id);
        bool AddNewFood(Food newfood);
        bool UpdateFood(Food food);
        bool DeleteFood(int Id);
    }
}
