using MistsOfTheGalaxyMenu;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MenuUnitTests
{
    [TestFixture]
    class NavigateUpTests
    {
        [TestCase(ItemSelectionMode.Select, NavigationMode.LoopOn)]
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOn)]
        [TestCase(ItemSelectionMode.Select, NavigationMode.LoopOff)]
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOff)]

        public void Check_All_Mode_EmptyMenuItemList(
            ItemSelectionMode itemSelectionMode,
            NavigationMode navigationType)
        {
            List<MenuItem> menuItems = new List<MenuItem> { };

            MenuTheme menuTheme = new MenuTheme()
            {
                DisabledItemSelectionMode = itemSelectionMode,
                NavigationMode = navigationType,
            };

            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [TestCase(ItemSelectionMode.Select, NavigationMode.LoopOn)]
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOn)]
        [TestCase(ItemSelectionMode.Select, NavigationMode.LoopOff)]
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOff)]

        public void Check_All_Mode_OneEnableMenuItem(
            ItemSelectionMode itemSelectionMode,
            NavigationMode navigationType)
        {
            List<MenuItem> menuItems = new List<MenuItem> { new MenuItem("a", true) };

            MenuTheme menuTheme = new MenuTheme()
            {
                DisabledItemSelectionMode = itemSelectionMode,
                NavigationMode = navigationType,
            };

            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [TestCase(ItemSelectionMode.Select, NavigationMode.LoopOn)]
        [TestCase(ItemSelectionMode.Select, NavigationMode.LoopOff)]

        public void Check_Select_Mode_OneDisableMenuItem(
            ItemSelectionMode itemSelectionMode, 
            NavigationMode navigationType) 
        {
            List<MenuItem> menuItems = new List<MenuItem> { new MenuItem("a", false) };

            MenuTheme menuTheme = new MenuTheme()
            {
                DisabledItemSelectionMode = itemSelectionMode,
                NavigationMode = navigationType,
            };

            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }
        
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOn)]
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOff)]

        public void Check_Skip_Mode_OneDisableMenuItem(  
            ItemSelectionMode itemSelectionMode, 
            NavigationMode navigationType) 
        {
            List<MenuItem> menuItems = new List<MenuItem> { new MenuItem("a", false) };

            MenuTheme menuTheme = new MenuTheme()
            {
                DisabledItemSelectionMode = itemSelectionMode,
                NavigationMode = navigationType,
            };

            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        public static IEnumerable<TestCaseData> LoopOn_Select_Mode_TestDataCase
        {
            get
            {
                MenuItem firstMenuItem = new MenuItem("a", false);
                MenuItem secondMenuItem = new MenuItem("b", true);
                MenuItem thirdMenuItem = new MenuItem("c", false);
                MenuItem fourthMenuItem = new MenuItem("d", true);
                MenuItem fifthMenuItem = new MenuItem("e", false);

                yield return new TestCaseData(new List<MenuItem> { firstMenuItem, secondMenuItem, thirdMenuItem, fourthMenuItem, fifthMenuItem }, fifthMenuItem );
                yield return new TestCaseData(new List<MenuItem> { secondMenuItem, firstMenuItem, thirdMenuItem, fifthMenuItem, fourthMenuItem }, fourthMenuItem );
            }
        }

        [TestCaseSource(nameof(LoopOn_Select_Mode_TestDataCase))]
        public void Check_LoopOn_Select_Mode_MenuItemList(List<MenuItem> list, MenuItem expectedResult)
        {
            MenuTheme menuTheme = new MenuTheme()
            {
                NavigationMode = NavigationMode.LoopOn,
                DisabledItemSelectionMode = ItemSelectionMode.Select,
            };

            Menu menu = new Menu(menuTheme, list);

            menu.NavigateUp();

            Assert.AreEqual(expectedResult, menu.SelectedMenuItem);
        }
        
        public static IEnumerable<TestCaseData> LoopOff_Select_Mode_TestDataCase
        {
            get
            {
                MenuItem firstMenuItem = new MenuItem("a", false);
                MenuItem secondMenuItem = new MenuItem("b", true);
                MenuItem thirdMenuItem = new MenuItem("c", false);
                MenuItem fourthMenuItem = new MenuItem("d", true);
                MenuItem fifthMenuItem = new MenuItem("e", false);

                yield return new TestCaseData(new List<MenuItem> { firstMenuItem, secondMenuItem, thirdMenuItem, fourthMenuItem, fifthMenuItem }, firstMenuItem );
                yield return new TestCaseData(new List<MenuItem> { secondMenuItem, firstMenuItem, thirdMenuItem, fifthMenuItem, fourthMenuItem }, secondMenuItem );
            }
        }

        [TestCaseSource(nameof(LoopOff_Select_Mode_TestDataCase))]
        public void Check_LoopOff_Select_Mode_MenuItemList(List<MenuItem> list, MenuItem expectedResult)
        {
            MenuTheme menuTheme = new MenuTheme()
            {
                NavigationMode = NavigationMode.LoopOff,
                DisabledItemSelectionMode = ItemSelectionMode.Select,
            };

            Menu menu = new Menu(menuTheme, list);

            menu.NavigateUp();

            Assert.AreEqual(expectedResult, menu.SelectedMenuItem);
        }
        
        public static IEnumerable<TestCaseData> LoopOn_Skip_Mode_TestDataCase
        {
            get
            {
                MenuItem firstMenuItem = new MenuItem("a", false);
                MenuItem secondMenuItem = new MenuItem("b", true);
                MenuItem thirdMenuItem = new MenuItem("c", false);
                MenuItem fourthMenuItem = new MenuItem("d", true);
                MenuItem fifthMenuItem = new MenuItem("e", false);

                yield return new TestCaseData(new List<MenuItem> { firstMenuItem, secondMenuItem, thirdMenuItem, fourthMenuItem, fifthMenuItem }, fourthMenuItem);
                yield return new TestCaseData(new List<MenuItem> { firstMenuItem, secondMenuItem, fourthMenuItem, thirdMenuItem, fifthMenuItem }, fourthMenuItem);
            }
        }

        [TestCaseSource(nameof(LoopOn_Skip_Mode_TestDataCase))]
        public void Check_LoopOn_Skip_Mode_MenuItemList(List<MenuItem> list, MenuItem expectedResult)
        {
            MenuTheme menuTheme = new MenuTheme()
            {
                NavigationMode = NavigationMode.LoopOn,
                DisabledItemSelectionMode = ItemSelectionMode.Skip,
            };

            Menu menu = new Menu(menuTheme, list);

            menu.NavigateUp();

            Assert.AreEqual(expectedResult, menu.SelectedMenuItem);
        }
        
        public static IEnumerable<TestCaseData> LoopOff_Skip_Mode_TestDataCase
        {
            get
            {
                MenuItem firstMenuItem = new MenuItem("a", false);
                MenuItem secondMenuItem = new MenuItem("b", true);
                MenuItem thirdMenuItem = new MenuItem("c", false);
                MenuItem fourthMenuItem = new MenuItem("d", true);
                MenuItem fifthMenuItem = new MenuItem("e", false);

                yield return new TestCaseData(new List<MenuItem> { firstMenuItem, secondMenuItem, thirdMenuItem, fourthMenuItem, fifthMenuItem }, secondMenuItem);
                yield return new TestCaseData(new List<MenuItem> { secondMenuItem, firstMenuItem, fourthMenuItem, thirdMenuItem, fifthMenuItem }, secondMenuItem);
            }
        }

        [TestCaseSource(nameof(LoopOff_Skip_Mode_TestDataCase))]
        public void Check_LoopOff_Skip_Mode_MenuItemList(List<MenuItem> list, MenuItem expectedResult)
        {
            MenuTheme menuTheme = new MenuTheme()
            {
                NavigationMode = NavigationMode.LoopOff,
                DisabledItemSelectionMode = ItemSelectionMode.Skip,
            };

            Menu menu = new Menu(menuTheme, list);

            menu.NavigateUp();

            Assert.AreEqual(expectedResult, menu.SelectedMenuItem);
        }
    }
}
