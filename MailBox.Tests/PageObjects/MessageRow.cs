using System;

namespace MailBox.Tests.PageObjects
{
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
}