namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс для редактирования темы меню.
    /// </summary>
    public class MenuDecorator
    {
        private readonly Menu _menu;

        /// <summary>
        /// Создает экземпляр <see cref="MenuDecorator"/>.
        /// </summary>
        /// <param name="menu">Экземпляр класса <see cref="Menu"/></param>
        public MenuDecorator(Menu menu)
        {
            _menu = menu;
        }
        
        /// <summary>
        /// Устанавливает тему меню.
        /// </summary>
        /// <param name="theme">Тема меню.</param>
        public void SetTheme(MenuTheme theme)
        {
            _menu.SetTheme(theme);
        }
    }
}
