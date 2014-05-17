using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeUnknown.Models
{
    public class TimelineModel : RecordModel
    {
        public TimelineModel(DateTime date, Uri url, Guid id, string name)
        {
            this.BeginningYear = date;
            this.Id = id;
            this.Name = name;
            this.PictureURL = url;
        }

        public DateTime BeginningYear { get; set; }

        public Uri PictureURL { get; set; }
    }
}