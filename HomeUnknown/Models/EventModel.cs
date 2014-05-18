using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeUnknown.Models
{
    public class EventModel : RecordModel
    {
        public string Location { get; set; }

        public DateTime Year { get; set; }

        public string Date
        {
            get
            {
                return this.Year.ToShortDateString();
            }
        }

        public Guid TimelineId { get; set; }

    }
}