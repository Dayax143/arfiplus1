using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARFI_POS
{
    public partial class uUsers : UserControl
    {
        sharedClass main = new sharedClass();
        public uUsers()
        {
            InitializeComponent();
        }

        arfiplusDBDataContext db = new arfiplusDBDataContext();

        void ex()
        {

            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadData()
        {
            try
            {
                var loadUsers = db.tblUsers.OrderByDescending(m => m.user_id).ToList();
                dataGridView1.DataSource = loadUsers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uUsers_Load(object sender, EventArgs e)
        {
            try
            {
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CbbUser_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString();
                TxtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                TxtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                CbbUsertype.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString();
                CbbQuestion.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value?.ToString();
                TxtAnswer.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value?.ToString();
                CbbStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value?.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                main.con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblUser (username, password, usertype, recoveryQuestion, recoveryAnswer, userStatus,date) VALUES" +
                    " (@username, @password, @usertype, @recoveryQuestion, @recoveryAnswer, @userStatus, @date)", main.con))
                {
                    cmd.Parameters.AddWithValue("@username", TxtUsername.Text.ToString());
                    cmd.Parameters.AddWithValue("@password", TxtPassword.Text.ToString());
                    cmd.Parameters.AddWithValue("@usertype", CbbUsertype.Text);
                    cmd.Parameters.AddWithValue("@recoveryQuestion", CbbQuestion.Text);
                    cmd.Parameters.AddWithValue("@recoveryAnswer", TxtAnswer.Text);
                    cmd.Parameters.AddWithValue("@userStatus", CbbStatus.Text);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    loadData();
                    MessageBox.Show("Successfully inserted ");
                    clearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Not inserted ");
            }
            finally
            {
                main.con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this product ?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Find the product to update
                    tblUser userTable = db.tblUsers
                    .FirstOrDefault(p => p.user_id == int.Parse(CbbUser_id.Text));

                    if (userTable != null)
                    {
                        // Update the properties
                        userTable.userName = TxtUsername.Text;
                        userTable.passWord = TxtPassword.Text;
                        userTable.userStatus = CbbStatus.Text;
                        userTable.usertype = CbbUsertype.Text;
                        userTable.recoveryQuestion = CbbQuestion.Text;
                        userTable.recoveryAnswer = TxtAnswer.Text;
                        userTable.date = DateTime.Now;

                        // Submit the changes
                        db.SubmitChanges();

                        loadData();
                        MessageBox.Show("Updated Successfully");
                        clearData();
                    }
                    else
                    {
                        MessageBox.Show("Product not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update: " + ex.Message);
                MessageBox.Show("Not updated");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this user ?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Find the product to update
                    tblUser deleteUser = db.tblUsers
                    .FirstOrDefault(p => p.user_id== int.Parse(CbbUser_id.Text));

                    db.tblUsers.DeleteOnSubmit(deleteUser);

                    db.SubmitChanges();
                    loadData();
                    MessageBox.Show("Deleted successfully");
                    clearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Not deleted ");
            }
        }

        public void clearData()
        {
            txtSearch.ResetText();
            TxtAnswer.ResetText();
            TxtPassword.ResetText();
            TxtUsername.ResetText();
            CbbQuestion.ResetText();
            CbbStatus.ResetText();
            CbbUsertype.ResetText();
            CbbUser_id.ResetText();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
