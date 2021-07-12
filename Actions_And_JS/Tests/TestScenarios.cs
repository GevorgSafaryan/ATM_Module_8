using Actions_And_JS.PageObjects;
using Actions_And_JS.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions_And_JS.Tests
{
    public class TestScenarios : BaseTest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        [OneTimeSetUp]
        public void SetupCredetials()
        {
            Login = JsonConvertor.GetTestData().Login;
            Password = JsonConvertor.GetTestData().Password;
            Recipient = JsonConvertor.GetTestData().Recipient;
            Subject = JsonConvertor.GetTestData().Subject;
            Body = JsonConvertor.GetTestData().Body;
        }

        [Test]
        public void SuccessfullyLoginTest()
        {
            HomePage homePage = new HomePage();
            homePage.Login(Login, Password);
            HeaderPage header = new HeaderPage();
            Assert.IsTrue(header.VerifySuccessfullLogin(Login));
        }

        [Test]
        public void TestTheCreationOfDraftEmail()
        {
            HomePage homePage = new HomePage();
            homePage.Login(Login, Password);
            LeftMenuPage leftMenu = new LeftMenuPage();
            leftMenu.ClickOnComposeButton();
            CreateEmailPage createEmail = new CreateEmailPage();
            createEmail.FillRecipient(Recipient);
            createEmail.FillSubject(Subject);
            createEmail.FillBody(Body);
            createEmail.SaveEmailByActions();
            createEmail.CloseNewEmailForm();
            leftMenu.OpenDraftsFolder();
            EmailContentPage emailContent = new EmailContentPage();
            emailContent.OpenEnEmailFromTheListById(0);
            Assert.IsTrue(createEmail.VerifyDraftEmailsContent(Recipient, Subject, Body));
        }

        [Test]
        public void TestDraftsFolderAfterSendingTheMail()
        {
            HomePage homePage = new HomePage();
            homePage.Login(Login, Password);
            LeftMenuPage leftMenu = new LeftMenuPage();
            leftMenu.ClickOnComposeButton();
            CreateEmailPage createEmail = new CreateEmailPage();
            createEmail.FillRecipient(Recipient);
            createEmail.FillSubject(Subject);
            createEmail.FillBody(Body);
            createEmail.SaveEmailByActions();
            createEmail.CloseNewEmailForm();
            leftMenu.OpenDraftsFolder();
            EmailContentPage emailContent = new EmailContentPage();
            emailContent.OpenEnEmailFromTheListById(0);
            createEmail.SendEmailByActions();
            createEmail.ClickOnCloseButtonAfterSendingEmail();
            Assert.IsTrue(emailContent.VerifyThatEmailDisappearsFromDraftsFolder());
        }

        [Test]
        public void TestThatEmailIsInSentFolderAfterSending()
        {
            HomePage homePage = new HomePage();
            homePage.Login(Login, Password);
            LeftMenuPage leftMenu = new LeftMenuPage();
            leftMenu.ClickOnComposeButton();
            CreateEmailPage createEmail = new CreateEmailPage();
            createEmail.FillRecipient(Recipient);
            createEmail.FillSubject(Subject);
            createEmail.FillBody(Body);
            createEmail.ClickOnSaveButton();
            createEmail.CloseNewEmailForm();
            leftMenu.OpenDraftsFolder();
            EmailContentPage emailContent = new EmailContentPage();
            emailContent.OpenEnEmailFromTheListById(0);
            createEmail.ClickOnSendButton();
            createEmail.ClickOnCloseButtonAfterSendingEmail();
            leftMenu.OpenSentFolder();
            emailContent.OpenEnEmailFromTheListById(0);
            Assert.IsTrue(emailContent.VerifySentEmailsContent(Recipient, Subject, Body));
        }

        [Test]
        public void TestDeletionOfTheEmailsByDragAndDrop()
        {
            HomePage homePage = new HomePage();
            homePage.Login(Login, Password);
            LeftMenuPage leftMenu = new LeftMenuPage();
            leftMenu.ClickOnComposeButton();
            CreateEmailPage createEmail = new CreateEmailPage();
            createEmail.FillRecipient(Recipient);
            createEmail.FillSubject(Subject);
            createEmail.FillBody(Body);
            createEmail.ClickOnSaveButton();
            createEmail.CloseNewEmailForm();
            leftMenu.OpenDraftsFolder();
            EmailContentPage emailContent = new EmailContentPage();
            emailContent.DeleteEmailsByDragAndDrop();
            Assert.IsTrue(emailContent.VerifyThatEmailDisappearsFromDraftsFolder());
        }

        [Test]
        public void TestSuccessfullyLogout()
        {
            HomePage homePage = new HomePage();
            homePage.Login(Login, Password);
            HeaderPage header = new HeaderPage();
            header.OpenProfileMenu();
            ProfileMenuPage profileMenu = new ProfileMenuPage();
            profileMenu.ClickOnLogoutButton();
            Assert.IsTrue(homePage.VerifySuccessfullLogout());
        }
    }
}
