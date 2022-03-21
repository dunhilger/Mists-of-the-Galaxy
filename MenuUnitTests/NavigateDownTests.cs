using MistsOfTheGalaxyMenu;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MenuUnitTests
{
    [TestFixture]
    class NavigateDownTests
    {
        [TestCase(DisabledItemSelectionMode.Select, NavigationMode.LoopOn)]
        [TestCase(DisabledItemSelectionMode.Skip, NavigationMode.LoopOn)]
        [TestCase(DisabledItemSelectionMode.Select, NavigationMode.LoopOff)]
        [TestCase(DisabledItemSelectionMode.Skip, NavigationMode.LoopOff)]

        [Test]
        public void Check_All_Mode_EmptyMenuItemList(
            DisabledItemSelectionMode disabledItemSelectionMode,
            NavigationMode navigationMode)
        {
            var menuItems = new List<MenuItem> { };

            var menuTheme = new MenuTheme()
            {
                DisabledItemSelectionMode = disabledItemSelectionMode,
                NavigationMode = navigationMode,
            };

            var menu = new Menu(menuItems, menuTheme);

            menu.NavigateDown();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [TestCase(DisabledItemSelectionMode.Select, NavigationMode.LoopOn)]
        [TestCase(DisabledItemSelectionMode.Skip, NavigationMode.LoopOn)]
        [TestCase(DisabledItemSelectionMode.Select, NavigationMode.LoopOff)]
        [TestCase(DisabledItemSelectionMode.Skip, NavigationMode.LoopOff)]

        [Test]
        public void Check_All_Mode_OneEnabledMenuItem(
            DisabledItemSelectionMode disabledItemSelectionMode,
            NavigationMode navigationMode)
        {
            var menuItems = new List<MenuItem> { new MenuItem("a", true) };

            var menuTheme = new MenuTheme()
            {
                DisabledItemSelectionMode = disabledItemSelectionMode,
                NavigationMode = navigationMode,
            };

            var menu = new Menu(menuItems, menuTheme);

            menu.NavigateDown();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [TestCase(NavigationMode.LoopOn)]
        [TestCase(NavigationMode.LoopOff)]

        [Test]
        public void Check_Select_Mode_OneDisabledMenuItem(NavigationMode navigationMode)
        {
            var menuItems = new List<MenuItem> { new MenuItem("a", false) };

            var menuTheme = new MenuTheme()
            {
                DisabledItemSelectionMode = DisabledItemSelectionMode.Select,
                NavigationMode = navigationMode,
            };

            var menu = new Menu(menuItems, menuTheme);

            menu.NavigateDown();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [TestCase(NavigationMode.LoopOn)]
        [TestCase(NavigationMode.LoopOff)]

        [Test]
        public void Check_Skip_Mode_OneDisabledMenuItem(NavigationMode navigationMode)
        {
            var menuItems = new List<MenuItem> { new MenuItem("a", false) };

            var menuTheme = new MenuTheme()
            {
                DisabledItemSelectionMode = DisabledItemSelectionMode.Skip,
                NavigationMode = navigationMode,
            };

            var menu = new Menu(menuItems, menuTheme);

            menu.NavigateDown();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 1 }, 3, 0)]
        [TestCase(new int[] { 0, 1, 1, 0 }, 5, 1)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 5, 1)]

        [Test]
        public void Check_LoopOn_Select_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            var menuTheme = new MenuTheme()
            {
                NavigationMode = NavigationMode.LoopOn,
                DisabledItemSelectionMode = DisabledItemSelectionMode.Select,
            };

            var menuItems = new List<MenuItem> { };

            foreach (int flag in enableFlags)
            {
                menuItems.Add(new MenuItem("a", Convert.ToBoolean(flag)));
            }

            var menu = new Menu(menuItems, menuTheme);

            for (int i = 0; i < moveCounter; i++)
            {
                menu.NavigateDown();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = menuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, menu.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 1 }, 3, 2)]
        [TestCase(new int[] { 0, 1, 0 }, 3, 2)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 4, 3)]

        [Test]
        public void Check_LoopOff_Select_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            var menuTheme = new MenuTheme()
            {
                NavigationMode = NavigationMode.LoopOff,
                DisabledItemSelectionMode = DisabledItemSelectionMode.Select,
            };

            var menuItems = new List<MenuItem> { };

            foreach (int flag in enableFlags)
            {
                menuItems.Add(new MenuItem("a", Convert.ToBoolean(flag)));
            }

            var menu = new Menu(menuItems, menuTheme);

            for (int i = 0; i < moveCounter; i++)
            {
                menu.NavigateDown();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = menuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, menu.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 1 }, 2, 0)]
        [TestCase(new int[] { 0, 1, 1, 0 }, 3, 2)]
        [TestCase(new int[] { 0, 1, 1, 0, 1, 0, 0 }, 3, 1)]

        [Test]
        public void Check_LoopOn_Skip_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            var menuTheme = new MenuTheme()
            {
                NavigationMode = NavigationMode.LoopOn,
                DisabledItemSelectionMode = DisabledItemSelectionMode.Skip,
            };

            var menuItems = new List<MenuItem> { };

            foreach (int flag in enableFlags)
            {
                menuItems.Add(new MenuItem("a", Convert.ToBoolean(flag)));
            }

            var menu = new Menu(menuItems, menuTheme);

            for (int i = 0; i < moveCounter; i++)
            {
                menu.NavigateDown();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = menuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, menu.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 0, 1 }, 2, 3)]
        [TestCase(new int[] { 0, 1, 1, 0 }, 2, 2)]
        [TestCase(new int[] { 0, 1, 0, 1 }, 2, 3)]

        [Test]
        public void Check_LoopOff_Skip_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            var menuTheme = new MenuTheme()
            {
                NavigationMode = NavigationMode.LoopOff,
                DisabledItemSelectionMode = DisabledItemSelectionMode.Skip,
            };

            var menuItems = new List<MenuItem> { };

            foreach (int flag in enableFlags)
            {
                menuItems.Add(new MenuItem("a", Convert.ToBoolean(flag)));
            }

            var menu = new Menu(menuItems, menuTheme);

            for (int i = 0; i < moveCounter; i++)
            {
                menu.NavigateDown();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = menuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, menu.SelectedMenuItem);
        }
    }
}
