using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARFI_POS
{
    public partial class uReport : UserControl
    {
        public uReport()
        {
            InitializeComponent();
        }

        arfiplusDBDataContext db = new arfiplusDBDataContext();

        private void uReport_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void LoadInvoiceReport(bool filterByDate, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var invoiceReportQuery = from i in db.tblInvoices
                                         join c in db.tblCustomers
                                         on i.customer_id equals c.customer_id
                                         join p in db.tblPayments on i.invoice_id equals p.invoice_id
                                         join s in db.tblSales on i.invoice_id equals s.invoice_id into salesGroup
                                         select new
                                         {
                                             i.invoice_id,
                                             p.payment_id,
                                             sale_ids = string.Join(", ", salesGroup.Select(s => s.sale_id)),
                                             c.customer_name,
                                             c.customer_phone,
                                             i.transactionStatus,
                                             p.paymentStatus,
                                             i.description,
                                             i.date,
                                         };

                // Apply filtering by date if required
                if (filterByDate && startDate.HasValue && endDate.HasValue)
                {
                    invoiceReportQuery = invoiceReportQuery.Where(i => i.date >= startDate.Value.Date && i.date <= endDate.Value.Date);
                }

                dgvInvoice.DataSource = invoiceReportQuery.ToList();
                dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvInvoice.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnLoadInvoice_Click(object sender, EventArgs e)
        {
            LoadInvoiceReport(false);            
        }

        private void btnFilterDateInvoice_Click(object sender, EventArgs e)
        {
            LoadInvoiceReport(true, dtPickerInvoice1.Value, dtPickerInvoice2.Value);
        }

        private void btnFilterSaleDate_Click(object sender, EventArgs e)
        {
            LoadSalesReport(true, dtPickerSales1.Value, dtPickerSales2.Value);
        }

        private void LoadSalesReport(bool filterByDate, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var salesReportQuery = from s in db.tblSales
                                       join c in db.tblCustomers on s.customer_id equals c.customer_id
                                       orderby s.sale_id descending
                                       select new
                                       {
                                           s.sale_id,
                                           s.invoice_id,
                                           s.payment_id,
                                           c.customer_name,
                                           s.item_name,
                                           s.price,
                                           s.quantity,
                                           s.netPrice,
                                           s.date,
                                           s.capturedAmount,
                                           s.unit_profit,
                                           s.status,
                                           s.returned,
                                       };

                // Apply filtering by date if required
                if (filterByDate && startDate.HasValue && endDate.HasValue)
                {
                    salesReportQuery = salesReportQuery.Where(s => s.date >= startDate.Value.Date && s.date <= endDate.Value.Date);
                }

                dgvSales.DataSource = salesReportQuery.ToList();
                dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvSales.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSaleLoad_Click(object sender, EventArgs e)
        {
            LoadSalesReport(false);
        }

        private void btnFilterDatePayment_Click(object sender, EventArgs e)
        {
            LoadPaymentReport(true, dtPickerPayment1.Value, dtPickerPayment2.Value);
        }

        private void LoadPaymentReport(bool filterByDate, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var paymentReportQuery = from p in db.tblPayments
                                         join c in db.tblCustomers on p.customer_id equals c.customer_id
                                         orderby p.payment_id descending
                                         select new
                                         {
                                             p.payment_id, // Includes all columns from tblPayments
                                             p.invoice_id,
                                             c.customer_name,
                                             p.netPaid,
                                             p.currency,
                                             p.netProfit,
                                             p.discount,
                                             p.paymentStatus,
                                             p.onhand,
                                             p.zaad,
                                             p.edahab,
                                             p.soltelco,
                                             p.bank,
                                             p.other,
                                             p.date,
                                         };

                // Apply date filtering if required
                if (filterByDate && startDate.HasValue && endDate.HasValue)
                {
                    paymentReportQuery = paymentReportQuery.Where(p => p.date >= startDate.Value.Date && p.date <= endDate.Value.Date);
                }

                dgvPayment.DataSource = paymentReportQuery.ToList();

                // Set auto-sizing for columns and rows
                dgvPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPayment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvPayment.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadPayment_Click(object sender, EventArgs e)
        {
            LoadPaymentReport(false);
        }

        private void btnLoadCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerReport(false);
        }

        private void LoadCustomerReport(bool filterByDate, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var customerReportQuery = db.tblCustomers.AsQueryable();

                // Apply date filtering if required
                if (filterByDate && startDate.HasValue && endDate.HasValue)
                {
                    customerReportQuery = customerReportQuery.Where(c => c.date >= startDate.Value.Date && c.date <= endDate.Value.Date);
                }

                dgvCustomer.DataSource = customerReportQuery.ToList();

                // Set auto-sizing for columns and rows
                dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCustomer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "From customer load");
            }
        }
        private void btnCustomerDateFilter_Click(object sender, EventArgs e)
        {
            LoadCustomerReport(true,dtPickerCustomer1.Value,dtPickerCustomer2.Value);
        }

        private void btnLoadProducts_Click(object sender, EventArgs e)
        {
            LoadProductsReport(false);
        }

        private void LoadProductsReport(bool filterByDate, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var productsReportQuery = from p in db.tblProducts
                                          join s in db.tblSuppliers on p.supplier_id equals s.supplier_id
                                          select new
                                          {
                                              p.product_id,
                                              p.product_name,
                                              p.quantity,
                                              unit_cost = p.cost,
                                              unit_price = p.price,
                                              p.product_type,
                                              s.supplier_name,
                                              supplier_phone = s.phone_number,
                                              date_registered = p.date,
                                              p.last_update,
                                              p.description,
                                          };

                // Apply date filtering if required
                if (filterByDate && startDate.HasValue && endDate.HasValue)
                {
                    productsReportQuery = productsReportQuery.Where(p => p.date_registered >= startDate.Value.Date && p.date_registered <= endDate.Value.Date);
                }

                dgvProducts.DataSource = productsReportQuery.ToList();

                // Set auto-sizing for columns and rows
                dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading products report");
            }
        }

        private void btnProductsDate_Click(object sender, EventArgs e)
        {
            LoadProductsReport(true, dtPickerProducts1.Value, dtPickerProducts2.Value);
        }

        private void btnSupplierDate_Click(object sender, EventArgs e)
        {
           LoadSupplierReport(true,dtPickerSupplier1.Value, dtPickerSupplier2.Value);
        }
        private void LoadSupplierReport(bool filterByDate, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var supplierReportQuery = db.tblSuppliers.AsQueryable();

                // Apply date filtering if required
                if (filterByDate && startDate.HasValue && endDate.HasValue)
                {
                    supplierReportQuery = supplierReportQuery.Where(d => d.date >= startDate.Value.Date && d.date <= endDate.Value.Date);
                }

                dgvSupplier.DataSource = supplierReportQuery.ToList();

                // Set auto-sizing for columns and rows
                dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSupplier.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading supplier report");
            }
        }

        private void btnLoadSupplier_Click(object sender, EventArgs e)
        {
            LoadSupplierReport(false);
        }

        private void LoadLoanReport(bool filterByDate, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var getLoanQuery = from l in db.tblLoans
                                   join c in db.tblCustomers on l.customer_id equals c.customer_id
                                   join p in db.tblPayments on l.customer_id equals p.customer_id
                                   select new
                                   {
                                       l.loan_id,
                                       p.payment_id,
                                       c.customer_name,
                                       l.balance,
                                       l.paidAmount,
                                       l.paymentMethod,
                                       c.customer_phone,
                                       p.paymentStatus,
                                       Taken_Date =l.date, // Assuming `tblLoans` has a date column
                                       l.last_update,
                                   };

                // Apply date filtering if required
                if (filterByDate && startDate.HasValue && endDate.HasValue)
                {
                    getLoanQuery = getLoanQuery.Where(l => l.Taken_Date >= startDate.Value.Date && l.Taken_Date <= endDate.Value.Date);
                }

                dgvLoan.DataSource = getLoanQuery.ToList();

                // Set auto-sizing for columns and rows
                dgvLoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLoan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading loan report");
            }
        }

        private void btnLoanDateFilter_Click(object sender, EventArgs e)
        {
            LoadLoanReport(true,dtPickerLoan1.Value,dtPickerLoan2.Value);
        }

        private void btnLoanLoad_Click(object sender, EventArgs e)
        {
            LoadLoanReport(false);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

        }
    }
}
