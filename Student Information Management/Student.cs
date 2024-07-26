using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_Management
{
	/// <summary>
	/// The Student Class is utilised by the Main form to add access to the Student table in the database and perform various CRUD operations in the Student table.
	/// <Field Properties> StudNumber, FullName, Gender, DateOfBirth, AssignedEmail, PersonalEmail, PhoneNumber, Street, Country and DegreeCode </Field >
	/// </Constuctors> A default constructor and a parametised constructor is created
	/// </summary>
	internal class Student
    {
        public string StudNumber { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AssignedEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string DegreeCode { get; set; }

		public Student() { }

        public Student(string studNumber, string fullName, string gender, DateTime dateOfBirth, string assignedEmail, string personalEmail, string phoneNumber, string street, string city, string country, string degreeCode)
        {
            StudNumber = studNumber;
			FullName = fullName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            AssignedEmail = assignedEmail;
            PersonalEmail = personalEmail;
            PhoneNumber = phoneNumber;
            Street = street;
            City = city;
            Country = country;
            DegreeCode = degreeCode;
        }
    }   
}
