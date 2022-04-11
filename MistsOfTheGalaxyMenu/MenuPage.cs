using System;
using System.Collections.Generic;

namespace MistsOfTheGalaxyMenu
{
    internal class MenuPage
    {
        public List<MenuItem> MenuItems { get; }

        public MenuItem SelectedMenuItem
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

        private int? cursorPosition = null;

        private readonly MenuPageSettings _menuPageSettings;

        public MenuPage(MenuPageItemList menuPageItemList, MenuPageSettings menuPageSettings)
        {
            MenuItems = menuPageItemList?.MenuItems ?? throw new ArgumentNullException(nameof(menuPageItemList));

            _menuPageSettings = menuPageSettings;

            SetCursorPosition();
        }

        public MenuPage GetMenuPage(MenuPageItemList menuPageItemList)
        {
            var nextPage = new MenuPage(menuPageItemList, _menuPageSettings);

            return nextPage;
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
