using Actions_And_JS.WebDriver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions_And_JS.Tests
{
    public class BaseTest
    {
        protected static Browser Instance;
        [SetUp]
        public void Setup()
        {
            Instance = Browser.Instance;
            Browser.Navigate(Configuration.URL);
        }

        [TearDown]
        public void CleanUp()
        {
            Browser.Quit();
        }
    }
}
