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
    public partial class uLoan : UserControl
    {
        arfiplusDBDataContext db = new arfiplusDBDataContext();
        public uLoan()
        {
            InitializeComponent();
        }

        public void loadLoan()
        {
            try
            {
                var loadDgv = from l in db.tblLoans
                                   join c in db.tblCustomers on l.customer_id equals c.customer_id
                                   join p in db.tblPayments on l.customer_id equals p.customer_id
                                   select new
                                   {
                                       l.loan_id,
                                       c.customer_name,
                                       l.balance,
                                       l.paidAmount,
                                       l.paymentMethod,
                                       c.customer_phone,
                                       p.paymentStatus,
                                       dateTaken =l.date, // Assuming `tblLoans` has a date column
                                       l.last_update,
                                   };

                dgvLoan.DataSource = loadDgv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uLoan_Load(object sender, EventArgs e)
        {
            loadLoan();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                // Get customer ID based on phone number
                // Get customer ID based on phone number
                var customerId = db.tblCustomers
                                   .Where(c => c.customer_phone == txtPhone.Text)
                                   .Select(c => c.customer_id)
                                   .FirstOrDefault();

                // Check if customer exists
                if (customerId == null)
                {
                    MessageBox.Show("Customer does not exist");
                    lblPreviousBalance.Text = lblDateTaken.Text = lblDaysLeft.Text = "No data";
                }
                else
                {
                    // Retrieve all loan records for the customer
                    var loans = db.tblLoans
                                  .Where(l => l.customer_id == customerId)
                                  .Select(l => new
                                  {
                                      l.balance,
                                      l.date
                                  })
                                  .ToList();

                    if (loans.Any())
                    {
                        // Show total balance
                        lblPreviousBalance.Text = loans.Sum(l => l.balance).ToString();
                        lblNumLoans.Text = $"{loans.Count}";

                        // Show most recent loan date
                        var latestLoanDate = loans.OrderBy(l => l.date).FirstOrDefault()?.date;
                        lblDateTaken.Text = latestLoanDate.HasValue ? latestLoanDate.Value.ToString() : "No data";

                        // Calculate date difference
                        int dateDiff = latestLoanDate.HasValue ? (DateTime.Now.Date - latestLoanDate.Value.Date).Days : 0;
                        lblDaysLeft.Text = dateDiff < 30
                            ? $"{dateDiff} Days left, less than a month"
                            : $"{dateDiff} Days left, more than a month";

                    }
                    else
                    {
                        MessageBox.Show("Customer does not exist");
                        lblPreviousBalance.Text = lblDateTaken.Text = lblDaysLeft.Text = "No data";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadLoan();
        }

        private void btnPayLoan_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}