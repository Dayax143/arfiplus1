using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARFI_POS
{
	public class sharedClass
	{
		//public string ConnectionString = "Data Source=(local);Initial Catalog=ArfiPlusPerfurmes;Integrated Security=True; user id='sa'; password=123;";
        public string query, status;
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter adapter = new SqlDataAdapter();
        public DataTable virtualTable = new DataTable();
        public DialogResult confirm;
        public string message = "Are you sure you want to delete this record";
        public string title = "Confirmation dialog";
		//public SqlConnection pubconnection = new SqlConnection(Properties.Settings.Default.SqlConnectionString);

		public SqlConnection con = new SqlConnection("Data Source = 172.16.168.212; Initial Catalog = ArfiPlusPerfurmes; Persist Security Info=True; User ID = sa; Password=123;Encrypt=True;TrustServerCertificate=True"); // making connection 
  

		public SqlDataAdapter adapt;
		public MessageBoxButtons yesno = MessageBoxButtons.YesNo;
		public DialogResult result;


        // this code is for reporting and inovice_Printing
        public string thisInvoiceId;
        public void displayData(DataGridView dgv, string table, string orderBy)
        {
            try
            {
                query = "select * from " + table + " order by " + orderBy + " desc";
                adapter = new SqlDataAdapter(query, con);
                virtualTable = new DataTable();
                adapter.Fill(virtualTable);

                dgv.DataSource = virtualTable;


                //loadStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

  //      public void OpenConnection()
		//{
		//	con = new SqlConnection(con);
		//	con.Open();
		//}

		public void displayUsers()
		{
			con.Open();
			con.Close();
		}

		public void CloseConnection()
		{
			con.Close();
		}


		public void ExecuteQueries(string Query_)
		{
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand(Query_, con);
				cmd.ExecuteNonQuery();
				con.Close();
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

		public SqlDataReader DataReader(string Query_)
		{
			SqlCommand cmd = new SqlCommand(Query_, con);
			SqlDataReader dr = cmd.ExecuteReader();
			return dr;
		}

		public object ShowDataInGridView(string Query_)
		{
			SqlDataAdapter dr = new SqlDataAdapter(Query_, con);
			DataSet ds = new DataSet();
			dr.Fill(ds);
			object dataum = ds.Tables[0];
			return dataum;
		}
	}
}
