using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    public class MenuPageItemList
    {
        public List<MenuItem> MenuItems { get; }

        public MenuPageItemList(List<MenuItem> menuItems)
        {
            MenuItems = menuItems ?? throw new ArgumentNullException(nameof(menuItems));
        }
    }
}
