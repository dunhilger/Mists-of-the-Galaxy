using NUnit.Framework;
using MistsOfTheGalaxyMenu;
using System.Collections.Generic;

namespace MenuUnitTests
{
    [TestFixture]
    public class NavigateDownTests
    {        
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOn)]
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOff)]

        public void NavigationDownTest_OneDisableMenuItem(
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
        

        [TestCase(ItemSelectionMode.Select, NavigationMode.LoopOn)]
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOn)]
        [TestCase(ItemSelectionMode.Select, NavigationMode.LoopOff)]
        [TestCase(ItemSelectionMode.Skip, NavigationMode.LoopOff)]

        public void NavigationDownTest_EmptyMenuItemList(
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

            menu.NavigateDown();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }
    }
}
