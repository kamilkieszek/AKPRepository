namespace AKP.Models
{
    using System;
    using System.Web.Mvc;
    public class Message
    {
        [HiddenInput(DisplayValue = false)]
        public int MessageId { get; set; }
        public string Name { get; set; }
        public int PersonReceiverId { get; set; }
        public int PersonSenderId { get; set; }
        public DateTime Added { get; set; }
        public string Content { get; set; }
        public int NumberVisits { get; set; }

    }
}