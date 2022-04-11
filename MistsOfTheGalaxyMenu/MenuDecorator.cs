using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    public class MenuDecorator
    {
        private readonly Menu _menu;

        public MenuDecorator(Menu menu)
        {
            _menu = menu;
        }

        public void SwitchOnLightTheme()
        {
            _menu.SwitchOnLightTheme();
        }
        
        public void SwitchOnDarkTheme()
        {
            _menu.SwitchOnDarkTheme();
        }
    }
}
