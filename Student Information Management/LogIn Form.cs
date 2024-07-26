using Student_Information_Management.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_Management
{
	public partial class frmLogin : Form
	{
		public frmLogin()
		{
			InitializeComponent();
			txtPassword.MaxLength = 8;
        }

		frmMainForm Main = new frmMainForm();

		//Inheriting classes and forms and Accessing different architecture layers
		CRUDLogic Clogic = new CRUDLogic();
		Student student = new Student();
		Lecturer lecturer = new Lecturer();

		private void btnSignUp_Click(object sender, EventArgs e)
		{
			List<Lecturer> lectList = RetrieveLoginfrmData();
            LoginLogic loginLogic = new LoginLogic();

			loginLogic.SignUp(lectList[0].Username, lectList[0].Password);
        }

		private void btnLogIn_Click(object sender, EventArgs e)
		{
			List<Lecturer> lectList = RetrieveLoginfrmData();
            LoginLogic loginLogic = new LoginLogic();

			if (loginLogic.ValidatePassword(lectList[0].Username, lectList[0].Password))
			{
				this.Hide();
				Main.FormClosing += MainForm_Closing;
			}	
		}

        //Method to show the Login form when the Main form is closed
        public void MainForm_Closing(object sender, EventArgs e)
		{
			this.Show();
			txtUsername.Text = "";
			txtPassword.Text = "";
		}

		//Collects and stores the textbox data into a List and returns the list
		private List<Lecturer> RetrieveLoginfrmData()
		{
			List<Lecturer> LecList = new List<Lecturer>();
			try
			{
				LecList.Add(new Lecturer(txtUsername.Text,txtPassword.Text));
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			return LecList;
		}
		
        private void chbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
                txtPassword.UseSystemPasswordChar = true;
        }

		private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
