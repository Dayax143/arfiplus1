using POS_VUL;
using System.Windows.Forms;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ARFI_POS
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }


        public void menus()
        {
            uCustomer1.Visible = false;
            uLoan1.Visible = false;
            uSales1.Visible = false;
            uReport1.Visible = false;
            uProducts1.Visible=false;
            uUsers1.Visible = false;

            pnlCustomer.Visible = false;
            pnlLoan.Visible = false;
            pnlProduct.Visible = false;
            pnlSale.Visible = false;
            pnlHome.Visible = false;
            pnlReport.Visible = false;
            pnlUser.Visible = false;
        }

        arfiplusDBDataContext a = new arfiplusDBDataContext();

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            menus();
            //startUp();

            //lblDate.Text = DateTime.Now.ToLongDateString();
            //lblTime.Text = DateTime.Now.ToLongDateString();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            menus();
            uCustomer1.Visible = true;
            pnlCustomer.Visible = true;
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            menus();
            uSales1.Visible = true;
            pnlSale.Visible = true;
        }

        private void optbtn_Click(object sender, EventArgs e)
        {
            if (pnlLeft.Width == 207)
            {
                pnlLeft.Width = 44;
            }
            else
            {
                pnlLeft.Width = 207;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            menus();
            pnlProduct.Visible = true;
            uProducts1.Visible = true;
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            menus();
            pnlLoan.Visible = true;
            uLoan1.Visible= true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            menus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menus();
            pnlReport.Visible= true;
            uReport1.Visible= true;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            menus();
            pnlUser.Visible= true;
            uUsers1.Visible= true;
        }

        //sharedClass main = new sharedClass();
        //public void BackupDatabase()
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Title = "Save Database Backup";
        //    saveFileDialog.Filter = "Backup Files (*.bak)|*.bak";
        //    saveFileDialog.InitialDirectory = @"C:\YourCustomFolder"; // Default folder

        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string backupFilePath = saveFileDialog.FileName;

        //        using (SqlConnection conn = new SqlConnection("Data Source = 172.16.168.212; Initial Catalog = ArfiPlusPerfurmes; Persist Security Info=True; User ID = sa; Password=123;Encrypt=True;TrustServerCertificate=True"))
        //        {
        //            conn.Open();
        //            string query = $"BACKUP DATABASE ArfiPlusPerfurmes TO DISK = '{backupFilePath}'";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show($"Database backup successful!\nSaved to: {backupFilePath}", "Success");
        //        }
        //    }
        //}

        private void btnBackup_Click(object sender, EventArgs e)
        {

        }
    }
}
