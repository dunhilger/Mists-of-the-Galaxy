using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    public class MenuItem
    {
        public string Name { get; }

        public bool IsEnabled { get; }

        public MenuPageItemList MenuPageItemList { get; }

        public Action<MenuNavigator> Action { get; }

        public MenuItem(string name, bool isEnabled, MenuPageItemList menuPage = null)
        {
            Name = name;
            IsEnabled = isEnabled;
            MenuPageItemList = menuPage;
        }

        public MenuItem(string name, bool isEnabled, Action<MenuNavigator> action)
        {
            Name = name;
            IsEnabled = isEnabled;
            Action = action;
        }
    }
}
