using Student_Information_Management.BusinessLogic;
using Student_Information_Management.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_Management
{
	public partial class frmMainForm : Form
	{
        CRUDLogic logic = new CRUDLogic();
        SQLDBData sqlData = new SQLDBData();

		public frmMainForm()
		{
			InitializeComponent();
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void frmMainForm_Load(object sender, EventArgs e)
		{

		}

        private void btnSearchNum_Click(object sender, EventArgs e)
        {
            dgvDisplay.DataSource = logic.SearchStudent(txtSearchNum.Text);
        }

        private void btnSaveNum_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student(txtStudNum.Text, txtName.Text, txtSurname.Text, cbxGender.Text, datetimeDOB.Value, txtAssEmail.Text, txtPerEmail.Text, txtPhoneNum.Text, txtStreet.Text, txtCity.Text, txtCountry.Text, cbxTypeDegree.Text);
                logic.UpdateStudent(student);
                MessageBox.Show("Student Updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dgvDisplay.DataSource = sqlData.ReadFromDB("Student");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDisplay.DataSource = logic.SearchModule(txtSearch.Text);
        }

        private void btnSaveMod_Click(object sender, EventArgs e)
        {
            try
            {
                StudentModule module = new StudentModule(cbxModNum.Text, txtModName.Text, rtbDescription.Text, cbxStatus.Text, double.Parse(txtAverage.Text), "15", "JavaScript basic - Exercises, Practice, Solution", "W3schools exercises", "https://www.w3resource.com/javascript-exercises/javascript-basic-exercises.php");
                logic.UpdateModule(module);
                MessageBox.Show("Module Updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dgvDisplay.DataSource = sqlData.ReadFromDB("Module");
            }
        }

        private void btnAllStudents_Click(object sender, EventArgs e)
        {
            dgvDisplay.DataSource = logic;
        }

        private void btnComputingStudents_Click(object sender, EventArgs e)
        {

        }

        private void btnITStudents_Click(object sender, EventArgs e)
        {

        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {

        }

        private void btnNewModule_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
