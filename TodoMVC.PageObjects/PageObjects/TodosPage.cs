using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TodoMVC.PageObjects.PageObjects
{
    public class TodosPage
    {
        private readonly IWebDriver driver;

        private IWebElement NewTaskField => driver.FindElement(By.Id("new-todo"));

        public TodosPage(IWebDriver driver)
        {
            this.driver = driver;
            WaitForPageLoad();
        }

        public void AddTask(string newTaskName)
        {
            NewTaskField.Click();
            NewTaskField.SendKeys(newTaskName + Keys.Enter);
        }

        public IList<TaskRow> TodosList
        {
            get
            {
                var rows = driver.FindElements(By.CssSelector("#todo-list li[ng-repeat*='todo in todos']"));
                return rows.Select(a => new TaskRow(a,driver)).ToList();
            }
        }

        public TaskRow FindTask(string task)
        {
            return TodosList.First(a => a.TaskText == task);
        }

        public void ClearAllCompletedTasks()
        {
            driver.FindElement(By.CssSelector("#clear-completed")).Click();
        }

        public void SelectViewAll()
        {
            driver.FindElement(By.XPath("//ul[@id='filters']//a[text()='All']")).Click();
        }

        public void SelectActiveTasksView()
        {
            driver.FindElement(By.XPath("//ul[@id='filters']//a[text()='Active']")).Click();
        }

        public void SelectCompletedTasksView()
        {
            driver.FindElement(By.XPath("//ul[@id='filters']//a[text()='Completed']")).Click();
        }

        private void WaitForPageLoad()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(a => NewTaskField.Displayed);
        }

    }
}