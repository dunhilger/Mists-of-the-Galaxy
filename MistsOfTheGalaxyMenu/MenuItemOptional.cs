using MistsOfTheGalaxyMenu.Interfaces;
using System;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс для создания опциональной команды меню
    /// </summary>
    public class MenuItemOptional : IMenuItem
    {
        /// <summary>
        /// Создание экземпляра <see cref="MenuItemOptional"/> с функцией навигации
        /// </summary>
        /// <param name="name">Имя команды</param>
        /// <param name="isEnabled">Доступность команды</param>
        /// <param name="action">Действие команды</param>
        public MenuItemOptional(string name, bool isEnabled, Action<IMenuFunctionalityProvider> action)
        {
            Name = name;
            IsEnabled = isEnabled;
            NavigatorAction = action;
        }

        /// <summary>
        /// <inheritdoc cref="IMenuItem.Name"/>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// <inheritdoc cref="IMenuItem.IsEnabled"/>
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// <inheritdoc cref="IMenuItem.NavigatorAction"/>
        /// </summary>
        public Action<IMenuFunctionalityProvider> NavigatorAction { get; }
    }
}
