using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_Management
{
	/// <summary>
	/// The Lecture Class is utilised by the login form to add new users to gain access to the system.
	/// <Field Properties> Username and Password </Field >
	/// </Constuctors> A default constructor and a parametised constructor is created
	/// </summary>
	internal class Lecturer
    {
		public string Username { get; set; }
        public string Password { get; set; }

		public Lecturer() { }

        public Lecturer(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
