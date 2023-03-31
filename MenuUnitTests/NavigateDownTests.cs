using MenuStucture;
using MenuStucture.Interfaces;
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
            var MenuItems = new List<IMenuItem> { };

            var MenuPageItemList = new MenuPageItemList(MenuItems);

            var MenuPageSettings = new MenuPageSettings(navigationMode, disabledItemSelectionMode);

            var MenuPage = new MenuPage(MenuPageItemList, MenuPageSettings, null);

            MenuPage.NavigateDown();

            Assert.AreEqual(null, MenuPage.SelectedMenuItem);
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
            Action<IMenuFunctionalityProvider> _noAction = n => { };

            var MenuItems = new List<IMenuItem> { new MenuItem("a", true, _noAction) };

            var MenuPageItemList = new MenuPageItemList(MenuItems);

            var MenuPageSettings = new MenuPageSettings(navigationMode, disabledItemSelectionMode);

            var MenuPage = new MenuPage(MenuPageItemList, MenuPageSettings, null);

            MenuPage.NavigateDown();

            Assert.AreEqual(MenuItems[0], MenuPage.SelectedMenuItem);
        }

        [TestCase(NavigationMode.LoopOn)]
        [TestCase(NavigationMode.LoopOff)]

        [Test]
        public void Check_Select_Mode_OneDisabledMenuItem(NavigationMode navigationMode)
        {
            Action<IMenuFunctionalityProvider> _noAction = n => { };

            var MenuItems = new List<IMenuItem> { new MenuItem("a", false, _noAction) };

            var MenuPageItemList = new MenuPageItemList(MenuItems);

            var MenuPageSettings = new MenuPageSettings(navigationMode, DisabledItemSelectionMode.Select);

            var MenuPage = new MenuPage(MenuPageItemList, MenuPageSettings, null);

            MenuPage.NavigateDown();

            Assert.AreEqual(MenuItems[0], MenuPage.SelectedMenuItem);
        }

        [TestCase(NavigationMode.LoopOn)]
        [TestCase(NavigationMode.LoopOff)]

        [Test]
        public void Check_Skip_Mode_OneDisabledMenuItem(NavigationMode navigationMode)
        {
            Action<IMenuFunctionalityProvider> _noAction = n => { };

            var MenuItems = new List<IMenuItem> { new MenuItem("a", false, _noAction) };

            var MenuPageItemList = new MenuPageItemList(MenuItems);

            var MenuPageSettings = new MenuPageSettings(navigationMode, DisabledItemSelectionMode.Skip);

            var MenuPage = new MenuPage(MenuPageItemList, MenuPageSettings, null);

            MenuPage.NavigateDown();

            Assert.AreEqual(null, MenuPage.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 1 }, 3, 0)]
        [TestCase(new int[] { 0, 1, 1, 0 }, 5, 1)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 5, 1)]

        [Test]
        public void Check_LoopOn_Select_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            Action<IMenuFunctionalityProvider> _noAction = n => { };

            var MenuItems = new List<IMenuItem> { };

            foreach (int flag in enableFlags)
            {
                MenuItems.Add(new MenuItem("a", Convert.ToBoolean(flag), _noAction));
            }

            var MenuPageItemList = new MenuPageItemList(MenuItems);

            var MenuPageSettings = new MenuPageSettings(NavigationMode.LoopOn, DisabledItemSelectionMode.Select);

            var MenuPage = new MenuPage(MenuPageItemList, MenuPageSettings, null);

            for (int i = 0; i < moveCounter; i++)
            {
                MenuPage.NavigateDown();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = (MenuItem)MenuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, MenuPage.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 1 }, 3, 2)]
        [TestCase(new int[] { 0, 1, 0 }, 3, 2)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 4, 3)]

        [Test]
        public void Check_LoopOff_Select_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            Action<IMenuFunctionalityProvider> _noAction = n => { };

            var MenuItems = new List<IMenuItem> { };

            foreach (int flag in enableFlags)
            {
                MenuItems.Add(new MenuItem("a", Convert.ToBoolean(flag), _noAction));
            }

            var MenuPageItemList = new MenuPageItemList(MenuItems);

            var MenuPageSettings = new MenuPageSettings(NavigationMode.LoopOff, DisabledItemSelectionMode.Select);

            var MenuPage = new MenuPage(MenuPageItemList, MenuPageSettings, null);

            for (int i = 0; i < moveCounter; i++)
            {
                MenuPage.NavigateDown();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = (MenuItem)MenuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, MenuPage.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 1 }, 2, 0)]
        [TestCase(new int[] { 0, 1, 1, 0 }, 3, 2)]
        [TestCase(new int[] { 0, 1, 1, 0, 1, 0, 0 }, 3, 1)]

        [Test]
        public void Check_LoopOn_Skip_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            Action<IMenuFunctionalityProvider> _noAction = n => { };

            var MenuItems = new List<IMenuItem> { };

            foreach (int flag in enableFlags)
            {
                MenuItems.Add(new MenuItem("a", Convert.ToBoolean(flag), _noAction));
            }

            var MenuPageItemList = new MenuPageItemList(MenuItems);

            var MenuPageSettings = new MenuPageSettings(NavigationMode.LoopOn, DisabledItemSelectionMode.Skip);

            var MenuPage = new MenuPage(MenuPageItemList, MenuPageSettings, null);

            for (int i = 0; i < moveCounter; i++)
            {
                MenuPage.NavigateDown();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = (MenuItem)MenuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, MenuPage.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 0, 1 }, 2, 3)]
        [TestCase(new int[] { 0, 1, 1, 0 }, 2, 2)]
        [TestCase(new int[] { 0, 1, 0, 1 }, 2, 3)]

        [Test]
        public void Check_LoopOff_Skip_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            Action<IMenuFunctionalityProvider> _noAction = n => { };

            var MenuItems = new List<IMenuItem> { };

            foreach (int flag in enableFlags)
            {
                MenuItems.Add(new MenuItem("a", Convert.ToBoolean(flag), _noAction));
            }

            var MenuPageItemList = new MenuPageItemList(MenuItems);

            var MenuPageSettings = new MenuPageSettings(NavigationMode.LoopOff, DisabledItemSelectionMode.Skip);

            var MenuPage = new MenuPage(MenuPageItemList, MenuPageSettings, null);

            for (int i = 0; i < moveCounter; i++)
            {
                MenuPage.NavigateDown();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = (MenuItem)MenuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, MenuPage.SelectedMenuItem);
        }
    }
}
