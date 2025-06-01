using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ARFI_POS;
using System.Xml.Linq;

namespace ARFI_POS
{
    public partial class uSales : UserControl
    {
        public uSales()
        {
            InitializeComponent();
        }
        
        private void uSales_Load(object sender, EventArgs e)
        {

        }

        private void btnInvioce_Click(object sender, EventArgs e)
        {
            frmSales frmSales = new frmSales();
            frmSales.ShowDialog();
        }
    }
}
