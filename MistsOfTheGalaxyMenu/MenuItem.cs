using MenuStucture.Interfaces;
using System;

namespace MenuStucture
{
    /// <summary>
    /// Класс для создания команды меню
    /// </summary>
    public class MenuItem : IMenuItem
    {
        /// <summary>
        /// Создание экземпляра <see cref="MenuItem"/> с функцией навигации
        /// </summary>
        /// <param name="name">Имя команды</param>
        /// <param name="isEnabled">Доступность команды</param>
        /// <param name="action">Действие команды</param>
        public MenuItem(string name, bool isEnabled, Action<IMenuFunctionalityProvider> action)
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
