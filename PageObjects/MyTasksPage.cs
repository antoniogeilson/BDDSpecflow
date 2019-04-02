using OpenQA.Selenium;
using System.Configuration;
using FluentAssertions;
using SeleniumWebdriverHelpers;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Linq;

namespace Project_AntonioGeilson.PageObjects
{
    public class MyTasksPage
    {
        private IWebDriver driver;

        public string taskDDC { get; set; }

        public MyTasksPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Page Factory

        //ToDo List
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/h1")]
        private IWebElement todoList;

        //New Task Field
        [FindsBy(How = How.Id, Using = "new_task")]
        private IWebElement newTask;

        //Add Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div[1]/form/div[2]/span")]
        private IWebElement addTaskButton;

        //Tasks List
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div[2]/div/table/tbody/tr[1]")]
        private IWebElement tasksTable;

        //Task Added
        [FindsBy(How = How.CssSelector, Using = "body>div.container>div.task_container.ng-scope>div.bs-example>div>table>tbody>tr:nth-child(1)>td.task_body.col-md-7>a")]
        private IWebElement taskAdded;

        //Update Task Added
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div[2]/div/table/tbody/tr[1]/td[2]/form/div/input")]
        private IWebElement updateTaskAdded;

        //Submit Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div[2]/div/table/tbody/tr[1]/td[2]/form/div/span/button[1]")]
        private IWebElement updateTaskButton;

        //Task Updated 
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/div[2]/div/table/tbody/tr/td[2]/a")]
        private IWebElement taskUpdated;

        //Manage Subtasks Button - First 
        [FindsBy(How = How.CssSelector, Using = "body>div.container>div.task_container.ng-scope>div.bs-example>div>table>tbody>tr:nth-child(1)>td:nth-child(4)>button")]
        private IWebElement manageSubTasksButton;
        
        #endregion

        #region Methods

        public void TodoListMessage(string user)
        {
            todoList.Text.Trim().ToLower().Should().Contain(user + "'s todo list", "Wrong Message, Please Check It!!!");
        }

        public void FillNewTask(string taskValue)
        {
            newTask.SendKeys(taskValue);
        }

        public void ClickAddButton()
        {
            addTaskButton.Click();
        }

        public void TaskAdded(string taskValue)
        {
            tasksTable.Text.Should().Contain(taskValue);
        }

        public void CheckTaskUpdated(string newTaskValue)
        {
            Thread.Sleep(1000);
            taskUpdated.Text.Trim().ToLower().Should().Contain(newTaskValue, "Wrong Message, Please Check It!!!");
        }

        public void ClickTaskAdded()
        {
            taskAdded.Click();
        }

        public void FillUpdatedTaskValue(string newValue)
        {
            Thread.Sleep(500);
            updateTaskAdded.ClearText();
            Thread.Sleep(500);
            updateTaskAdded.SendKeys(newValue);
        }

        public void ClickUpdateButton()
        {
            updateTaskButton.Click();
        }

        //Characters Generator
        public static string RandomString(int length)
        {
            var rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        
        public void FillTaskCCDCharacters()
        {
            Thread.Sleep(1000);
            var newValue = RandomString(250);
            taskDDC = newValue;
            newTask.SendKeys(newValue);                        
        }

        public void CheckTaskCCDCharacters()
        {            
            taskAdded.GetText().Trim().ToLower().Should().Contain(taskDDC.Trim().ToLower(), "Wrong Message, Please Check It!!!");
        }

        public void ClickManageSubtasksButton()
        {
            manageSubTasksButton.Click();
        }

        #endregion
    }
}