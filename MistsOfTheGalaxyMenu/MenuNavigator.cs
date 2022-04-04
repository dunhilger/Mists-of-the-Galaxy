using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MistsOfTheGalaxyMenu
{
    public class MenuNavigator
    {
        private readonly Menu _menu;

        public MenuNavigator(Menu menu)
        {
            _menu = menu;
        }

        public void TurnToPreviousPage()
        {
            _menu.TurnToPreviousPage();
        }

        public void TurnToMainPage()
        {
            _menu.TurnToMainPage();
        }
    }
}
