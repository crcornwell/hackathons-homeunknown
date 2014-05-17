using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeUnknown.Models
{
    public class ContentModel : RecordModel
    {
        Uri ContentURL { get; set; }

        string NoteText { get; set; }

        Guid EventId { get; set; }

        ContentType ContentType { get; set; }

    }
}