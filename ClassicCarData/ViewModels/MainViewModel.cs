using ClassicCarData.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCarData.Core.ViewModels
{
   public class MainViewModel
    {

        public List<Listing> Listings { get; set; }
        public List<Dealer> Dealers { get; set; }
        public MainViewModel()
        {
            Listings = new();
            Dealers = new();
            LoadDealers();
            LoadListings();
        }

        private void LoadListings()
        {
            using var db = new CCLdbContext();
            Listings = db.Listings.Take(100).ToList();
        }

        private void LoadDealers()
        {
            using var db = new CCLdbContext();
            Dealers = db.Dealers.ToList();
        }
    }
}
