using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MVVM.Persistency;

namespace MVVM.Handler
{
    class HotelHandler
    {
        public HotelPersistency HotelPersistency { get; set; }

        public ViewModel ViewModel { get; set; }

        public HotelHandler(ViewModel viewModel, HotelPersistency hotelPersistency )
        {
            ViewModel = viewModel;
            HotelPersistency = hotelPersistency;
        }

        public void CreateHotel()
        {
            Hotel newHotel = new Hotel(ViewModel.Name, ViewModel.Address);

            ViewModel.ListHotels.Add(newHotel);
            HotelPersistency.Create(newHotel);
        }

        public void RemoveHotel()
        {
            ViewModel.ListHotels.Remove(ViewModel.SelectHotel);
        }


    }
}
