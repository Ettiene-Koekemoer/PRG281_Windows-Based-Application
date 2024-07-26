using Student_Information_Management.BusinessLogic;
using Student_Information_Management.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Student_Information_Management
{
	/// <summary>
	/// This class is part of the Presentation Layer.
	/// Its main task is to capture the data from the form and store them into a Student and Module List to be accessed and used by other classes to perform CRUD operations.
	/// It is also used to display the various database information in the form.
	/// </summary>

	public partial class frmMainForm : Form
	{
		public frmMainForm() { InitializeComponent(); }

		BindingSource src = new BindingSource();
		SQLDBData SqlData = new SQLDBData();
		DataTable dt = new DataTable();
		List<Student> StudList = new List<Student>();
		List<StudentModule> ModList = new List<StudentModule>();
		CRUDLogic logic = new CRUDLogic();
		SQLDBData sqlData = new SQLDBData();

		/// <methods>
		/// frmMainForm_Load()						-> When the form is loaded the Student Information tab will be shown and both the Student and Module datagridviews will be loaded with the relevent information.
		/// tabControlInformation_Selected()		-> The controlling of the switch between the Student and Module tab to show the Student or Module datagridview tabs
		/// dgvTabControl_Selected()				-> The controlling of the switch between the Student or Module datagridview tabs to show the Student and Module tab
		/// </methods>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmMainForm_Load(object sender, EventArgs e)
		{
			tabControlInformation.SelectedIndex = 0;

			string viewtable2 = "Module";
			src.DataSource = SqlData.ReadFromDB(viewtable2);
			dgvModuleDisplay.DataSource = src;

			string viewtable = "Student";
			src.DataSource = SqlData.ReadFromDB(viewtable);
			dgvDisplayStudents.DataSource = src;
		}

		private void tabControlInformation_Selected(object sender, TabControlEventArgs e)
		{
			if (tabControlInformation.SelectedIndex == 0)
			{
				dgvTabControl.SelectedIndex = 0;
			}
			else
			{
				dgvTabControl.SelectedIndex = 1;
			}
		}

		private void dgvTabControl_Selected(object sender, TabControlEventArgs e)
		{
			if (dgvTabControl.SelectedIndex == 0)
			{
				string viewtable = "Student";
				src.DataSource = SqlData.ReadFromDB(viewtable);
				tabControlInformation.SelectedIndex = 0;
				dgvDisplayStudents.DataSource = src;
			}
			else
			{
				string viewtable = "Module";
				src.DataSource = SqlData.ReadFromDB(viewtable);
				tabControlInformation.SelectedIndex = 1;
				dgvDisplayStudents.DataSource = src;
			}
		}

		/// <methods>
		/// RetrieveMainfrmStudentData()	-> Collects and stores the textbox data on the Student Information into Lists
		/// RetrieveMainfrmModuleData()		-> Collects and stores the textbox data on the Student Information into Lists
		/// </methods>
		/// <returns></returns>
		private List<Student> RetrieveMainfrmStudentData()
		{
			try
			{
				StudList.Add(new Student(txtStudNum.Text, txtFullName.Text, cbxGender.SelectedItem.ToString(), datetimeDOB.Value, txtAssEmail.Text, txtPerEmail.Text, txtPhoneNum.Text, txtStreet.Text, txtCity.Text, txtCountry.Text, cbxTypeDegree.SelectedItem.ToString()));
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			return StudList;
		}

		private List<StudentModule> RetrieveMainfrmModuleData()
		{
			try
			{
				ModList.Add(new StudentModule(cbxModNum.SelectedItem.ToString(), txtModName.Text, rtbDescription.Text, cbxStatus.SelectedItem.ToString(), double.Parse(txtAverage.Text)));
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			return ModList;
		}

        /// <methods>
        /// btnNewStudent_Click()		-> Inserts a student's information into the Student table
        /// btnNewModule_Click()		-> Inserts a new module's information into the Module table
        /// btnUpdateStud_Click()		-> Updates the student's information to the Student table through StudentNumber
        /// btnUpdateMod_Click()		-> Updates the module's information to the Module table through ModuleCode
        /// btnDelete_Click()			-> Deletes the student's information from the Student table through StudentNumber
        /// </methods>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewStudent_Click(object sender, EventArgs e)
		{
			if (!(txtStudNum.Text == "" || txtFullName.Text == "" || txtPhoneNum.Text == "" || txtPerEmail.Text == "" || txtAssEmail.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || txtCountry.Text == "") && (cbxTypeDegree.SelectedIndex > -1 || cbxGender.SelectedIndex > -1))
			{
				try
				{
					Student student = new Student(txtStudNum.Text, txtFullName.Text, cbxGender.SelectedItem.ToString(), datetimeDOB.Value, txtAssEmail.Text, txtPerEmail.Text, txtPhoneNum.Text, txtStreet.Text, txtCity.Text, txtCountry.Text, cbxTypeDegree.SelectedItem.ToString());
					logic.CreateStudent(student);
					MessageBox.Show("New student added!");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					src.DataSource = sqlData.ReadFromDB("Student");
					dgvDisplayStudents.DataSource = src;
				}
			}
			else
			{
				MessageBox.Show("Student has not been added as not all inputs have been filled!");
			}
		}

		private void btnNewModule_Click(object sender, EventArgs e)
		{
			if (!(cbxModNum.SelectedItem.ToString() == null || cbxStatus.SelectedItem.ToString() == null || txtModName.Text == "" || rtbDescription.Text == "" || txtAverage.Text == ""))
			{
				try
				{
					StudentModule module = new StudentModule(cbxModNum.SelectedItem.ToString(), txtModName.Text, rtbDescription.Text, cbxStatus.SelectedItem.ToString(), double.Parse(txtAverage.Text));
					logic.CreateModule(module);
					MessageBox.Show("Module added!");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					src.DataSource = sqlData.ReadFromDB("Module");
					dgvDisplayStudents.DataSource = src;
				}
			}
			else
			{
				MessageBox.Show("Module has not been added as not all inputs have been filled!");
			}
		}

		private void btnUpdateStud_Click(object sender, EventArgs e)
		{
			try
			{
				Student student = new Student(txtStudNum.Text, txtFullName.Text, cbxGender.SelectedItem.ToString(), datetimeDOB.Value, txtAssEmail.Text, txtPerEmail.Text, txtPhoneNum.Text, txtStreet.Text, txtCity.Text, txtCountry.Text, cbxTypeDegree.SelectedItem.ToString());
				logic.UpdateStudent(student);
				DataTable table = logic.SearchStudent(txtStudNum.Text);
				if (table.Rows.Count != 0)
				{
					MessageBox.Show($"Student {txtStudNum.Text} has been updated!");
				}
				else
				{
					MessageBox.Show($"Student {txtStudNum.Text} does not exists and no updates can occur!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				src.DataSource = sqlData.ReadFromDB("Student");
				dgvDisplayStudents.DataSource = src;
			}
		}

		private void btnUpdateMod_Click(object sender, EventArgs e)
		{
			try
			{
				StudentModule module = new StudentModule(cbxModNum.SelectedItem.ToString(), txtModName.Text, rtbDescription.Text, cbxStatus.SelectedItem.ToString(), double.Parse(txtAverage.Text));
				logic.UpdateModule(module);
				MessageBox.Show($"{cbxModNum.SelectedItem.ToString()} module has been updated!"); }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				src.DataSource = sqlData.ReadFromDB("Module");
				dgvDisplayStudents.DataSource = src;
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				DataTable table = logic.SearchStudent(txtDelete.Text);
				if (table.Rows.Count != 0)
				{
					logic.DeleteStudent(txtDelete.Text);
					MessageBox.Show($"Student {txtDelete.Text} has been deleted!");
				}
				else
				{
					MessageBox.Show($"Student {txtDelete.Text} does not exists and no deletions can occur!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				src.DataSource = sqlData.ReadFromDB("Student");
				dgvDisplayStudents.DataSource = src;
			}
		}

		/// <methods>
		/// btnComputingStudents_Click()		-> Displays only students that take the computer course in the Student DataGridView
		/// btnAllStudents_Click()				-> Displays All the students in the Student DataGridView
		/// btnITStudents_Click()				-> Displays only students that take the course IT in the Student DataGridView
		/// dgvDisplayStudents_CellEnter()		-> Displays the data that is selected in the Student DataGridView into the relevent textboxes, dropdown boxes and Image container.
		/// dgvModuleDisplay_CellEnter()		-> Displays the data that is selected in the Module DataGridView into the relevent textboxes and dropdown boxes.
		/// </methods>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnComputingStudents_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(dgvTabControl.SelectedIndex == 0))
				{
					tabControlInformation.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				src.DataSource = logic.DisplayStudents("BCOMP");
				dgvDisplayStudents.DataSource = src;
			}
		}

		private void btnAllStudents_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(dgvTabControl.SelectedIndex == 0))
				{
					tabControlInformation.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				src.DataSource = sqlData.ReadFromDB("Student");
				dgvDisplayStudents.DataSource = src;
			}
		}

		private void btnITStudents_Click(object sender, EventArgs e)
		{
			try
			{
				if (!(dgvTabControl.SelectedIndex == 0))
				{
					tabControlInformation.SelectedIndex = 0;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				src.DataSource = logic.DisplayStudents("BIT");
				dgvDisplayStudents.DataSource = src;
			}
		}

        private void dgvDisplayStudents_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
			if (dgvTabControl.SelectedIndex == 0)
			{
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvDisplayStudents.Rows[e.RowIndex];
                    txtStudNum.Text = row.Cells["StudentNumber"].Value.ToString();
                    txtFullName.Text = row.Cells["FullName"].Value.ToString();
                    txtPhoneNum.Text = row.Cells["PhoneNumber"].Value.ToString();
                    txtPerEmail.Text = row.Cells["PersonalEmail"].Value.ToString();
                    txtAssEmail.Text = row.Cells["AssignedEmail"].Value.ToString();
                    txtStreet.Text = row.Cells["Street"].Value.ToString();
                    txtCity.Text = row.Cells["City"].Value.ToString();
                    txtCountry.Text = row.Cells["Country"].Value.ToString();
                    datetimeDOB.Value = DateTime.Parse(row.Cells["DOB"].Value.ToString());

                    if (row.Cells["Gender"].Value.ToString() == "Male")
                    {
                        cbxGender.SelectedItem = "Male";
                    }
                    else
                    {
                        cbxGender.SelectedItem = "Female";
                    }

                    if (row.Cells["DegreeCode"].Value.ToString() == "BIT")
                    {
                        cbxTypeDegree.SelectedItem = "Bachelor of IT";
                    }
                    else
                    {
                        cbxTypeDegree.SelectedItem = "Bachelor of Computing";
                    }

					try
					{
                        //Crediting the icons creator
                        //https://www.freepik.com/free-vector/find-person-job-opportunity_8063764.htm#query=user%20profile&position=13&from_view=search&track=ais (By studiogstock on Freepik)
                        picStudentImg.Image = Image.FromFile($@"Student Images\{row.Cells["ImageName"].Value.ToString()}");
                    }
					catch (Exception)
					{
						MessageBox.Show($"Image file for student {row.Cells["StudentNumber"].Value.ToString()} does not exist in images folder.");
					}                    
                }
            }
        }

        private void dgvModuleDisplay_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTabControl.SelectedIndex == 1)
			{
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvModuleDisplay.Rows[e.RowIndex];
                    txtModName.Text = row.Cells["ModuleName"].Value.ToString();
                    txtAverage.Text = row.Cells["ClassAverage"].Value.ToString();
                    rtbDescription.Text = row.Cells["ModuleDescription"].Value.ToString();

                    switch (row.Cells["ModuleCode"].Value.ToString())
                    {
                        case "DBD271":
                            cbxModNum.SelectedItem = "DBD271";
                            break;
                        case "DBD281":
                            cbxModNum.SelectedItem = "DBD281";
                            break;
                        case "MAT271":
                            cbxModNum.SelectedItem = "MAT271";
                            break;
                        case "MAT281":
                            cbxModNum.SelectedItem = "MAT281";
                            break;
                        case "PRG271":
                            cbxModNum.SelectedItem = "PRG271";
                            break;
                        case "PRG281":
                            cbxModNum.SelectedItem = "PRG281";
                            break;
                        case "WPR271":
                            cbxModNum.SelectedItem = "WPR271";
                            break;
                        case "WPR281":
                            cbxModNum.SelectedItem = "WPR281";
                            break;
                        case "SWT281":
                            cbxModNum.SelectedItem = "SWT281";
                            break;
                    }

                    switch (row.Cells["ModuleStatus"].Value.ToString())
                    {
                        case "Upcoming":
                            cbxStatus.SelectedItem = "Upcoming";
                            break;
                        case "In Progress":
                            cbxStatus.SelectedItem = "In Progress";
                            break;
                        case "Exam Results Pending":
                            cbxStatus.SelectedItem = "Exam Results Pending";
                            break;
                        case "Finished":
                            cbxStatus.SelectedItem = "Finished";
                            break;
                    }

					//Populating resources
					List <Resource> resourceList = logic.DisplayResource(row.Cells["ModuleCode"].Value.ToString());

					lblLink1.Text = resourceList[0].Name;
					lblLink2.Text = resourceList[1].Name;
					lbltype1.Text = resourceList[0].Type;
					lbltype2.Text = resourceList[1].Type;
					rbtURL1.Text = resourceList[0].URL;
					rbtURL2.Text = resourceList[1].URL;
                }
            }
        }

		/// <methods>
		/// btnPrev_Click()		-> The button will move to the Previous cell in the datagridviews list.
		/// btnFirst_Click()	-> The button will move to the First cell in the datagridviews list.
		/// btnNext_Click()		-> The button will move to the Next cell in the datagridviews list.
		/// btnLast_Click()		-> The button will move to the Last cell in the datagridviews list.
		/// btnExit_Click()		-> The button will Exit the Main form and display the Login form.
		/// </methods>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnPrev_Click(object sender, EventArgs e)
		{
			src.MovePrevious();
		}

		private void btnFirst_Click(object sender, EventArgs e)
		{
			src.MoveFirst();
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			src.MoveNext();
		}

		private void btnLast_Click(object sender, EventArgs e)
		{
			src.MoveLast();
		}

		private void btnExit_Click(object sender, EventArgs e) 
		{
			frmLogin login = new frmLogin();
			this.Close();
			login.Show();
		}

		/// <methods>
		/// btnSearch_Click()			-> The search feature for the Modules tab to locate a specific module's details based on the module code entered.
		/// btnSearchNum_Click()		-> The search feature for the Students tab to locate a specific student's details based on the student number entered.
		/// btnClearStud_Click()		-> The button will clear all textboxes to empty, return all dropdown boxes to a default option and sets the DateTime to current on the Student Tab
		/// btnClearMode_Click()		-> The button will clear all textboxes and labels to empty and return all dropdown boxes to a default option on the Module Tab.
		/// </method>
		/// <Error Messages> All Error messages will indicate if the specified function was successful or if it failed</Error>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			try{
                src.DataSource = logic.SearchModule(txtSearch.Text);
                dgvModuleDisplay.DataSource = src;
                dgvModuleDisplay.SelectAll();

                if (dgvModuleDisplay.SelectedCells.Count > 0) {
                    MessageBox.Show("Module found!");
                }else{
                    MessageBox.Show("Module not found!");
                }
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

		private void btnSearchNum_Click(object sender, EventArgs e)
		{
			try{
                src.DataSource = logic.SearchStudent(txtSearchNum.Text);
				dgvDisplayStudents.DataSource = src;
				dgvDisplayStudents.SelectAll();

				if (dgvDisplayStudents.SelectedCells.Count > 0){
					MessageBox.Show("Student found!");
				}else{
                    MessageBox.Show("Student not found!");
                }				
			}catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

		private void btnClearStud_Click(object sender, EventArgs e)
		{
			txtStudNum.Text = "";
			txtFullName.Text = "";
			txtPerEmail.Text = "";
			txtAssEmail.Text = "";
			txtStreet.Text = "";
			txtCity.Text = "";
			txtCountry.Text = "";
			txtPhoneNum.Text = "";
			cbxGender.Text = "Select an Option";
			cbxTypeDegree.Text = "Select an Option";
			datetimeDOB.Value = DateTime.Now;
			txtSearchNum.Text = "";
        }

		private void btnClearMode_Click(object sender, EventArgs e)
		{
			txtModName.Text= "";
			rtbDescription.Text = "Insert description here...";
			txtAverage.Text = "";
			txtSearch.Text = "";
			cbxModNum.Text = "Select an Option";
			cbxStatus.Text = "Select an Option";

            lblLink1.Text = "Insert resource title here...";
            lblLink2.Text = "Insert resource title here...";
            lbltype1.Text = "Insert the type of resource here...";
            lbltype2.Text = "Insert the type of resource here...";
            rbtURL1.Text = "";
            rbtURL2.Text = "";
        }

        private void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
