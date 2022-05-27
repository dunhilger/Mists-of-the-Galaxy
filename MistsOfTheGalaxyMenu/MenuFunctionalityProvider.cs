using MistsOfTheGalaxyMenu.Interfaces;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс - поставщик функционала меню
    /// </summary>
    public class MenuFunctionalityProvider : IMenuFunctionalityProvider
    {
        /// <summary>
        /// Создание экземпляра <see cref="MenuFunctionalityProvider"/>
        /// </summary>
        /// <param name="menu">Экземпляр класса <see cref="Menu"/></param>
        public MenuFunctionalityProvider(Menu menu)
        {
            _menu = menu;
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.TurnToPreviousPage"/>
        /// </summary>
        public void TurnToPreviousPage()
        {
            _menu.TurnToPreviousPage();
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.TurnToMainPage"/>
        /// </summary>
        public void TurnToMainPage()
        {
            _menu.TurnToMainPage();
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.CloseMenu"/>
        /// </summary>
        public void CloseMenu()
        {
            _menu.CloseMenu();
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.NavigateToNextPage(MenuPageItemList)"/>
        /// </summary>
        /// <param name="menuPageItemList">Список команд следующей страницы меню</param>
        public void NavigateToNextPage(MenuPageItemList menuPageItemList)
        {
            _menu.NavigateToNextPage(menuPageItemList);  
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.SetTheme(MenuTheme)"/>
        /// </summary>
        /// <param name="theme">Тема меню</param>
        public void SetTheme(MenuTheme theme)
        {
            _menu.SetTheme(theme);
        }

        private readonly Menu _menu;
    }
}
