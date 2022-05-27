using System;

namespace MistsOfTheGalaxyMenu.Interfaces
{
    /// <summary>
    /// Интерфейс команды меню
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Имя команды меню
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Свойство доступности команды меню
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// Действие навигационного типа
        /// </summary>
        Action<IMenuFunctionalityProvider> NavigatorAction { get; }
    }
}
