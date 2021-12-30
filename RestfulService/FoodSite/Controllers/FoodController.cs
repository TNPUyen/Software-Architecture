using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FoodSite.Models;

namespace FoodSite.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FoodController : ApiController
    {
        [HttpGet]
        [Route("api/food")]
        public List<Food> GetAll()
        {
            List<Food> foodList = new FoodDAO().SelectAll();
            return foodList;
        }

        [HttpGet]
        [Route("api/food/search/{keyword}")]
        public List<Food> Seacrh(String keyword)
        {
            List<Food> foodList = new FoodDAO().SelectByKeyword(keyword);
            return foodList;
        }

        [HttpGet]
        [Route("api/food/{Id}")]
        public Food GetFoodDetails(int Id)
        {
            Food food = new FoodDAO().SelectByCode(Id);
            return food;
        }

        [HttpPost]
        [Route("api/food")]
        public bool AddNewFood(Food newfood)
        {
            bool result = new FoodDAO().Insert(newfood);
            return result;
        }

        [HttpDelete]
        [Route("api/food/{Id}")]
        public bool DeleteFood(int Id)
        {
            bool res = new FoodDAO().Delete(Id);
            return res;
        }

        [HttpPut]
        [Route("api/food/{Id}")]
        public bool UpdateFood(int Id, Food food)
        {
            if (Id != food.Id) return false;
            bool result = new FoodDAO().Update(food);
            return result;
        }
    }
}