using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExample
{
    public class MenuItem
    {
        public Action Operation { get; set; }   

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }  
        }

        public bool IsEnabled { get; set; } 

        public MenuItem(string name, bool ActivStatus)
        {
            Name = name;
            IsEnabled = ActivStatus;
        }     
    }
}
