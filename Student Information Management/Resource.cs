using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_Management
{
    /// <summary>
	/// The Resource Class is utilised by the CRUDLogic and Main form classes to display a module's resources from the database in the Resource table.
	/// <Field Properties> ResourceID, ModuleCode, Type, Name, URL </Field >
	/// </Constuctors> A parametised constructor is created
	/// </summary>
    internal class Resource
    {
        public int ResourceID { get; set; }
        public string ModuleCode { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public Resource(int resourceID, string moduleCode, string type, string name, string uRL)
        {
            ResourceID = resourceID;
            ModuleCode = moduleCode;
            Type = type;
            Name = name;
            URL = uRL;
        }
    }
}
