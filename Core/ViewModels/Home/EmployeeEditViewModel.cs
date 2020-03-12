using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.ViewModels.Home
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingImagePath { get; set; }
    }
}
