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
    public partial class frmCustomer : Form
    {
        sharedClass shared = new sharedClass();

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            try
            {
                var dataTable = db.tblCustomers
                                    .Where(p => p.customer_phone == txtSearch.Text)
                                    .Select(p => new { p.customer_id, p.customer_name, p.customer_address })
                                    .FirstOrDefault();
                if (dataTable != null)
                {
                    txtName.Text = dataTable.customer_name.ToString();
                    txtId.Text = dataTable.customer_id.ToString();
                    txtAddress.Text = dataTable.customer_address.ToString();

                }
                else { }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        arfiplusDBDataContext db = new arfiplusDBDataContext();
        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void clearData()
        {
            try
            {
                txtId.Clear();
                txtName.Clear();
                txtPhone.Clear();
                txtSearch.Clear();
                txtAddress.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var oo = db.tblSales.Where(s => s.item_name == textBox1.Text).ToList();
                dataGridView1.DataSource = oo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                tblCustomer customer = new tblCustomer
                {
                    customer_name = txtName.Text.ToString(),
                    customer_phone = txtPhone.Text.ToString(),
                    customer_address = txtAddress.Text.ToString(),
                    date = DateTime.Now,
                    loanLimit = string.IsNullOrWhiteSpace(txtLoanLimit.Text) ? 0 : int.Parse(txtLoanLimit.Text),
                    cust_level = cmbLevel.Text,
                };

                db.tblCustomers.InsertOnSubmit(customer);
                db.SubmitChanges();

                MessageBox.Show("Successfully inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                // Query the database for product details
                var productDetails = db.tblSales
                                      .Where(a => a.customer_id.Equals(txtId.Text))
                                      .Select(p => new { p.sale_id, p.quantity, p.netPrice, p.item_name })
                                      .ToList(); // Convert to list

                // Bind data to DataGridView
                dataGridView1.DataSource = productDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            //try
            //{
            //    string query = "select item_name,quantity,date,status from tblSales where customer_id=" + txtId.Text + "";
            //    SqlCommand cmd = new SqlCommand(query, shared.con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dataTable = new DataTable();
            //    da.Fill(dataTable);
            //    dataGridView1.DataSource = dataTable;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
