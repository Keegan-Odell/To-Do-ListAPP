using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoClassLib
{
    public class ChoreClass(string choreName)
    {
        public string ChoreName { get; private set; } = choreName;
        //public DateOnly ChoreDueDate { get; private set; } = choreDueDate;
        public bool FinishedBool { get; set; } = false;
    }
}
