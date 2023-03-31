using MenuStucture.Interfaces;
using System;
using System.Collections.Generic;

namespace MenuStucture
{
    /// <summary>
    /// Класс создания страницы меню
    /// </summary>
    public class MenuPage
    {
        private readonly MenuPageItemList _MenuPageItemList;

        private readonly MenuPageSettings _MenuPageSettings;

        private readonly MenuFunctionalityProvider _MenuFunctionalityProvider;

        /// <summary>
        /// Создание экземпляра <see cref="MenuPage"/>
        /// </summary>
        /// <param name="MenuPageItemList">Экземпляр класса <see cref="MenuPageItemList"/></param>
        /// <param name="MenuPageSettings">Экземпляр класса <see cref="MenuPageSettings"/></param>
        /// <param name="MenuFunctionalityProvider">Экземпляр класса <see cref="MenuFunctionalityProvider"/></param>
        public MenuPage(MenuPageItemList MenuPageItemList,
            MenuPageSettings MenuPageSettings,
            MenuFunctionalityProvider MenuFunctionalityProvider)
        {
            _MenuPageItemList = MenuPageItemList;

            IndicatedMenuItem = MenuPageItemList?.IsIndicate;

            MenuItems = _MenuPageItemList?.MenuItems ?? throw new ArgumentNullException(nameof(MenuPageItemList));

            _MenuPageSettings = MenuPageSettings;

            _MenuFunctionalityProvider = MenuFunctionalityProvider;

            SetCursorPosition();
        }

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
                    switch (_MenuPageSettings.NavigationMode)
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
                    switch (_MenuPageSettings.NavigationMode)
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

        /// <summary>
        /// Активация команды, выделенной курсором 
        /// </summary>
        internal void ActivateItem()
        {
            if (SelectedMenuItem is not null && SelectedMenuItem.IsEnabled)
            {
                if (SelectedMenuItem is MenuItemOptional MenuItemOptional)
                {
                    _MenuPageItemList.IsIndicate = MenuItemOptional;
                    IndicatedMenuItem = _MenuPageItemList.IsIndicate;
                }

                SelectedMenuItem.NavigatorAction?.Invoke(_MenuFunctionalityProvider);
            }
        }

        private int? cursorPosition = null;
       
        private void Navigate(Func<int, int> getIndex)
        {
            if (cursorPosition == null || MenuItems.Count == 0) return;

            int i = cursorPosition.Value;

            while (true)
            {
                int previousEnabledIndex = i;

                i = getIndex(i);

                if (_MenuPageSettings.DisabledItemSelectionMode == DisabledItemSelectionMode.Skip)
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

        private void SetCursorPosition()
        {
            for (int i = 0; i < MenuItems.Count; i++)
            {
                if (_MenuPageSettings.DisabledItemSelectionMode == DisabledItemSelectionMode.Skip)
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
