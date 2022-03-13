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
        public void GetMenuWidthTest(List<MenuItem> list, int expectedResult)
        {
            MenuTheme menuTheme = new MenuTheme();
            Menu menu = new Menu(menuTheme, list);

            Assert.AreEqual(expectedResult, menu.MenuWidth);
        }
    }
}
