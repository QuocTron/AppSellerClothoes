using ClothingSellManager.DAO;
using ClothingSellManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClothingSellManager
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        bool Login(string userName ,string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }
        private bool CheckValueLogin()
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Nhập tên đăng nhập");
                return false;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Nhập mật khẩu");
                return false;
            }
            return true;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckValueLogin())
            {
                string userName = txtUserName.Text;
                string pasWord = txtPass.Text;
                if (Login(userName, pasWord))
                {
                    AccountDTO accountDTO = AccountDAO.Instance.GetAccountIDNhanVien(userName);
                    FManagerSellClothing f = new FManagerSellClothing(accountDTO);
                    object postion = AccountDAO.Instance.NamePosition(userName);
                    if (MessageBox.Show("Truy cập với quyền của " + postion.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản đăng nhập");
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ckbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienMatKhau.Checked == true)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}
