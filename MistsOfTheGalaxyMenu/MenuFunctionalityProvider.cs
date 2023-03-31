using MenuStucture.Interfaces;

namespace MenuStucture
{
    /// <summary>
    /// Класс - поставщик функционала меню
    /// </summary>
    public class MenuFunctionalityProvider : IMenuFunctionalityProvider
    {
        /// <summary>
        /// Создание экземпляра <see cref="MenuFunctionalityProvider"/>
        /// </summary>
        /// <param name="Menu">Экземпляр класса <see cref="Menu"/></param>
        public MenuFunctionalityProvider(Menu Menu)
        {
            _Menu = Menu;
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.TurnToPreviousPage"/>
        /// </summary>
        public void TurnToPreviousPage()
        {
            _Menu.TurnToPreviousPage();
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.TurnToMainPage"/>
        /// </summary>
        public void TurnToMainPage()
        {
            _Menu.TurnToMainPage();
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.CloseMenu"/>
        /// </summary>
        public void CloseMenu()
        {
            _Menu.CloseMenu();
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.NavigateToNextPage(MenuPageItemList)"/>
        /// </summary>
        /// <param name="MenuPageItemList">Список команд следующей страницы меню</param>
        public void NavigateToNextPage(MenuPageItemList MenuPageItemList)
        {
            _Menu.NavigateToNextPage(MenuPageItemList);  
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.SetTheme(MenuTheme)"/>
        /// </summary>
        /// <param name="theme">Тема меню</param>
        public void SetTheme(MenuTheme theme)
        {
            _Menu.SetTheme(theme);
        }

        private readonly Menu _Menu;
    }
}
