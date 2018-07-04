# PageObjectsDemo
Demonstration of how to build robust PageObject classes that follow OOP concepts  

The solution contains 2 projects
1. MailBox without Selenlium implementation 
2. TodoMVC tests - woring example (with Selenium implementation) on the http://todomvc.com/examples/angularjs/#/ 

For example:
 ```csharp
        [Test]
        public void CheckIfMessageWithSubjectIsUnread()
        {
            bool isUnread = Inbox.IsMessageWithSubjectIsUnread("I like cheese");
        }
VS
        [Test]
        public void CheckIfMessageWithSubjectIsUnread()
        {
            bool isUnread = Inbox
                .Messages
                .First(a => a.Subject == "I like cheese")
                .IsUnread();
        }   
    And  
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

    
VS    

    public class OOPInboxPageObject
    {
        public OOPInboxPageObject(IWebDriver driver)
        {
            
        }

        public IList<MessageRow> Messages { get; set; }
    }
    
    public class MessageRow
    {
        public bool IsUnread()
        {
            throw new System.NotImplementedException();
        }

        public string Subject { get; set; }
        public string Sender { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }

        public bool IsFlagged()
        {
            throw new System.NotImplementedException();
        }

        public MessagePage Open()
        {
            throw new System.NotImplementedException();
        }
    }
    
    ```       
