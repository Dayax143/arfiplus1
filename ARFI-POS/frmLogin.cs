using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Windows.Markup;
using ARFI_POS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using POS_VUL;

namespace ARFI_POS
{
    public partial class frmLogin : Form
    {

        SqlConnection con = new SqlConnection("Data Source=172.16.168.212;Initial Catalog=ArfiPlusPerfurmes;Persist Security Info=True; User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True"); // making connection   
        SqlCommand cmd;


        //frmSplash splash = new frmSplash();


        sharedClass main = new sharedClass();

        string message = "Are you sure to change your password ?";
        string title = "Confirmation box";
        MessageBoxButtons yesno = MessageBoxButtons.YesNo;
        DialogResult result;
        string userType;

        sharedClass mainClass = new sharedClass();

        string query, attemptedUser;
        int attempt = 0;
        frmSplash splash = new frmSplash();
        public frmLogin()
        {
            InitializeComponent();



            //Create new thread to run the splash screen
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(4000);// increase or decrease here the timeSplashing
            t.Abort();
            splash.Hide();
        }

        public void StartForm()
        {
            try
            {
                Application.Run(new frmSplash());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                splash.Close();
            }
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }


        // forgot link for resetting the PASSWORD - Shows the resetting feature
        private void forgotlbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;

            cbbQuestion.Visible = false;

            lblMain.Text = "Recover your account";

            btnRecover.Text = "Recover";

        }

        private void btnSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("only admin can create account!, if you are admin - login to your account then create a new account");
        }

        // does the Reset-Password process - FUNCTION
        public void resetPassword()
        {
            try
            {
                // trying to verify who want to reset this account
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tblUser WHERE employee_id='" +
                  cbbEmployeeId.Text + "' AND username='" + cbbUserName.Text + "' AND recoveryAnswer='" + cbbAnswer.Text + "'", con);
                /* in above line the program is selecting the whole data from table and the matching it with the user name,usertype and password provided by user. */
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);


                if (dt.Rows[0][0].ToString() == "1")
                {
                    try
                    {
                        result = MessageBox.Show(message, title, yesno);
                        if (result == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("update tblUser set password='" + cbbNewPassword.Text + "' where employee_id=" + cbbEmployeeId.Text + "", con);
                            con.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Successfully resetted, please remember it");
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Canceled by user, not resetted");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Password not resetted, there is an issue !");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Your verification is invalid, please ensure that your entry relates to you.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // does the login process - FUNCTION
        public void loginFunction()
        {
            try
            {
                progressBar1.Visible = true;

                string userName, password;

                userName = txtUserName.Text.ToString();
                password = txtPassWord.Text.ToString();

                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM tblUser WHERE username='" + userName + "' AND password='" + password + "'AND userStatus='Active'", con);
                /* in above line the program is selecting the whole data from table and the matching it with the username,usertype and password provided by user. */
                DataTable dt = new DataTable(); //this is creating a virtual table  

                sda.Fill(dt);

                SqlDataAdapter daValidationForSecurity = new SqlDataAdapter("select username,userType,userStatus from tblUser where username = '" + userName + "'", con);
                DataTable dtValidationForSecurity = new DataTable(); //this is creating a virtual table  
                daValidationForSecurity.Fill(dtValidationForSecurity);


                SqlDataAdapter checkExistense = new SqlDataAdapter("SELECT COUNT(username) FROM tblUser WHERE username = '" + userName + "'", con);
                DataTable check = new DataTable();
                checkExistense.Fill(check);


                if (check.Rows[0][0].ToString() == "0")
                {
                    MessageBox.Show("This username is not valid at the system !");
                }
                else if (dt.Rows[0][0].ToString() == "1")
                {
                    /* I have made a new page called home page. If the user is successfully authenticated then the form will be moved to the next form */
                    this.Hide();
                    frmDashboard frm = new frmDashboard();

                    // PREPARING to move to Dashboard
                    if (userType == "Admin")
                    {
                        frm.typeuser.Text = "Admin: ";
                        frm.lblUsername.Text = userName;


                        // this code changes the label up-right corner to the selected userPower

                    }
                    else
                    {
                        frm.typeuser.Text = "Employee: ";
                        frm.lblUsername.Text = userName;

                        frm.Width = 1105;
                        frm.Height = 527;

                        //frm.btnEmployee.Visible = false;
                        //frm.btnSalary.Visible = false;
                        //frm.btnExpense.Visible = false;
                        //frm.btnIncome.Visible = false;
                    }
                    frm.ShowDialog();
                }
                else if (dtValidationForSecurity.Rows[0][2].ToString() == "Blocked")
                {
                    MessageBox.Show("you have too many failed attempts! so we have blocked your username for security reason, contact to your manager soon ");

                }
                else if (dtValidationForSecurity.Rows[0][0].ToString() == "")
                {
                    MessageBox.Show("Invalid username or password if you are new to the system, create your account or contact to your admin ");
                }
                else if (userName == dtValidationForSecurity.Rows[0][0].ToString() && dtValidationForSecurity.Rows[0][1].ToString() != "Admin")
                {
                    attemptedUser = dtValidationForSecurity.Rows[0][0].ToString();
                    limitAttempt();
                }
                else if (dtValidationForSecurity.Rows[0][1].ToString() == "Admin" && dt.Rows[0][0].ToString() != "1")
                {
                    MessageBox.Show("Invalid username or password ensure your details ");

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void limitAttempt()
        {
            try
            {
                query = "update tblUser set userStatus='Blocked' where userName = '" + txtUserName.Text.ToString() + "'";

                if (attempt < 5 && attemptedUser == lblActive.Text)
                {
                    attempt++;

                    int chancesLeft;
                    chancesLeft = 5 - attempt;

                    MessageBox.Show("Invalid username or password otherwise check if your account disabled");
                    progressBar1.Value = progressBar1.Value + 20;
                    MessageBox.Show(chancesLeft + " attempts left for blocking " + attemptedUser);

                    lblActive.Text = txtUserName.Text.ToString();
                }
                else if (attempt >= 5 && attemptedUser == lblActive.Text)
                {
                    cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    progressBar1.Value = 0;
                    MessageBox.Show("you have too many failed attempts! so we have blocked your username for security reason, contact to your manager soon ");
                    attempt = 0;
                }
                else if (attemptedUser != lblActive.Text)
                {
                    attempt = 0;
                    attempt++;

                    progressBar1.Value = 0;

                    int chancesLeft;
                    chancesLeft = 5 - attempt;

                    MessageBox.Show(attemptedUser + " will be blocked if too many wrong attempts, please be carefull.");
                    progressBar1.Value = progressBar1.Value + 20;
                    MessageBox.Show(chancesLeft + " attempts left for blocking " + attemptedUser);

                    lblActive.Text = txtUserName.Text.ToString();
                }
                else
                {
                    attempt = 0;
                    attempt++;
                    progressBar1.Value = 0;

                    int chancesLeft;
                    chancesLeft = 5 - attempt;
                    MessageBox.Show("Invalid username or password otherwise check if your account disabled !!!  attempt : " + attempt);

                    progressBar1.Value = progressBar1.Value + 20;
                    MessageBox.Show(chancesLeft + " attempts left for blocking " + attemptedUser);

                    lblActive.Text = txtUserName.Text.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // activates the login BUTTON
        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginFunction();
        }

        public void newUser()
        {
            try
            {

                string addUser = "insert into tblUser (username,password,usertype,recoveryQuestion,recoveryAnswer,userstatus, employee_id) values('" +
                    cbbUserName.Text + "','" + cbbNewPassword.Text + "','Employee','" + cbbQuestion.Text + "','" + cbbAnswer.Text + "','blocked'," + cbbEmployeeId.Text + ")";

                cmd = new SqlCommand(addUser, con);

                con.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show("user registered succesfully, your user will be activated by your manager");

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

        // activates the reset BUTTON
        private void btnRecover_Click(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                else if (con.State == ConnectionState.Closed)
                {

                    if (cbbQuestion.Visible == true)
                    {
                        newUser();
                    }
                    else if (cbbQuestion.Visible == false)
                    {
                        resetPassword();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.ShowDialog();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // make the password VISIBLE - or Hide RECOVER VIEW
        private void btnShow2_Click(object sender, EventArgs e)
        {
            if (cbbNewPassword.UseSystemPasswordChar == true)
            {
                cbbNewPassword.UseSystemPasswordChar = false;
                btnShow2.Text = "Show";
            }
            else
            {
                cbbNewPassword.UseSystemPasswordChar = true;
                btnShow2.Text = "Hide";
            }

        }

        // make the password VISIBLE - or Hide LOIGIN VIEW
        private void btnShow1_Click(object sender, EventArgs e)
        {
            if (txtPassWord.UseSystemPasswordChar == true)
            {
                txtPassWord.UseSystemPasswordChar = false;
                btnShow1.Text = "Show";
            }
            else
            {
                txtPassWord.UseSystemPasswordChar = true;
                btnShow1.Text = "Hide";
            }

        }

        private void btnSignUp_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            cbbQuestion.Visible = true;


            lblMain.Text = "Register new account";
            btnRecover.Text = "Register";

        }

        private void cbbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbUserName_MouseLeave(object sender, EventArgs e)
        {

        }

        private void cbbUserName_Leave(object sender, EventArgs e)
        {
            try
            {
                string readQuestion = "select recoveryQuestion from tblUser where username = '" + cbbUserName.Text + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(readQuestion, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows[0][0].ToString() != null)
                {
                    lblQuestion.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("user doesn't exist");
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        private void cbbQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
