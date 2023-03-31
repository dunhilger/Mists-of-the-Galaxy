using MenuStucture;
using MenuStucture.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MenuUnitTests
{
    [TestFixture]
    class GeneralTests
    {
        public static IEnumerable<TestCaseData> GetMenuWidth_TestDataCase
        {
            get
            {
                Action<IMenuFunctionalityProvider> _noAction = n => { };

                yield return new TestCaseData(new List<IMenuItem> { }, 0);
                yield return new TestCaseData(new List<IMenuItem> { new MenuItem("a", false, _noAction) }, 7);
                yield return new TestCaseData(new List<IMenuItem>
                {
                    new MenuItem("ab", true, _noAction),
                    new MenuItem("abc", true, _noAction),
                    new MenuItem("abcd", true, _noAction),
                    new MenuItem("abcde", true, _noAction),
                    new MenuItem("abcdef", true, _noAction),
                }, 12);
            }
        }

        [TestCaseSource(nameof(GetMenuWidth_TestDataCase))]

        [Test]
        public void Get_MenuWidth_Test(List<IMenuItem> list, int expectedResult)
        {
            var MenuTheme = new MenuTheme();
            var MenuPageItemList = new MenuPageItemList(list);
            var Menu = new Menu(MenuPageItemList, MenuTheme);

            Assert.AreEqual(expectedResult, Menu.MenuWidth);
        }

        public static IEnumerable<TestCaseData> MenuItems_TestDataCase
        {
            get
            {
                Action<IMenuFunctionalityProvider> _noAction = n => { };

                yield return new TestCaseData(new List<IMenuItem> { }, 0);
                yield return new TestCaseData(new List<IMenuItem> { new MenuItem("a", false, _noAction) }, 1);
                yield return new TestCaseData(new List<IMenuItem>
                {
                    new MenuItem("ab", true, _noAction),
                    new MenuItem("abc", true, _noAction),
                    new MenuItem("abcd", true, _noAction),
                    new MenuItem("abcde", true, _noAction),
                    new MenuItem("abcdef", true, _noAction),
                }, 5);
            }
        }

        [TestCaseSource(nameof(MenuItems_TestDataCase))]

        [Test]
        public void MenuItems_Test(List<MenuItem> list, int expectedResult)
        {
            Assert.AreEqual(list.Count, expectedResult);
        }

        [Test]
        public void Theme_Test()
        {
            var MenuTheme = new MenuTheme();
            var Menu = new Menu(new MenuPageItemList(new List<IMenuItem>()), MenuTheme);

            Assert.AreEqual(MenuTheme, Menu.Theme);
        }

        [Test]
        public void Menu_Default_Theme_Test()
        {
            var Menu = new Menu(new MenuPageItemList(new List<IMenuItem>()));

            Assert.NotNull(Menu.Theme);
        }

        [Test]
        public void Menu_Test()
        {
            var MenuTheme = new MenuTheme();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var Menu = new Menu(null, MenuTheme);
            });
        }        
    }
}
