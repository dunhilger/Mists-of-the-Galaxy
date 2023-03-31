using MenuStucture.Interfaces;
using System;
using System.Collections.Generic;

namespace MenuStucture
{
    /// <summary>
    /// Класс для создания списка команд страницы меню
    /// </summary>
    public class MenuPageItemList 
    {
        /// <summary>
        /// Создание экземпляра <see cref="MenuPageItemList"/>
        /// </summary>
        /// <param name="MenuItems">Список команд страницы меню</param>
        public MenuPageItemList(List<IMenuItem> MenuItems)
        {
            this.MenuItems = MenuItems ?? throw new ArgumentNullException(nameof(MenuItems));
        }

        /// <summary>
        /// Список команд страницы меню
        /// </summary>
        public List<IMenuItem> MenuItems { get; }

        /// <summary>
        /// Команда меню, отмеченная индикатором 
        /// </summary>
        public MenuItemOptional IsIndicate { get; set; }
    }
}
