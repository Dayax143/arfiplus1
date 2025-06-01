using ARFI_POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARFI_POS
{
    public partial class uCustomer : UserControl
    {
        sharedClass main = new sharedClass();
        public uCustomer()
        {
            InitializeComponent();
        }

        private void uCustomer_Load(object sender, EventArgs e)
        {
            main.displayData(dgvCustomer, "tblCustomer", "customer_id");
        }

        arfiplusDBDataContext db = new arfiplusDBDataContext();

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into tblCustomer (customer_name,customer_phone,customer_address,date,cust_level,loanLimit,last_update) " +
                    "values(@customername,@customerphone,@customeraddress,@date,@cust_level,@loanLimit,@last_update)", main.con);
                cmd.Parameters.AddWithValue("@customername", txtName.Text);
                cmd.Parameters.AddWithValue("@customerphone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@customeraddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@cust_level", cmbLevel.Text);
                cmd.Parameters.AddWithValue("@loanLimit", float.Parse(txtLoanLimit.Text));
                cmd.Parameters.AddWithValue("@last_update", DateTime.Now);
                main.con.Open();
                cmd.ExecuteNonQuery();

                //tblCustomer tblCustomer = new tblCustomer
                //{
                //    customer_name = txtName.Text,
                //    customer_phone = txtPhone.Text,
                //    customer_address = txtAddress.Text,
                //    date = DateTime.Now,
                //};
                //db.tblCustomers.InsertOnSubmit(tblCustomer);
                //db.SubmitChanges();

                main.displayData(dgvCustomer, "tblCustomer", "customer_id");

                MessageBox.Show("Successfully Inserted");
            }
            catch (Exception ex)
            {
                // Transaction will not be completed, automatically rolling back
                MessageBox.Show("Failed to insert: " + ex.Message);
            }
            finally
            {
                main.con.Close();
            }
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Ask user for confirmation to update
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this customer ?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Find the customer to update
                    tblCustomer customerToUpdate = db.tblCustomers
                    .FirstOrDefault(c => c.customer_id == int.Parse(cbbCustomerId.Text));

                    if (customerToUpdate != null)
                    {
                        // Update the properties
                        customerToUpdate.customer_name = txtName.Text;
                        customerToUpdate.customer_phone = txtPhone.Text;
                        customerToUpdate.customer_address = txtAddress.Text;
                        customerToUpdate.last_update = DateTime.Now;
                        customerToUpdate.loanLimit = float.Parse(txtLoanLimit.Text);
                        customerToUpdate.cust_level = cmbLevel.Text;

                        // Submit the changes
                        db.SubmitChanges();

                        main.displayData(dgvCustomer, "tblCustomer", "customer_id");

                        MessageBox.Show("Successfully Updated");
                    }
                    else
                    {
                        MessageBox.Show("Customer not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update: " + ex.Message);
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this customer ?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Find the customer to delete
                    tblCustomer customerToDelete = db.tblCustomers
                    .FirstOrDefault(c => c.customer_id == int.Parse(cbbCustomerId.Text));

                    if (customerToDelete != null)
                    {
                        // Delete the record
                        db.tblCustomers.DeleteOnSubmit(customerToDelete);
                        db.SubmitChanges();

                        main.displayData(dgvCustomer, "tblCustomer", "customer_id");

                        MessageBox.Show("Successfully Deleted");
                    }
                    else
                    {
                        MessageBox.Show("Customer not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete: " + ex.Message);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            cbbCustomerId.ResetText();
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtFind.Clear();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbCustomerId.Text = dgvCustomer.Rows[e.RowIndex].Cells[0].Value?.ToString();
                txtName.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value?.ToString();
                txtPhone.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value?.ToString();
                txtAddress.Text = dgvCustomer.Rows[e.RowIndex].Cells[3].Value?.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        public void filterData()
        {
            try
            {
                var filtered = db.tblCustomers.OrderByDescending(id => id.customer_id).Where(name => name.customer_name.Contains(txtFind.Text.ToString())).ToList();
                dgvCustomer.DataSource= filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            filterData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
