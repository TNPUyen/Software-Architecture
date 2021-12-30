using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodSite
{
    public partial class FoodForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Food> employees = new FoodBUS().GetAll();
            gvFoodList.DataSource = employees;
            gvFoodList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<Food> employees = new FoodBUS().Search(keyword);
            gvFoodList.DataSource = employees;
            gvFoodList.DataBind();
        }

        protected void gvFoodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(gvFoodList.SelectedRow.Cells[1].Text.Trim());
            Food food = new FoodBUS().GetFoodDetails(id);
            if (food != null)
            {
                txtId.Text = food.Id.ToString();
                txtName.Text = food.Name;
                txtType.Text = food.Type;
                txtDes.Text = food.Description;
                txtPrice.Text = food.Price.ToString();
                txtAmount.Text = food.Amount.ToString();
                txtStatus.Text = food.Status;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Food food = new Food()
            {
                Id = 0,
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Description = txtDes.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim()),
                Amount = int.Parse(txtAmount.Text.Trim()),
                Status = txtStatus.Text.Trim(),
            };
            bool result = new FoodBUS().AddNewFood(food);
            if (result)
            {
                List<Food> foodlist = new FoodBUS().GetAll();
                gvFoodList.DataSource = foodlist;
                gvFoodList.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Food food = new Food()
            {
                Id = int.Parse(txtId.Text.Trim()),
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Description = txtDes.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim()),
                Amount = int.Parse(txtAmount.Text.Trim()),
                Status = txtStatus.Text.Trim(),
            };
            bool result = new FoodBUS().UpdateFood(food);
            if (result)
            {
                List<Food> foodlist = new FoodBUS().GetAll();
                gvFoodList.DataSource = foodlist;
                gvFoodList.DataBind();
            }
            else
            {
                WebMsgBox.Show("Update Failed!!!");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text.Trim());
            bool result = new FoodBUS().DeleteFood(id);
            if (result)
            {
                List<Food> employees = new FoodBUS().GetAll();
                gvFoodList.DataSource = employees;
                gvFoodList.DataBind();
            }
            else
            {
                WebMsgBox.Show("Can not Delete!");
            }
        }
    }
}