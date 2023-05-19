using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MailTracker.Desktop.Models
{
    public class GetMail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string RecipientName { get; set; }
        public string SenderName { get; set; }
        public string Content { get; set; }
        public ObservableCollection<GetDocumentDto> Documents { get; set; }
    }
}
