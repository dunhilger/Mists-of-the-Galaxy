using System;
using System.Collections.Generic;

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

        public void NavigateToNextPage(MenuPageItemList menuPageItemList)
        {
            _menu.NavigateToNextPage(menuPageItemList);  
        }

        public void InsertPlug()
        {
            _menu.InsertPlug();
        }
    }
}
