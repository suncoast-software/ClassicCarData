using System;
using System.Collections.Generic;

#nullable disable

namespace ClassicCarData.Data.Models
{
    public partial class Model
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Value { get; set; }
    }
}
