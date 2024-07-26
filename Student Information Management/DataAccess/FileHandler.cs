using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Student_Information_Management.DataAccess
{
	/// <summary>
	/// FileHandler class implements methods to read and write to the text file "Administrator Login" for the login page to use to login already valid and signup new users and add them to the file.
	/// </summary>

	internal class FileHandler
    {
		string usersTxt = "AdministratorLogin.txt";

		public string[] ReadFromFile()
        {
            string[] users = File.ReadAllLines(usersTxt);
            return users;
        }

        public void WriteToFile(string username, string password)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(usersTxt))
                {
                    writer.WriteLine($"{username},{password}");
                }
                MessageBox.Show("User has successfully been added, you can now login with that account");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
