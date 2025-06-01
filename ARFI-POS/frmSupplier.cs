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
using System.Xml.Linq;

namespace ARFI_POS
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbSupplierId.Text = dgvSupplier.Rows[e.RowIndex].Cells[0].Value?.ToString();

                cbbName.Text = dgvSupplier.Rows[e.RowIndex].Cells[1].Value != null
                    ? dgvSupplier.Rows[e.RowIndex].Cells[1].Value.ToString()
                    : "";

                cbbAddress.Text = dgvSupplier.Rows[e.RowIndex].Cells[3].Value != null
                    ? dgvSupplier.Rows[e.RowIndex].Cells[3].Value.ToString()
                    : "";

                cbbPhone.Text = dgvSupplier.Rows[e.RowIndex].Cells[4].Value != null
                    ? dgvSupplier.Rows[e.RowIndex].Cells[4].Value.ToString()
                    : "";

                txtSupplierDetail.Text = dgvSupplier.Rows[e.RowIndex].Cells[5].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        arfiplusDBDataContext db = new arfiplusDBDataContext();

        public void filterData()
        {
            try
            {
                var filtered = db.tblSuppliers.OrderByDescending(id => id.supplier_id).Where(name => name.supplier_name.Contains(txtFind.Text.ToString())).ToList();

                dgvSupplier.DataSource = filtered;
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
                var loadSupplier = db.tblSuppliers.OrderByDescending(id => id.supplier_id).ToList();

                dgvSupplier.DataSource = loadSupplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            loadData();
        }

        sharedClass main = new sharedClass();

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into tblSupplier (supplier_name,phone_number,address,detail,date) values" +
                    "(@suppliername,@supplierphone,@supplieraddress,@supplierdetail,@date)", main.con);
                cmd.Parameters.AddWithValue("@suppliername", cbbName.Text);
                cmd.Parameters.AddWithValue("@supplierphone", cbbPhone.Text);
                cmd.Parameters.AddWithValue("@supplieraddress", cbbAddress.Text);
                cmd.Parameters.AddWithValue("@supplierdetail", txtSupplierDetail.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                main.con.Open();
                cmd.ExecuteNonQuery();

                //tblSupplier tblSupplier= new tblSupplier
                //{
                //    supplier_name = cbbName.Text,
                //    phone_number = int.Parse(cbbPhone.Text),
                //    address= cbbAddress.Text,
                //    detail=txtSupplierDetail.Text,
                //    date = DateTime.Now,
                //};
                //db.tblSuppliers.InsertOnSubmit(tblSupplier);
                //db.SubmitChanges();

                loadData();
                MessageBox.Show("Successfully Inserted");
                clearData();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this supplier ?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Find the customer to update
                    tblSupplier supplierTable = db.tblSuppliers
                    .FirstOrDefault(c => c.supplier_id == int.Parse(cbbSupplierId.Text));

                    if (supplierTable != null)
                    {
                        // Update the properties
                        supplierTable.supplier_name = cbbName.Text;
                        supplierTable.phone_number = int.Parse(cbbPhone.Text);
                        supplierTable.address = cbbAddress.Text;
                        supplierTable.detail = txtSupplierDetail.Text;
                        supplierTable.date = DateTime.Now;

                        // Submit the changes
                        db.SubmitChanges();

                        loadData();
                        MessageBox.Show("Successfully Updated");
                        clearData();
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
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this supplier ?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Find the customer to delete
                    tblSupplier supplierTable = db.tblSuppliers
                    .FirstOrDefault(c => c.supplier_id == int.Parse(cbbSupplierId.Text));

                    if (supplierTable != null)
                    {
                        // Delete the record
                        db.tblSuppliers.DeleteOnSubmit(supplierTable);
                        db.SubmitChanges();

                        loadData();
                        MessageBox.Show("Successfully Deleted");
                        clearData();
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

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            filterData();
        }

        public void clearData()
        {
            cbbName.ResetText();
            cbbPhone.ResetText();
            cbbAddress.ResetText();
            txtSupplierDetail.ResetText();
            cbbSupplierId.ResetText();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
