using MenuStucture.Interfaces;
using System;

namespace MenuStucture
{
    /// <summary>
    /// Ложный класс - поставщик функционала меню
    /// </summary>
    public class FakeMenuFunctionalityProvider : IMenuFunctionalityProvider
    {
        private readonly MenuNavigatorParameters _MenuNavigatorParameters;

        /// <summary>
        /// Создание экземпляра <see cref="FakeMenuFunctionalityProvider"/>
        /// </summary>
        /// <param name="MenuNavigatorParameters">Параметры навигации меню</param>

        public FakeMenuFunctionalityProvider(MenuNavigatorParameters MenuNavigatorParameters)
        {
            _MenuNavigatorParameters = MenuNavigatorParameters;
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
        /// <param name="MenuPageItemList">Список команд следующей страницы меню</param>
        public void NavigateToNextPage(MenuPageItemList MenuPageItemList)
        {
            _MenuNavigatorParameters.MenuPageItemList = MenuPageItemList;
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