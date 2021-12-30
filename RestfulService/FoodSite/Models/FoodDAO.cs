using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace FoodSite.Models
{
    class FoodDAO
    {
        //String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        MyDBDataContext db = new MyDBDataContext(ConfigurationManager.ConnectionStrings["strcon"].ConnectionString);
        public List<Food> SelectAll()
        {
            //List<Food> foodList = new List<Food>();
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = " SELECT * FROM Food";
            //SqlCommand com = new SqlCommand(strCom, con);
            //SqlDataReader dr = com.ExecuteReader();
            //while (dr.Read())
            //{
            //    Food food = new Food()
            //    {
            //        Id = (int)dr["Id"],
            //        Name = (String)dr["Name"],
            //        Type = (String)dr["Type"],
            //        Description = (String)dr["Description"],
            //        Price = (int)dr["Price"],
            //        Amount = (int)dr["Amount"],
            //        Status = (String)dr["Status"],
            //    };
            //    foodList.Add(food);
            //}
            //con.Close();
            //return foodList;
            List<Food> foodList = db.Foods.ToList();
            return foodList;
        }

        public List<Food> SelectByKeyword(String keyword)
        {
            //List<Food> foodList = new List<Food>();
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "SELECT * FROM Food WHERE Name LIKE @Keyword";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));
            //SqlDataReader dr = com.ExecuteReader();
            //while (dr.Read())
            //{
            //    Food food = new Food()
            //    {
            //        Id = (int)dr["Id"],
            //        Name = (String)dr["Name"],
            //        Type = (String)dr["Type"],
            //        Description = (String)dr["Description"],
            //        Price = (int)dr["Price"],
            //        Amount = (int)dr["Amount"],
            //        Status = (String)dr["Status"],
            //    };
            //    foodList.Add(food);
            //}
            //con.Close();
            //return foodList;
            List<Food> foodList = db.Foods.Where(x => x.Name.Contains(keyword)).ToList();
            return foodList;
        }

        public Food SelectByCode(int ID)
        {
            //Food food = null;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "SELECT * FROM Food WHERE ID=@ID";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@ID", ID));
            //SqlDataReader dr = com.ExecuteReader();
            //if (dr.Read())
            //{
            //    food = new Food()
            //    {
            //        Id = (int)dr["Id"],
            //        Name = (String)dr["Name"],
            //        Type = (String)dr["Type"],
            //        Description = (String)dr["Description"],
            //        Price = (int)dr["Price"],
            //        Amount = (int)dr["Amount"],
            //        Status = (String)dr["Status"],
            //    };
            //}
            //con.Close();
            //return food;
            Food food = db.Foods.SingleOrDefault(x => x.Id == ID);
            return food;
        }

        public bool Insert(Food newfood)
        {
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "INSERT INTO Food(Name,Type,Description,Price,Amount,Status) VALUES(@Name,@Type,@Description,@Price,@Amount,@Status)";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("@Name", newfood.Name));
            //com.Parameters.Add(new SqlParameter("@Type", newfood.Type));
            //com.Parameters.Add(new SqlParameter("@Description", newfood.Description));
            //com.Parameters.Add(new SqlParameter("@Price", newfood.Price));
            //com.Parameters.Add(new SqlParameter("@Amount", newfood.Amount));
            //com.Parameters.Add(new SqlParameter("@Status", newfood.Status));
            //try
            //{
            //    result = com.ExecuteNonQuery() > 0;
            //}
            //catch
            //{
            //    result = false;
            //}
            //con.Close();
            //return result;
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
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "DELETE FROM Food WHERE ID=@ID";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("Id", Id));
            //try
            //{
            //    result = com.ExecuteNonQuery() > 0;
            //}
            //catch
            //{
            //    result = false;
            //}
            //con.Close();
            //return result;
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
            //bool result = false;
            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //String strCom = "UPDATE Food SET Name=@Name,Type=@Type,Description=@Description,Price=@Price,Amount=@Amount,Status=@Status WHERE ID=@ID";
            //SqlCommand com = new SqlCommand(strCom, con);
            //com.Parameters.Add(new SqlParameter("ID", food.Id));
            //com.Parameters.Add(new SqlParameter("@Name", food.Name));
            //com.Parameters.Add(new SqlParameter("@Type", food.Type));
            //com.Parameters.Add(new SqlParameter("@Description", food.Description));
            //com.Parameters.Add(new SqlParameter("@Price", food.Price));
            //com.Parameters.Add(new SqlParameter("@Amount", food.Amount));
            //com.Parameters.Add(new SqlParameter("@Status", food.Status));
            //try
            //{
            //    result = com.ExecuteNonQuery() > 0;
            //}
            //catch
            //{
            //    result = false;
            //}
            //con.Close();
            //return result;
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
