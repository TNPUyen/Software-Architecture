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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Account account = new Account()
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };
            bool result = new AccountBUS().CheckAccount(account);
            if (result)
            {
                new FoodForm().Show();
                this.Hide();
            }
            else { MessageBox.Show("Login failed"); };
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Account newAccount = new Account()
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };
            bool result = new AccountBUS().AddNewAccount(newAccount);
            if (result) MessageBox.Show("Register successful");

        }
    }
}
