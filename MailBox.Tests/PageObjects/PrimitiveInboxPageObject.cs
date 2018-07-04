using System;
using OpenQA.Selenium;

namespace MailBox.Tests.PageObjects
{
    public class PrimitiveInboxPageObject
    {
        public PrimitiveInboxPageObject(IWebDriver driver)
        {
            
        }

        public bool IsMessageWithSubjectIsUnread(string subject)
        {
            throw new NotImplementedException();
        }

        public bool IsMessageFromSenderIsUnread(string sender)
        {
            throw new NotImplementedException();
        }

        public bool IsMessageWithSubjectHasFlag(string subject)
        {
            throw new NotImplementedException();
        }

        public bool IsMessageFromSenderHasFlag(string sender)
        {
            throw new NotImplementedException();
        }

        public string GetSubjectOfMessageWithSender(string sender)
        {
            throw new NotImplementedException();
        }

        public string GetSenderOfMessageWithSubject(string subject)
        {
            throw new NotImplementedException();
        }

        public MessagePage OpenMessageBySubject(string subject)
        {
            throw new NotImplementedException();
        }

        public void OpenMessageBySender(string sender)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateOfMessageWithSender(string sender)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateOfMessageWithSubject(string subject)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfUnreadMessages()
        {
            throw new NotImplementedException();
        }

        public int GetMessageCountByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public int GetMessageSizeBySender(string git)
        {
            throw new NotImplementedException();
        }

        public int GetMessageSizeBySubject(string subject)
        {
            throw new NotImplementedException();
        }
    }
}