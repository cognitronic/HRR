using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRR.Core.Domain.Interfaces
{
    public interface IMessageRecipient
    {
        int ID { get; set; }
        int MessageID { get; set; }
        int RecipientTypeID { get; set; }
        int RecipientID { get; set; }
        int MessageFolderID { get; set; }
        int MessageStatusTypeID { get; set; }
    }
}
