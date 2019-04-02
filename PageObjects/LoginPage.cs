using OpenQA.Selenium;
using System.Configuration;
using FluentAssertions;
using SeleniumWebdriverHelpers;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Project_AntonioGeilson.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        #region Page Factory

        //Email Field
        [FindsBy(How = How.Id, Using = "user_email")]            
        private IWebElement userEmail;

        //Password Field
        [FindsBy(How = How.Id, Using = "user_password")]
        private IWebElement userPassword;

        //SingIn Button
        [FindsBy(How = How.Name, Using = "commit")]
        private IWebElement singInButton;

        //SingIn Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]")]
        private IWebElement loginSucessfully;

        //Click My Tasks
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[2]/ul[1]/li[2]/a")]
        private IWebElement myTaskMenu;

        //Click My Tasks
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]")]
        private IWebElement messageAlert;

        //Welcome User Message
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[2]/ul[2]/li[1]/a")]
        private IWebElement welcomeMessage;
                  
        #endregion

        #region Methods
        
        public void WrongLogIn(string password)
        {
            //Fill Email Field
            userEmail.SendKeys(ConfigurationManager.AppSettings["User"]);

            //Fill Password Field
            userPassword.SendKeys(password);

            //Click SignIn Button
            singInButton.Click();
        }

        public void LogInTodo()
        {
            //Fill Email Field
            userEmail.SendKeys(ConfigurationManager.AppSettings["User"]);

            //Fill Password Field
            userPassword.SendKeys(ConfigurationManager.AppSettings["Password"]);                                   

            //Click SignIn Button
            singInButton.Click();
        }

        public void LoginSuccessfully()
        {
            Thread.Sleep(1000);
            var expectedMessage = "Signed in successfully.";
            loginSucessfully.Text.ShouldBeEquivalentTo(expectedMessage.Trim(), "Wrong Welcome Message, Please Check!!!");                        
        }

        public void ClickMyTasks()
        {
            myTaskMenu.Click();
        }

        public void MessageSignRequired()
        {
            var expectedMessage = "You need to sign in or sign up before continuing.";
            messageAlert.Text.Trim().ShouldBeEquivalentTo(expectedMessage.Trim(), "Wrong Message, Please Check It!!!");            
        }

        public void MessageInvalidEmailPassword()
        {
            var expectedMessage = "Invalid email or password.";
            messageAlert.Text.Trim().ToLower().ShouldBeEquivalentTo(expectedMessage.Trim().ToLower(), "Wrong Message, Please Check It!!!");
        }

        public void WelcomeUserMessage(string user)
        {            
            welcomeMessage.Text.Trim().ToLower().Should().Contain("welcome, " + user + "!" , "Wrong Message, Please Check It!!!");
        }
        
        public void Url()
        {
            //Default URL
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URLToDoApp"]);
        }

        public void UrlSignIn()
        {
            //Default URL
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URLSignIn"]);
        }
        #endregion

    }
}
