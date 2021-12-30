using FoodShared;
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
        const String uri = "tcp://127.0.0.1:1234/xxx";
        IFoodBUS ifoodBUS = (IFoodBUS)Activator.GetObject(typeof(IFoodBUS), uri);
        public FoodForm()
        {
            InitializeComponent();
        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            List<Food> foodlist = ifoodBUS.GetAll();
            gridFood.DataSource = foodlist;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<Food> foodList = ifoodBUS.Seacrh(keyword);
            gridFood.DataSource = foodList;
        }

        private void gridFood_SelectionChanged(object sender, EventArgs e)
        {
            if (gridFood.SelectedRows.Count > 0)
            {
                int id = int.Parse(gridFood.SelectedRows[0].Cells["ID"].Value.ToString());
                Food food = ifoodBUS.GetFoodDetails(id);
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Food newfood = new Food()
            {
                Id = 0,
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Description = txtDes.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim()),
                Amount = int.Parse(txtAmount.Text.Trim()),
                Status = txtStatus.Text.Trim(),
            };
            bool result = ifoodBUS.AddNewFood(newfood);
            if (result)
            {
                List<Food> foodList = ifoodBUS.GetAll();
                gridFood.DataSource = foodList;
            }
            else MessageBox.Show("Add failed");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Food newfood = new Food()
            {
                Id = int.Parse(txtId.Text.Trim()),
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Description = txtDes.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim()),
                Amount = int.Parse(txtAmount.Text.Trim()),
                Status = txtStatus.Text.Trim(),
            };
            bool result = ifoodBUS.UpdateFood(newfood);
            if (result)
            {
                List<Food> foodList = ifoodBUS.GetAll();
                gridFood.DataSource = foodList;
            }
            else MessageBox.Show("Update failed");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int id = int.Parse(txtId.Text.Trim());
                bool result = ifoodBUS.DeleteFood(id);
                if (result)
                {
                    List<Food> foodList = ifoodBUS.GetAll();
                    gridFood.DataSource = foodList;
                }
                else MessageBox.Show("Delete failed");
            }
        }
    }
}
