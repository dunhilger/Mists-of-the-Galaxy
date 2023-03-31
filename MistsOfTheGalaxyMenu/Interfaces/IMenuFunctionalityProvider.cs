namespace MenuStucture.Interfaces
{
    /// <summary>
    /// Интерфейс класса - поставщика функционала меню
    /// </summary>
    public interface IMenuFunctionalityProvider
    {
        /// <summary>
        /// Возврат на предыдущую страницу меню
        /// </summary>
        void TurnToPreviousPage();

        /// <summary>
        /// Возврат на главную страницу меню
        /// </summary>
        void TurnToMainPage();

        /// <summary>
        /// Завершение работы меню
        /// </summary>
        void CloseMenu();

        /// <summary>
        /// Переход к следующей странице меню
        /// </summary>
        /// <param name="MenuPageItemList">Список команд следующей страницы меню</param>
        void NavigateToNextPage(MenuPageItemList MenuPageItemList);

        /// <summary>
        /// Устанавливает тему меню.
        /// </summary>
        /// <param name="theme">Тема меню.</param>
        void SetTheme(MenuTheme theme);
    }
}
