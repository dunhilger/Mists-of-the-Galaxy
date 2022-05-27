using MistsOfTheGalaxyMenu.Interfaces;
using System;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Ложный класс - поставщик функционала меню
    /// </summary>
    public class FakeMenuFunctionalityProvider : IMenuFunctionalityProvider
    {
        private readonly MenuNavigatorParameters _menuNavigatorParameters;

        /// <summary>
        /// Создание экземпляра <see cref="FakeMenuFunctionalityProvider"/>
        /// </summary>
        /// <param name="menuNavigatorParameters">Параметры навигации меню</param>

        public FakeMenuFunctionalityProvider(MenuNavigatorParameters menuNavigatorParameters)
        {
            _menuNavigatorParameters = menuNavigatorParameters;
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.CloseMenu"/>
        /// </summary>
        public void CloseMenu()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.NavigateToNextPage(MenuPageItemList)"/>
        /// </summary>
        /// <param name="menuPageItemList">Список команд следующей страницы меню</param>
        public void NavigateToNextPage(MenuPageItemList menuPageItemList)
        {
            _menuNavigatorParameters.MenuPageItemList = menuPageItemList;
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.SetTheme(MenuTheme)"/>
        /// </summary>
        /// <param name="theme">Тема меню.</param>
        public void SetTheme(MenuTheme theme)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.TurnToMainPage"/>
        /// </summary>
        public void TurnToMainPage()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// <inheritdoc cref="IMenuFunctionalityProvider.TurnToPreviousPage"/>
        /// </summary>
        public void TurnToPreviousPage()
        {
            //throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Класс для хранения параметров навигации меню
    /// </summary>
    public class MenuNavigatorParameters
    {
        /// <summary>
        /// Список команд страницы
        /// </summary>
        public MenuPageItemList MenuPageItemList { get; set; }
    }
}