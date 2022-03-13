using NUnit.Framework;
using MistsOfTheGalaxyMenu;
using System.Collections.Generic;

namespace UnitTests
{
    public class Tests
    {

        //LoopOnSkip
        //____________

        public static IEnumerable<TestCaseData> LoopOn_NavigateDown_TestDataCase
        {
            get
            {
                yield return new TestCaseData(new List<MenuItem> { }, null);
                yield return new TestCaseData(new List<MenuItem> { new MenuItem("a", false) }, null);                       
            }
        }

        [TestCaseSource(nameof(LoopOn_NavigateDown_TestDataCase))]
        public void LoopOnSkipMode_NavigationDown_Test(List<MenuItem> list, int? expectedResult)
        {
            MenuTheme menuTheme = new MenuTheme()   
            {
                DisabledItemSelectionMode = ItemSelectionMode.Skip,
                NavigationMode = NavigationMode.LoopOn,
            };

            Menu menu = new Menu(menuTheme, list);

            menu.NavigateDown();

            Assert.AreEqual(expectedResult, menu.SelectedMenuItem);
        }

        //____________


        [Test]
        public void LoopOnSkipMode_NavigationDownTest_OneEnableMenuItem()  
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", true),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOnSkipMode_NavigationDownTest_OneDisableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOnSkipMode_NavigationDownTest_ListMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
                new MenuItem("b", true),
                new MenuItem("c", false),
                new MenuItem("d", true),
                new MenuItem("e", false),
            };
            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            for (int i = 0; i < menuItems.Count; i++)
            {
                menu.NavigateDown();
            }

            Assert.AreEqual(menuItems[3], menu.SelectedMenuItem);
        }


        [Test]
        public void LoopOnSkipMode_NavigationUpTest_ListMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
                new MenuItem("b", true),
                new MenuItem("c", false),
                new MenuItem("d", true),
                new MenuItem("e", false),
            };
            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[3], menu.SelectedMenuItem);
        }

        //LoopOn_Select

        [Test]
        public void LoopOnSelectMode_NavigationDownTest_EmptyMenuItemList()
        {
            List<MenuItem> menuItems = new List<MenuItem> { };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOnSelectMode_NavigationDownTest_OneEnableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", true),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOnSelectMode_NavigationDownTest_OneDisableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOnSelectMode_NavigationDownTest_ListMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
                new MenuItem("b", true),
                new MenuItem("c", false),
                new MenuItem("d", true),
                new MenuItem("e", false),
            };
            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            for (int i = 0; i < menuItems.Count; i++)
            {
                menu.NavigateDown();
            }

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOnSelectMode_NavigationUpTest_EmptyMenuItemList()
        {
            List<MenuItem> menuItems = new List<MenuItem> { };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOnSelectMode_NavigationUpTest_OneDisableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOnSelectMode_NavigationUpTest_OneEnableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", true),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOnSelectMode_NavigationUpTest_ListMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
                new MenuItem("b", true),
                new MenuItem("c", false),
                new MenuItem("d", true),
                new MenuItem("e", false),
            };
            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[4], menu.SelectedMenuItem);
        }

        //LoopOffSkip

        [Test]
        public void LoopOffSkipMode_NavigationDownTest_EmptyMenuItemList()
        {
            List<MenuItem> menuItems = new List<MenuItem> { };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();
                      
            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSkipMode_NavigationDownTest_OneEnableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", true),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSkipMode_NavigationDownTest_OneDisableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSkipMode_NavigationDownTest_ListMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
                new MenuItem("b", true),
                new MenuItem("c", false),
                new MenuItem("d", true),
                new MenuItem("e", false),
            };
            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            for (int i = 0; i < menuItems.Count; i++)
            {
                menu.NavigateDown();
            }

            Assert.AreEqual(menuItems[3], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSkipMode_NavigationUpTest_EmptyMenuItemList()
        {
            List<MenuItem> menuItems = new List<MenuItem> { };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSkipMode_NavigationUpTest_OneDisableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSkipMode_NavigationUpTest_OneEnableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", true),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSkipMode_NavigationUpTest_ListMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
                new MenuItem("b", true),
                new MenuItem("c", false),
                new MenuItem("d", true),
                new MenuItem("e", false),
            };
            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[1], menu.SelectedMenuItem);
        }

        //LoopOff_Select

        [Test]
        public void LoopOffSelectMode_NavigationDownTest_EmptyMenuItemList()
        {
            List<MenuItem> menuItems = new List<MenuItem> { };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSelectMode_NavigationDownTest_OneEnableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", true),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSelectMode_NavigationDownTest_OneDisableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateDown();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSelectMode_NavigationDownTest_ListMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
                new MenuItem("b", true),
                new MenuItem("c", false),
                new MenuItem("d", true),
                new MenuItem("e", false),
            };
            MenuTheme menuTheme = new MenuTheme() 
            { 
                NavigationMode = NavigationMode.LoopOff,
                DisabledItemSelectionMode = ItemSelectionMode.Select,
            };
            Menu menu = new Menu(menuTheme, menuItems);

            for (int i = 0; i < menuItems.Count; i++)
            {
                menu.NavigateDown();
            }

            Assert.AreEqual(menuItems[4], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSelectMode_NavigationUpTest_EmptyMenuItemList()
        {
            List<MenuItem> menuItems = new List<MenuItem> { };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(null, menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSelectMode_NavigationUpTest_OneDisableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSelectMode_NavigationUpTest_OneEnableMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", true),
            };

            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }

        [Test]
        public void LoopOffSelectMode_NavigationUpTest_ListMenuItem()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem("a", false),
                new MenuItem("b", true),
                new MenuItem("c", false),
                new MenuItem("d", true),
                new MenuItem("e", false),
            };
            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, menuItems);

            menu.NavigateUp();

            Assert.AreEqual(menuItems[0], menu.SelectedMenuItem);
        }
    }
}