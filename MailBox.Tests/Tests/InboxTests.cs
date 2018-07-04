using System;
using System.Linq;
using MailBox.Tests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace MailBox.Tests.Tests
{
    [TestFixture]
    public class InboxTests
    {
        public InboxTests()
        {
            var driver = new ChromeDriver();
            primitiveInbox = new PrimitiveInboxPageObject(driver);
            oopInbox = new OOPInboxPageObject(driver);
        }

        private PrimitiveInboxPageObject primitiveInbox;
        private OOPInboxPageObject oopInbox;

        [Test]
        public void CheckIfMessageWithSubjectIsUnread()
        {
            bool isUnread = primitiveInbox.IsMessageWithSubjectIsUnread("I like cheese");

            isUnread = oopInbox
                .Messages
                .First(a => a.Subject == "I like cheese")
                .IsUnread();
        }

        [Test]
        public void CheckIfMessageFromSenderIsUnread()
        {
            bool isUnread = primitiveInbox.IsMessageFromSenderIsUnread("Gil");

            isUnread = oopInbox
                .Messages
                .First(a => a.Sender == "Gil")
                .IsUnread();
        }

        [Test]
        public void CheckIfMessageWithSubjectHasFlag()
        {
            bool hasFlag = primitiveInbox.IsMessageWithSubjectHasFlag("I like cheese");

            hasFlag = oopInbox
                .Messages
                .First(a => a.Subject == "I like cheese")
                .IsFlagged();
        }

        [Test]
        public void CheckIfMessageFromSenderHasFlag()
        {
            bool hasFlag = primitiveInbox.IsMessageFromSenderHasFlag("Gil");

            hasFlag = oopInbox
                .Messages
                .First(a => a.Sender == "Gil")
                .IsFlagged();
        }

        [Test]
        public void GetSubjectBySender()
        {
            string subject = primitiveInbox.GetSubjectOfMessageWithSender("Gil");

            subject = oopInbox
                .Messages
                .First(a => a.Sender == "Gil")
                .Subject;
        }

        [Test]
        public void GetSenderBySubject()
        {
            string sender = primitiveInbox.GetSenderOfMessageWithSubject("I like cheese");

            sender = oopInbox
                .Messages
                .First(a => a.Subject == "I like cheese")
                .Sender;
        }

        [Test]
        public void OpenMessageBySubject()
        {
            primitiveInbox.OpenMessageBySubject("I like cheese");

            oopInbox.Messages.First(a => a.Subject == "I like cheese").Open();
        }

        [Test]
        public void OpenMessageBySender()
        {
            primitiveInbox.OpenMessageBySender("Gil");

            oopInbox.Messages.First(a => a.Sender == "Gil").Open();
        }

        [Test]
        public void GetDateBySender()
        {
            DateTime dateBySender = primitiveInbox.GetDateOfMessageWithSender("Gil");

            dateBySender = oopInbox.Messages.First(a => a.Sender == "Gil").Date;
        }

        [Test]
        public void GetDateBySubject()
        {
            DateTime dateBySubject = primitiveInbox.GetDateOfMessageWithSubject("I like cheese");

            dateBySubject = oopInbox.Messages.First(a => a.Subject == "I like cheese").Date;
        }

        [Test]
        public void GetCountOfUnread()
        {
            int count = primitiveInbox.GetCountOfUnreadMessages();

            count = oopInbox.Messages.Count(a => a.IsUnread());
        }

        [Test]
        public void GetCountByDate()
        {
            int count = primitiveInbox.GetMessageCountByDate(DateTime.Today);

            count = oopInbox.Messages.Count(a => a.Date == DateTime.Today);
        }

        [Test]
        public void GetMessageSizeBySender()
        {
            int sizeBySender = primitiveInbox.GetMessageSizeBySender("Git");

            sizeBySender = oopInbox.Messages.First(a => a.Sender == "Gil").Size;
        }

        [Test]
        public void GetMessageSizeBySubject()
        {
            int sizeBySubject = primitiveInbox.GetMessageSizeBySubject("I like cheese");

            sizeBySubject = oopInbox.Messages.First(a => a.Subject == "I like cheese").Size;
        }
    }
}