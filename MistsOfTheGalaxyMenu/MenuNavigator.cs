namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс навигации между страницами меню
    /// </summary>
    public class MenuNavigator
    {
        private readonly Menu _menu;

        /// <summary>
        /// Создание экземпляра <see cref="MenuNavigator"/>
        /// </summary>
        /// <param name="menu">Экземпляр класса <see cref="Menu"/></param>
        public MenuNavigator(Menu menu)
        {
            _menu = menu;
        }

        /// <summary>
        /// Возврат на предыдущую страницу меню
        /// </summary>
        public void TurnToPreviousPage()
        {
            _menu.TurnToPreviousPage();
        }

        /// <summary>
        /// Возврат на главную страницу меню
        /// </summary>
        public void TurnToMainPage()
        {
            _menu.TurnToMainPage();
        }

        /// <summary>
        /// Завершение работы меню
        /// </summary>
        public void CloseMenu()
        {
            Menu.CloseMenu();
        }

        /// <summary>
        /// Переход к следующей странице меню
        /// </summary>
        /// <param name="menuPageItemList">Список команд следующей страницы меню</param>
        public void NavigateToNextPage(MenuPageItemList menuPageItemList)
        {
            _menu.NavigateToNextPage(menuPageItemList);  
        }
    }
}
