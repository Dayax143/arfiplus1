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
    public partial class frmSales : Form
    {
        SqlConnection con = new SqlConnection("Server =172.16.168.212; database =ArfiPlusPerfurmes; USER ID=SA; PASSWORD=123; ");
        SqlCommand cmd;
        string confirmationCompleteInvoice = "are you sure you want to complete this invoice ? ";

        string doInvoice, newInvoice_id, completeInvoice;

        public frmSales()
        {
            InitializeComponent();
        }

        public void getProduct()
        {
            try
            {
                //if (txtSearchProduct.Text != "")
                //{
                //string sql = "select * from tblProduct where " + searchBy.ToString() + "  like '%" + resultBy.ToString() + "%'";
                string sql = "select * from tblProduct where product_name  like '%" + txtSearchProduct.Text + "%'";
                cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                listViewSearch.Items.Clear();
                while (rdr.Read())
                {
                    ListViewItem listViewItem = new ListViewItem(rdr["product_id"].ToString());
                    listViewItem.SubItems.Add(rdr["product_name"].ToString());
                    listViewItem.SubItems.Add(rdr["quantity"].ToString());
                    listViewItem.SubItems.Add(rdr["price"].ToString());
                    //listViewItem.SubItems.Add(rdr["barcode"].ToString());
                    //listViewItem.SubItems.Add(rdr["product_id"].ToString());
                    //txtnetQty.Text = rdr["profit"].ToString();

                    listViewSearch.Items.Add(listViewItem);
                }
                //}
                //else
                //{
                //    listView1.Items.Clear();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "from getProduct FUNCTION");
            }

            finally
            {
                con.Close();
            }
        }

        public void AddCart()
        {
            try
            {
                foreach (ListViewItem item in listViewSearch.SelectedItems)
                {
                    // Check if the item already exists in listView2
                    bool exists = false;
                    foreach (ListViewItem existingItem in listViewCart.Items)
                    {
                        if (existingItem.Text == item.Text) // Compare item text
                        {
                            exists = true;
                            break;
                        }
                    }
                    // Add item only if it doesn't exist
                    if (!exists)
                    {
                        //listViewCart.Items.Add((ListViewItem)item.Clone());

                        ListViewItem defaultQty = (ListViewItem)item.Clone();

                        // Ensure Quantity column (index 2) is set to default "1"
                        defaultQty.SubItems[2].Text = "1";

                        // Add modified item to listView2
                        listViewCart.Items.Add(defaultQty);
                        //listViewCart.Items.Add((ListViewItem)item.Clone());

                    }
                    listViewSearch.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            AddCart();
        }

        private void btnRemoveCart_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewCart.SelectedItems)
            {
                listViewCart.Items.Remove(item);
            }
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer customer = new frmCustomer();
            customer.ShowDialog();
        }

        public void getProduct(string searchBy, string resultBy)
        {
            try
            {
                if (txtSearchProduct.Text != "")
                {
                    string sql = "select * from tblProduct where " + searchBy.ToString() + "  like '%" + resultBy.ToString() + "%'";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    listViewSearch.Items.Clear();
                    while (rdr.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem(rdr["product_id"].ToString());
                        listViewItem.SubItems.Add(rdr["product_name"].ToString());
                        listViewItem.SubItems.Add(rdr["price"].ToString());
                        listViewItem.SubItems.Add(rdr["quantity"].ToString());
                        //listViewItem.SubItems.Add(rdr["barcode"].ToString());
                        //listViewItem.SubItems.Add(rdr["product_id"].ToString());
                        //txtnetQty.Text = rdr["profit"].ToString();

                        listViewSearch.Items.Add(listViewItem);
                    }
                }
                else
                {
                    listViewSearch.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "from getProduct FUNCTION");
            }

            finally
            {
                con.Close();
            }

        }
        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            getProduct();
        }

        private void btnAddCart_Click_1(object sender, EventArgs e)
        {
            AddCart();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                rate = float.Parse(cbbRate.Text.ToString());
                lblShilingRate.Text = rate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listViewCart.SelectedItems)
                {
                    int quantity = 1;
                    quantity = int.Parse(item.SubItems[2].Text); // Assuming quantity is in the second column
                    quantity++; // Increase quantity
                    item.SubItems[2].Text = quantity.ToString(); // Update ListView
                }
                getPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "from IncreaseQty FUNCTION");
            }
        }

        public float rate, discount, totalAmount, quantity, price, itemTotal, checkPayment;

        public void getPrice()
        {
            try
            {
                foreach (ListViewItem item in listViewCart.Items)
                {
                    // Get quantity and price from subitems
                    quantity = float.Parse(item.SubItems[2].Text.ToString()); // Assuming quantity is in column index 1
                    price = float.Parse(item.SubItems[3].Text.ToString()); // Assuming price is in column index 2
                    if (txtDiscount.Text != null)
                    {
                        discount = float.Parse(txtDiscount.Text);
                    }
                    else if (txtDiscount.Text == null)
                    {
                        discount = 0;
                    }

                    // Calculate total for this item
                    itemTotal = quantity * price;
                    // Add to overall total
                    totalAmount += itemTotal;
                }

                // Display total amount
                //MessageBox.Show("Total Amount: " + totalAmount.ToString("C"));
                lblDollar.Text = (totalAmount - discount).ToString();
                lblShiling.Text = ((totalAmount * rate) - discount).ToString();

                lblNetLoan.Text = lblDollar.Text;
                lblNetpaid.Text = lblDollar.Text;

                totalAmount = 0;
                itemTotal = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "from getPrice FUNCTION");
            }
        }


        public float unitCost, unitPrice, netProfit, unitProfit, totalProfit, netQty, netDiscount;
        public void getUnitCost()
        {
            try
            {
                totalProfit = 0; // Reset total profit before calculation

                foreach (ListViewItem item in listViewCart.Items)
                {
                    int productId = int.Parse(item.SubItems[0].Text); // Correctly fetch product ID

                    var productData = db.tblProducts
                                        .Where(p => p.product_id == productId)
                                        .Select(p => new { p.cost, p.price })
                                        .FirstOrDefault();

                    if (productData != null)
                    {
                        unitCost = Convert.ToSingle(productData.cost);
                        unitPrice = float.Parse(item.SubItems[3].Text);
                        netQty = int.Parse(item.SubItems[2].Text);
                        netDiscount = float.Parse(txtDiscount.Text);

                        unitProfit = ((unitPrice * netQty) - (unitCost * netQty) - netDiscount); // Calculate profit for the item
                        totalProfit += unitProfit; // Accumulate total profit
                    }
                    else
                    {
                        MessageBox.Show($"Product ID {productId} not found.");
                    }
                }

                lblNetProfit.Text = totalProfit.ToString(); // Display final total profit outside loop
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in getUnitCost function");
            }
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listViewCart.SelectedItems)
                {
                    int quantity = 1;
                    quantity = int.Parse(item.SubItems[2].Text); // Assuming quantity is in the second column
                    quantity--; // Increase quantity
                    item.SubItems[2].Text = quantity.ToString(); // Update ListView
                }
                getPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getPrice();
        }

        private void btnRemoveCart_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listViewCart.SelectedItems)
                {
                    listViewCart.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        arfiplusDBDataContext db = new arfiplusDBDataContext();
        float zaad, edahab, soltelco, bank, onhand, netPaid, other = 0;

        private void btnSaveSale_Click(object sender, EventArgs e)
        {
            try
            {
                // this code is ok (saved)
                tblPayment tblPayment = new tblPayment
                {
                    netPaid = float.Parse(lblNetpaid.Text),
                    netProfit = float.Parse(lblNetProfit.Text),
                    currency = currency,
                    zaad = zaad,
                    edahab = edahab,
                    onhand = onhand,
                    other = other,
                    bank = bank,
                    soltelco = soltelco,
                    note = txtNote.Text,
                    date = DateTime.Now,
                    discount = discount,
                    invoice_id = db.tblInvoices.Max(i => i.invoice_id),
                    customer_id = db.tblCustomers
                    .Where(c => c.customer_phone.Contains(txtFindCustomer.Text))
                    .Select(c => c.customer_id)
                    .FirstOrDefault()
                };

                db.tblPayments.InsertOnSubmit(tblPayment);
                db.SubmitChanges();
                MessageBox.Show("Payment done");

                // checking this code found(if commented)
                foreach (ListViewItem item in listViewCart.Items)
                {
                    float qty, unit_price, net_unitprice = 0;
                    qty = float.Parse(item.SubItems[2].Text.ToString()); // Assuming quantity is in column index 1
                    unit_price = float.Parse(item.SubItems[3].Text.ToString()); // Assuming price is in column index 2
                    net_unitprice = qty * unit_price;

                    //getPrice();
                    tblSale tblSale = new tblSale
                    {
                        product_id = int.Parse(item.SubItems[0].Text.ToString()),
                        item_name = item.SubItems[1].Text.ToString(),
                        quantity = int.Parse(item.SubItems[2].Text.ToString()),
                        price = float.Parse(item.SubItems[3].Text.ToString()),
                        payment_id = db.tblPayments.Max(i => i.payment_id),
                        invoice_id = db.tblInvoices.Max(i => i.invoice_id),
                        date = DateTime.Now,
                        netPrice = net_unitprice,
                        //unit_profit = unitPrice,
                        capturedAmount = float.Parse(lblNetpaid.Text.ToString()),
                    };
                    db.tblSales.InsertOnSubmit(tblSale);
                    db.SubmitChanges();

                    MessageBox.Show("Your sale");

                    // this code is ok
                    if (chbLoan.Checked == true && chbSale.Checked == false)
                    {
                        tblPayment.paymentStatus = "LOAN";
                        tblSale.status = "LOAN";
                    }
                    else if (chbSale.Checked == true && chbLoan.Checked == false)
                    {
                        tblPayment.paymentStatus = "SALE";
                        tblSale.status = "SALE";

                    }
                    else if (chbLoan.Checked == true && chbSale.Checked == true)
                    {
                        tblPayment.paymentStatus = "PARTIAL PAYMENT";
                        tblSale.status = "PARTIAL PAYMENT";
                    }
                }

                // this code is ok
                foreach (ListViewItem proItem in listViewCart.Items)
                {
                    int productId = int.Parse(proItem.SubItems[0].Text); // Get product ID
                    int soldQuantity = int.Parse(proItem.SubItems[2].Text); // Get sold quantity

                    // Find the product in the database
                    tblProduct product = db.tblProducts.FirstOrDefault(p => p.product_id == productId);

                    if (product != null)
                    {
                        // Update quantity (subtract sold quantity)
                        product.quantity -= soldQuantity;

                        // If quantity reaches zero, remove the product from the database
                        if (product.quantity <= 0)
                        {
                            MessageBox.Show("Your product is empty");
                        }
                    }
                }

                MessageBox.Show("Your product update");
                // Find the invoice you want to update (assuming invoice ID is known)
                tblInvoice invoiceTable = db.tblInvoices
                    .OrderByDescending(i => i.invoice_id)
                    .FirstOrDefault();

                // still found the error even if this code is commented
                if (invoiceTable != null) // Ensure invoice exists
                {
                    invoiceTable.date = DateTime.Now; // Update date
                    invoiceTable.transactionStatus = "Completed"; // Update status

                    db.SubmitChanges(); // Commit changes to the database
                }
                else
                {
                    MessageBox.Show("Invoice not found!");
                }

                MessageBox.Show("Your invoice update");

                db.SubmitChanges();
                MessageBox.Show("Inserted successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not saved" + " from save button", ex.Message + ex.Data);
            }
        }

        public void fetch()
        {
            try
            {
                var dataTable = db.tblCustomers
                                    .Where(p => p.customer_phone == txtFindCustomer.Text)
                                    .Select(p => new { p.customer_name })
                                    .First();
                lblCustomerName.Text = dataTable.customer_name.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                fetch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void uSales_Load(object sender, EventArgs e)
        {

        }

        public void initialTransaction()
        {
            try
            {
                listViewSearch.Items.Clear();
                listViewCart.Items.Clear();
                zaad = 0;
                edahab = 0;
                soltelco = 0;
                bank = 0;
                other = 0;
                onhand = 0;
                netPaid = 0;
                totalProfit = 0;
                itemTotal = 0;
                discount = 0;

                txtDiscount.Clear();
                lblNetpaid.ResetText();
                lblDollar.ResetText();
                lblShiling.ResetText();
                lblNetpaid.ResetText();
                lblNetPrice.ResetText();
                lblOnHand.ResetText();
                lblZaad.ResetText();
                lblEdahab.ResetText();
                lblSoltelco.ResetText();
                lblBank.ResetText();
                lblOther.ResetText();

                //uSales uSales = new uSales();
                //uSales.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnInvoice_Click_1(object sender, EventArgs e)
        {
            InvoiceManage();
            //lblInvoice_id.Text = db.tblInvoices.Max(i => i.invoice_id).ToString();
        }

        public void filtersale()
        {
            try
            {
                if (chbLoan.Checked == true && chbSale.Checked == true)
                {
                    pnlPayment.Visible = true;

                    lblNetpaid.Visible = true;
                    paidLabel.Visible = true;

                    lblNetLoan.Visible = true;
                    loanLabel.Visible = true;
                }
                else if (chbLoan.Checked == true && chbSale.Checked == false)
                {
                    pnlPayment.Visible = false;

                    lblNetLoan.Visible = true;
                    loanLabel.Visible = true;

                    lblNetpaid.Visible = false;
                    paidLabel.Visible = false;
                }
                else if (chbLoan.Checked == false && chbSale.Checked == true)
                {
                    pnlPayment.Visible = true;

                    lblNetLoan.Visible = false;
                    loanLabel.Visible = false;

                    lblNetpaid.Visible = true;
                    paidLabel.Visible = true;
                }
                else if (chbLoan.Checked == false && chbSale.Checked == false)
                {
                    pnlPayment.Visible = false;

                    lblNetLoan.Visible = false;
                    loanLabel.Visible = false;

                    lblNetpaid.Visible = false;
                    paidLabel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        float varPaid = 0;
        public void validateSale()
        {
            try
            {

                varPaid = float.Parse(lblNetpaid.Text);
                if (netPaid > varPaid)
                {
                    MessageBox.Show("You cannot pay more than the required amount");
                    netPaid = varPaid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "from validate function");
            }
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
           validateSale();
        }

        private void pnlPayment_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSavePrint_Click(object sender, EventArgs e)
        {

        }

        private void paidLabel_Click(object sender, EventArgs e)
        {

        }

        private void lblNetLoan_Click(object sender, EventArgs e)
        {

        }

        private void loanLabel_Click(object sender, EventArgs e)
        {

        }

        private void lblNetpaid_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblNetProfit_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblShilingRate_Click(object sender, EventArgs e)
        {

        }

        private void cbbRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listViewSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewCart_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSearchProduct_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click_1(object sender, EventArgs e)
        {

        }

        private void lblEligible_Click(object sender, EventArgs e)
        {

        }

        private void lblCustomerName_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtFindCustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void chbBoth_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblDollar_Click(object sender, EventArgs e)
        {

        }

        private void lblShiling_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblNetPrice_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnValidate_Click_1(object sender, EventArgs e)
        {

        }

        private void pnlAccount_Enter(object sender, EventArgs e)
        {

        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {

        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnOther_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSoltelco_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBank_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEdahab_Click_1(object sender, EventArgs e)
        {

        }

        private void btnZaad_Click_1(object sender, EventArgs e)
        {

        }

        private void btnHand_Click_1(object sender, EventArgs e)
        {

        }

        private void rdbShillings_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void rdbDollars_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void lblOther_Click(object sender, EventArgs e)
        {

        }

        private void lblSoltelco_Click(object sender, EventArgs e)
        {

        }

        private void lblBank_Click(object sender, EventArgs e)
        {

        }

        private void lblEdahab_Click(object sender, EventArgs e)
        {

        }

        private void lblZaad_Click(object sender, EventArgs e)
        {

        }

        private void lblOnHand_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chbLoan_CheckedChanged(object sender, EventArgs e)
        {
            filtersale();  
        }

        private void chbSale_CheckedChanged(object sender, EventArgs e)
        {
            filtersale();
        }

        private void txtSearchProduct_TextChanged_1(object sender, EventArgs e)
        {
            getProduct();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to proceed? ", "Confirmation",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                tblInvoice invoiceTable = db.tblInvoices
                        .OrderByDescending(i => i.invoice_id)
                        .FirstOrDefault();

                // still found the error even if this code is commented
                if (invoiceTable != null) // Ensure invoice exists
                {
                    invoiceTable.date = DateTime.Now; // Update date
                    invoiceTable.transactionStatus = "Canceled"; // Update status

                    db.SubmitChanges(); // Commit changes to the database
                }

                btnInvoice.Text = "New transaction";
                btnInvoice.BackColor = Color.Green;
                btnCancel.Visible = false;
                this.Close();
            }
            else
            {

            }
            db.SubmitChanges();
        }

        private void rdbShillings_CheckedChanged(object sender, EventArgs e)
        {
            //filterAccount();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            getPrice();
            getUnitCost();
            validateSale();
        }

        private void btnApplyRate_Click(object sender, EventArgs e)
        {
            try
            {
                rate = float.Parse(cbbRate.Text.ToString());
                lblShilingRate.Text = rate.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void rdbDollars_CheckedChanged(object sender, EventArgs e)
        {
            //filterAccount();
        }

        private void btnSoltelco_Click(object sender, EventArgs e)
        {
            pnlAccount.Visible = true;
            //lblAccount.Text = "SOLTELCO";
            //txtAccount.ResetText();
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            pnlAccount.Visible = true;
            //lblAccount.Text = "OTHER";
            //txtAccount.ResetText();
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            pnlAccount.Visible = true;
            //lblAccount.Text = "BANK";
            //txtAccount.ResetText();
        }

        private void btnEdahab_Click(object sender, EventArgs e)
        {
            pnlAccount.Visible = true;
            //lblAccount.Text = "EDAHAB";
            //txtAccount.ResetText();
        }

        private void btnZaad_Click(object sender, EventArgs e)
        {
            pnlAccount.Visible = true;
            //lblAccount.Text = "ZAAD";
            //txtAccount.ResetText();
        }

        private void btnHand_Click(object sender, EventArgs e)
        {
            pnlAccount.Visible = true;
            //lblAccount.Text = "ONHAND";
            //txtAccount.ResetText();
        }

        public void calculateNetpaid()
        {
            try
            {
                netPaid = onhand + zaad + edahab + soltelco + bank + other;
                lblNetpaid.Text = netPaid.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            //filterAccount();
            calculateNetpaid();
            txtAccount.ResetText();
        }

        string currency;
        //public void filterAccount()
        //{
        //    try
        //    {
        //        if (lblAccount.Text == "ONHAND")
        //        {
        //            onhand = float.Parse(txtAccount.Text);
        //            lblOnHand.Text = onhand.ToString();
        //        }
        //        if (lblAccount.Text == "ZAAD")
        //        {
        //            zaad = float.Parse(txtAccount.Text);
        //            lblZaad.Text = zaad.ToString();
        //        }
        //        if (lblAccount.Text == "EDAHAB")
        //        {
        //            edahab = float.Parse(txtAccount.Text);
        //            lblEdahab.Text = edahab.ToString();
        //        }
        //        if (lblAccount.Text == "SOLTELCO")
        //        {
        //            soltelco = float.Parse(txtAccount.Text);
        //            lblSoltelco.Text = soltelco.ToString();
        //        }
        //        if (lblAccount.Text == "BANK")
        //        {
        //            bank = float.Parse(txtAccount.Text);
        //            lblBank.Text = bank.ToString();
        //        }
        //        if (lblAccount.Text == "OTHER")
        //        {
        //            other = float.Parse(txtAccount.Text);
        //            lblOther.Text = other.ToString();
        //        }

        //        if (rdbDollars.Checked)
        //        {
        //            currency = "DOLLARS";
        //        }
        //        else if (rdbShillings.Checked)
        //        {
        //            currency = "SHILINGS";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        public void InvoiceManage()
        {
            string confirmationCompleteInvoice = "are you sure you want to complete this invoice ? ";
            string doInvoice, newInvoice_id, completeInvoice;

            newInvoice_id = "select max(invoice_id)+1 from tblInvoice";

            doInvoice = "insert into tblInvoice (date,transactionStatus) values('" + DateTime.Now + "','initialized')";

            //completeInvoice = "update tblInvoice set transactionStatus='completed' where invoice_id=" + cbbInvoice_id.Text + "";

            try
            {
                cmd = new SqlCommand(doInvoice, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                listViewCart.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                // this code is ok (saved)
                tblPayment tblPayment = new tblPayment
                {
                    netPaid = float.Parse(lblNetpaid.Text),
                    netProfit = float.Parse(lblNetProfit.Text),
                    currency = currency,
                    zaad = zaad,
                    edahab = edahab,
                    onhand = onhand,
                    other = other,
                    bank = bank,
                    soltelco = soltelco,
                    note = txtNote.Text,
                    date = DateTime.Now,
                    discount = discount,
                    invoice_id = db.tblInvoices.Max(i => i.invoice_id),
                    customer_id = db.tblCustomers
                    .Where(c => c.customer_phone.Contains(txtFindCustomer.Text))
                    .Select(c => c.customer_id)
                    .FirstOrDefault()
                };

                db.tblPayments.InsertOnSubmit(tblPayment);
                db.SubmitChanges();
                MessageBox.Show("Payment done");

                // checking this code found(if commented)
                foreach (ListViewItem item in listViewCart.Items)
                {
                    float qty, unit_price, net_unitprice = 0;
                    qty = float.Parse(item.SubItems[2].Text.ToString()); // Assuming quantity is in column index 1
                    unit_price = float.Parse(item.SubItems[3].Text.ToString()); // Assuming price is in column index 2
                    net_unitprice = qty * unit_price;

                    //getPrice();
                    tblSale tblSale = new tblSale
                    {
                        product_id = int.Parse(item.SubItems[0].Text.ToString()),
                        item_name = item.SubItems[1].Text.ToString(),
                        quantity = int.Parse(item.SubItems[2].Text.ToString()),
                        price = float.Parse(item.SubItems[3].Text.ToString()),
                        payment_id = db.tblPayments.Max(i => i.payment_id),
                        invoice_id = db.tblInvoices.Max(i => i.invoice_id),
                        date = DateTime.Now,
                        netPrice = net_unitprice,
                        //unit_profit = unitPrice,
                        customer_id = db.tblCustomers
                        .Where(c => c.customer_phone.Contains(txtFindCustomer.Text))
                        .Select(c => c.customer_id)
                        .FirstOrDefault(),
                        capturedAmount = float.Parse(lblNetpaid.Text.ToString()),
                    };
                    db.tblSales.InsertOnSubmit(tblSale);
                    db.SubmitChanges();

                    MessageBox.Show("Your sale");

                    // this code is ok
                    if (chbLoan.Checked == true && chbSale.Checked == false)
                    {
                        tblPayment.paymentStatus = "LOAN";
                        tblSale.status = "LOAN";
                    }
                    else if (chbSale.Checked == true && chbLoan.Checked == false)
                    {
                        tblPayment.paymentStatus = "SALE";
                        tblSale.status = "SALE";

                    }
                    else if (chbLoan.Checked == true && chbSale.Checked == true)
                    {
                        tblPayment.paymentStatus = "PARTIAL PAYMENT";
                        tblSale.status = "PARTIAL PAYMENT";
                    }
                }

                // this code is ok
                foreach (ListViewItem proItem in listViewCart.Items)
                {
                    int productId = int.Parse(proItem.SubItems[0].Text); // Get product ID
                    int soldQuantity = int.Parse(proItem.SubItems[2].Text); // Get sold quantity

                    // Find the product in the database
                    tblProduct product = db.tblProducts.FirstOrDefault(p => p.product_id == productId);

                    if (product != null)
                    {
                        // Update quantity (subtract sold quantity)
                        product.quantity -= soldQuantity;

                        // If quantity reaches zero, remove the product from the database
                        if (product.quantity <= 0)
                        {
                            MessageBox.Show("Your product is empty");
                        }
                    }
                }

                MessageBox.Show("Your product update");
                // Find the invoice you want to update (assuming invoice ID is known)
                tblInvoice invoiceTable = db.tblInvoices
                    .OrderByDescending(i => i.invoice_id)
                    .FirstOrDefault();

                // still found the error even if this code is commented
                if (invoiceTable != null) // Ensure invoice exists
                {
                    invoiceTable.date = DateTime.Now; // Update date
                    invoiceTable.transactionStatus = "Completed"; // Update status
                    invoiceTable.customer_id = db.tblCustomers.Where(name => name.customer_name.Contains(lblCustomerName.Text)).Select(id => id.customer_id).FirstOrDefault();

                    db.SubmitChanges(); // Commit changes to the database
                }
                else
                {
                    MessageBox.Show("Invoice not found!");
                }

                MessageBox.Show("Your invoice update");

                db.SubmitChanges();
                MessageBox.Show("Inserted successfully");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not saved" + " from save button", ex.Message + ex.Data);
            }
            finally
            {
            }
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            filtersale();
        }
    }
}
