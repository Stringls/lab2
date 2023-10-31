using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class SendMailViewModel
    {
        [DataType(DataType.EmailAddress), Display(Name = "Mail To"), Required]
        public string MailTo { get; set; }

        [DataType(DataType.Text), Display(Name = "Message"), Required]
        public string Message { get; set; }

        public SendMailViewModel()
        {
            MailTo = string.Empty;
            Message = string.Empty;
        }
    }
}
