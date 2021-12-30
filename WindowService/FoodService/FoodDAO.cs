using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShared;

namespace FoodService
{
    class FoodDAO
    {
        //String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        MyDBDataContext db = new MyDBDataContext(ConfigurationManager.ConnectionStrings["strcon"].ConnectionString);
        public List<Food> SelectAll()
        {
            db.ObjectTrackingEnabled = false;
            List<Food> foodList = db.Foods.ToList();
            return foodList;
        }

        public List<Food> SelectByKeyword(String keyword)
        {
            db.ObjectTrackingEnabled = false;
            List<Food> foodList = db.Foods.Where(x => x.Name.Contains(keyword)).ToList();
            return foodList;
        }

        public Food SelectByCode(int ID)
        {
            db.ObjectTrackingEnabled = false;
            Food food = db.Foods.SingleOrDefault(x => x.Id == ID);
            return food;
        }

        public bool Insert(Food newfood)
        {
            
            try
            {
                db.Foods.InsertOnSubmit(newfood);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int Id)
        {
            
            Food food = db.Foods.SingleOrDefault(x => x.Id == Id);
            if (food != null)
            {
                try
                {
                    db.Foods.DeleteOnSubmit(food);
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool Update(Food currentfood)
        {
           
            Food food = db.Foods.SingleOrDefault(x => x.Id == currentfood.Id);
            if (food != null)
            {
                try
                {
                    food.Name = currentfood.Name;
                    food.Type = currentfood.Type;
                    food.Description = currentfood.Description;
                    food.Price = currentfood.Price;
                    food.Amount = currentfood.Amount;
                    food.Status = currentfood.Status;
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }
    }
}
