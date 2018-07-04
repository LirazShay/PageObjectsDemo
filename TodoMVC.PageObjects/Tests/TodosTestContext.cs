using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TodoMVC.PageObjects.PageObjects;

namespace TodoMVC.PageObjects.Tests
{
    public class TodosTestContext : IDisposable
    {
        public TodosTestContext()
        {
            WebDriver = new ChromeDriver();
        }

        public IWebDriver WebDriver { get; set; }

        public void Dispose()
        {
            WebDriver.Quit();
        }

        public TodosPage GotoTodosPage()
        {
            WebDriver.Navigate().GoToUrl("http://todomvc.com/examples/angularjs/#/");
            return new TodosPage(WebDriver);
        }
    }
}