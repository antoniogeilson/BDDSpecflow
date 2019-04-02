using System;
using OpenQA.Selenium;
using Project_AntonioGeilson.PageObjects;
using TechTalk.SpecFlow;

namespace Project_AntonioGeilson.Features
{
    [Binding]
    public class CreateTaskSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private MyTasksPage myTasksPage;

        public CreateTaskSteps(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            myTasksPage = new MyTasksPage(driver);
        }

        #region Given
        
        [Given(@"I am on the ToDO App Sign In page")]
        public void GivenIAmOnTheToDOAppSignInPage()
        {
            loginPage.UrlSignIn();
        }

        [Given(@"I am on the ToDO App Home page on Logged Session")]
        public void GivenIAmOnTheToDOAppHomePageOnLoggedSession()
        {
            loginPage.UrlSignIn();
            loginPage.LogInTodo();
            loginPage.LoginSuccessfully();
        }

        [Given(@"i click on My Tasks on The Navbar")]
        public void GivenIClickOnMyTasksOnTheNavbar()
        {
            loginPage.ClickMyTasks();
        }

        [Given(@"I fill new tasks field (.*)")]
        public void GivenIFillNewTasksFieldAbc(string taskValue)
        {
            myTasksPage.FillNewTask(taskValue);
        }

        [Given(@"I click add button")]
        public void GivenIClickAddButton()
        {
            myTasksPage.ClickAddButton();
        }

        [Given(@"I click on task added")]
        public void GivenIClickOnTaskAdded()
        {
            myTasksPage.ClickTaskAdded();
        }

        [Given(@"I update field value (.*)")]
        public void GivenIUpdateFieldValue(string newValue)
        {
            myTasksPage.FillUpdatedTaskValue(newValue);

        }
        
        [Given(@"I am on the Taks Page on Logged Session")]
        public void GivenIAmOnTheTaksPageOnLoggedSession()
        {
            loginPage.UrlSignIn();
            loginPage.LogInTodo();
            loginPage.LoginSuccessfully();
            loginPage.ClickMyTasks();
        }

        [Given(@"I fill new tasks field_ with DDC characters")]
        public void GivenIFillNewTasksFieldWithDDCCharacters()
        {
            myTasksPage.FillTaskCCDCharacters();
        }

        #endregion

        #region When

        [When(@"I login to ToDo App")]
        public void WhenILoginToToDoApp()
        {
            loginPage.LogInTodo();
        }

        [When(@"i click on My Tasks on The Navbar")]
        public void WhenIClickOnMyTasksOnTheNavbar()
        {
            loginPage.ClickMyTasks();
        }

        [When(@"I login to ToDo App with wrong (.*)")]
        public void WhenILoginToToDoAppWithWrongAbc(string password)
        {
            loginPage.WrongLogIn(password);
        }
        
        [When(@"I click add button")]
        public void WhenIClickAddButton()
        {
            myTasksPage.ClickAddButton();
        }
        
        [When(@"I click Submit Button")]
        public void WhenIClickSubmitButton()
        {
            myTasksPage.ClickUpdateButton();
        }
        #endregion

        #region Then
        
        [Then(@"the Message You need to sign in or sign up before continuing is displayed")]
        public void ThenTheMessageYouNeedToSignInOrSignUpBeforeContinuingIsDisplayed()
        {
            loginPage.MessageSignRequired();
        }

        [Then(@"I see the Message Welcome username")]
        public void ThenISeeTheMessageWelcomeUsername()
        {
            loginPage.LoginSuccessfully();
        }
        
        [Then(@"the Message Invalid email or password is displayed")]
        public void ThenTheMessageInvalidEmailOrPasswordIsDisplayed()
        {
            loginPage.MessageInvalidEmailPassword();
        }

        [Then(@"the Message Welcome (.*)")]
        public void ThenTheMessageWelcome(string user)
        {
            loginPage.WelcomeUserMessage(user);
        }
             
        [Then(@"i see the message (.*)'s ToDo List")]
        public void ThenISeeTheMessageAntonioGeilsonParenteLopesSToDoList(string user)
        {
            myTasksPage.TodoListMessage(user);
        }
              
        [Then(@"I see the task register added (.*)")]
        public void ThenIISeeTheTaskRegisterAdded(string taskValue)
        {
            myTasksPage.TaskAdded(taskValue);
        }
        
        [Then(@"I see the task updated (.*)")]
        public void ThenISeeTheTaskUpdated(string newValue)
        {
            myTasksPage.CheckTaskUpdated(newValue);

        }

        [Then(@"I see the task register added")]
        public void ThenISeeTheTaskRegisterAdded()
        {
            myTasksPage.CheckTaskCCDCharacters();
        }
        #endregion

    }
}
