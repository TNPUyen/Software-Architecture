using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FoodSite
{
    /// <summary>
    /// Summary description for FoodService
    /// </summary>
    [WebService(Namespace = "http://projectasp.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FoodService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Food> GetAll()
        {
            List<Food> foodList = new FoodDAO().SelectAll();
            return foodList;
        }

        [WebMethod]
        public List<Food> Search(String keyword)
        {
            List<Food> foodList = new FoodDAO().SelectByKeyword(keyword);
            return foodList;
        }

        [WebMethod]
        public Food GetFoodDetails(int Id)
        {
            Food food = new FoodDAO().SelectByCode(Id);
            return food;
        }

        [WebMethod]
        public bool AddNewFood(Food newfood)
        {
            bool result = new FoodDAO().Insert(newfood);
            return result;
        }

        [WebMethod]
        public bool DeleteFood(int Id)
        {
            bool res = new FoodDAO().Delete(Id);
            return res;
        }

        [WebMethod]
        public bool UpdateFood(Food food)
        {
            bool result = new FoodDAO().Update(food);
            return result;
        }

    }
}
