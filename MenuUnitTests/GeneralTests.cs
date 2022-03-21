using MistsOfTheGalaxyMenu;
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
                yield return new TestCaseData(new List<MenuItem> { }, 0);
                yield return new TestCaseData(new List<MenuItem> { new MenuItem("a", false) }, 7);
                yield return new TestCaseData(new List<MenuItem>
                {
                    new MenuItem("ab", true),
                    new MenuItem("abc", true),
                    new MenuItem("abcd", true),
                    new MenuItem("abcde", true),
                    new MenuItem("abcdef", true),
                }, 12);
            }
        }

        [TestCaseSource(nameof(GetMenuWidth_TestDataCase))]

        [Test]
        public void Get_MenuWidth_Test(List<MenuItem> list, int expectedResult)
        {
            var menuTheme = new MenuTheme();
            var menu = new Menu(list, menuTheme);

            Assert.AreEqual(expectedResult, menu.MenuWidth);
        }

        public static IEnumerable<TestCaseData> MenuItems_TestDataCase
        {
            get
            {
                yield return new TestCaseData(new List<MenuItem> { }, 0);
                yield return new TestCaseData(new List<MenuItem> { new MenuItem("a", false) }, 1);
                yield return new TestCaseData(new List<MenuItem>
                {
                    new MenuItem("ab", true),
                    new MenuItem("abc", true),
                    new MenuItem("abcd", true),
                    new MenuItem("abcde", true),
                    new MenuItem("abcdef", true),
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
            var menuTheme = new MenuTheme();
            var menu = new Menu(new List<MenuItem>(), menuTheme);

            Assert.AreEqual(menuTheme, menu.Theme);
        }

        [Test]
        public void Menu_Default_Theme_Test()
        {
            var menu = new Menu(new List<MenuItem>());

            Assert.NotNull(menu.Theme);
        }

        [Test]
        public void Menu_Test()
        {
            var menuTheme = new MenuTheme();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var menu = new Menu(null, menuTheme);
            });
        }        
    }
}
