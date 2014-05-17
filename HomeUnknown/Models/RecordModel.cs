using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeUnknown.Models
{
    public abstract class RecordModel
    {
        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}