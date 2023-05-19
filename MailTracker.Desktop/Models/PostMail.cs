using MailTracker.Desktop.Models;
using System;
using System.Collections.Generic;

namespace MailTracker.App.Models
{
    public class PostMail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int RecipientId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public IEnumerable<DocumentDto> Documents { get; set; }
    }
}
