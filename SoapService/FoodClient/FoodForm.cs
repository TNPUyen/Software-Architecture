using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodClient
{
    public partial class FoodForm : Form
    {
        bsite.FoodService foodService = new bsite.FoodService();
        public FoodForm()
        {
            InitializeComponent();
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            List<bsite.Food> foodlist = foodService.GetAll().ToList();
            gridFood.DataSource = foodlist;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<bsite.Food> foodlist = foodService.Search(keyword).ToList();
            gridFood.DataSource = foodlist;
        }

        private void gridFood_SelectionChanged(object sender, EventArgs e)
        {
            if (gridFood.SelectedRows.Count == 1)
            {
                int id = int.Parse(gridFood.SelectedRows[0].Cells["ID"].Value.ToString());
                bsite.Food food = foodService.GetFoodDetails(id);
                if (food != null)
                {
                    txtID.Text = food.Id.ToString();
                    txtName.Text = food.Name;
                    txtType.Text = food.Type;
                    txtDes.Text = food.Description;
                    txtPrice.Text = food.Price.ToString();
                    txtAmount.Text = food.Amount.ToString();
                    txtStatus.Text = food.Status;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bsite.Food food = new bsite.Food()
            {
                Id = 0,
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Description = txtDes.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim()),
                Amount = int.Parse(txtAmount.Text.Trim()),
                Status = txtStatus.Text.Trim(),
            };
            bool result = foodService.AddNewFood(food);
            if (result)
            {
                List<bsite.Food> foodlist = foodService.GetAll().ToList();
                gridFood.DataSource = foodlist;
            }
            else
            {
                MessageBox.Show("Add new food failed");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bsite.Food food = new bsite.Food()
            {
                Id = int.Parse(txtID.Text.Trim()),
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Description = txtDes.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim()),
                Amount = int.Parse(txtAmount.Text.Trim()),
                Status = txtStatus.Text.Trim(),
            };
            bool result = foodService.UpdateFood(food);
            if (result)
            {
                List<bsite.Food> employees = foodService.GetAll().ToList();
                gridFood.DataSource = employees;
            }
            else
            {
                MessageBox.Show("Update failed");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE U SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int id = int.Parse(txtID.Text.Trim());
                bool result = foodService.DeleteFood(id);
                if (result)
                {
                    List<bsite.Food> employees = foodService.GetAll().ToList();
                    gridFood.DataSource = employees;
                }
                else
                {
                    MessageBox.Show("Delete failed");
                }
            }
        }
    }
}
