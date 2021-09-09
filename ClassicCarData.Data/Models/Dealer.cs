using System;
using System.Collections.Generic;

#nullable disable

namespace ClassicCarData.Data.Models
{
    public partial class Dealer
    {
        public int Id { get; set; }
        public string ListingId { get; set; }
        public string DealerName { get; set; }
        public string DealerUrl { get; set; }
        public string StockNumber { get; set; }
        public DateTime DateVisited { get; set; }
    }
}
