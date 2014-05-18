using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeUnknown.Models
{
    public class ContentModel : RecordModel
    {
        public Uri ContentURL { get; set; }

        public string NoteText { get; set; }

        public Guid EventId { get; set; }

        public ContentType ContentType { get; set; }

    }
}