using System.Collections.Generic;
using OpenQA.Selenium;

namespace MailBox.Tests.PageObjects
{
    public class OOPInboxPageObject
    {
        public OOPInboxPageObject(IWebDriver driver)
        {
            
        }

        public IList<MessageRow> Messages { get; set; }
    }
}