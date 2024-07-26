using Student_Information_Management.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Student_Information_Management.BusinessLogic
{
    internal class CRUDLogic
    {
        /// <summary>
        /// This class contains all CRUD operations for Student and Module tables
        /// Creations, Updates, and Deletes call the WriteToDB method from the SQLDBData class in the data access layer
        /// Reads return a table to be used in the DataGridView(s)
        /// </summary>
        
        SQLDBData sQLDBData = new SQLDBData();
        string connect = @"Server = .; Initial Catalog = BelgiumCampusStudentsDB; Integrated Security = SSPI";

        public void DeleteStudent(string deleteStudent)
        {
            //Removes a student
            string query = $"DELETE Student WHERE StudentNumber = '{deleteStudent}'";
            sQLDBData.WriteToDB(query);
        }

        public DataTable DisplayStudents(string criteria)
        {
            //View either all, bacheleor of computing, or bacheleor of IT students
            string query = $"SELECT * FROM Student WHERE DegreeCode = '{criteria}'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public DataTable SearchStudent(string studentSearch)
        {
            //Search for entered student number
            string query = $"SELECT * FROM Student WHERE StudentNumber = '{studentSearch}'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public DataTable SearchModule(string moduleSearch)
        {
            //Search for entered module code
            string query = $"SELECT * FROM Module WHERE ModuleCode = '{moduleSearch}'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public void UpdateStudent(Student student)
        {
            //Edit a student

            //Variable used in ImageName database field in Student table
            string image = student.StudNumber + ".png";

            //Translating recieved degree code into acronym for database use
            string degCode;            
            if (student.DegreeCode == "Bachelor of Computing")
            {
                degCode = "BCOMP";
            }
            else
            {
                degCode = "BIT";
            }

            string query = $"UPDATE Student SET StudentNumber = '{student.StudNumber}', FullName = '{student.FullName}', DOB = '{student.DateOfBirth}', Gender = '{student.Gender}', PhoneNumber = '{student.PhoneNumber}', PersonalEmail = '{student.PersonalEmail}', AssignedEmail = '{student.AssignedEmail}', Street = '{student.Street}', City = '{student.City}', Country = '{student.Country}', ImageName = '{image}', DegreeCode = '{degCode}' WHERE StudentNumber = '{student.StudNumber}'";

            sQLDBData.WriteToDB(query);
        }

        public void UpdateModule(StudentModule module)
        {
            //Edit a module
            string query = $"UPDATE Module SET ModuleCode = '{module.ModuleCode}', ModuleName = '{module.ModuleName}', ModuleDescription = '{module.Description}', ModuleStatus = '{module.Status}', ClassAverage = {module.AverageMark} WHERE ModuleCode = '{module.ModuleCode}'";
            
            sQLDBData.WriteToDB(query);                       
        }

        public void CreateStudent(Student student)
        {
            //Capture details and add a new student

            //Variable used in ImageName database field in Student table
            string image = student.StudNumber + ".png";

            //Translating recieved degree code into acronym for database use
            string degCode;
            if (student.DegreeCode == "Bachelor of Computing")
            {
                degCode = "BCOMP";
            }
            else
            {
                degCode = "BIT";
            }

            string query = $"INSERT INTO Student VALUES ('{student.StudNumber}', '{student.FullName}', '{student.DateOfBirth}', '{student.Gender}', '{student.PhoneNumber}', '{student.PersonalEmail}', '{student.AssignedEmail}', '{student.Street}', '{student.City}', '{student.Country}', '{image}', '{degCode}')";
        
            sQLDBData.WriteToDB(query);
        }

        public void CreateModule(StudentModule module)
        {
            //Capture details and add a new module
            string query = $"INSERT INTO Module Values ('{module.ModuleCode}', '{module.ModuleName}', '{module.Description}', '{module.Status}', '{module.AverageMark}')";
            
            sQLDBData.WriteToDB(query);
        }

        public List<Resource> DisplayResource(string moduleCode)
        {
            //Display the relevant module's two resources' information
            List<Resource> resourceList = new List<Resource>();
            string query = $"SELECT * FROM Resources WHERE ModuleCode = '{moduleCode}';";
            SqlConnection conn = new SqlConnection(connect);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        resourceList.Add(new Resource(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3), reader.GetString(4)));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return resourceList;
        }
    }
}
