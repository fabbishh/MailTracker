using MailTracker.Desktop.Models;
using System.Collections.ObjectModel;

namespace MailTracker.Desktop.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<GetMail> Emails { get; set; } = new ObservableCollection<GetMail>();
        public ObservableCollection<DocumentDto> Documents { get; set; } = new ObservableCollection<DocumentDto>();
    }
}
