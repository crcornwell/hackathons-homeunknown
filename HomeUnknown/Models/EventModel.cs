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
                return String.Format("{0},{1},{2}", this.Year.Year, this.Year.Month, this.Year.Day);
            }
        }

        public Guid TimelineId { get; set; }

    }
}