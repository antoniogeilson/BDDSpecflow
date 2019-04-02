using OpenQA.Selenium;
using System.Configuration;
using FluentAssertions;
using SeleniumWebdriverHelpers;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Project_AntonioGeilson.PageObjects
{
    public class MySubTasksPage
    {
        private IWebDriver driver;
        public string subTaskValue { get; set; }

        public MySubTasksPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region Page Factory

        //ToDo List
        [FindsBy(How = How.Id, Using = "new_sub_task")]
        private IWebElement newSubTaskDescription;

        [FindsBy(How = How.Id, Using = "dueDate")]
        private IWebElement newSubTaskDate;

        [FindsBy(How = How.Id, Using = "add-subtask")]
        private IWebElement addSubTaskButton;

        [FindsBy(How = How.CssSelector, Using = "body > div.modal.fade.ng-isolate-scope.in>div>div>div.modal-body.ng-scope>div:nth-child(4)>table>tbody>tr:nth-child(1)>td.task_body.col-md-8")]
        private IWebElement subTaskAdded;
        
        #endregion

        #region Methods

        public void FillSubTaskFields(string description, string date)
        {
            subTaskValue = description;
            newSubTaskDescription.SendKeys(description);
            newSubTaskDate.SendKeys(date);
        }

        public void ClickSubTaskButton()
        {
            addSubTaskButton.Click();
        }

        public void CheckSubTaskAdded()
        {

            subTaskAdded.Text.Trim().ToLower().Should().Contain(subTaskValue.Trim().ToLower(), "Wrong Message, Please Check It!!!");
        }

        #endregion

    }
}
