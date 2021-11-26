using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExample
{
    class MenuItem
    {
        public Action Operation { get; set; }   

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }  
        }

        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; } 
        }

        public MenuItem(string name)
        {
            Name = name;
        }
    }
}
