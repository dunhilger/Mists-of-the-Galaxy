using MistsOfTheGalaxyMenu.Interfaces;
using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс для создания списка команд страницы меню
    /// </summary>
    public class MenuPageItemList 
    {
        /// <summary>
        /// Список команд страницы меню
        /// </summary>
        public List<IMenuItem> MenuItems { get; }

        /// <summary>
        /// Команда меню, отмеченная индикатором 
        /// </summary>
        public MenuItemOptional IsIndicate { get; set; }

        /// <summary>
        /// Создание экземпляра <see cref="MenuPageItemList"/>
        /// </summary>
        /// <param name="menuItems">Список команд страницы меню</param>
        public MenuPageItemList(List<IMenuItem> menuItems)
        {
            MenuItems = menuItems ?? throw new ArgumentNullException(nameof(menuItems));
        }
    }
}
