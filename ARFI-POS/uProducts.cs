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
    public partial class uProducts : UserControl
    {
        sharedClass main = new sharedClass();
        public uProducts()
        {
            InitializeComponent();
        }

        float cost, price = 0;
        public void validatePrice()
        {
            try
            {
                cost = float.Parse(cbbPriceIn.Text);
                price = float.Parse(cbbPriceOut.Text);

                if (cost >= price)
                {
                    MessageBox.Show("There is a mismatch in cost! cost must be less than selling price");
                }
                else
                {
                    MessageBox.Show("Validated! you can save it");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                main.con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblProduct (product_name, product_type, quantity, barcode, cost, price, date) VALUES (@product_name, @product_type, @quantity, @barcode, @cost, @price, @date)", main.con))
                {
                    cmd.Parameters.AddWithValue("@product_name", cbbName.Text.ToString());
                    cmd.Parameters.AddWithValue("@product_type", cbbType.Text.ToString());
                    cmd.Parameters.AddWithValue("@quantity", cbbQuantity.Text);
                    cmd.Parameters.AddWithValue("@barcode", cbbBarcode.Text);
                    cmd.Parameters.AddWithValue("@cost", cost);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@supplierId", cbbSupplierId.Text);

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

        arfiplusDBDataContext db = new arfiplusDBDataContext();
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this product ?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Find the product to update
                    tblProduct productToUpdate = db.tblProducts
                    .FirstOrDefault(p => p.product_id == int.Parse(cbbProductId.Text));

                    if (productToUpdate != null)
                    {
                        // Update the properties
                        productToUpdate.product_name = cbbName.Text;
                        productToUpdate.product_type = cbbType.Text;
                        productToUpdate.quantity = int.Parse(cbbQuantity.Text);
                        productToUpdate.barcode = int.Parse(cbbBarcode.Text);
                        productToUpdate.cost = float.Parse(cbbPriceIn.Text);
                        productToUpdate.price = float.Parse(cbbPriceOut.Text);
                        productToUpdate.date = DateTime.Now;
                        productToUpdate.supplier_id = int.Parse(cbbSupplierId.Text);
                        productToUpdate.last_update = DateTime.Now;

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

        public void filterData()
        {
            try
            {
                var filtered = db.tblProducts
                    .Where(s => s.product_name.Contains(txtFind.Text))
                    .ToList();

                dgvProduct.DataSource = filtered;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbbProductId.Text = dgvProduct.Rows[e.RowIndex].Cells[0].Value?.ToString();
                cbbName.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value?.ToString();
                cbbType.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value?.ToString();
                cbbQuantity.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value?.ToString();
                cbbBarcode.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value?.ToString();
                cbbPriceIn.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value?.ToString();
                cbbPriceOut.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value?.ToString();
                cbbSupplierId.Text = dgvProduct.Rows[e.RowIndex].Cells[7].Value?.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            filterData();
        }

        public void loadData()
        {
            try
            {
                var suppliers = db.tblSuppliers
                        .Select(s => new { s.supplier_id, s.supplier_name })
                        .ToList();

                // Bind Supplier IDs to the first ComboBox
                cbbSupplierId.DataSource = suppliers;
                cbbSupplierId.DisplayMember = "supplier_id"; // Show supplier IDs
                cbbSupplierId.ValueMember = "supplier_id"; // Selected value

                // Bind Supplier Names to the second ComboBox
                cbbSupplierName.DataSource = suppliers;
                cbbSupplierName.DisplayMember = "supplier_name"; // Show supplier names
                cbbSupplierName.ValueMember = "supplier_id"; // Selected value (matches supplier ID)

                var loadProducts = db.tblProducts.OrderByDescending(id => id.product_id).ToList();

                //cbbSupplierName.DataSource= filtered;
                //cbbSupplierId.DataSource = filtered;

                dgvProduct.DataSource = loadProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uProducts_Load(object sender, EventArgs e)
        {
            //main.displayData(dgvProduct, "tblProduct", "product_id");
            loadData();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this product ?", "Confirmation", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    // Find the product to update
                    tblProduct deleteProduct = db.tblProducts
                    .FirstOrDefault(p => p.product_id == int.Parse(cbbProductId.Text.ToString()));

                    db.tblProducts.DeleteOnSubmit(deleteProduct);

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

        private void btnValidate_Click(object sender, EventArgs e)
        {
            validatePrice();
        }

        public void clearData()
        {
            cbbProductId.ResetText();
            cbbName.ResetText();
            cbbType.ResetText();
            cbbQuantity.ResetText();
            cbbBarcode.ResetText();
            cbbPriceIn.ResetText();
            cbbPriceOut.ResetText();
            cbbSupplierId.ResetText();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier supplier = new frmSupplier();
            supplier.ShowDialog();
        }
    }
}
