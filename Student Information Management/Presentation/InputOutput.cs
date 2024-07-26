using Student_Information_Management.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Information_Management.Presentation
{
	/// <summary>
	/// This class is part of the Presentation Layer.
	/// Its main task is to capture the data from the various forms and store them into a Student List to be accessed and used by other classes.
	/// </summary>
 
	internal class InputOutput
    {
        //Inheriting classes and forms and Accessing different architecture layers
        CRUDLogic Clogic = new CRUDLogic();
        Student student = new Student();
		Lecturer lecturer = new Lecturer();
		frmLogin login = new frmLogin();
		frmMainForm mainForm = new frmMainForm();

		/// <summary>
		/// GetLoginInput() method is used to retrieve the user's login username and password and stores them in a List
		/// </summary>
		public void GetLoginInput()
        {
			//string username = login.
            try
            {
				Lecturer lecture = new Lecturer();

			}catch (Exception e){
                MessageBox.Show(e.Message);
			}
        }

		public void GetMainInput()
        {

        }
    }
}
