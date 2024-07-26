using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_Management
{
	/// <summary>
	/// The StudentModule Class is utilised by the Main form to add new modules and perform various CRUD operations on the data in the StudentModule table
	/// <Field Properties> ModuleCode, ModuleName, Description, Status, and AverageMark </Field >
	/// </Constuctors> A default constructor and a parametised constructor is created
	/// </summary>
	internal class StudentModule
    {
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public double AverageMark { get; set; }

        public StudentModule() { }

        public StudentModule(string moduleCode, string moduleName, string description, string status, double averageMark)
        {
            ModuleCode = moduleCode;
            ModuleName = moduleName;
            Description = description;
            Status = status;
            AverageMark = averageMark;
        }
    }
}
