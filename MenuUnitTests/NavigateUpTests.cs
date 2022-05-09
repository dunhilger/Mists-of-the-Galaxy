using MistsOfTheGalaxyMenu;
using MistsOfTheGalaxyMenu.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MenuUnitTests
{
    [TestFixture]
    class NavigateUpTests
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
            var menuItems = new List<IMenuItem> { };

            var menuPageItemList = new MenuPageItemList(menuItems);

            var menuPageSettings = new MenuPageSettings(navigationMode, disabledItemSelectionMode);

            var menuPage = new MenuPage(menuPageItemList, menuPageSettings, null, null);

            menuPage.NavigateUp();

            Assert.AreEqual(null, menuPage.SelectedMenuItem);
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
            Action<MenuNavigator> _noAction = n => { };

            var menuItems = new List<IMenuItem> { new MenuItem("a", true, _noAction) };

            var menuPageItemList = new MenuPageItemList(menuItems);

            var menuPageSettings = new MenuPageSettings(navigationMode, disabledItemSelectionMode);

            var menuPage = new MenuPage(menuPageItemList, menuPageSettings, null, null);

            menuPage.NavigateUp();

            Assert.AreEqual(menuItems[0], menuPage.SelectedMenuItem);
        }

        [TestCase(NavigationMode.LoopOn)]
        [TestCase(NavigationMode.LoopOff)]

        [Test]
        public void Check_Select_Mode_OneDisabledMenuItem(NavigationMode navigationMode) 
        {
            Action<MenuNavigator> _noAction = n => { };

            var menuItems = new List<IMenuItem> { new MenuItem("a", false, _noAction) };

            var menuPageItemList = new MenuPageItemList(menuItems);

            var menuPageSettings = new MenuPageSettings(navigationMode, DisabledItemSelectionMode.Select);

            var menuPage = new MenuPage(menuPageItemList, menuPageSettings, null, null);

            menuPage.NavigateUp();

            Assert.AreEqual(menuItems[0], menuPage.SelectedMenuItem);
        }
        
        [TestCase(NavigationMode.LoopOn)]
        [TestCase(NavigationMode.LoopOff)]

        [Test]
        public void Check_Skip_Mode_OneDisabledMenuItem(NavigationMode navigationMode) 
        {
            Action<MenuNavigator> _noAction = n => { };

            var menuItems = new List<IMenuItem> { new MenuItem("a", false, _noAction) };

            var menuPageItemList = new MenuPageItemList(menuItems);

            var menuPageSettings = new MenuPageSettings(navigationMode, DisabledItemSelectionMode.Skip);

            var menuPage = new MenuPage(menuPageItemList, menuPageSettings, null, null);

            menuPage.NavigateUp();

            Assert.AreEqual(null, menuPage.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 1 }, 2, 1)]
        [TestCase(new int[] { 0, 1, 1, 0 }, 5, 3)]
        [TestCase(new int[] { 1, 1, 1, 0, 1 }, 5, 0)]

        [Test]
        public void Check_LoopOn_Select_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            Action<MenuNavigator> _noAction = n => { };

            var menuItems = new List<IMenuItem> { };

            foreach (int flag in enableFlags)
            {
                menuItems.Add(new MenuItem("a", Convert.ToBoolean(flag), _noAction));
            }

            var menuPageItemList = new MenuPageItemList(menuItems);

            var menuPageSettings = new MenuPageSettings(NavigationMode.LoopOn, DisabledItemSelectionMode.Select);

            var menuPage = new MenuPage(menuPageItemList, menuPageSettings, null, null);

            for (int i = 0; i < moveCounter; i++)
            {
                menuPage.NavigateUp();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = (MenuItem)menuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, menuPage.SelectedMenuItem);
        }

        [TestCase(new int[] { 1, 0, 1 }, 2, 0)]
        [TestCase(new int[] { 0, 1, 1 }, 2, 0)]
        [TestCase(new int[] { 0, 0, 1 }, 2, 0)]

        [Test]
        public void Check_LoopOff_Select_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            Action<MenuNavigator> _noAction = n => { };

            var menuItems = new List<IMenuItem> { };

            foreach (int flag in enableFlags)
            {
                menuItems.Add(new MenuItem("a", Convert.ToBoolean(flag), _noAction));
            }

            var menuPageItemList = new MenuPageItemList(menuItems);

            var menuPageSettings = new MenuPageSettings(NavigationMode.LoopOff, DisabledItemSelectionMode.Select);

            var menuPage = new MenuPage(menuPageItemList, menuPageSettings, null, null);

            for (int i = 0; i < moveCounter; i++)
            {
                menuPage.NavigateUp();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = (MenuItem)menuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, menuPage.SelectedMenuItem);
        }
        
        [TestCase(new int[] { 0, 1, 0}, 2, 1)]
        [TestCase(new int[] { 0, 1, 1, 0}, 3, 2)]
        [TestCase(new int[] { 1, 0, 0, 1}, 3, 3)]

        [Test]
        public void Check_LoopOn_Skip_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            Action<MenuNavigator> _noAction = n => { };

            var menuItems = new List<IMenuItem> { };

            foreach (int flag in enableFlags)
            {
                menuItems.Add(new MenuItem("a", Convert.ToBoolean(flag), _noAction));
            }

            var menuPageItemList = new MenuPageItemList(menuItems);

            var menuPageSettings = new MenuPageSettings(NavigationMode.LoopOn, DisabledItemSelectionMode.Skip);

            var menuPage = new MenuPage(menuPageItemList, menuPageSettings, null, null);

            for (int i = 0; i < moveCounter; i++)
            {
                menuPage.NavigateUp();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = (MenuItem)menuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, menuPage.SelectedMenuItem);
        }
        
        [TestCase(new int[] { 0, 1, 0}, 2, 1)]
        [TestCase(new int[] { 1, 1, 0}, 2, 0)]
        [TestCase(new int[] { 0, 0, 1, 0 }, 2, 2)]

        [Test]
        public void Check_LoopOff_Skip_Mode_MenuItemList(int[] enableFlags, int moveCounter, int? selectedIndex)
        {
            Action<MenuNavigator> _noAction = n => { };

            var menuItems = new List<IMenuItem> { };

            foreach (int flag in enableFlags)
            {
                menuItems.Add(new MenuItem("a", Convert.ToBoolean(flag), _noAction));
            }

            var menuPageItemList = new MenuPageItemList(menuItems);

            var menuPageSettings = new MenuPageSettings(NavigationMode.LoopOff, DisabledItemSelectionMode.Skip);

            var menuPage = new MenuPage(menuPageItemList, menuPageSettings, null, null);

            for (int i = 0; i < moveCounter; i++)
            {
                menuPage.NavigateUp();
            }

            MenuItem expectedMenuItem = null;

            if (selectedIndex.HasValue)
            {
                expectedMenuItem = (MenuItem)menuItems[selectedIndex.Value];
            }

            Assert.AreEqual(expectedMenuItem, menuPage.SelectedMenuItem);
        }
    }
}
