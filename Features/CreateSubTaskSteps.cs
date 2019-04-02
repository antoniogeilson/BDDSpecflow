using OpenQA.Selenium;
using Project_AntonioGeilson.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Project_AntonioGeilson.Features
{
    [Binding]
    public class CreateSubTaskSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private MyTasksPage myTasksPage;
        private MySubTasksPage mySubTasksPage;

        public CreateSubTaskSteps(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            myTasksPage = new MyTasksPage(driver);
            mySubTasksPage = new MySubTasksPage(driver);
        }

        [Given(@"I am on Editing Popup")]
        public void GivenIAmOnEditingPopup()
        {
            loginPage.UrlSignIn();
            loginPage.LogInTodo();
            loginPage.LoginSuccessfully();
            loginPage.ClickMyTasks();
            myTasksPage.ClickManageSubtasksButton();
        }

        [When(@"I fill tasks fields (.*), (.*)")]
        public void WhenIFillTasksFields(string description, string date)
        {
            mySubTasksPage.FillSubTaskFields(description, date);
        }

        [When(@"I click add SubTasks button")]
        public void WhenIClickAddSubTasksButton()
        {
            mySubTasksPage.ClickSubTaskButton();            
        }

        [Then(@"I see the subtask register added")]
        public void ThenISeeTheSubtaskRegisterAdded()
        {            
            mySubTasksPage.CheckSubTaskAdded();
        }        
    }
}
