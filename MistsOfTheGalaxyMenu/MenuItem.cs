using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    public class MenuItem
    {
        public string Name { get; }
        public bool IsEnabled { get; } 

        public MenuItem(string name, bool ActivStatus)
        {
            Name = name;
            IsEnabled = ActivStatus;
        }     
    }
}
