using MistsOfTheGalaxyMenu.Interfaces;
using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс для создания опциональной команды меню
    /// </summary>
    public class MenuItemOptional : IMenuItem
    {
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
        public Action<MenuNavigator> NavigatorAction { get; }

        /// <summary>
        /// <inheritdoc cref="IMenuItem.DecoratorAction"/>
        /// </summary>
        public Action<MenuDecorator> DecoratorAction { get; }

        /// <summary>
        /// Создание экземпляра <see cref="MenuItemOptional"/> с функцией навигации
        /// </summary>
        /// <param name="name">Имя команды</param>
        /// <param name="isEnabled">Доступность команды</param>
        /// <param name="action">Действие команды</param>
        public MenuItemOptional(string name, bool isEnabled, Action<MenuNavigator> action)
        {
            Name = name;
            IsEnabled = isEnabled;
            NavigatorAction = action;
        }

        /// <summary>
        /// Создание экземпляра <see cref="MenuItemOptional"/> с функцией управления темой меню 
        /// </summary>
        /// <param name="name">Имя команды</param>
        /// <param name="isEnabled">Доступность команды</param>
        /// <param name="action">Действие команды</param>
        public MenuItemOptional(string name, bool isEnabled, Action<MenuDecorator> action)
        {
            Name = name;
            IsEnabled = isEnabled;
            DecoratorAction = action;
        }
    }
}
