using MistsOfTheGalaxyMenu.Interfaces;
using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    /// <summary>
    /// Класс создания страницы меню
    /// </summary>
    public class MenuPage
    {
        /// <summary>
        /// Список команд страницы
        /// </summary>
        public List<IMenuItem> MenuItems { get; }

        /// <summary>
        /// Команда меню, выделенная курсором 
        /// </summary>
        public IMenuItem SelectedMenuItem
        {
            get
            {
                if (cursorPosition.HasValue)
                {
                    return MenuItems[cursorPosition.Value];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Команда меню, отмеченная индикатором  
        /// </summary>
        public MenuItemOptional IndicatedMenuItem { get; private set; }

        private int? cursorPosition = null;

        private readonly MenuPageItemList _menuPageItemList;

        private readonly MenuPageSettings _menuPageSettings;

        private readonly MenuNavigator _navigator;

        private readonly MenuDecorator _decorator;

        /// <summary>
        /// Создание экземпляра <see cref="MenuPage"/>
        /// </summary>
        /// <param name="menuPageItemList">Экземпляр класса <see cref="MenuPageItemList"/></param>
        /// <param name="menuPageSettings">Экземпляр класса <see cref="MenuPageSettings"/></param>
        /// <param name="navigator">Экземпляр класса <see cref="MenuNavigator"/></param>
        /// <param name="decorator">Экземпляр класса <see cref="MenuDecorator"/></param>
        public MenuPage(MenuPageItemList menuPageItemList, 
            MenuPageSettings menuPageSettings,
            MenuNavigator navigator,
            MenuDecorator decorator)
        {
            _menuPageItemList = menuPageItemList;

            IndicatedMenuItem = menuPageItemList?.IsIndicate;

            MenuItems = _menuPageItemList?.MenuItems ?? throw new ArgumentNullException(nameof(menuPageItemList));

            _menuPageSettings = menuPageSettings;

            _navigator = navigator;

            _decorator = decorator;

            SetCursorPosition();
        }

        private void Navigate(Func<int, int> getIndex)
        {
            if (cursorPosition == null || MenuItems.Count == 0) return;

            int i = cursorPosition.Value;

            while (true)
            {
                int previousEnabledIndex = i;

                i = getIndex(i);

                if (_menuPageSettings.DisabledItemSelectionMode == DisabledItemSelectionMode.Skip)
                {
                    if (i == cursorPosition.Value || MenuItems[i].IsEnabled)
                    {
                        break;
                    }
                    else if (i == previousEnabledIndex)
                    {
                        i = cursorPosition.Value;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            cursorPosition = i;
        }

        /// <summary>
        /// Активация команды, выделенной курсором 
        /// </summary>
        internal void ActivateItem()
        {
            if (SelectedMenuItem != null && SelectedMenuItem.IsEnabled)
            {
                if (SelectedMenuItem is MenuItemOptional menuItemOptional)
                {
                    _menuPageItemList.IsIndicate = menuItemOptional;
                    IndicatedMenuItem = _menuPageItemList.IsIndicate;                 
                }

                SelectedMenuItem.DecoratorAction?.Invoke(_decorator);
                SelectedMenuItem.NavigatorAction?.Invoke(_navigator);
            }
        }

        /// <summary>
        /// Навигация по странице вверх
        /// </summary>
        public void NavigateUp()
        {
            Navigate(index =>
            {
                index--;

                if (index < 0)
                {
                    switch (_menuPageSettings.NavigationMode)
                    {
                        case NavigationMode.LoopOff:
                            index++;
                            break;
                        case NavigationMode.LoopOn:
                            index = MenuItems.Count - 1;
                            break;
                    }
                }
                return index;
            });
        }

        /// <summary>
        /// Навигация по странице вниз
        /// </summary>
        public void NavigateDown()
        {
            Navigate(index =>
            {
                index++;

                if (index > MenuItems.Count - 1)
                {
                    switch (_menuPageSettings.NavigationMode)
                    {
                        case NavigationMode.LoopOff:
                            index--;
                            break;
                        case NavigationMode.LoopOn:
                            index = 0;
                            break;
                    }
                }
                return index;
            });
        }

        private void SetCursorPosition()
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (_menuPageSettings.DisabledItemSelectionMode == DisabledItemSelectionMode.Skip)
                {
                    if (MenuItems[i].IsEnabled)
                    {
                        cursorPosition = i;
                        break;
                    }
                }
                else
                {
                    cursorPosition = i;
                    break;
                }
            }
        }
    }
}
