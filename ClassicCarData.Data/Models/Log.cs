using System;
using System.Collections.Generic;

#nullable disable

namespace ClassicCarData.Data.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public int LogId { get; set; }
        public int StatusCode { get; set; }
        public string LogMessage { get; set; }
        public DateTime? Created { get; set; }
    }
}
