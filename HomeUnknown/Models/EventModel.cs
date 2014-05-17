using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeUnknown.Models
{
    public class EventModel : RecordModel
    {
        string Location { get; set; }

        DateTime Year { get; set; }

        Guid TimelineId { get; set; }

    }
}