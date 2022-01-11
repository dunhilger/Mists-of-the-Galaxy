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
        public string Name { get; }
        public bool IsEnabled { get; } 

        public MenuItem(string name, bool ActivStatus)
        {
            Name = name;
            IsEnabled = ActivStatus;
        }     
    }
}
