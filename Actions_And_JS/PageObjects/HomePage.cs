using Actions_And_JS.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions_And_JS.PageObjects
{
    public class HomePage : BasePage
    {
        private static readonly string homePageTitle = "Mail.ru: почта, поиск в интернете, новости, игры";
        private readonly WebElement loginField = new WebElement(By.XPath("//input[@name = 'login']"));
        private readonly WebElement enterPasswordButton = new WebElement(By.XPath("//button[@data-testid= 'enter-password']"));
        private readonly WebElement passwordField = new WebElement(By.XPath("//input[@name= 'password']"));
        private readonly WebElement enterButton = new WebElement(By.XPath("//button[@data-testid= 'login-to-mail']"));
        private readonly WebElement createAccountButton = new WebElement(By.XPath("//a[@href = '//account.mail.ru/signup?from=main&rf=auth.mail.ru&app_id_mytracker=52848']"));

        public HomePage() : base(homePageTitle)
        {

        }

        public void Login(string login, string password)
        {
            loginField.SendKeys(login);
            enterPasswordButton.Click();
            passwordField.SendKeys(password);
            enterButton.Click();
        }

        public bool VerifySuccessfullLogout()
        {
            return wait.Until(WaitConditions.IsElementDisplayed(createAccountButton.GetElement()));
        }
    }
}
