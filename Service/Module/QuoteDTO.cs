﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Service.Module
{
    public class QuoteDTO
    {
        public int QuoteID { get; set; }
        public string QuoteType { get; set; }
        public string Contact { get; set; }
        public string Task { get; set; }
        public string TaskType { get; set; }
        public string DueDate { get; set; }
    }
}
